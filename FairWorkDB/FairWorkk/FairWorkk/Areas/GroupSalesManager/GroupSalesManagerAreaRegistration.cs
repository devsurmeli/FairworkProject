using System.Web.Mvc;

namespace FairWorkk.Areas.GroupSalesManager
{
    public class GroupSalesManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GroupSalesManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GroupSalesManager_default",
                "GroupSalesManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}