using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TDKRSports.Web.CustomerPortal.ViewModels
{
    public class CustomerViewModel
    {
        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [Required(ErrorMessage = "Name Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Maximum 30 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string CustomerAddress { get; set; }

        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [Required(ErrorMessage = "City Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Maximum 30 characters")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "State Province Required")]
        public string CustomerStateProvince { get; set; }

        [Required(ErrorMessage = "Country Required")]
        public string CustomerCountry { get; set; }

        [Required(ErrorMessage = "Mail Required")]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            ErrorMessage = "Invalid mail")]
        public string CustomerEmail { get; set; }

    }
}
