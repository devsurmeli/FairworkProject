using System.Web.Mvc;

namespace FairWorkk.Areas.ParticipatingCompany
{
    public class ParticipatingCompanyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ParticipatingCompany";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ParticipatingCompany_default",
                "ParticipatingCompany/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}