using System.Web;
using System.Web.SessionState;

namespace DevExpress.Web.Demos {
    public class ScrollingDemoHelper {

        const string ScrollingHelperSessionKey = "CB61EF44-0967-48A6-9E85-FAEDC43F82C8";

        public static ScrollingDemoOptions Options {
            get {
                if(Session[ScrollingHelperSessionKey] == null)
                    Session[ScrollingHelperSessionKey] = new ScrollingDemoOptions();
                return (ScrollingDemoOptions)Session[ScrollingHelperSessionKey];
            }
            set { Session[ScrollingHelperSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
