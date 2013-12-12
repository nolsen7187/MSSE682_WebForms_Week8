using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SVC;

namespace WSApplication
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        private bool logonFound, passwordFound;
        private string verifiedLogon;

        [WebMethod]
        public string AuthenticateUser(string logon, string password)
        {
            SVC_AuthenticateUser svcAuthenticateUser = new SVC_AuthenticateUser();
            logonFound = svcAuthenticateUser.AuthenticateLogon(logon);
            passwordFound = svcAuthenticateUser.AuthenticatePassword(password);

            if ((logonFound && passwordFound) == true)
            {
                verifiedLogon = logon;
                return verifiedLogon;
            }
            else
            {
                return "User not verified";
            }
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}