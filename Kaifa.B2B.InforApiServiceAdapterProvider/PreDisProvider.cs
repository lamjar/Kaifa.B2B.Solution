﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduledTaskAdapter.TaskComponents;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Kaifa.B2B.InforApiServiceAdapterProvider
{
    public class PreDisProvider : IScheduledTaskStreamProvider
    {
        public Type GetParameterType()
        {
            return typeof(PreDisProviderParameters);
        }




        #region IScheduledTaskStreamProvider Members


        public System.IO.Stream GetStream(object args)
        {
            PreDisProviderParameters _args = new PreDisProviderParameters();
            _args = args as PreDisProviderParameters;
            _args.tagnamespace = "http://Kaifa.B2B.Schemas.PREDIS";
            string orderkey = GetOrderKey(_args);
            if (!string.IsNullOrEmpty(orderkey))
            {

                MemoryStream ms = new MemoryStream();
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                xws.Indent = true;

                using (XmlWriter xw = XmlWriter.Create(ms, xws))
                {
                    PreDisGenerator tdn = new PreDisGenerator(orderkey, _args.warehous, _args.connectionstring, _args.tagnamespace);
                    XDocument doc = tdn.Generator();
                    doc.WriteTo(xw);
                }
                ms.Seek(0, SeekOrigin.Begin);
                //System.Diagnostics.Trace.WriteLine("");


                UpdateFlag(_args, orderkey);
                System.Diagnostics.Trace.WriteLine(string.Format("Create PREDIS {0}", orderkey), "PreDisGenerator");
                return ms;


                
            }
            else
            {
                return null;
            }
        }

        private string GetOrderKey(PreDisProviderParameters _args)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_args.connectionstring))
                {
                    conn.Open();
                    string sqlcmd = string.Format(@"SELECT TOP 1 T.ORDERKEY  FROM  [{0}].[ORDERS]  T WHERE (T.B2BFLAG4 = 0) AND ( STATUS=N'88'  
                                                     OR ( T.STATUS=N'92' AND  NOT  EXISTS (SELECT 1 FROM [{0}].[ORDERDETAIL] T2 WHERE  T2.STATUS<'88' AND T.ORDERKEY=T2.ORDERKEY ) ))
                                               AND  EXISTS (SELECT ORDERKEY FROM [{0}].[PREDISB2B] T1 WHERE T.ORDERKEY = T1.ORDERKEY )
                                        ", _args.warehous);
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sqlcmd;
                    object result = cmd.ExecuteScalar();
                    conn.Close();
                    return (result == null ? string.Empty : result.ToString());

                }
            }
            catch {
                return string.Empty;
            }
        }
        private void UpdateFlag(PreDisProviderParameters _args, string orderkey)
        {
            using (SqlConnection conn = new SqlConnection(_args.connectionstring))
            {
                conn.Open();
                //string whereexpression = "    WHERE RECEIPTKEY  IN (" + string.Join(",", receiptKeys.Select(t => "'" + t + "'").ToArray()) + ")";
                string sqlcmd = string.Format("UPDATE  [{0}].[ORDERS]  SET B2BFLAG4 = 1 where ORDERKEY = N'{1}'", _args.warehous, orderkey);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                cmd.ExecuteNonQuery();

            }
        }

        #endregion
    }

    [Serializable()]
    public class PreDisProviderParameters
    {
      
        [Description("Warehouse Name"), Category("Config")]
        public string warehous { get; set; }

        [Description("Connection String"), Category("Config")]
        public string connectionstring { get; set; }
        [Description("Xml targetNamespace"), Category("Config")]
        public string tagnamespace { get; set; }
    }

}
