using System;
using System.Collections.Generic;
namespace Models
{
    public partial class EquipementInfo
    {
        public int Id { get; set; }
        public string NSerie { get; set; }
        public DateTime Date { get; set; }
        public string InfoSystemeHtml { get; set; }
        public string SoftwareHtml { get; set; }
    }
}
