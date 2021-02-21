using System.Web;
using System.Web.SessionState;

namespace DevExpress.Web.Demos {
    public class BatchEditingDemoHelper {

        const string BatchEditingHelperSessionKey = "A8E558C7-66F3-4DB3-82C7-6C819DEF418F";

        public static BatchEditingDemoOptions Options {
            get {
                if(Session[BatchEditingHelperSessionKey] == null)
                    Session[BatchEditingHelperSessionKey] = new BatchEditingDemoOptions();
                return (BatchEditingDemoOptions)Session[BatchEditingHelperSessionKey];
            }
            set { Session[BatchEditingHelperSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
