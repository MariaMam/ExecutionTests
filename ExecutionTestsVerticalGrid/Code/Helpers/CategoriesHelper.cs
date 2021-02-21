using System.Web;
using System.Web.SessionState;

namespace DevExpress.Web.Demos {
    public class CategoriesDemoHelper {

        const string CategoriesHelperSessionKey = "E6452758-E1A0-4BD7-930D-B84EE466CCDB";

        public static CategoriesDemoOptions Options {
            get {
                if(Session[CategoriesHelperSessionKey] == null)
                    Session[CategoriesHelperSessionKey] = new CategoriesDemoOptions();
                return (CategoriesDemoOptions)Session[CategoriesHelperSessionKey];
            }
            set { Session[CategoriesHelperSessionKey] = value; }
        }
        protected static HttpSessionState Session { get { return HttpContext.Current.Session; } }
    }
}
