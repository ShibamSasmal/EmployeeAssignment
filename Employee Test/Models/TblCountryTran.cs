using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Test.Models
{
    public class TblCountryTran : BaseEntity
    {
        
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual TblCountry TblCountry { get; set; } = null;

        public string LangCode { get; set; } = null!;

        [ForeignKey(nameof(LangCode))]
        public virtual TblAppLangMaster TblAppLangMaster { get; set; } = null!;
        public string CountryName {  get; set; } 
    }
}
