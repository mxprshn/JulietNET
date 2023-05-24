using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseWeb : AbstractTestCaseWebBase
    {
#if (!OMITBAD)
        public abstract void Bad(HttpRequest req, HttpResponse resp);
#endif //omitbad
#if (!OMITGOOD)
        public abstract void Good(HttpRequest req, HttpResponse resp);
#endif //omitgood
        override public void RunTest(String webName, HttpRequest req, HttpResponse resp)
        {
            resp.WriteAsync("<br><br>Starting tests for Web testcase " + webName);
#if (!OMITGOOD)
            try
            {
                Good(req, resp);

                resp.WriteAsync("<br>Completed good() without Exception for Web testcase " + webName);
            }
            catch (Exception throwableException)
            {
                resp.WriteAsync("<br>Caught thowable from good() in Web testcase " + webName);

                resp.WriteAsync("<br>Throwable's message = " + throwableException.Message);

                resp.WriteAsync("<br><br>Stack trace below");

                resp.WriteAsync("<br>" + throwableException.StackTrace);

            }
#endif //omitgood
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
