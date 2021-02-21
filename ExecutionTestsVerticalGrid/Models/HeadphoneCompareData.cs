using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;

namespace DevExpress.Web.Demos {
    public class HeadphoneCompareData {
        static ICriteriaToExpressionConverter Converter = new CriteriaToExpressionConverter();

        public static IEnumerable<Headphone> GetHeadphones() {
            return HeadphonesDataProvider.SelectHeadphones().Take(2);
        }

        public static bool HasRowDifferentValues(string fieldName) {
            var query = GetHeadphones().AsQueryable().MakeSelect(Converter, new OperandProperty(fieldName));
            var expression = Expression.Call(typeof(Queryable), "Distinct", new Type[] { query.ElementType }, query.Expression);
            return query.Provider.CreateQuery(expression).Count() > 1;
        }
    }
}
