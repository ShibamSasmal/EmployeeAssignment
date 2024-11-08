using Employee_Test.countryDto;
using Employee_Test.Data;
using Employee_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Employee_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IStringLocalizer<CountryController> _localizer;
        public CountryController(AppDbContext appDbContext, IStringLocalizer<CountryController> localizer)
        {
             _appDbContext = appDbContext;
            _localizer = localizer;
        }

        [HttpGet,Route("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _appDbContext.Set<TblCountry>() 
                .Include(i => i.TblCountryTrans)
                .ToListAsync();
            return Ok(countries);
        }

        [HttpPost, Route("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryRequest request)
        {
            string countryCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

            // Initialize the country entity
            var country = new TblCountry
            {
                CountryCode = countryCode,
                TblCountryTrans = new List<TblCountryTran>()
            };

            foreach (var translation in request.Translations)
            {
                // Check if the LangCode exists in TblAppLangMaster
                var lang = await _appDbContext.TblAppLangMaster
                    .FirstOrDefaultAsync(l => l.LangCode == translation.LangCode);

                if (lang == null)
                {
                    // Add new language to TblAppLangMaster if it doesn't exist
                    _appDbContext.TblAppLangMaster.Add(new TblAppLangMaster
                    {
                        LangCode = translation.LangCode,
                        LangName = translation.LangName ?? translation.LangCode.ToUpper(), 
                        IsDefault = false
                    });
                    await _appDbContext.SaveChangesAsync();
                }

                // Add the translation to TblCountryTrans
                country.TblCountryTrans.Add(new TblCountryTran
                {
                    LangCode = translation.LangCode,
                    CountryName = translation.CountryName
                });
            }

            // Check if default language (English) exists in TblAppLangMaster
            var englishLang = await _appDbContext.TblAppLangMaster
                .FirstOrDefaultAsync(l => l.LangCode == "en");

            if (englishLang == null && !request.Translations.Any(t => t.LangCode == "en"))
            {
                // If English is not in the translations provided, insert it as the default
                _appDbContext.TblAppLangMaster.Add(new TblAppLangMaster
                {
                    LangCode = "en",
                    LangName = "English",
                    IsDefault = true
                });
                await _appDbContext.SaveChangesAsync();

                // Add the English translation
                country.TblCountryTrans.Add(new TblCountryTran
                {
                    LangCode = "en",
                    CountryName = request.CountryName 
                });
            }

            // Add the country and its translations
            await _appDbContext.TblCountries.AddAsync(country);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete, Route("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromBody] Guid Id)
        {
            var country = await _appDbContext.Set<TblCountry>().FindAsync(Id);

            if (country != null)
            {
                _appDbContext.Set<TblCountry>().Remove(country);
                await _appDbContext.SaveChangesAsync();

                // Use localized string
                var message = _localizer["CountryDeleted"];
                return Ok(message);
            }
            return NotFound(_localizer["CountryNotFound"]);
        }

        [HttpGet("GetCountriesByLanguage")]
        public IActionResult GetCountriesByLanguage([FromQuery] string langCode)
        {
            var countries = _appDbContext.TblCountryTrans
                .Where(ct => ct.LangCode == langCode)
                .Select(ct => new
                {
                    CountryName = ct.CountryName,
                    LangCode = ct.LangCode
                }).ToList();

            return Ok(countries);
        }

        [HttpGet, Route("GetAvailableLanguages")]
        public async Task<IActionResult> GetAvailableLanguages()
        {
            var languages = await _appDbContext.TblAppLangMaster
                .Select(lang => new
                {
                    LangCode = lang.LangCode,
                    LangName = lang.LangName
                })
                .ToListAsync();

            return Ok(languages);
        }


    }
}
