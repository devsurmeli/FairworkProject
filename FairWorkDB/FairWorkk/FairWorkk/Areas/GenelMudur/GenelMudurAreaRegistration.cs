using System.Web.Mvc;

namespace FairWorkk.Areas.GenelMudur
{
    public class GenelMudurAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GenelMudur";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GenelMudur_default",
                "GenelMudur/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}