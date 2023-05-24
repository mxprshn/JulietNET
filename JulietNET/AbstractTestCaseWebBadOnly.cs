using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseWebBadOnly : AbstractTestCaseWebBase
    {
#if (!OMITBAD)
        public abstract void Bad(HttpRequest req, HttpResponse resp);
#endif //omitbad
        override public void RunTest(String webName, HttpRequest req, HttpResponse resp)
        {
            resp.WriteAsync("<br><br>Starting tests for Web testcase " + webName);
#if (!OMITBAD)
            try
            {
                Bad(req, resp);

                resp.WriteAsync("<br>Completed bad() without Exception for Web testcase " + webName);
            }
            catch (Exception throwableException)
            {
                resp.WriteAsync("<br>Caught thowable from bad() in Web testcase " + webName);

                resp.WriteAsync("<br>Throwable's message = " + throwableException.Message);

                resp.WriteAsync("<br><br>Stack trace below");

                resp.WriteAsync("<br>" + throwableException.StackTrace);

            }
#endif //omitbad
        }
    }
}
