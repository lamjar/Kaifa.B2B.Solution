﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Kaifa.B2B.InforApiServiceAdapterProvider;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlClient;
using System.Xml.XPath;
using System.Globalization;
using Kaifa.B2B.VendorAlloc;
using System.IO;
using Excel;
using System.Data;
using Kaifa.B2B.CLS.XmlHelper;
namespace TestConsoleApp
{
    class Program
    {
        private static void sp_zh_wmstobill( string fdin, string edin)
        {
            using (SqlConnection conn = new SqlConnection("Server=10.10.205.147;Database=SCPRD;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False"))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SCPRD.wmwhse2.sp_zh_wmstobill";
                cmd.Parameters.Add(new SqlParameter("@v_fdin", fdin));
                cmd.Parameters.Add(new SqlParameter("@v_edin", edin));
                SqlParameter outp=new SqlParameter("@v_ret","");
                outp.Direction= ParameterDirection.Output;
                cmd.Parameters.Add(outp);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        static void test1() {
            XmlDocument doc = new XmlDocument();
            doc.Load("c:\\H.xml");
            ListB2B.Read(doc);
             
        
        }

        static void Main(string[] args)
        {
            //PreDisGenerator P = new PreDisGenerator("1000000034", "wmwhse1", "Server=10.10.205.147;Database=SCPRD;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False", "");
            //XDocument d = P.Generator();
            //d.Save("c:\\test.xml");
            test1();
            //DateTime date = DateTime.Now;
            //DateTime firstOfNextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1);
            //DateTime lastOfThisMonth = firstOfNextMonth.AddDays(-1);
            //int lastscday = lastOfThisMonth.Day - 2;

            //DateTime sdt =DateTime.Now;
            //if (date.Month == 1)
            //{
            //    sdt = new DateTime((date.Year-1), 12, 21);
            //}else{
            //    sdt = new DateTime(date.Year, (date.Month - 1), 21);
            //}
            //DateTime edt = new DateTime(date.Year, date.Month, 21);
            //sp_zh_wmstobill( sdt.ToString("yyyyMMdd"), edt.ToString("yyyyMMdd"));
            //XmlDocument doc = new XmlDocument();
            //doc.Load("c:\\hddec.xml");
            //HBDec.Read(doc);
            //DisB2B.Read(doc);

            //run();
            //Console.ReadLine();
            //string _excelFile="c:\\szt_vendor_alloc_quarter20151002000231.xlsx";
            //FileStream stream = File.Open(_excelFile, FileMode.Open, FileAccess.Read);
            //    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //    excelReader.IsFirstRowAsColumnNames = true;
            //    DataSet result = excelReader.AsDataSet();
            //    DataTable dt = result.Tables[0];
            //    excelReader.Close();
            //    stream.Close();

            //    MailClient.SendAllocNotificationMail(dt, _excelFile, string.Empty);
            //    Console.Read();


            //test();
            //Kaifa.B2B.Utility.SAPARReturnHelper.Update("20151105_15141", "test", "test");
            //ARGenerator ar = new ARGenerator("20151105", "wmwhse1", "Server=10.10.205.37;Database=STEST;User ID=sa;Password=1;Trusted_Connection=False;", "");
            //XDocument doc= ar.Generator();

            //Console.WriteLine(doc);

            //DateTime date = DateTime.Now;
            //DateTime sdt = new DateTime(date.Year, (date.Month - 1), 21);
            //DateTime edt = new DateTime(date.Year, date.Month, 21);

            //SAP.ZfiCreateArForWmsRequest req = new TestConsoleApp.SAP.ZfiCreateArForWmsRequest();
            //SAP.ZfiWmsStru body = new TestConsoleApp.SAP.ZfiWmsStru();
          

            //string dt=  DateTime.Now.ToString("yyyyMMddT000000.000") + "Z";
            //TDN940Generator tdn = new TDN940Generator("0000000273", "wmwhse1", "Server=10.10.205.37;Database=STEST;User ID=sa;Password=1;Trusted_Connection=False;", "");
            //XDocument doc= tdn.Generator();

            //Console.WriteLine(doc);
            //TestAPI();
            //XmlDocument doc = new XmlDocument();
            //doc.Load("c:\\webreponse.xml");
            //string xml = doc.DocumentElement.ChildNodes[0].InnerText;
            //XmlDocument ddd = new XmlDocument();
            //ddd.LoadXml(xml);
            //XmlNode node= ddd.DocumentElement.SelectSingleNode("/Message/Body/Error");
            //if (node != null)
            //{
            //    node.InnerText;
            //}


            //"Server=10.10.205.37;Database=STEST;User ID=sa;Password=1;Trusted_Connection=False"
            //CalendarTask t = new CalendarTask("C:\\test\\in", "C:\\test\\bk", "Server=10.10.205.37;Database=STEST;User ID=sa;Password=1;Trusted_Connection=False;");
            //t.Start();
            //Console.ReadLine();
            //t.Stop();

            //CalendarProcess p = new CalendarProcess("C:\\希捷日历11.xlsx", "Server=10.10.205.147;Database=STEST;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False", "wmwhse2");
            //p.Read();
            AllocProcess p = new AllocProcess("c:\\szt_vendor_alloc_adhoc201602030.xlsx", "Server=10.10.205.147;Database=STEST;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False", "wmwhse1");
            p.Read();
            Console.Read();
            //string a = "STZ".Substring(0, 2);
            //string connstring = "Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False";
            //string warehouse = "wmwhse1";
            //IEnumerable<string> r = GetReceiptKeys(connstring, warehouse);
            //Console.WriteLine(r.Count());

            //XmlDocument doc = new XmlDocument();
            //doc.Load("c:\\4C1.xml");
            //string content = Kaifa.B2B.Utility.HeaderHelper.ReturnSCWithDocType(doc, "4C1R0200");
            //XmlDocument doc1 = RemoveNamespace(doc);
            //string id = pipInstanceIdentifier(doc, "");
        //    UserInfo user = new UserInfo();
        //    user.UserName = "sceadmin";
        //    user.Password = "123";
        //    user.Whcode = "SCPRD_wmwhse1";
        //    string[] keys = new string[] { "0000000348", "0000000348", "0000000348" };
        //    string str = DateTime.Now.ToString("yyyyMMddTHHmmss.fff") + "Z";
            //string str = DateTime.Now.ToString("MMMddyyyy", CultureInfo.CreateSpecificCulture("en-US"));
            //string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //inv();
            //Console.WriteLine(str);

            //AdvancedShipNoticeGenerator g = new AdvancedShipNoticeGenerator(keys, "c:\\config.xml",
            //     "SZT", "Seagate", "e2open", "wmwhse1",
            //    "Server=10.10.205.147;Database=SCPRD;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False",
            //    "http://kaifa.b2b.schemas/AdvancedShipNotice");
            //XDocument asn = g.Generator();
            //Console.WriteLine(asn);
            //string orderkey = GetOrderKey();
            ////IEnumerable<string> orders = GetOrderKeys();
            //UpdateFlag(orders.ToArray());
            //string orderkey = "1000000056";
            //OrderShipmentGenerator g = new OrderShipmentGenerator(orderkey, "c:\\config.xml",
            //     "SZT", "Seagate", "e2open", "wmwhse1",
            //    "Server=10.10.205.147;Database=SCPRD;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False",
            //    "http://kaifa.b2b.schemas/OrderShipment");
            //XDocument asn = g.Generator();
            //Console.WriteLine(asn);
            //string[] orderkeys = new string[] { "0000000647" };
            //OrderShipmentPODGenerator g = new OrderShipmentPODGenerator(orderkeys, "c:\\config.xml",
            //    "SZT", "Seagate", "e2open", "wmwhse1",
            //   "Server=10.10.205.37;Database=STEST;User ID=sa;Password=1;Trusted_Connection=False",
            //   "http://kaifa.b2b.schemas/OrderShipment");
            //XDocument asn = g.Generator();
            //Console.WriteLine(asn);

            //InventoryReportGenerator inv = new InventoryReportGenerator(true, "c:\\config.xml",
            //        "SZT", "Seagate", "e2open", "wmwhse1",
            //    "Server=10.10.205.147;Database=SCPRD;User ID=sa;Password=Suwmsdb_2015;Trusted_Connection=False",
            //    "http://kaifa.b2b.schemas/InventoryReport");
            //XDocument doc = inv.Generator();
            //Console.WriteLine(doc);

            //DataReader();
            //LoginTest(user);
            //AsnListTest(user);
//            var xml = XElement.Parse(@"<ns0:Root xmlns:ns0=""http://Test.Schema"">
//                                    <a>1</a>
//                                    <a>2</a>
//                                        </ns0:Root>");
//            var xd = new XDocument(xml);
//            var xmld = xd.GetXmlDocument();

//            Console.WriteLine(stripNS(xml));

            //XNamespace nsSys = "http://schemas.microsoft.com/2004/06/windows/eventlog/system";
            //XElement head1 = Header();
            //XElement details = Detail();
            //foreach (XElement el in details.Elements("Detail"))
            //{
            //    head1.LastNode.AddAfterSelf(el);
            //}
            
            ////doc.AddAfterSelf(head1);
            //XDocument doc = new XDocument(new XElement("Root", head1));
            //string res = doc.ToString();

            ////doc.Root.Add(new XAttribute(XNamespace.Xmlns + "ns0", nsSys));
            //foreach (XElement el in doc.Descendants())
            //{
            //    el.Name = nsSys  + el.Name.LocalName;
            //}
            //string res1 = doc.ToString();
            //inv();
            //asn();
        }

        //[Site]*[Storer Key]*[Supplier DO#]*[Special Remarks from Supplier DO]*[Seagate PO#] e.g. TH*TTKABC12345*U276D11-MC0*15P/1440*PO1234

        //<Site>*<Storer Key>*<Supplier DO#>*< Trace Code as special remark>*<Seagate PO#>*<RTV/Ref Number, if applicable>
        //Examples:
        //SZ*SZT12345*U276D11-MC0*TC123*PO1234*
        //SZ*SZT60558*RBCA-00001040*TC123*PO#123*RTV/rmaref-2015-1222
        public string SeagateProprietaryLocator(string site, string storerkey, string suppliterDO, string specialRemarks, string seagatePO, string ordertype)
        {
            if (ordertype.Trim().ToUpper() == "20")
                //return string.Format("{0}*SZT{1}*{2}*{3}*{4}*{5}", site.Substring(0, 2), storerkey, suppliterDO, "RTV", "", seagatePO);
                return string.Format("{0}*SZT{1}*{2}*{3}*{4}*{5}", site.Substring(0, 2), storerkey, suppliterDO, specialRemarks, "", "RTV/" + seagatePO);
            else
                return string.Format("{0}*SZT{1}*{2}*{3}*{4}*", site.Substring(0, 2), storerkey, suppliterDO, specialRemarks, seagatePO);
        }

        //For ON Hold Qty
        //<Site>/<InventoryType>/<Original Hub Receipt Date>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#> *<RMA/RTV Number>
        //<Site>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#>
        public string ProprietaryLotIdentifier(string Site, string InventoryType,
             string onholdRemark,
             string ReceiptDate, string StorerKey, string SupplierDO,
             string SpecialRemarks, string SeagatePO, string OnHoldQty)
        {

            string receivedate = "";
            if (decimal.Parse(OnHoldQty) > 0)
            {
                if (!string.IsNullOrEmpty(ReceiptDate))
                {
                    receivedate = DateTime.Parse(ReceiptDate).ToString("MMMddyyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                }
                if (onholdRemark.ToUpper().Trim() == "RTV")
                {
                    //<Site>/<InventoryType>/<Original Hub Receipt Date>*<Storer Key>*<Supplier DO#>*<Tracecode as special remarks>
                    //*<Seagate PO#> *<RTV/rtv number>
                    //Example: SZ/ONHOLD SHIP/AUG252015*SZT60558*RBCA-00001040*TC123*XYZ*RTV/rmaref-2015-1222
                    return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}*{7}", Site.Substring(0, 2), InventoryType + " " + onholdRemark, receivedate, StorerKey, SupplierDO, SpecialRemarks, "", "RTV/" + SeagatePO);
                    //return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}*{7}", Site.Substring(0, 2), InventoryType + " " + onholdRemark, receivedate, StorerKey, SupplierDO, onholdRemark, "", "RTV/" + SeagatePO);

                }
                else
                {
                    return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}*{7}", Site.Substring(0, 2), InventoryType + " " + onholdRemark, receivedate, StorerKey, SupplierDO, SpecialRemarks, SeagatePO, "");
                }
            }
            else
            {
                return string.Format("{0}*{1}*{2}*{3}*{4}", Site.Substring(0, 2), StorerKey, SupplierDO, SpecialRemarks, SeagatePO);
            }
        }

        public static void run() {

            string connectionstring = System.Configuration.ConfigurationManager.AppSettings["connectionstring"];
            string alldir = System.Configuration.ConfigurationManager.AppSettings["allocDir"];
            string allbakdir = System.Configuration.ConfigurationManager.AppSettings["allocBakDir"];

            AllocTask allTask = new AllocTask(alldir, allbakdir, connectionstring, "wmwhse2");
            string caldir = System.Configuration.ConfigurationManager.AppSettings["calDir"];
            string calbakdir = System.Configuration.ConfigurationManager.AppSettings["calBakDir"];

            CalendarTask calTask = new CalendarTask(caldir, calbakdir, connectionstring, "wmwhse2");

            allTask.Start();
            calTask.Start();
        
        
        }
        public string remarkaddsku(string pcode, string remark, string sku)
        {
            if (pcode.Trim() == "0" && !string.IsNullOrEmpty(remark))
            {
                return  remark + "," + sku;
            }
            else
            {
                return remark;
            }
        }
        public string strLottable06(string p) {
            if (p.Trim() == "1" || p.Trim() == "0")
            {
                return "OK";
            }
            else {
                return "MANUAL";
            }
        
        }
        public static string test() {
            DateTime date = DateTime.Now;
            string batchId = date.ToString("yyyyMMdd");
            DateTime sdt = new DateTime(date.Year, (date.Month - 1), 21);
            DateTime edt = new DateTime(date.Year, date.Month, 21);

            using (SqlConnection conn = new SqlConnection("Server=10.10.205.37;Database=STEST;User ID=sa;Password=1;Trusted_Connection=False"))
            {
                conn.Open();
                string sqlcmd = string.Format(@" update BILLADMIN.BIC_CHARGE set ARBATCHID = '{0}_'+ CUST_CODE where CHARGE_DATE>='{1}' AND CHARGE_DATE<='{2}'  
                                        ", batchId, sdt.ToString("yyyy-MM-dd HH:mm:ss"), edt.ToString("yyyy-MM-dd HH:mm:ss"));
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                object up= cmd.ExecuteScalar();
                Console.WriteLine(up);

                cmd.CommandText = string.Format("select count(*) from BILLADMIN.BIC_CHARGE where ARBATCHID like '{0}_%'", batchId);
                object res = cmd.ExecuteScalar(); 
                int count = Convert.ToInt32(res);
                if (count > 0)
                    return batchId;
                else
                    return string.Empty;



            }
        }
        public string dtnowstring() {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        //For ON Hold Qty
        //<Site>/<InventoryType>/<Original Hub Receipt Date>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#> *<RMA/RTV Number>
        //<Site>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#>
        //public string ProprietaryLotIdentifier(string Site, string InventoryType,
        //     string onholdRemark,
        //     string ReceiptDate, string StorerKey, string SupplierDO,
        //     string SpecialRemarks, string SeagatePO, string OnHoldQty)
        //{

        //    string receivedate = "";
        //    if (decimal.Parse(OnHoldQty) > 0)
        //    {
        //        if (!string.IsNullOrEmpty(ReceiptDate))
        //        {
        //            receivedate = DateTime.Parse(ReceiptDate).ToString("MMMddyyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        //        }
        //        if (onholdRemark.ToUpper().Trim() == "RTV")
        //        {
        //            return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}*{7}", Site.Substring(0, 2), InventoryType + " " + onholdRemark, receivedate, StorerKey, SupplierDO, onholdRemark, "", SeagatePO);
        //        }
        //        else
        //        {
        //            return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}*{7}", Site.Substring(0, 2), InventoryType + " " + onholdRemark, receivedate, StorerKey, SupplierDO, SpecialRemarks,  SeagatePO,"");
        //        }
        //    }
        //    else
        //    {
        //        return string.Format("{0}*{1}*{2}*{3}*{4}", Site.Substring(0, 2), StorerKey, SupplierDO, SpecialRemarks, SeagatePO);
        //    }
        //}


        ////[Site]*[Storer Key]*[Supplier DO#]*[Special Remarks from Supplier DO]*[Seagate PO#] e.g. TH*TTKABC12345*U276D11-MC0*15P/1440*PO1234
        //public string SeagateProprietaryLocator(string site, string storerkey, string suppliterDO, string specialRemarks, string seagatePO, string ordertype)
        //{
        //    if (ordertype.Trim().ToUpper()=="20")
        //        return string.Format("{0}*SZT{1}*{2}*{3}*{4}*{5}", site.Substring(0, 2), storerkey, suppliterDO, specialRemarks,"" ,seagatePO);
        //    else
        //        return string.Format("{0}*SZT{1}*{2}*{3}*{4}*", site.Substring(0, 2), storerkey, suppliterDO, specialRemarks, seagatePO);
        //}

        public string getrequestime(string datetime) {
            //2015-09-22T01:10:00;
            return datetime.Substring(10, 5).Replace(":", "-");
        }
        public string convertdatetimestring(string dtstr)
        {
            //2015-11-02T12:00:00
            //20151101T000052.791Z

            return dtstr.Replace("-", "").Replace(":", "") + ".000Z";
        }
        public string PrimaryRemark(string pcode, string remark, string storerkey) {

            if (pcode.ToUpper().Trim() == "2")
            {
                return remark;
            }
            else
            {
                return storerkey;
            }
        }

        public string POformat(string asic, string po, string cmsite)
        {
            if (asic.ToUpper().Trim() == "ASIC")
            {
                return po;
            }
            else
            {
                return po + "-" + cmsite;
            }
        }
        public static void TestAPI() {
            string path = "c:\\Cm_940.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlDocument doc1 = RemoveNamespace(doc);
            WmsAPI.WmsWebServicePortTypeClient  client = new TestConsoleApp.WmsAPI.WmsWebServicePortTypeClient();
            //string RequestType, string MessageType, string RequestMethod, string XmlString
            //"MessageProcessor","ShipmentOrder","storeByQuote",strContent
            string res = client.callBackEnd("MessageProcessor", "ShipmentOrder", "storeByQuote",doc1.DocumentElement.OuterXml);
            Console.WriteLine(res);
        
        }
        public string dateformat(string strdate,string strmin){
            string dt = string.Format("{0}/{1}/{2}", strdate.Substring(0, 4), strdate.Substring(5, 2), strdate.Substring(7, 2));
            return string.Format("{0} {1}", dt, strmin.Trim().Replace("-",":") + ":00");
        }

        public string getType(string PrimeOnly) {

            if (PrimeOnly.Trim() != "2")
                return "0";
            else
                return "10";

        }
        public string SpiltSite(string site) {

            //SNK-KFM
            return site.Trim().Substring(4, 3);
        
        }
        static private void UpdateFlag( string[] orderkeys)
        {
            using (SqlConnection conn = new SqlConnection("Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False"))
            {
                conn.Open();
                string whereexpression = "    WHERE ORDERKEY  IN (" + string.Join(",", orderkeys.Select(t => "'" + t + "'").ToArray()) + ")";
                string sqlcmd = string.Format("UPDATE  [{0}].[ORDERS]  SET B2BFLAG2 = 1 {1}", "wmwhse1", whereexpression);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                cmd.ExecuteNonQuery();

            }
        }
        static private IEnumerable<string> GetOrderKeys()
        {
            using (SqlConnection conn = new SqlConnection("Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False"))
            {
                 
                conn.Open();
                string sqlcmd = string.Format(@"SELECT T.ORDERKEY  FROM  [{0}].[ORDERS]  T WHERE T.B2BFLAG2=0 OR T.B2BFLAG2 IS NULL 
                                               AND  EXISTS (SELECT ORDERKEY FROM [{0}].[ORDER_POD] T1 WHERE T.ORDERKEY = T1.ORDERKEY )
                                        ", "wmwhse1");
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return reader.GetString(0);
                }

            }
        }

        //<Site><Vendor Number><Transtype><DateTime in yyyyMMddHHMMSS><System Generated Running Seq Number> 
         public string ProprietaryDocumentIdentifier(string Site, string vendorCode, string msgType)
        {
            string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string seq = "000001";
            return string.Format("{0}{1}{2}{3}{4}", Site, vendorCode,msgType, str, seq);
        }
        public string SeagateProprietaryRTVReason(string l06) {
             if (l06.Trim().ToUpper() == "RTV" || l06.Trim().ToUpper() == "SBR" || l06.Trim().ToUpper() == "RW" || l06.Trim().ToUpper() == "DAM" || l06.Trim().ToUpper() == "QRB")
             {
                 return l06.Trim().ToUpper();
             }
             else
             {
                 return "";
             }
         }
        static public string SeagateProprietarySite(string hubsite, string cmsite) {
            return string.Format("{0}-{1}", hubsite, cmsite);
        }
        //[Site][Vendor Number]~[CM Code]~[CM KitList to Hub Provider] e.g. TTK12345~CCT~M1001098
        static public string ProprietaryReferenceIdentifier1(string site, string VendorCode,string cmCode,string kitlist)
        {
            return string.Format("{0}{1}~{2}~{3}", site, VendorCode, cmCode, kitlist);
         }
        //NON ASIC Purchase Order# of format [Site][Vendor Number]-[CM Code] e.g TTK12345-CCT
        static public string NONASICPurchaseOrder(string Site,string VendorCode,string CmCode) {
            return string.Format("{0}{1}-{2}", Site, VendorCode, CmCode);
        
        }
        static  public string ProprietaryDocumentIdentifier1(string Site, string vendorCode, string msgType, string supplierDuns)
        {
            string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string seq = "000001";
            return string.Format("{0}{5}{1}{2}{3}{4}", Site, msgType, str, supplierDuns, seq, vendorCode);
        }

        static public string GetOrderKey()
        {
            using (SqlConnection conn = new SqlConnection("Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False"))
            {
                conn.Open();
                string sqlcmd = string.Format("SELECT TOP 1 T.ORDERKEY  FROM  [{0}].[ORDERS]  T WHERE T.B2BFLAG1=0 OR T.B2BFLAG1 is NULL", "wmwhse1");
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    return "";
                }
                else
                {
                    return result.ToString();
                }

            }
        }
        
        static public string DateTimeFormat(string str) {
            //20150616T021822.000Z
            //2015-03-31T21:44:21
            return str.Replace("-", string.Empty).Replace(":", string.Empty).Substring(0,15) + ".000Z";
        }
         
        static public string pipInstanceIdentifier(XmlDocument doc, string tag)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns0", doc.DocumentElement.NamespaceURI);
            XmlNode node = doc.DocumentElement.SelectSingleNode("descendant::ns0:thisDocumentIdentifier/ns0:ProprietaryDocumentIdentifier",ns);
            return node.InnerText;

        }
        //<Site>/<InventoryType>/<Original Hub Receipt Date>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#> 
        //<Site>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#>
        //public string ProprietaryLotIdentifier(string Site, string InventoryType,
        //     string onholdRemark,
        //     string ReceiptDate, string StorerKey, string SupplierDO,
        //     string SpecialRemarks, string SeagatePO, string OnHoldQty)
        //{

        //    string receivedate = "";
        //    if (decimal.Parse(OnHoldQty) > 0)
        //    {
        //        if (!string.IsNullOrEmpty(ReceiptDate))
        //        {
        //            receivedate = DateTime.Parse(ReceiptDate).ToString("MMMddyyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        //        }
        //        return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}", Site, InventoryType + " " + onholdRemark , receivedate, StorerKey, SupplierDO, SpecialRemarks, SeagatePO);
        //    }
        //    else
        //    {
        //        return string.Format("{0}*{1}*{2}*{3}*{4}", Site, StorerKey, SupplierDO, SpecialRemarks, SeagatePO);
        //    }
        //}



        //For ON Hold Qty
        //<Site>/<InventoryType>/<Original Hub Receipt Date>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#> *<RMA/RTV Number>
        //<Site>*<Storer Key>*<Supplier DO#>*<Special Remarks from Supplier DO>*<Seagate PO#>
        //public string ProprietaryLotIdentifier(string Site, string InventoryType,
        //     string onholdRemark,
        //     string ReceiptDate, string StorerKey, string SupplierDO,
        //     string SpecialRemarks, string SeagatePO, string OnHoldQty)
        //{

        //    string receivedate = "";
        //    if (decimal.Parse(OnHoldQty) > 0)
        //    {
        //        if (!string.IsNullOrEmpty(ReceiptDate))
        //        {
        //            receivedate = DateTime.Parse(ReceiptDate).ToString("MMMddyyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        //        }
        //        return string.Format("{0}/{1}/{2}*{3}*{4}*{5}*{6}*{7}", Site.Substring(0, 2), InventoryType + " " + onholdRemark, receivedate, StorerKey, SupplierDO, SpecialRemarks,"", SeagatePO);
        //    }
        //    else
        //    {
        //        return string.Format("{0}*{1}*{2}*{3}*{4}", Site.Substring(0, 2), StorerKey, SupplierDO, SpecialRemarks, SeagatePO);
        //    }
        //}


        //<SITE><MSG TYPE><DATE TIME><SUPPLIER DUNS><SYSTEM GENERATED RUNNING SEQ NUMBER>
        //public string ProprietaryDocumentIdentifier(string Site,string msgType,string supplierDuns) {
        //    string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //    string seq = "000001";
        //    return string.Format("{0}{2}{3}{4}", Site, msgType, str, supplierDuns, seq);
        //}
        //[Site]*[Storer Key]*[Supplier DO#]*[Special Remarks from Supplier DO]*[Seagate PO#] e.g. TH*TTKABC12345*U276D11-MC0*15P/1440*PO1234
        public string SeagateProprietaryLocator(string site,string storerkey,string suppliterDO,string specialRemarks,string seagatePO) {
            return string.Format("{0}*{1}*{2}*{3}*{4}", site, storerkey, suppliterDO, specialRemarks, seagatePO);
        }
        private static void asn(){
            XDocument doc = new XDocument(new XElement("Asn"));

            string sql = @"select * from [wmwhse1].[RECEIPT] RECEIPT,[wmwhse1].[RECEIPTDETAIL] RECEIPTDETAIL
where RECEIPT.RECEIPTKEY = RECEIPTDETAIL.RECEIPTKEY FOR  XML AUTO, ELEMENTS";

            string connstr = "Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
           
            //string sql = string.Format("select * from [wmwhse1].[RECEIPTDETAIL] as RECEIPTDETAIL where  RECEIPTDETAIL.RECEIPTKEY='{0}' FOR  XML AUTO, ELEMENTS", "0000000007");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            XmlReader reader = cmd.ExecuteXmlReader();


            reader.Read();
            while (!reader.EOF)
            {
                string row = reader.ReadOuterXml();
                XElement el = XElement.Parse(row);
                doc.Root.Add(el);
                Console.WriteLine(row);

            }
            reader.Close();
            conn.Close();
        
        }
        public static void inv() {

            XDocument doc = new XDocument(new XElement("Inv"));

            string sql = @"SELECT * FROM [wmwhse1].[INVENTORYREPORT_SGHUB] INVENTORYREPORT FOR XML AUTO,ELEMENTS";

            string connstr = "Server=10.10.201.155;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
           
            //string sql = string.Format("select * from [wmwhse1].[RECEIPTDETAIL] as RECEIPTDETAIL where  RECEIPTDETAIL.RECEIPTKEY='{0}' FOR  XML AUTO, ELEMENTS", "0000000007");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            XmlReader reader = cmd.ExecuteXmlReader();

            List<XElement> list = new List<XElement>();
            reader.Read();
            while (!reader.EOF)
            {
                string row = reader.ReadOuterXml();
                XElement el = XElement.Parse(row);
                list.Add(el);
                Console.WriteLine(row);

            }
            reader.Close();
            conn.Close();
            

            IEnumerable<string> storerkeys = list.Select(x => x.Element("STORERKEY").Value).Distinct();
            foreach (string key in storerkeys)
            {
                XElement report = new XElement("Report");
                report.Add(new XAttribute("Vendor", key));
                
                report.Add(new XAttribute("VendorDOUNS", key));
                IEnumerable<XElement> det = list.Where(x => x.Element("STORERKEY").Value == key).ToArray();
                report.Add(det);
                doc.Root.Add(report);

            }

            if (!string.IsNullOrEmpty("aaaaaa"))
            {
                XNamespace nsSys = "http://www.163.com";
                //asn.Root.Add(new XAttribute(XNamespace.Xmlns, nsSys));
                foreach (XElement el in doc.Descendants())
                {
                    el.Name = nsSys + el.Name.LocalName;
                }
            }
            XNamespace ns = doc.Root.GetDefaultNamespace();
            var namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace("ns", "http://www.163.com");
            XElement xx = doc.Root.XPathSelectElement("/ns:Inv/ns:Report[1]", namespaceManager);
            Console.WriteLine(storerkeys);


        }
        public static string documentId(string site, string transtype,string datetimestring, string supplierduns,string seq )
        {

            return site.ToUpper() + transtype.ToUpper() + datetimestring.Replace(".", "").Replace("Z", "") + supplierduns + seq;
        }
        private static XElement getRole(string parten,string roleType) {
            XDocument config = XDocument.Load("c:\\config.xml");
            string xpath = string.Format("/Config/role[Partner='{0}'][roleType='{1}']", parten, roleType);
            XElement role = config.XPathSelectElement(xpath);
            return role;
        }
        //private static void DataReader() {

        //    XDocument doc = new XDocument(new XElement("AdvancedShipNotice"));
        //    XElement fromrole = ConfigHelper.GetRoleElement("WMS", "fromRole");
        //    XElement torole = ConfigHelper.GetRoleElement("STX", "toRole");
        //    doc.Root.Add(new XElement("fromRole",fromrole.Elements()));

        //    string connstr = "Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False";
        //    SqlConnection conn = new SqlConnection(connstr);
        //    conn.Open();
        //    string sql = "Select * from  [wmwhse1].[RECEIPT] as RECEIPT FOR  XML AUTO, ELEMENTS";
        //    //string sql = string.Format("select * from [wmwhse1].[RECEIPTDETAIL] as RECEIPTDETAIL where  RECEIPTDETAIL.RECEIPTKEY='{0}' FOR  XML AUTO, ELEMENTS", "0000000007");
        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = sql;
        //    XmlReader reader = cmd.ExecuteXmlReader();
            

        //    reader.Read();
        //    while (!reader.EOF)
        //    {
        //       string row= reader.ReadOuterXml();
        //       XElement el = XElement.Parse(row);
        //       doc.Root.Add(el);
        //       Console.WriteLine(row);
               
        //    }
        //    reader.Close();
        //    conn.Close();

        //    foreach (XElement receipt in doc.Root.Elements("RECEIPT")) {
        //        string receiptkey = receipt.Element("RECEIPTKEY").Value;
        //        IEnumerable<XElement> details = GetDetail(receiptkey);
        //        receipt.LastNode.AddAfterSelf(details);
        //    }
        //    Console.WriteLine(doc.ToString());
        
        //}
        private static IEnumerable<XElement>  GetDetail(string receiptkey) {
            List<XElement> list = new List<XElement>();
            string connstr = "Server=10.10.201.154;Database=SCPRD;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False";
            //string receiptkey = receipt.Element("RECEIPTKEY").Value;
            string sql1 = string.Format("select * from [wmwhse1].[RECEIPTDETAIL] as RECEIPTDETAIL where  RECEIPTDETAIL.[RECEIPTKEY]='{0}' FOR  XML AUTO, ELEMENTS", receiptkey);
            //cmd = conn.CreateCommand();
            SqlConnection conn1 = new SqlConnection(connstr);
            conn1.Open();
            SqlCommand cmd1 = conn1.CreateCommand();
            cmd1.CommandText = sql1;
            XmlReader reader1 = cmd1.ExecuteXmlReader();
            reader1.Read();
            while (!reader1.EOF)
            {
                string row = reader1.ReadOuterXml();
                if (string.IsNullOrEmpty(row))
                {
                    continue;
                }
                XElement el = XElement.Parse(row);
                list.Add(el);
                //Console.WriteLine(row);

            }
            reader1.Close();

            return list;
        }

        //private static void AsnListTest(UserInfo user)
        //{
        //    Kaifa.B2B.InforApiServiceAdapterProvider.Entities.asnlist01.Request.AdvancedShipNotice asn = Kaifa.B2B.InforApiServiceAdapterProvider.Entities.asnlist01.Request.AdvancedShipNotice.CreateByReceiptKey("0000000007", "");
        //    RequestMessage request = new RequestMessage(enumRequestType.MessageProcessor,
        //        enumMessageType.AdvancedShipNotice,
        //        enumRequestMethod.list,
        //        user,
        //        enumSendSysId.EXceed,
        //        asn);
        //    ResponseMessage response = ThreadHelper.Execute(request);
        //    Console.WriteLine(response);
        //}

        //private static void LoginTest(UserInfo user)
        //{
        //    Kaifa.B2B.InforApiServiceAdapterProvider.Entities.NSPRFOT08.Request.Utility login = Kaifa.B2B.InforApiServiceAdapterProvider.Entities.NSPRFOT08.Request.Utility.Create(user.UserName, user.Password);
        //    RequestMessage request = new RequestMessage(enumRequestType.MessageProcessor,
        //        enumMessageType.Utility,
        //        enumRequestMethod.functionOperation,
        //        user,
        //        enumSendSysId.EXceed,
        //        login);
        //    ResponseMessage response = ThreadHelper.Execute(request);
        //    Console.WriteLine(response);
        //}

        static XElement stripNS(XElement root)
        {
            return new XElement(
                root.Name.LocalName,
                root.HasElements ?
                    root.Elements().Select(el => stripNS(el)) :
                    (object)root.Value
            );
        }
        static public XmlDocument RemoveNamespace(XmlDocument xmlDoc)
        {

            string sResponse = xmlDoc.InnerXml;
            sResponse = sResponse.Replace("ns0:", String.Empty);
            xmlDoc.LoadXml(sResponse);
            xmlDoc.DocumentElement.RemoveAllAttributes();
            return xmlDoc;
        }
        static IEnumerable<string> GetReceiptKeys(string connstring,string warehouse)
        {
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string sqlcmd = string.Format("select t.RECEIPTKEY  from  [{0}].[RECEIPT]  t where t.B2BFLAG=2  ", warehouse);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yield return reader.GetString(0);
                }

            }

        }

