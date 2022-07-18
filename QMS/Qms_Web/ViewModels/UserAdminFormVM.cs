using System.ComponentModel.DataAnnotations;

namespace Qms_Web.ViewModels
{
    public class UserAdminFormVM
    {
        public int UserId { get; set; }

        public int? ManagerId { get; set; }

        [Required]
        [Display(Name = "Organization")]
        public int? OrgId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; } = String.Empty;

        [Required]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; } = String.Empty;

        public List<RoleAdminVM> Roles { get; } = new List<RoleAdminVM>();
        public List<RoleAdminVM> CheckboxRoles { get; } = new List<RoleAdminVM>();

        public string AspAction { get; set; } = String.Empty;
        public string SubmitButtonLabel { get; set; } = String.Empty;
        public string CardHeader { get; set; } = String.Empty;
        public bool Deactivatable { get; set; } = false;
        public bool Reactivatable { get; set; } = false;
        public bool Mutatatable { get; set; } = false;
    }
}
