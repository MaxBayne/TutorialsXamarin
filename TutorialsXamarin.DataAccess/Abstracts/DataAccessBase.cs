using System;
using TutorialsXamarin.Common.Enums;
using TutorialsXamarin.DataAccess.Contexts;
using TutorialsXamarin.DataAccess.ContextsMock;

namespace TutorialsXamarin.DataAccess.Abstracts
{
    public class DataAccessBase: IDisposable
    {
        protected static ApplicationDbContext Db;
        //protected static MockDb Mock;
        protected ConnectionType ConnectionType; //SQL Server , Mock


        protected DataAccessBase(ConnectionType connectionType)
        {
            ConnectionType = connectionType;


            switch (ConnectionType)
            {
                case ConnectionType.Sqlserver: //For ERP Mode
                    Db = new ApplicationDbContext();
                    break;
            }

        }

        protected string GetConnectionString(ConnectionType connectionType)
        {
            //switch (connectionType)
            //{
            //    case ConnectionType.LocalConnection: //For ERP Mode
            //        return ERP_DB_Connection.ConnectionStringLocalDb;
            //    case ConnectionType.GlobalConnection: //For ERP Mode
            //        return ERP_DB_Connection.ConnectionStringGlobalDb;
            //    case ConnectionType.TransferConnection: //For ERP Mode
            //        return ERP_DB_Connection.ConnectionStringTransferDb;
            //    case ConnectionType.SystemConnection: //For E-Invoice Mode
            //        return ERP_DB_Connection.ConnectionStringSystemDb;
            //    case ConnectionType.TaxpayerConnection: //For E-Invoice Mode
            //        return ERP_DB_Connection.ConnectionStringTaxpayerDb;
            //    default:
            //        return ERP_DB_Connection.ConnectionStringLocalDb;
            //}

            return string.Empty;
        }

        public void Dispose()
        {
            //Cn.Close();
            //Cn.Dispose();

            //Db.Dispose();
        }
    }
}