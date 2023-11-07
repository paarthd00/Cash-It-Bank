using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class UserVM
    {
        [Key]
        public string ClientID { get; set; }
    }

}
