namespace Qms_Web.ViewModels
{
    public class ParentMenuVM
    {
        public string ParentMenuName { get; set; } = string.Empty;

        public IList<ChildMenuVM> ChildMenus { get; set; } = new List<ChildMenuVM>();
    }
}
