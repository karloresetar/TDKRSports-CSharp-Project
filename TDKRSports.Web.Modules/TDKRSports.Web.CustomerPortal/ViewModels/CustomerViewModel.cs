using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TDKRSports.Web.CustomerPortal.ViewModels
{
    public class CustomerViewModel
    {
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [Required(ErrorMessage = "Name Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Maximum 30 characters for Name")]
        public string CustomerName { get; set; }

        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required for Address")]
        [Required(ErrorMessage = "Address Required")]
        public string CustomerAddress { get; set; }

        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required for City")]
        [Required(ErrorMessage = "City Required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Maximum 30 characters for City")]
        public string CustomerCity { get; set; }

        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required for State Province")]
        [Required(ErrorMessage = "State Province Required")]
        public string CustomerStateProvince { get; set; }

        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required for Country")]
        [Required(ErrorMessage = "Country Required")]
        public string CustomerCountry { get; set; }

        [Required(ErrorMessage = "Mail Required")]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            ErrorMessage = "Invalid mail, your E-mail should look like: [ example@mail.com ]")]
        public string CustomerEmail { get; set; }

    }
}
