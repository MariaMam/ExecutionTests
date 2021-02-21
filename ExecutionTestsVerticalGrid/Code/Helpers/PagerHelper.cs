using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace DevExpress.Web.Demos {
    public class PagerDemoHelper {
        const string PagerOptionsSessionKey = "90B5E388-9FB8-4BD0-9F76-626F8492C663";

        public static PagerDemoOptions Options {
            get {
                if(Session[PagerOptionsSessionKey] == null)
                    Session[PagerOptionsSessionKey] = new PagerDemoOptions();
                return (PagerDemoOptions)Session[PagerOptionsSessionKey];
            }
            set { Session[PagerOptionsSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
