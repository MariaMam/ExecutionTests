using System.Web;
using System.Web.SessionState;

namespace DevExpress.Web.Demos {
    public class FixedRowsDemoHelper {

        const string FixedRowsHelperSessionKey = "434B45FB-B184-49DF-B356-CD647047D24E";

        public static FixedRowsDemoOptions Options {
            get {
                if(Session[FixedRowsHelperSessionKey] == null)
                    Session[FixedRowsHelperSessionKey] = new FixedRowsDemoOptions();
                return (FixedRowsDemoOptions)Session[FixedRowsHelperSessionKey];
            }
            set { Session[FixedRowsHelperSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