        static XElement Header() { 
            string header =@"<Header>
	<Id>2</Id>
	<BillNo>0000000003</BillNo>
	<VehicleId>1</VehicleId>
	<InputDateTime>2015-04-13T16:18:07.427</InputDateTime>
	<PreDeliveredDateTime>2015-04-04T15:34:47</PreDeliveredDateTime>
	<Status>已配载</Status>
	<CompanyId>1</CompanyId>
	<PlateNumber>苏EF1234</PlateNumber>
	<Driver>司机1</Driver>
	<PlanDispatchDateTime>1900-01-01T00:00:00</PlanDispatchDateTime>
	<VehLoadWeight>0</VehLoadWeight>
	<PlateNumberPosition/>
	<VehLoadVolume>0</VehLoadVolume>
</Header>";

            XElement el = XElement.Parse(header);
            return el;
      

        }

        static XElement Detail()
        {
            string detail = @"<Details><Detail>
	<Id>1</Id>
	<BillNo>0000000003</BillNo>
	<WayBillId>2</WayBillId>
	<OrderId>12</OrderId>
	<MasterId>0000000005</MasterId>
	<CustomerName>飞力达</CustomerName>
	<StartingCity>昆山</StartingCity>
	<DestinationCity>苏州市区</DestinationCity>
	<BusinessType>业务类型2</BusinessType>
	<ServiceType>门到门</ServiceType>
	<OrderDateTime>2015-04-03T15:34:47</OrderDateTime>
	<GoodsName>sdfs</GoodsName>
	<LoadedWeight>360.00</LoadedWeight>
	<LoadedVolume>360.00</LoadedVolume>
	<LoadedPackages>360</LoadedPackages>
	<LoadedCartons>360</LoadedCartons>
	<Remark/>
	<CreatedUserId>Anonymous</CreatedUserId>
	<CreatedDateTime>2015-04-13T16:18:11.987</CreatedDateTime>
	<LoadedPallets>36</LoadedPallets>
</Detail>
<Detail>
	<Id>2</Id>
	<BillNo>0000000004</BillNo>
	<WayBillId>3</WayBillId>
	<OrderId>11</OrderId>
	<MasterId>0000000004</MasterId>
	<CustomerName>飞力达</CustomerName>
	<StartingCity>昆山</StartingCity>
	<DestinationCity>苏州市区</DestinationCity>
	<BusinessType>业务类型1</BusinessType>
	<ServiceType>门到门</ServiceType>
	<OrderDateTime>2015-04-03T15:28:02</OrderDateTime>
	<GoodsName>adasd</GoodsName>
	<LoadedWeight>260.00</LoadedWeight>
	<LoadedVolume>260.00</LoadedVolume>
	<LoadedPackages>260</LoadedPackages>
	<LoadedCartons>260</LoadedCartons>
	<Remark/>
	<CreatedUserId>Anonymous</CreatedUserId>
	<CreatedDateTime>2015-04-13T16:36:05.613</CreatedDateTime>
	<LoadedPallets>26</LoadedPallets>
</Detail></Details>
";

            XElement el = XElement.Parse(detail);
            return el;


        }
    }



    public static class MyExtensions
    {
        public static XElement GetXElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }

        public static XmlNode GetXmlNode(this XElement element)
        {
            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }

        public static XDocument GetXDocument(this XmlDocument document)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                document.WriteTo(xmlWriter);
            XmlDeclaration decl =
                document.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
            if (decl != null)
                xDoc.Declaration = new XDeclaration(decl.Version, decl.Encoding,
                    decl.Standalone);
            return xDoc;
        }

        public static XmlDocument GetXmlDocument(this XDocument document)
        {
            using (XmlReader xmlReader = document.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                if (document.Declaration != null)
                {
                    XmlDeclaration dec = xmlDoc.CreateXmlDeclaration(document.Declaration.Version,
                        document.Declaration.Encoding, document.Declaration.Standalone);
                    xmlDoc.InsertBefore(dec, xmlDoc.FirstChild);
                }
                return xmlDoc;
            }
        }
    }

}
