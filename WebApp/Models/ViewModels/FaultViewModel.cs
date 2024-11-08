using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.DTO;
using WebApp.Extensions;
using WebApp.Models.Classes;

namespace WebApp.Models.ViewModels
{

    public class FaultViewModel
    {
        public List<ProductDTO>? ProductList { get; set; }
        public int? CustomerId { get; set; }
        public string? Description { get; set; }

        // StatusList'i FaultStatuEnum türünde tutuyoruz
        public List<FaultStatuEnum> StatusList { get; set; } = null!;
        public List<string> StatusListStrings => StatusList?.Select(status => status.GetStatusString()).ToList() ?? new List<string>();

        // StatusList'teki ilk öğe üzerinden DefaultDurationInMinutes hesaplıyoruz
        public int DefaultDurationInMinutes => StatusList?.FirstOrDefault().GetDefaultDurationInMinutes() ?? 0;
    }
}
