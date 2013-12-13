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
        private string encodedUserXML, encodedPasswordXML, lclUsername, lclPassword, decodedXML;
        private XmlReader xmlReader;

        public string UserNameEncodeXML(string username)//Would be passing a list and spinning values to dynamically build XML if time permitted
        {
            encodedUserXML = @"<?xml version='1.0'?><xmlroot><USERNAME>" + username + "</USERNAME></xmlroot>";
            return encodedUserXML;
        }
        public string PasswordEncodeXML(string password)//Would be passing a list and spinning values to dynamically build XML if time permitted
        {
            encodedPasswordXML = @"<?xml version='1.0'?><xmlroot><PASSWORD>" + password + "</PASSWORD></xmlroot>";
            return encodedPasswordXML;
        }
        public string DecodeXML(string passedInXML)//Would be passing a list and spinning values to dynamically build XML if time permitted
        {
            xmlReader = XmlReader.Create(new StringReader(passedInXML));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Text
                && xmlReader.NodeType != XmlNodeType.EndElement
                && xmlReader.Value != "\n")
                {
                    decodedXML = xmlReader.Value;
                    break;
                }
            }

        /*TempUser data = new TempUser();
        data.WebLogon = lclUsername;
        data.WebPassword = lclPassword;

        List<TempUser> lstUser = new List<TempUser>();
        lstUser.Add(data);
        */
        return decodedXML;
        }
    }
    /*public class TempUser
    {
        public string WebLogon { set; get; }
        public string WebPassword { set; get; }
    }*/
}
