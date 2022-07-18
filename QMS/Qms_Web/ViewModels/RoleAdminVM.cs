using System.Text;

namespace Qms_Web.ViewModels
{
    public class RoleAdminVM
    {
        public int RoleId { get; set; }
        public string RoleCode { get; set; } = String.Empty;
        public string RoleLabel { get; set; } = String.Empty;
        public bool Selected { get; set; } = false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("UARoleViewModel = {");
            sb.Append("RoleId: ");
            sb.Append(this.RoleId);
            sb.Append(", RoleCode: ");
            sb.Append(this.RoleCode);
            sb.Append(", RoleLabel: ");
            sb.Append(this.RoleLabel);
            sb.Append(", Selected: ");
            sb.Append(this.Selected);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
