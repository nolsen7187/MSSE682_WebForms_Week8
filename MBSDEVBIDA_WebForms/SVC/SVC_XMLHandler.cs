using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVC
{
    public class SVC_XMLHandler
    {
        private string encodedUserXML, encodedPasswordXML, lclUsername, lclPassword;
        private XmlReader xmlReader;

        public string UserNameEncodeXML(string username, string password)//Would be passing a list and spinning values to dynamically build XML if time permitted
        {
            encodedUserXML = "@'<?xml version='1.0'?><xmlroot><USERNAME>" + username + "</USERNAME></xmlroot>";
            return encodedUserXML;
        }
        public string PasswordEncodeXML(string username, string password)//Would be passing a list and spinning values to dynamically build XML if time permitted
        {
            encodedPasswordXML = "@'<?xml version='1.0'?><xmlroot><PASSWORD>" + password + "</PASSWORD></xmlroot>";
            return encodedPasswordXML;
        }
        public List<TempUser> UserDecodeXML(string passedInXML)//Would be passing a list and spinning values to dynamically build XML if time permitted
        {
            xmlReader = XmlReader.Create(new StringReader(passedInXML));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Text
                && xmlReader.NodeType != XmlNodeType.EndElement
                && xmlReader.Value != "\n")
                {
                    lclUsername = xmlReader.Value;
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Text
                        && xmlReader.NodeType != XmlNodeType.EndElement
                        && xmlReader.Value != "\n")
                        {
                            lclPassword = xmlReader.Value;
                            xmlReader.Close();
                            break;
                        }
                    }
                    //break;
                }
            }

        TempUser data = new TempUser();
        data.WebLogon = lclUsername;
        data.WebPassword = lclPassword;

        List<TempUser> lstUser = new List<TempUser>();
        lstUser.Add(data);

        return lstUser;
        }
    }
    public class TempUser
    {
        public string WebLogon { set; get; }
        public string WebPassword { set; get; }
    }
}
