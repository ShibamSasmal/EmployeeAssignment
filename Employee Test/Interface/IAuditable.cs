﻿namespace Employee_Test.Interface
{
    public interface IAuditable
    {

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}