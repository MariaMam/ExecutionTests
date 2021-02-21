using System.Web;
using System.Web.SessionState;

namespace DevExpress.Web.Demos {
    public class FilterBuilderDemoHelper {
        const string FilterBuilderOptionsSessionKey = "10B3D706-7CAD-41D4-BB0D-3332A3037059";

        public static FilterBuilderDemoOptions Options {
            get {
                if(Session[FilterBuilderOptionsSessionKey] == null)
                    Session[FilterBuilderOptionsSessionKey] = new FilterBuilderDemoOptions();
                return (FilterBuilderDemoOptions)Session[FilterBuilderOptionsSessionKey];
            }
            set { Session[FilterBuilderOptionsSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
