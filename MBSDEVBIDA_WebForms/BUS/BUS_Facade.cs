﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVC;

using System.Diagnostics;
using System.ServiceModel;
using WCFClient;


namespace BUS
{
    public class BUS_Facade
    {
        private SVC_PerformAction svcPerformAction;
        private SVC_AuthenticateUser svcAuthenticateUser;

        private SVC_ClientSideSocketConnection svcClientSideSocketConnection;

        private Object lclObjectClass;
        private int lclActionType;

        private String logon, password;
        private bool foundLogon, foundPassword, isSalesRep;

        public BUS_Facade(Object Object, int ActionType)
        {
            this.lclObjectClass = Object;
            this.lclActionType = ActionType;
        }
        public BUS_Facade(string _Logon, string _Password = "")
        {
            this.logon = _Logon;
            this.password = _Password;
        }
        public void ProcessRequest()
        {
            svcPerformAction = new SVC_PerformAction();
            svcPerformAction.Action(lclObjectClass, lclActionType);
        }
        public string ProcessAuthenticationRequest()
        {
            svcAuthenticateUser = new SVC_AuthenticateUser();
            foundLogon = svcAuthenticateUser.AuthenticateLogon(logon);
            foundPassword = svcAuthenticateUser.AuthenticatePassword(password);
            if (foundLogon && foundPassword)
            {
                 return logon;
            }
            else
            {
                return "Invalid Password Entered";
            }
        }
        public bool ProcessCheckIfUserIsSalesRep()
        {
            svcAuthenticateUser = new SVC_AuthenticateUser();
            isSalesRep = svcAuthenticateUser.IsSalesRep(logon);
            return isSalesRep;            
        }
        public string ProcessLogonNameAuthenticity()
        {
            svcAuthenticateUser = new SVC_AuthenticateUser();
            foundLogon = svcAuthenticateUser.AuthenticateLogon(logon);

            if (foundLogon)
            {
                return logon;
            }
            else
            {
                return "Valid Username Entered.";
            }
        }
        //Added to authenticate user via authentication server.
        public string TestAuthenticationServer()
        {
            svcClientSideSocketConnection = new SVC_ClientSideSocketConnection();
            foundLogon = svcClientSideSocketConnection.Client(logon, password);

            if (foundLogon)
            {
                return logon;
            }
            else
            {
                return "Valid Username Entered.";
            }            

        }
        public string WCFAuthenticateUser()
        {
            localhost.AuthenticationServices client = new localhost.AuthenticationServices();
            string wcfOutput = client.AuthenticateUser(logon, password);
            //Process.Start("@C:\\Users\\NOLSEN\\Source\\Repos\\MSSE682_WebForms_Week7\\MBSDEVBIDA_WebForms\\WCFHost\\bin\\Debug\\WCFHost.exe");
            //WCFClient.ServiceReference1.ServicesClient client = new WCFClient.ServiceReference1.ServicesClient();
            //WCFClient.WCFAuthenticationClient client = new WCFAuthenticationClient();
            return wcfOutput;
        }
        public string WCFAuthenticateUser1()
        {
            WCFAuthenticationClient client = new WCFAuthenticationClient();
            //ServiceReference1.ServicesClient client = new ServicesClient();
            string wcfOutput = client.WCFAuthUser(logon, password);// "";// client.AuthenticateUser(logon, password);
            
            //AuthenticateUser.IServices = new IServices                        
            //foundLogon = client.AuthenticateUser(logon, password, foundLogon, foundPassword);
            //foundLogon = svcClientSideSocketConnection.Client(logon, password);

            if (wcfOutput == "true")
            {
                return logon;
            }
            else
            {
                return "Valid Username Entered.";
            }

        }
        public string WSAuthenticateUser()
        {
            WSAuthenticate.Service1 wsClient = new WSAuthenticate.Service1();
            string wcfOutput = wsClient.AuthenticateUser(logon, password);
            //Process.Start("@C:\\Users\\NOLSEN\\Source\\Repos\\MSSE682_WebForms_Week7\\MBSDEVBIDA_WebForms\\WCFHost\\bin\\Debug\\WCFHost.exe");
            //WCFClient.ServiceReference1.ServicesClient client = new WCFClient.ServiceReference1.ServicesClient();
            //WCFClient.WCFAuthenticationClient client = new WCFAuthenticationClient();
            return wcfOutput;
        }
    }
}
