using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Classes;

namespace WebApp.Extensions
{
    public static class FaultStatuEnumExtensions
    {
        public static string GetStatusString(this FaultStatuEnum status)
        {
            return status switch
            {
                FaultStatuEnum.Kurulum => "Kurulum",
                FaultStatuEnum.Bakim => "Bakim",
                FaultStatuEnum.Onarim => "Onarim",
                FaultStatuEnum.Ariza => "Ariza",
                _ => "Bilinmeyen"  // Herhangi bir durumda varsayılan değer
            };
        }
    }
}