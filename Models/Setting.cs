﻿using System.ComponentModel.DataAnnotations;

namespace Studio.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string Key { get; set; }
        [StringLength(maximumLength: 150)]
        public string Value { get; set; }
    }
}
