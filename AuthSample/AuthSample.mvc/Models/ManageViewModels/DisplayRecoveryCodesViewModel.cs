using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthSample.mvc.Models.ManageViewModels
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
