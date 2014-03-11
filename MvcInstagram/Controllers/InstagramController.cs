using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using InstaSharp.Model.Responses;
using MvcInstagram.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcInstagram.Controllers
{
   
    public class InstagramController : Controller
    {
        
        //
        // GET: /Instagram/
        public string Index()
        {
            return "Instagram Controller";
        }
       
        //
        // GET: /Instagram/GetBasicAuthToken/
        public ActionResult GetBasicAuthToken()
        {
            var link = InstagramHelper.GetBasicAuthLink();
            return Redirect(link);
        }

        //
        // GET: /Instagram/GetRelationshipsAuthLink/
        public ActionResult GetRelationshipsAuthLink()
        {
            var link = InstagramHelper.GetRelationshipsAuthLink();
            return Redirect(link);
        }

        [HttpGet]
        public string OauthRedirect(string code, string callback)
        {
            var auth = InstagramHelper.GetAuth();
            var oauthResponse = auth.RequestToken(code);
            return JsonConvert.SerializeObject(oauthResponse);
        }
        
        [HttpGet]
        public string UsersFeed()
        {
            var config = InstagramHelper.GetConfig();
            var authInfo = InstagramHelper.GetAuthInfo();
            var feed = new InstaSharp.Endpoints.Users.Authenticated(config, authInfo);
            var result = feed.Feed("self", 10);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        public string GetPhotos()
        {
            var config = InstagramHelper.GetConfig();
            var authInfo = InstagramHelper.GetAuthInfo();
            var users = new InstaSharp.Endpoints.Users.Authenticated(config, authInfo);
            var result = users.Feed("self");
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        public string GetTags()
        {
            var config = InstagramHelper.GetConfig();
            var authInfo = InstagramHelper.GetAuthInfo();
            var tags = new InstaSharp.Endpoints.Tags.Authenticated(config, authInfo);
            const string tagName = "hlktoday";
            var result = tags.Get(tagName);
            return JsonConvert.SerializeObject(result);
        }

        
        //
        // GET: /Instagram/RecentTags/
        [HttpGet]
        public ActionResult RecentTags()
        {
            var config = InstagramHelper.GetConfig();
            var authInfo = InstagramHelper.GetAuthInfo();
            var tags = new InstaSharp.Endpoints.Tags.Authenticated(config, authInfo);
            const string tagName = "hlktoday";
            var recent = tags.Recent(tagName);
            var json = JsonConvert.DeserializeObject<TagsResponse>(JsonConvert.SerializeObject(recent));
            ViewBag.JsonResult = new JavaScriptSerializer().Serialize(
                JsonConvert.SerializeObject(json.Json, Formatting.None)
            );
      
            return View();
        }
    }
}