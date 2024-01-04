﻿using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Alerts
{
    [Table("Alerts")]
    public class Alert
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Headline { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public Metadata Metadata { get; set; }
    }
}
