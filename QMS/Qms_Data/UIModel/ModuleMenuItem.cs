
using System;
using System.Collections.Generic;
using System.Text;
using QmsCore.Model;

namespace QmsCore.UIModel
{
    public class ModuleMenuItem :IComparable<ModuleMenuItem>
    {
        public int DisplayOrder {get;set;}
        public int ModuleMenuItemId {get;set;}
        public string Title {get;set;}
        public string Controller {get;set;}
        public string ControllerAction {get;set;}
        public string UseCase {get;set;}        

        public List<MenuItem> MenuItems{get;set;}

        public ModuleMenuItem()
        {
            MenuItems = new List<MenuItem>();
            UseCase = string.Empty;
        }

        public int CompareTo(ModuleMenuItem other)
        {
            return this.DisplayOrder.CompareTo(other.DisplayOrder);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("ModuleMenuItem = {");
            sb.Append("ModuleMenuItemId: ");
            sb.Append(this.ModuleMenuItemId);
            sb.Append(", Title: ");
            sb.Append(this.Title);
            sb.Append(", Controller: ");
            sb.Append(this.Controller);
            sb.Append(", ControllerAction: ");
            sb.Append(this.ControllerAction);
            sb.Append(", UseCase: ");
            sb.Append(this.UseCase);
            sb.Append(", DisplayOrder: ");
            sb.Append(this.DisplayOrder);
            if (this.MenuItems != null)
            {
                foreach (var mi in this.MenuItems)
                {
                    sb.Append("\n\t");
                    sb.Append(mi.ToString());
                }
            }
            sb.Append("}");

            return sb.ToString();
        }
    }//end class
}//end namespace