using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSC_Project.Extentions;
using NSC_Project.Extentions.Models;

namespace ShopASP.Middlewares
{
    public class AuthUserMiddleware
    {
        
        public void Configure(IApplicationBuilder app, ITempDataProvider tempDataProvider)
        {
            app.Use(async Task (context,next) => {
                var mySessionUser = context.Session.GetObjectFromJson<UserSession>("Client");

                if (mySessionUser==null)
                {
                    //TempData["Message"] : session dùng 1 lần
                    tempDataProvider.SaveTempData(context, new Dictionary<string, object> { ["Message"] = "Sử dụng TempData" });
                    context.Response.Redirect("/Account/Login");
                }
                await next(context);
            });
        }
    }
}
