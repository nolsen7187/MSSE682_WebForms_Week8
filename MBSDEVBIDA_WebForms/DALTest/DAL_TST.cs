﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;
using DAL;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using System.Configuration;

namespace DALTest
{
    //Week 6
    [TestClass]
    public class DAL_TST
    {
        [TestMethod]
        public void DAL_TST_WriteToDataAreaTable()
        {
            AXMbsDevEntities data = new AXMbsDevEntities();
            DATAAREA DA = new DATAAREA();
            DA.ID = "TST";
            DA.NAME = "Test Office Products";

            data.DATAAREA.Add(DA);
            data.SaveChanges();
        }
        [TestMethod]
        public void DAL_TST_RepositoryWriteToDataAreaTable()
        {
            var DARepo = new DataRepository<DATAAREA>();
            DATAAREA DA = new DATAAREA();
            DA.ID = "aR";
            DA.NAME = "Sucks";
            DARepo.Create(DA);
        }
        [TestMethod]
        public void DAL_TST_RepositoryWriteToMbsWbWebUserTable()
        {
            var MWCRepo = new DataRepository<MBSWBWEBUSERCONTACT>();
            MBSWBWEBUSERCONTACT MWC = new MBSWBWEBUSERCONTACT();
            MWC.ACCOUNTNUM = "100";
            MWC.EMAIL = "nolsen@mbsdev.com";
            MWC.NAME = "Nick Olsen";
            MWC.CONTACTPERSONID = "101";
            MWC.WEBLOGON = "username";
            MWC.WEBPASSWORD = "Pass@word1";
            MWC.DATAAREAID = "MBS";
            MWCRepo.Create(MWC);
        }
    }
}
