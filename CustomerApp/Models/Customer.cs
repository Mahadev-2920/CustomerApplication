using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models
{
    public class Customer
    {
        [DisplayName("Customer Id")]
        public string? id { get; set; }
        [DisplayName("First Name")]
        public string? firstname { get; set; }
        [DisplayName("Last Name")]
        public string? lastname { get; set; }
        [Required]
        [DisplayName("Email")]
        public string? email { get; set; }
        [DisplayName("Phone Number")]
        public string? phone_Number { get; set; }
        [DisplayName("Country Code")]
        public string? country_code { get; set; }
        [DisplayName("Gender")]
        public string? gender { get; set; }
        [DisplayName("Balance")]
        public decimal balance { get; set; }
        public string? salutation { get; set; }
        public string? initials { get; set; }
        public string? firstname_ascii { get; set; }
        public string? firstname_country_rank { get; set; }
        public string? firstname_country_frequency { get; set; }
        public string? lastname_ascii { get; set; }
        public string? lastname_country_rank { get; set; }
        public string? lastname_country_frequency { get; set; }
        public string? password { get; set; }
        public string? country_code_alpha { get; set; }
        public string? country_name { get; set; }
        public string? primary_language_code { get; set; }
        public string? primary_language { get; set; }
        public string? currency { get; set; }

    }

}
