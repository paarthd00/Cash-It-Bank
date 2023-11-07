using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class ClientVM
    {
        private int _ClientID;
        public int ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public float? Balance { get; internal set; }
    }
}
