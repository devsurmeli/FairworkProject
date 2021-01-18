using System.Web.Mvc;

namespace FairWorkk.Areas.BoxOfficeAttendant
{
    public class BoxOfficeAttendantAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BoxOfficeAttendant";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BoxOfficeAttendant_default",
                "BoxOfficeAttendant/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}