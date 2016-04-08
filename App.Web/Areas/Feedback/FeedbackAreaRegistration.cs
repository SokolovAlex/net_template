using System.Web.Mvc;

namespace App.Web.Areas.Feedback
{
    public class FeedbackAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Feedback";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Feedback_Default", "Feedback/{controller}/{action}/{id}", new { controller = "FeedbackHome", action = "Index", id = UrlParameter.Optional });
        }
    }
}