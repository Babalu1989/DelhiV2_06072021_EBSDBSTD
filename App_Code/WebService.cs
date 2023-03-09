using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using System.Reflection;


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{
    clsBapiCall obj = new clsBapiCall();
    public WebService()
    {
    }
    
    [WebMethod]
    public DataSet Z_BAPI_DISPLAY_BIIL_OPOWER_ORC(string strCANumber, string strBillMonth)
    {
        DataSet BAPI_RESULT = new DataSet();
        if (checkConsumer(MethodBase.GetCurrentMethod().Name))
        {
            //DataSet Ds = obj.Get_Z_BAPI_CMS_ISU_CA_DISPLAY(strCANumber, strSerialNumber, strConsumerNumber, strTelephoneNumber, strKNumber, strContractNumber);
            BAPI_RESULT = GetCA_OpowerData(strCANumber);
        }
        return BAPI_RESULT;
    }

    public bool checkConsumer(string _sFunName)
    {
        // In this method you can check the username and password 
        // with your database or something
        // You could also encrypt the password for more security

        //if (consumer != null)
        //{
        //    if (NewClassFile.getWebSericeAccess(consumer.userName, consumer.password, _sFunName))
        return true;
        //    else
        //        return false;
        //}
        //else
        //    return false;
    }

    public DataSet GetCA_OpowerData(string _sCaNumber)
    {
        DataSet ds = new DataSet();
        DataTable _dt = new DataTable();
        string _sSql = string.Empty;

        _sSql = " select CONTRACT_ACCOUNT  Ca_Number, BUSINESS_PARTNER Bp_Number, FIRST_NAME ||' '|| LAST_NAME Bp_Name,'0' Bp_Type, '0' Search_Term1, ";
        _sSql += " ACCOUNT_CLASS Search_Term2,'0' House_Number, '0'House_Number_Sup,'0'Floor,CONSUMER_STATUS Premise_Type, ";
        _sSql += " ADDRESS Street , '0'Street2,'0'Street3,'0'Street4, 'NEW DELHI' City,'0' Post_Code, 'DEL' Region,'IN' Country,'0' Desc_Con_Object, ";
        _sSql += " DIVISION Reg_Str_Group, '0' Device_Sr_Number, TEL_NUMBER Telephone_No,'0'Mru, '0' Func_Descr, ";
        _sSql += " '000000' Outage_Fromtime, '000000'Outage_Totime, '0' Legacy_Acct,'0' Bill_Class, RATE_CATEGORY Rate_Cat,'0' Activity,'0' Adr_Notes, MOBILE_NO Tel1_Number, ";
        _sSql += " '0' Vertrag, EMAIL E_Mail, '0' Move_Out_Date, '0' Con_Obj_No,'0' Clerk_Id,'0' Text,'00' Status, '0' Discreason, '0'POLE_NO ";
        _sSql += " from pcm.CONSUMER_SAP_MASTER where CONTRACT_ACCOUNT='" + _sCaNumber + "' ";

        _dt = dmlgetquery(_sSql);

        if (_dt.Rows.Count > 0)
        {

            DataTable ISUSTDTable = new DataTable();
            DataColumn column = new DataColumn();

            ISUSTDTable.Columns.Add("CONSUMER_NO", typeof(string));
            ISUSTDTable.Columns.Add("strBillMonth", typeof(string));
            ISUSTDTable.Columns.Add("FIRSTNAME", typeof(string));
            ISUSTDTable.Columns.Add("AMNT_AFT_DUE_DAT", typeof(string));
            ISUSTDTable.Columns.Add("BILL_MONTH", typeof(string));
            ISUSTDTable.Columns.Add("DUE_DATE", typeof(string));
            ISUSTDTable.Columns.Add("LASTNAME", typeof(string));
            ISUSTDTable.Columns.Add("SANC_LOAD", typeof(string));
            ISUSTDTable.Columns.Add("RATE_CATEGORY", typeof(string));
            ISUSTDTable.Columns.Add("BILL_BASIS", typeof(string));
            ISUSTDTable.Columns.Add("HOUSE_NO", typeof(string));
            ISUSTDTable.Columns.Add("FATHER_NAME", typeof(string));
            ISUSTDTable.Columns.Add("STR_SUPPL2", typeof(string));
            ISUSTDTable.Columns.Add("CITY", typeof(string));
            ISUSTDTable.Columns.Add("POSTL_COD1", typeof(string));
            ISUSTDTable.Columns.Add("TOT_UNITS_BILLED", typeof(string));
            ISUSTDTable.Columns.Add("MDI", typeof(string));
            ISUSTDTable.Columns.Add("INVOICE_NO", typeof(string));
            ISUSTDTable.Columns.Add("DATE_OF_INVOICE", typeof(string));
            ISUSTDTable.Columns.Add("CYCLE_NO", typeof(string));
            ISUSTDTable.Columns.Add("COMPANY_CODE", typeof(string));
            ISUSTDTable.Columns.Add("CUR_MTH_BILL_AMT", typeof(string));
            ISUSTDTable.Columns.Add("NET_AMNT", typeof(string));
            ISUSTDTable.Columns.Add("UNIT_DESCR", typeof(string));
            ISUSTDTable.Columns.Add("MIDDLE_NAME", typeof(string));
            ISUSTDTable.Columns.Add("OPOWER", typeof(string));

            DataRow dr;
            dr = ISUSTDTable.NewRow();

            dr["CONSUMER_NO"] = _dt.Rows[0]["Ca_Number"].ToString();
            dr["strBillMonth"] = "0";
            dr["FIRSTNAME"] = _dt.Rows[0]["Bp_Name"].ToString();
            dr["AMNT_AFT_DUE_DAT"] = "0";
            dr["BILL_MONTH"] = "0";
            dr["DUE_DATE"] = "0";
            dr["LASTNAME"] = "0";
            dr["SANC_LOAD"] = "0";
            dr["RATE_CATEGORY"] = _dt.Rows[0]["Rate_Cat"].ToString();
            dr["BILL_BASIS"] = "0";
            dr["HOUSE_NO"] = "0";
            dr["FATHER_NAME"] = "0";
            dr["STR_SUPPL2"] = "0";
            dr["CITY"] = "0";
            dr["POSTL_COD1"] = "0";
            dr["TOT_UNITS_BILLED"] = "0";
            dr["MDI"] = "0";
            dr["INVOICE_NO"] = "0";
            dr["DATE_OF_INVOICE"] = "0";
            dr["CYCLE_NO"] = "0";
            dr["COMPANY_CODE"] = "BRPL";
            dr["CUR_MTH_BILL_AMT"] = "";
            dr["NET_AMNT"] = "0";
            dr["UNIT_DESCR"] = "0";
            dr["MIDDLE_NAME"] = "0";
            dr["OPOWER"] = "0";

            ISUSTDTable.Rows.Add(dr);
            ISUSTDTable.AcceptChanges();

            ds.Tables.Add(ISUSTDTable);
            ds.Tables[0].TableName = "ISUSTDTable";
            ds.DataSetName = "BAPI_RESULT";

        }

        return ds;
    }

    //public DataSet GetCAWise_DisplayData(string _sCaNumber)
    //{
    //    DataSet ds = new DataSet();
    //    DataTable _dt = new DataTable();
    //    string _sSql = string.Empty;

    //    DataTable ISUSTDTable = new DataTable();
    //    DataColumn column = new DataColumn();

    //    ISUSTDTable.Columns.Add("Ca_Number", typeof(string));
    //    ISUSTDTable.Columns.Add("Bp_Number", typeof(string));
    //    ISUSTDTable.Columns.Add("Bp_Name", typeof(string));
    //    ISUSTDTable.Columns.Add("Bp_Type", typeof(string));
    //    ISUSTDTable.Columns.Add("Search_Term1", typeof(string));
    //    ISUSTDTable.Columns.Add("Search_Term2", typeof(string));
    //    ISUSTDTable.Columns.Add("House_Number", typeof(string));
    //    ISUSTDTable.Columns.Add("House_Number_Sup", typeof(string));
    //    ISUSTDTable.Columns.Add("Floor", typeof(string));
    //    ISUSTDTable.Columns.Add("Premise_Type", typeof(string));
    //    ISUSTDTable.Columns.Add("Street", typeof(string));
    //    ISUSTDTable.Columns.Add("Street2", typeof(string));
    //    ISUSTDTable.Columns.Add("Street3", typeof(string));
    //    ISUSTDTable.Columns.Add("Street4", typeof(string));
    //    ISUSTDTable.Columns.Add("City", typeof(string));
    //    ISUSTDTable.Columns.Add("Post_Code", typeof(string));
    //    ISUSTDTable.Columns.Add("Region", typeof(string));
    //    ISUSTDTable.Columns.Add("Country", typeof(string));
    //    ISUSTDTable.Columns.Add("Desc_Con_Object", typeof(string));
    //    ISUSTDTable.Columns.Add("Reg_Str_Group", typeof(string));
    //    ISUSTDTable.Columns.Add("Device_Sr_Number", typeof(string));
    //    ISUSTDTable.Columns.Add("Telephone_No", typeof(string));
    //    ISUSTDTable.Columns.Add("Mru", typeof(string));
    //    ISUSTDTable.Columns.Add("Func_Descr", typeof(string));
    //    ISUSTDTable.Columns.Add("Outage_Fromtime", typeof(string));
    //    ISUSTDTable.Columns.Add("Outage_Totime", typeof(string));
    //    ISUSTDTable.Columns.Add("Legacy_Acct", typeof(string));
    //    ISUSTDTable.Columns.Add("Bill_Class", typeof(string));
    //    ISUSTDTable.Columns.Add("Rate_Cat", typeof(string));
    //    ISUSTDTable.Columns.Add("Activity", typeof(string));
    //    ISUSTDTable.Columns.Add("Adr_Notes", typeof(string));
    //    ISUSTDTable.Columns.Add("Tel1_Number", typeof(string));
    //    ISUSTDTable.Columns.Add("Vertrag", typeof(string));
    //    ISUSTDTable.Columns.Add("E_Mail", typeof(string));
    //    ISUSTDTable.Columns.Add("Move_Out_Date", typeof(string));
    //    ISUSTDTable.Columns.Add("Con_Obj_No", typeof(string));
    //    ISUSTDTable.Columns.Add("Clerk_Id", typeof(string));
    //    ISUSTDTable.Columns.Add("Text", typeof(string));
    //    ISUSTDTable.Columns.Add("Status", typeof(string));
    //    ISUSTDTable.Columns.Add("Discreason", typeof(string));
    //    ISUSTDTable.Columns.Add("POLE_NO", typeof(string));
    //    ISUSTDTable.Columns.Add("DUE_DATE", typeof(string));
    //    ISUSTDTable.Columns.Add("NET_AMNT", typeof(string));
    //    ISUSTDTable.Columns.Add("SANCTIONED_LOAD", typeof(string));
    //    ISUSTDTable.Columns.Add("COMPANY_CODE", typeof(string));
    //    ISUSTDTable.Columns.Add("BILL_BASIS", typeof(string));

    //    _sSql = " select CONTRACT_ACCOUNT  Ca_Number, BUSINESS_PARTNER Bp_Number, FIRST_NAME ||' '|| LAST_NAME Bp_Name,'.' Bp_Type, '.' Search_Term1, ";
    //    _sSql += " s.ACCOUNT_CLASS Search_Term2,'.' House_Number, '.'House_Number_Sup,'.'Floor,CONSUMER_STATUS Premise_Type, ";
    //    _sSql += " ADDRESS Street , '.'Street2,'.'Street3,'.'Street4, 'NEW DELHI' City,'.' Post_Code, 'DEL' Region,'IN' Country,'.' Desc_Con_Object,SANCTIONED_LOAD, ";
    //    _sSql += " s.DIVISION Reg_Str_Group, '.' Device_Sr_Number, TEL_NUMBER Telephone_No,'.'Mru, '.' Func_Descr, ";
    //    _sSql += " '000000' Outage_Fromtime, '000000'Outage_Totime, '.' Legacy_Acct,'.' Bill_Class, RATE_CATEGORY Rate_Cat,'.' Activity,'.' Adr_Notes, S.MOBILE_NO Tel1_Number, ";
    //    _sSql += " '.' Vertrag, EMAIL E_Mail, '.' Move_Out_Date, '.' Con_Obj_No,'.' Clerk_Id,'.' Text,'.' Status, '.' Discreason, '.'POLE_NO, 'BRPL' COMPANY_CODE, ";
    //    //_sSql += " CASE WHEN trunc(SMS_GEN_DATE) <'19-May-2021' THEN '202105'||substr(due_date,1,2)  ELSE '202106'||substr(due_date,1,2) END  DueDate,substr(AMOUNT,4) AMOUNT ";
    //    _sSql += " to_char(DUE_DATE,'YYYYMMDD')  DueDate, AMOUNT,BILL_BASIS ";
    //    _sSql += " from pcm.CONSUMER_SAP_MASTER S, MOBAPP.BRPL_BILL_MASTER M where S.CONTRACT_ACCOUNT=M.CA_NUMBER(+)  AND S.CONTRACT_ACCOUNT='" + _sCaNumber + "' ";
    //    _sSql += " order by m.SMS_GEN_DATE desc  ";

    //    _dt = dmlgetquery(_sSql);

    //    if (_dt.Rows.Count == 0)
    //    {
    //        _sSql = "  select CONTRACT_ACCOUNT Ca_Number, BUSINESS_PARTNER Bp_Number, FIRST_NAME ||' '|| LAST_NAME Bp_Name,'0' Bp_Type, '0' Search_Term1, ";
    //        _sSql += " '' Search_Term2,'.' House_Number, '.'House_Number_Sup,'.'Floor,'.' Premise_Type, ";
    //        _sSql += " ADDRESS Street , '0'Street2,'0'Street3,'0'Street4, 'DELHI' City,'0' Post_Code, 'DEL' Region,'IN' Country,'0' Desc_Con_Object, LOAD SANCTIONED_LOAD, ";
    //        _sSql += " DIVISION Reg_Str_Group, '0' Device_Sr_Number, TELEPHONE_NUMBER Telephone_No,'0'Mru, '0' Func_Descr,  ";
    //        _sSql += " '000000' Outage_Fromtime, '000000'Outage_Totime, '0' Legacy_Acct,S.ACCOUNT_CLASS Bill_Class, RATE_CATEGORY Rate_Cat,'0' Activity,'0' Adr_Notes, TELEPHONE_NUMBER Tel1_Number, ";
    //        _sSql += " '0' Vertrag, EMAIL E_Mail, '0' Move_Out_Date, '0' Con_Obj_No,'0' Clerk_Id,'0' Text,'00' Status, '0' Discreason, '0'POLE_NO ,COMPANY_CODE,  ";
    //        _sSql += " to_char(DUE_DATE,'YYYYMMDD') DUEDATE,AMOUNT,BILL_BASIS ";
    //        _sSql += " from admin.payment_mobile_data  S, ADMIN.BYPL_BILL_MASTER M where S.CONTRACT_ACCOUNT=M.CA_NUMBER  AND S.CONTRACT_ACCOUNT='" + _sCaNumber + "'  ";
    //        _sSql += "  order by m.SMS_GEN_DATE desc ";

    //        _dt = dmlgetquery(_sSql);


    //        //if (_dt.Rows.Count == 0)
    //        //{

    //        //    _sSql = " select CONS_REF Ca_Number,'.' Bp_Number, NAME bp_NAME,'.' Bp_Type, '.' Search_Term1,  ";
    //        //    _sSql += " '' Search_Term2,'.' House_Number, '.'House_Number_Sup,'.'Floor,'.' Premise_Type, ";
    //        //    _sSql += " '.' Street , '.'Street2,'.'Street3,'.'Street4, 'NEW DELHI' City,'.' Post_Code, 'DEL' Region,'IN' Country,'.' Desc_Con_Object,SANCT_LOAD SANCTIONED_LOAD, ";
    //        //    _sSql += " DISTRICT Reg_Str_Group, '.' Device_Sr_Number, S.MOBILE_NO Telephone_No,'.'Mru, '.' Func_Descr,";
    //        //    _sSql += " '000000' Outage_Fromtime, '000000'Outage_Totime, '.' Legacy_Acct,'.' Bill_Class, '.' Rate_Cat,'.' Activity,'.' Adr_Notes, S.MOBILE_NO Tel1_Number, ";
    //        //    _sSql += " '.' Vertrag, '.' E_Mail, '.' Move_Out_Date, '.' Con_Obj_No,'.' Clerk_Id,'.' Text,'.' Status, '.' Discreason, '.'POLE_NO, SAP_COMPANY COMPANY_CODE, ";
    //        //    _sSql += " CASE WHEN trunc(SMS_GEN_DATE) <'19-May-2021' THEN '202105'||substr(due_date,1,2)  ELSE '202106'||substr(due_date,1,2) END  DueDate,substr(AMOUNT,4) AMOUNT ";
    //        //    _sSql += " from rcmpa.sap_formy_vws S, MOBAPP.BRPL_BILL_MASTER M where S.CONS_REF='000'||M.CA_NUMBER(+)  AND S.CONS_REF='" + _sCaNumber + "'  ";
    //        //    _sSql += " order by m.SMS_GEN_DATE desc  ";

    //        //    _dt = dmlgetquery(_sSql);
    //        //}
    //    }


    //    if (_dt.Rows.Count > 0)
    //    {
    //        DataRow dr;
    //        dr = ISUSTDTable.NewRow();

    //        dr["Ca_Number"] = _dt.Rows[0]["Ca_Number"].ToString();
    //        dr["Bp_Number"] = _dt.Rows[0]["Bp_Number"].ToString();
    //        dr["Bp_Name"] = _dt.Rows[0]["Bp_Name"].ToString();
    //        dr["Bp_Type"] = _dt.Rows[0]["Bp_Type"].ToString();
    //        dr["Search_Term1"] = _dt.Rows[0]["Search_Term1"].ToString();
    //        dr["Search_Term2"] = _dt.Rows[0]["Search_Term2"].ToString();
    //        dr["House_Number"] = _dt.Rows[0]["House_Number"].ToString();
    //        dr["House_Number_Sup"] = _dt.Rows[0]["House_Number_Sup"].ToString();
    //        dr["Floor"] = _dt.Rows[0]["Floor"].ToString();
    //        dr["Premise_Type"] = _dt.Rows[0]["Premise_Type"].ToString();
    //        dr["Street"] = _dt.Rows[0]["Street"].ToString();
    //        dr["Street2"] = _dt.Rows[0]["Street2"].ToString();
    //        dr["Street3"] = _dt.Rows[0]["Street3"].ToString();
    //        dr["Street4"] = _dt.Rows[0]["Street4"].ToString();
    //        dr["City"] = _dt.Rows[0]["City"].ToString();
    //        dr["Post_Code"] = _dt.Rows[0]["Post_Code"].ToString();
    //        dr["Region"] = _dt.Rows[0]["Region"].ToString();
    //        dr["Country"] = _dt.Rows[0]["Country"].ToString();
    //        dr["Desc_Con_Object"] = _dt.Rows[0]["Desc_Con_Object"].ToString();
    //        dr["Reg_Str_Group"] = _dt.Rows[0]["Reg_Str_Group"].ToString();
    //        dr["Device_Sr_Number"] = _dt.Rows[0]["Device_Sr_Number"].ToString();
    //        dr["Telephone_No"] = _dt.Rows[0]["Telephone_No"].ToString();
    //        dr["Mru"] = _dt.Rows[0]["Mru"].ToString();
    //        dr["Func_Descr"] = _dt.Rows[0]["Func_Descr"].ToString();
    //        dr["Outage_Fromtime"] = _dt.Rows[0]["Outage_Fromtime"].ToString();
    //        dr["Outage_Totime"] = _dt.Rows[0]["Outage_Totime"].ToString();
    //        dr["Legacy_Acct"] = _dt.Rows[0]["Legacy_Acct"].ToString();
    //        dr["Bill_Class"] = _dt.Rows[0]["Bill_Class"].ToString();
    //        dr["Rate_Cat"] = _dt.Rows[0]["Rate_Cat"].ToString();
    //        dr["Activity"] = _dt.Rows[0]["Activity"].ToString();
    //        dr["Adr_Notes"] = _dt.Rows[0]["Adr_Notes"].ToString();
    //        dr["Tel1_Number"] = _dt.Rows[0]["Tel1_Number"].ToString();
    //        dr["Vertrag"] = _dt.Rows[0]["Vertrag"].ToString();
    //        dr["E_Mail"] = _dt.Rows[0]["E_Mail"].ToString();
    //        dr["Move_Out_Date"] = _dt.Rows[0]["Move_Out_Date"].ToString();
    //        dr["Con_Obj_No"] = _dt.Rows[0]["Con_Obj_No"].ToString();
    //        dr["Clerk_Id"] = _dt.Rows[0]["Clerk_Id"].ToString();
    //        dr["Text"] = _dt.Rows[0]["Text"].ToString();
    //        dr["Status"] = _dt.Rows[0]["Status"].ToString();
    //        dr["Discreason"] = _dt.Rows[0]["Discreason"].ToString();
    //        dr["POLE_NO"] = _dt.Rows[0]["POLE_NO"].ToString();
    //        dr["DUE_DATE"] = _dt.Rows[0]["DUEDATE"].ToString();
    //        dr["NET_AMNT"] = _dt.Rows[0]["AMOUNT"].ToString();
    //        dr["SANCTIONED_LOAD"] = _dt.Rows[0]["SANCTIONED_LOAD"].ToString();
    //        dr["COMPANY_CODE"] = _dt.Rows[0]["COMPANY_CODE"].ToString();
    //        dr["BILL_BASIS"] = _dt.Rows[0]["BILL_BASIS"].ToString();

    //        ISUSTDTable.Rows.Add(dr);
    //        ISUSTDTable.AcceptChanges();

    //        ds.Tables.Add(ISUSTDTable);
    //        ds.Tables[0].TableName = "ISUSTDTable";
    //        ds.DataSetName = "BAPI_RESULT";
    //    }
    //    else
    //    {

    //        ISUSTDTable.Rows.Add("No Record Found", "No Record Found", "No Record Found", "No Record Found", "No Record Found", "No Record Found");
    //        ds.Tables.Add(ISUSTDTable);

    //        ds.Tables[0].TableName = "ISUSTDTable";
    //        ds.DataSetName = "BAPI_RESULT";
    //    }

    //    return ds;
    //}

    public DataTable dmlgetquery(string sql)
    {
        DataTable dt = new DataTable();
        OleDbCommand dbcommand;
        OleDbTransaction dbtrans;
        NDS objNDS = new NDS();
        OleDbDataAdapter da;

        OleDbConnection ocon = new OleDbConnection(objNDS.conPCM());
        try
        {
            if (ocon.State == ConnectionState.Closed)
            {
                ocon.Open();
            }
            dbcommand = new OleDbCommand();
            dbcommand.Connection = ocon;
            da = new OleDbDataAdapter();
            da.SelectCommand = dbcommand;
            dt = null;
            dt = new DataTable();
            dbcommand.CommandType = CommandType.Text;
            dbcommand.CommandText = sql;
            //dbcommand.Transaction = dbtrans;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            ex.ToString();
            return dt;
        }
        finally
        {
            if (ocon.State == ConnectionState.Open)
            {
                ocon.Close();
                ocon.Dispose();
            }
        }
    }

    [WebMethod]
    public DataSet Z_BAPI_CMS_ISU_CA_DISPLAY(string strCANumber, string strSerialNumber, string strConsumerNumber, string strTelephoneNumber,
                                                    string strKNumber, string strContractNumber)
    {
        DataSet Ds = obj.Get_Z_BAPI_CMS_ISU_CA_DISPLAY(strCANumber, strSerialNumber, strConsumerNumber, strTelephoneNumber, strKNumber, strContractNumber);
       // DataSet BAPI_RESULT = GetCAWise_DisplayData(strCANumber);
        return Ds;
    }
    [WebMethod]
    public DataSet ZBAPI_DISPLAY_BILL_WEB(string strCANumber, string strBillMonth)
    {
        //DataSet Ds = obj.Get_ZBAPI_DISPLAY_BILL_WEB(strCANumber, strBillMonth);
        DataTable _dtData = new DataTable();

          //if(GetCAWise_DisplayData(strCANumber).Tables.Count>0)
        //_dtData = GetCAWise_DisplayData(strCANumber).Tables[0];

        DataSet Ds = new DataSet();

        if (_dtData.Rows.Count > 0)
        {
            DataTable billDetailsTable1 = new DataTable();
            DataColumn column = new DataColumn();
            billDetailsTable1.Columns.Add("INVOICE_NO", typeof(string));
            billDetailsTable1.Columns.Add("CONSUMER_NO", typeof(string));
            billDetailsTable1.Columns.Add("DATE_OF_INVOICE", typeof(string));
            billDetailsTable1.Columns.Add("CYCLE_NO", typeof(string));
            billDetailsTable1.Columns.Add("FIRSTNAME", typeof(string));
            billDetailsTable1.Columns.Add("HOUSE_NO", typeof(string));
            billDetailsTable1.Columns.Add("UNIT_DESCR", typeof(string));
            billDetailsTable1.Columns.Add("CIRCLE_DESCR", typeof(string));
            billDetailsTable1.Columns.Add("NET_AMNT", typeof(string));
            billDetailsTable1.Columns.Add("DUE_DATE", typeof(string));
            billDetailsTable1.Columns.Add("BILL_MONTH", typeof(string));
            billDetailsTable1.Columns.Add("TOT_UNITS_BILLED", typeof(string));
            billDetailsTable1.Columns.Add("BILL_BASIS", typeof(string));
            billDetailsTable1.Columns.Add("SANC_LOAD", typeof(string));
            billDetailsTable1.Columns.Add("RATE_CATEGORY", typeof(string));
            billDetailsTable1.Columns.Add("CONT_DEMAND", typeof(string));
            billDetailsTable1.Columns.Add("TOT_ENRGY_CHRG", typeof(string));
            billDetailsTable1.Columns.Add("TOT_ENE_CHRG_AMD", typeof(string));
            billDetailsTable1.Columns.Add("TOT_ENE_CHG_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("TOT_FIX_CHRG", typeof(string));
            billDetailsTable1.Columns.Add("TOT_FIX_CHRG_AMD", typeof(string));
            billDetailsTable1.Columns.Add("TOT_FIX_CHG_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("ELECT_TAX", typeof(string));
            billDetailsTable1.Columns.Add("ELECT_TAX_AMNDS", typeof(string));
            billDetailsTable1.Columns.Add("ELECT_TAX_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("REBATE", typeof(string));
            billDetailsTable1.Columns.Add("REBATE_AMNDS", typeof(string));
            billDetailsTable1.Columns.Add("REBATE_AMNDTAM", typeof(string));
            billDetailsTable1.Columns.Add("RATE_SUBSIDY", typeof(string));
            billDetailsTable1.Columns.Add("RATE_SUBSIDY_AMD", typeof(string));
            billDetailsTable1.Columns.Add("RATE_SBSIDY_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("SPL_SUBSIDY", typeof(string));
            billDetailsTable1.Columns.Add("SPL_SUBSIDY_AMN", typeof(string));
            billDetailsTable1.Columns.Add("SPL_SBSIDY_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("OTHER_CHRGS", typeof(string));
            billDetailsTable1.Columns.Add("OTHER_CHRGS_AMND", typeof(string));
            billDetailsTable1.Columns.Add("OTHER_CHRGS_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("LPSC_CURRENT", typeof(string));
            billDetailsTable1.Columns.Add("CUR_MTH_BILL_AMT", typeof(string));
            billDetailsTable1.Columns.Add("CUR_MTH_BILL_AMD", typeof(string));
            billDetailsTable1.Columns.Add("CUR_MTH_BIL_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("ARR_PAYABLE", typeof(string));
            billDetailsTable1.Columns.Add("ARR_PAYABLE_AMD", typeof(string));
            billDetailsTable1.Columns.Add("ARR_PAYABLE_AMDA", typeof(string));
            billDetailsTable1.Columns.Add("ARR_ENRGY_CHRG", typeof(string));
            billDetailsTable1.Columns.Add("ARR_ELECT_TAX", typeof(string));
            billDetailsTable1.Columns.Add("ARR_OTHER_CHRGS", typeof(string));
            billDetailsTable1.Columns.Add("ARR_LPSC", typeof(string));
            billDetailsTable1.Columns.Add("AR_LAST_MTH_BILL", typeof(string));
            billDetailsTable1.Columns.Add("REFUND", typeof(string));
            billDetailsTable1.Columns.Add("DEFERRED_AMNT", typeof(string));
            billDetailsTable1.Columns.Add("INST_NOT_DUE", typeof(string));
            billDetailsTable1.Columns.Add("PYMT_RECD_AMNT", typeof(string));
            billDetailsTable1.Columns.Add("ARREARS_PAYABLE", typeof(string));
            billDetailsTable1.Columns.Add("AMEN_PERIOD_FRM", typeof(string));
            billDetailsTable1.Columns.Add("AMEN_PERIOD_TO", typeof(string));
            billDetailsTable1.Columns.Add("AMD_REASON", typeof(string));
            billDetailsTable1.Columns.Add("TOT_ORIG_AMNT", typeof(string));
            billDetailsTable1.Columns.Add("TOT_AMND_AMNT", typeof(string));
            billDetailsTable1.Columns.Add("UNITS_1", typeof(string));
            billDetailsTable1.Columns.Add("UNITS_2", typeof(string));
            billDetailsTable1.Columns.Add("UNITS_3", typeof(string));
            billDetailsTable1.Columns.Add("UNITS_4", typeof(string));
            billDetailsTable1.Columns.Add("UNITS_5", typeof(string));
            billDetailsTable1.Columns.Add("UNITS_6", typeof(string));
            billDetailsTable1.Columns.Add("AMNT_AFT_DUE_DAT", typeof(string));
            billDetailsTable1.Columns.Add("PYMT_ACCNTD_UPTO", typeof(string));
            billDetailsTable1.Columns.Add("SEC_DEP_AMNT", typeof(string));
            billDetailsTable1.Columns.Add("TARIFF", typeof(string));
            billDetailsTable1.Columns.Add("METER_TYPE", typeof(string));
            billDetailsTable1.Columns.Add("COMPANY_CODE", typeof(string));
            billDetailsTable1.Columns.Add("LASTNAME", typeof(string));
            billDetailsTable1.Columns.Add("MIDDLE_NAME", typeof(string));
            billDetailsTable1.Columns.Add("FATHER_NAME", typeof(string));
            billDetailsTable1.Columns.Add("STREET", typeof(string));
            billDetailsTable1.Columns.Add("STR_SUPPL1", typeof(string));
            billDetailsTable1.Columns.Add("STR_SUPPL2", typeof(string));
            billDetailsTable1.Columns.Add("STR_SUPPL3", typeof(string));
            billDetailsTable1.Columns.Add("CITY", typeof(string));
            billDetailsTable1.Columns.Add("POSTL_COD1", typeof(string));
            billDetailsTable1.Columns.Add("ADJUSTMENT", typeof(string));
            billDetailsTable1.Columns.Add("PAYMENT_RECEIVED", typeof(string));
            billDetailsTable1.Columns.Add("PAYMENT_DATE", typeof(string));
            billDetailsTable1.Columns.Add("TOT_BIL_AMT", typeof(string));
            billDetailsTable1.Columns.Add("TOT_BIL_AMNDS", typeof(string));
            billDetailsTable1.Columns.Add("TOT_BIL_AMDTAM", typeof(string));
            billDetailsTable1.Columns.Add("MDI", typeof(string));
            billDetailsTable1.Columns.Add("MOB_NO", typeof(string));
            billDetailsTable1.Columns.Add("EMAIL", typeof(string));

            DataRow dr;
            dr = billDetailsTable1.NewRow();
            dr["INVOICE_NO"] = ".";

            dr["CONSUMER_NO"] = _dtData.Rows[0]["CA_NUMBER"].ToString();
            dr["DATE_OF_INVOICE"] = ".";
            dr["CYCLE_NO"] = ".";
            dr["FIRSTNAME"] = _dtData.Rows[0]["BP_NAME"].ToString().Trim();
            dr["HOUSE_NO"] = ".";
            dr["UNIT_DESCR"] = _dtData.Rows[0]["REG_STR_GROUP"].ToString();
            dr["CIRCLE_DESCR"] = ".";

            if (_dtData.Rows[0]["NET_AMNT"] != null)
            {
                if (_dtData.Rows[0]["NET_AMNT"].ToString().Trim() != "")
                {
                    dr["NET_AMNT"] = _dtData.Rows[0]["NET_AMNT"].ToString().Replace(",", "").Trim();

                    if (_dtData.Rows[0]["NET_AMNT"].ToString().Replace(",", "").Trim() == "0")
                        dr["DUE_DATE"] = "0";
                    else
                        dr["DUE_DATE"] = _dtData.Rows[0]["DUE_DATE"].ToString();
                }
                else
                {
                    dr["NET_AMNT"] = "0";
                    dr["DUE_DATE"] = "0";
                }
            }
            else if (_dtData.Rows[0]["NET_AMNT"].ToString() == "")
            {
                dr["NET_AMNT"] = "0";
                dr["DUE_DATE"] = "0";
            }
            else
            {
                dr["NET_AMNT"] = "0";
                dr["DUE_DATE"] = "0";
            }

            //dr["DUE_DATE"] = _dtData.Rows[0]["DUE_DATE"].ToString();
            dr["BILL_MONTH"] = ".";
            dr["TOT_UNITS_BILLED"] = ".";
            dr["BILL_BASIS"] = _dtData.Rows[0]["BILL_BASIS"].ToString();
            dr["SANC_LOAD"] = _dtData.Rows[0]["SANCTIONED_LOAD"].ToString();
            dr["RATE_CATEGORY"] = _dtData.Rows[0]["Rate_Cat"].ToString();
            dr["CONT_DEMAND"] = "0";
            dr["TOT_ENRGY_CHRG"] = "0";
            dr["TOT_ENE_CHRG_AMD"] = "0";
            dr["TOT_ENE_CHG_AMDA"] = "0";
            dr["TOT_FIX_CHRG"] = "0";
            dr["TOT_FIX_CHRG_AMD"] = "0";
            dr["TOT_FIX_CHG_AMDA"] = "0";
            dr["ELECT_TAX"] = "0";
            dr["ELECT_TAX_AMNDS"] = "0";
            dr["ELECT_TAX_AMDA"] = "0";
            dr["REBATE"] = "0";
            dr["REBATE_AMNDS"] = "0";
            dr["REBATE_AMNDTAM"] = "0";
            dr["RATE_SUBSIDY"] = "0";
            dr["RATE_SUBSIDY_AMD"] = "0";
            dr["RATE_SBSIDY_AMDA"] = "0";
            dr["SPL_SUBSIDY"] = "0";
            dr["SPL_SUBSIDY_AMN"] = "0";
            dr["SPL_SBSIDY_AMDA"] = "0";
            dr["OTHER_CHRGS"] = "0";
            dr["OTHER_CHRGS_AMND"] = "0";
            dr["OTHER_CHRGS_AMDA"] = "0";
            dr["LPSC_CURRENT"] = "0";
            dr["CUR_MTH_BILL_AMT"] = "0";
            dr["CUR_MTH_BILL_AMD"] = "0";
            dr["CUR_MTH_BIL_AMDA"] = "0";
            dr["ARR_PAYABLE"] = "0";
            dr["ARR_PAYABLE_AMD"] = "0";
            dr["ARR_PAYABLE_AMDA"] = "0";
            dr["ARR_ENRGY_CHRG"] = "0";
            dr["ARR_ELECT_TAX"] = "0";
            dr["ARR_OTHER_CHRGS"] = "0";
            dr["ARR_LPSC"] = "0";
            dr["AR_LAST_MTH_BILL"] = "0";
            dr["REFUND"] = "0";
            dr["DEFERRED_AMNT"] = "0";
            dr["INST_NOT_DUE"] = "0";
            dr["PYMT_RECD_AMNT"] = "0";
            dr["ARREARS_PAYABLE"] = "0";
            dr["AMEN_PERIOD_FRM"] = "0";
            dr["AMEN_PERIOD_TO"] = "0";
            dr["AMD_REASON"] = ".";
            dr["TOT_ORIG_AMNT"] = "0";
            dr["TOT_AMND_AMNT"] = "0";
            dr["UNITS_1"] = "0";
            dr["UNITS_2"] = "0";
            dr["UNITS_3"] = "0";
            dr["UNITS_4"] = "0";
            dr["UNITS_5"] = "0";
            dr["UNITS_6"] = "0";
            dr["AMNT_AFT_DUE_DAT"] = "0";
            dr["PYMT_ACCNTD_UPTO"] = "0";
            dr["SEC_DEP_AMNT"] = "0";
            dr["TARIFF"] = "0";
            dr["METER_TYPE"] = ".";
            dr["COMPANY_CODE"] = _dtData.Rows[0]["COMPANY_CODE"].ToString();
            dr["LASTNAME"] = ".";
            dr["MIDDLE_NAME"] = ".";
            dr["FATHER_NAME"] = ".";
            dr["STREET"] = _dtData.Rows[0]["STREET"].ToString();
            dr["STR_SUPPL1"] = ".";
            dr["STR_SUPPL2"] = ".";
            dr["STR_SUPPL3"] = ".";
            dr["POSTL_COD1"] = ".";
            dr["ADJUSTMENT"] = ".";
            dr["PAYMENT_RECEIVED"] = "0";
            dr["PAYMENT_DATE"] = "0";
            dr["TOT_BIL_AMT"] = "0";
            dr["TOT_BIL_AMNDS"] = "0";
            dr["TOT_BIL_AMDTAM"] = "0";
            dr["MDI"] = "0";
            dr["MOB_NO"] = _dtData.Rows[0]["Tel1_Number"].ToString();
            dr["EMAIL"] = _dtData.Rows[0]["E_Mail"].ToString();

            billDetailsTable1.Rows.Add(dr);
            billDetailsTable1.AcceptChanges();

            DataTable meterDetailsTable1 = new DataTable();
            meterDetailsTable1.Columns.Add("Meter_No", typeof(string));
            meterDetailsTable1.Columns.Add("Mf_Factor", typeof(string));
            meterDetailsTable1.Columns.Add("Pre_Mr_Date", typeof(string));
            meterDetailsTable1.Columns.Add("Curr_Mr_Date", typeof(string));
            meterDetailsTable1.Columns.Add("Prev_Mr_Kwh", typeof(string));
            meterDetailsTable1.Columns.Add("Curr_Mr_Kwh", typeof(string));
            meterDetailsTable1.Columns.Add("Unit_Consum_Kwh", typeof(string));
            meterDetailsTable1.Columns.Add("Prev_Mr_Kvah", typeof(string));
            meterDetailsTable1.Columns.Add("Curr_Mr_Kvah", typeof(string));
            meterDetailsTable1.Columns.Add("Unit_Consum_Kvah", typeof(string));
            meterDetailsTable1.Columns.Add("Prev_Mr_Kw", typeof(string));
            meterDetailsTable1.Columns.Add("Curr_Mr_Kw", typeof(string));
            meterDetailsTable1.Columns.Add("Unit_Consum_Kw", typeof(string));
            meterDetailsTable1.Columns.Add("Prev_Mr_Kva", typeof(string));
            meterDetailsTable1.Columns.Add("Curr_Mr_Kva", typeof(string));
            meterDetailsTable1.Columns.Add("Unit_Consum_Kva", typeof(string));

            DataRow dr1;
            dr1 = meterDetailsTable1.NewRow();
            dr1["Meter_No"] = "0";
            dr1["Mf_Factor"] = "0";
            dr1["Pre_Mr_Date"] = "0";
            dr1["Curr_Mr_Date"] = "0";
            dr1["Prev_Mr_Kwh"] = "0";
            dr1["Curr_Mr_Kwh"] = "0";
            dr1["Unit_Consum_Kwh"] = "0";
            dr1["Prev_Mr_Kvah"] = "0";
            dr1["Curr_Mr_Kvah"] = "0";
            dr1["Unit_Consum_Kvah"] = "0";
            dr1["Prev_Mr_Kw"] = "0";
            dr1["Curr_Mr_Kw"] = "0";
            dr1["Unit_Consum_Kw"] = "0";
            dr1["Prev_Mr_Kva"] = "0";
            dr1["Curr_Mr_Kva"] = "0";
            dr1["Unit_Consum_Kva"] = "0";

            meterDetailsTable1.Rows.Add(dr1);
            meterDetailsTable1.AcceptChanges();

            Ds.Tables.Add(billDetailsTable1);
            Ds.Tables.Add(meterDetailsTable1);

            Ds.Tables[0].TableName = "billDetailsTable";
            Ds.Tables[1].TableName = "meterDetailsTable";

            Ds.DataSetName = "BAPI_RESULT";

            // Ds.Merge(billDetailsTable.Copy());

        }

        return Ds;
    }

    public DataTable GetCAWise_SDKInfo(string _sCaNumber)
    {

        DataTable _dt = new DataTable();
        string _sSql = string.Empty;
        if (_sCaNumber.Length == 9)
            _sCaNumber = "000" + _sCaNumber;
        else if (_sCaNumber.Length == 10)
            _sCaNumber = "00" + _sCaNumber;
        else if (_sCaNumber.Length == 11)
            _sCaNumber = "0" + _sCaNumber;

        _sSql = " select S.MOBILE_NO Tel1_Number, EMAIL E_Mail,substr(AMOUNT,4)AMOUNT,'BRPL'COMPANY_CODE ";
        _sSql += " from pcm.CONSUMER_SAP_MASTER S, MOBAPP.BRPL_BILL_MASTER M where S.CONTRACT_ACCOUNT='000'||M.CA_NUMBER and S.CONTRACT_ACCOUNT='" + _sCaNumber + "' ";
        _sSql += " order by m.SMS_GEN_DATE desc  ";

        _dt = dmlgetquery(_sSql);

        if (_dt.Rows.Count == 0)
        {
            _sSql = "  select  TELEPHONE_NUMBER Tel1_Number,EMAIL E_Mail,AMOUNT,COMPANY_CODE ";
            _sSql += " from admin.payment_mobile_data  S, ADMIN.BYPL_BILL_MASTER M where S.CONTRACT_ACCOUNT='000'||M.CA_NUMBER  AND S.CONTRACT_ACCOUNT='" + _sCaNumber + "'  ";
            _sSql += "  order by m.SMS_GEN_DATE desc ";

            _dt = dmlgetquery(_sSql);

            if (_dt.Rows.Count == 0)
            {
                _sSql = " select  S.MOBILE_NO Tel1_Number,'' E_Mail,substr(AMOUNT,4) AMOUNT, SAP_COMPANY COMPANY_CODE";
                _sSql += " from rcmpa.sap_formy_vws S, MOBAPP.BRPL_BILL_MASTER M where S.CONS_REF='000'||M.CA_NUMBER(+)  AND S.CONS_REF='" + _sCaNumber + "'  ";
                _sSql += " order by m.SMS_GEN_DATE desc  ";

                _dt = dmlgetquery(_sSql);
            }
        }


        return _dt;
    }

    [WebMethod]
    public string BSES_SDK_PAYMENT(string strCANumber)
    {
        string _sResult = string.Empty;
        string _sTelNo = string.Empty, _sEmail = string.Empty, _sAmt = string.Empty, _sCompCode = string.Empty;



        DataTable _dtData = new DataTable();
        _dtData = GetCAWise_SDKInfo(strCANumber);

        if (_dtData.Rows.Count > 0)
        {
            if (_dtData.Rows[0]["Tel1_Number"] != null)
                _sTelNo = _dtData.Rows[0]["Tel1_Number"].ToString();
            else
                _sTelNo = "";

            if (_dtData.Rows[0]["E_Mail"] != null)
                _sEmail = _dtData.Rows[0]["E_Mail"].ToString();
            else
                _sEmail = "";

            if (_dtData.Rows[0]["AMOUNT"] != null)
            {
                _sAmt = _dtData.Rows[0]["AMOUNT"].ToString().Replace(",", "").Trim();
                if (_sAmt.ToString().Trim() == "")
                    _sAmt = "0";
            }
            else
                _sAmt = "0";

            if (_dtData.Rows[0]["COMPANY_CODE"] != null)
                _sCompCode = _dtData.Rows[0]["COMPANY_CODE"].ToString();
            else
                _sCompCode = "";

            _sResult = _sTelNo + "|" + _sEmail + "|" + _sAmt + "|" + _sCompCode;
        }
        else
        {
            _sResult = "n|n|n|n";
        }

        return _sResult;

    }

    [WebMethod]
    public DataSet ZBAPI_CA_OUTSTANDING_AMT(string strCANumber)
    {
        DataSet dsBAPIOutput = obj.get_ZFI_CURR_OUTS_FLAG(strCANumber);

        return dsBAPIOutput;
    }

    [WebMethod]
    public DataSet ZBAPI_LAST_MODE_PAY(string CA, string FLAG)
    {
        DataSet Ds = obj.Get_ZBAPI_LAST_MODE_PAY(CA, FLAG);
        return Ds;
    }

    [WebMethod]
    public DataSet BAPI_MTRREADDOC_GETLIST(string METERNO)//By Babalu Kumar
    {
        string KWH = string.Empty;
        string KW = string.Empty;
        string KVAH = string.Empty;
        string KVA = string.Empty;
        string Readdate = string.Empty;
        string MeterNo = string.Empty;
        DataSet Ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn column = new DataColumn();
        dt.Columns.Add("Device", typeof(string));
        dt.Columns.Add("BillDate", typeof(string));
        dt.Columns.Add("KWH", typeof(string));
        dt.Columns.Add("KW", typeof(string));
        dt.Columns.Add("KVAH", typeof(string));
        dt.Columns.Add("KVA", typeof(string));
        try
        {
            DataSet ds = obj.Get_BAPI_MTRREADDOC_GETLIST(METERNO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtnew = SelectDistinct(ds.Tables[0], "MRDATEFORBILLING");
                DataRow dr;
                for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                {
                    KWH = "NA";
                    KW = "NA";
                    KVAH = "NA";
                    KVA = "NA";
                    MeterNo = ds.Tables[0].Rows[i]["DEVICE"].ToString();
                    Readdate = dtnew.Rows[i]["MRDATEFORBILLING"].ToString();
                    dr = dt.NewRow();
                    DataRow[] result = ds.Tables[0].Select("MRDATEFORBILLING ='" + dtnew.Rows[i]["MRDATEFORBILLING"].ToString() + "'");
                    foreach (DataRow row in result)
                    {
                        if (row[3].ToString() == "001")
                        {
                            KWH = row[13].ToString();

                        }
                        else if (row[3].ToString() == "002")
                        {
                            KW = row[13].ToString();
                        }
                        else if (row[3].ToString() == "003")
                        {
                            KVAH = row[13].ToString();
                        }
                        else if (row[3].ToString() == "004")
                        {
                            KVA = row[13].ToString();
                        }
                    }
                    dr["Device"] = MeterNo;
                    dr["BillDate"] = Readdate;
                    dr["KWH"] = KWH;
                    dr["KW"] = KW;
                    dr["KVAH"] = KVAH;
                    dr["KVA"] = KVA;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                Ds.Tables.Add(dt);
            }
            else
            {
                dt.Rows.Add("Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again");
                Ds.Tables.Add(dt);
            }
            return Ds;
        }
        catch (Exception ex)
        {
            dt.Rows.Add(ex.Message.ToString(), "", "", "", "", "");
            Ds.Tables.Add(dt);
            return Ds;
        }
    }

    private bool ColumnEqual(object A, object B)
    {
        if (A == DBNull.Value && B == DBNull.Value)
            return true;
        if (A == DBNull.Value || B == DBNull.Value)
            return false;
        return (A.Equals(B));
    }
    public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
    {
        DataTable dt = new DataTable(SourceTable.TableName);
        dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
        object LastValue = null;
        foreach (DataRow dr in SourceTable.Select("", FieldName))
        {
            if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
            {
                LastValue = dr[FieldName];
                dt.Rows.Add(new object[] { LastValue });
            }
        }
        return dt;
    }

    [WebMethod]
    public DataSet ZBAPI_FETCH_ENF_USER_DET(string CA_NUMBER) //Added By Babalu Kumar 14082020
    {
        DataTable dt = new DataTable();
        DataColumn column = new DataColumn();
        dt.Columns.Add("CASE_ID", typeof(string));
        dt.Columns.Add("COMPLAINT_ID", typeof(string));
        dt.Columns.Add("INSPECTION_DATE", typeof(string));
        dt.Columns.Add("INSP_CA_NUMBER", typeof(string));
        dt.Columns.Add("USER_NAME", typeof(string));
        dt.Columns.Add("HOUSEFLATNO", typeof(string));
        dt.Columns.Add("BUILDING_NAME1", typeof(string));
        dt.Columns.Add("STREET1", typeof(string));
        dt.Columns.Add("COLONY_AREA1", typeof(string));
        dt.Columns.Add("LANDMARK", typeof(string));
        dt.Columns.Add("CITY_CODE1", typeof(string));
        dt.Columns.Add("PIN_CODE1", typeof(string));
        dt.Columns.Add("CASE_TYPE", typeof(string));
        dt.Columns.Add("ENF_ORDER", typeof(string));
        dt.Columns.Add("ENF_CA", typeof(string));
        dt.Columns.Add("SOURCE_OF_COMPLA", typeof(string));
        dt.Columns.Add("COKEY", typeof(string));
        dt.Columns.Add("SUB_DIV", typeof(string));
        DataSet Ds = obj.Get_ZBAPI_FETCH_ENF_USER_DET(CA_NUMBER);
        if (Ds.Tables[0].Rows.Count > 0)
        {
            Ds.Tables.Add(dt);
            Ds.Tables.Remove("Table2");
            Ds.Tables.Remove("messageTable");
            dt.AcceptChanges();
        }
        else
        {
            Ds.Tables.Remove("Table1");
            Ds.Tables.Remove("messageTable");
            dt.TableName = "Table1";
            dt.Rows.Add("Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again",
                "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again",
                "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again", "Data not available try again",
                "Data not available try again", "Data not available try again", "Data not available try again");
            Ds.Tables.Add(dt);
            dt.AcceptChanges();

        }
        return Ds;
    }

    [WebMethod]
    public DataSet ZBAPI_BILL_DET(string CA_NUMBER)
    {
        DataSet dsCAInfo = new DataSet();
        DataTable dt = new DataTable();
        string _sCircle = string.Empty, _sDivision = string.Empty, _sCompany = string.Empty, _sName = string.Empty;
        string _sSerReqDateTime = System.DateTime.Now.ToString();
        string _sSerReqOutDateTime = string.Empty;

        DelhiWSV2.WebService obj1 = new DelhiWSV2.WebService();
        dsCAInfo = new DataSet();
        dsCAInfo = obj1.ZBAPI_DISPLAY_BILL_WEB(CA_NUMBER.Length == 9 ? "000" + CA_NUMBER : CA_NUMBER, "");
        if (dsCAInfo.Tables[0].Rows.Count > 0)
        {
            dt = new DataTable();
            dt = dsCAInfo.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //CA_NUMBER = CA_NUMBER.ToString().Substring(3, 9);
                _sName = Convert.ToString(dt.Rows[0]["FIRSTNAME"]) + " " + Convert.ToString(dt.Rows[0]["MIDDLE_NAME"]) + " " + Convert.ToString(dt.Rows[0]["LASTNAME"]);
                _sCircle = Convert.ToString(dt.Rows[0]["CIRCLE_DESCR"]);
                _sDivision = Convert.ToString(dt.Rows[0]["UNIT_DESCR"]);
                _sCompany = Convert.ToString(dt.Rows[0]["COMPANY_CODE"]);

                Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, "", "");
            }
        }

        DataSet Ds = obj.Get_ZBAPI_BILL_DET(CA_NUMBER);
        Insert_Service_Log(CA_NUMBER, null, _sName, _sCircle, _sDivision, _sCompany, "", "");

        return Ds;
    }

    private void Insert_Service_Log(string _sCA_No, string _sReqInDateTime, string Name, string Circle, string Division, string CompName, string MobileNo,
                                   string ResponseData)
    {
        string _sSql = string.Empty;
        string _sReqInTime = string.Empty;
        if (_sReqInDateTime != null)
            _sReqInTime = _sReqInDateTime;
        else
            _sReqInDateTime = null;

        if (_sReqInDateTime != null)
        {
            // System.DateTime.Now.ToString("dd/MM/yyyy hh:m:ss")
            _sReqInDateTime = Convert.ToDateTime(_sReqInDateTime).ToString("dd/MM/yyyy hh:m:ss");
        }

        if (_sReqInDateTime != null)
        {
            _sSql = "INSERT INTO mobapp.BRPL_SERVICE_LOG_DT(CA_NUMBER,SERVICE_TYPE,CONS_NAME,CIRCLE,DIVISION,COMPANY_NAME,MOBILE_NO,REQ_SERVICE_INDATE,REQ_SERVICE_OUTDATE,RESPONSE) VALUES ";
            _sSql += " ('" + _sCA_No + "','BILLEXPLAIN-WHATSAPP','" + Name + "','" + Circle + "','" + Division + "','" + CompName + "','" + MobileNo + "',TO_DATE('" + _sReqInDateTime + "','DD/MM/YYYY HH24:MI:SS'),sysdate,'" + ResponseData + "')";


            //_sSql = "INSERT INTO mobapp.BRPL_SERVICE_LOG_DT(CA_NUMBER,SERVICE_TYPE,CONS_NAME,CIRCLE,DIVISION,COMPANY_NAME,MOBILE_NO,REQ_SERVICE_INDATE,REQ_SERVICE_OUTDATE,RESPONSE) VALUES ";
            //_sSql += " ('" + _sCA_No + "','BILLEXPLAIN-WHATSAPP','" + Name + "','" + Circle + "','" + Division + "','" + CompName + "','" + MobileNo + "',sysdate,null,'" + ResponseData + "')";
        }
        //else
        //{
        //    _sSql = "INSERT INTO mobapp.BRPL_SERVICE_LOG_DT(CA_NUMBER,SERVICE_TYPE,CONS_NAME,CIRCLE,DIVISION,COMPANY_NAME,MOBILE_NO,REQ_SERVICE_INDATE,REQ_SERVICE_OUTDATE,RESPONSE) VALUES ";
        //    _sSql += " ('" + _sCA_No + "','BILLEXPLAIN-WHATSAPP','" + Name + "','" + Circle + "','" + Division + "','" + CompName + "','" + MobileNo + "',null,sysdate,'" + ResponseData + "')";
        //}

        dmlsinglequery(_sSql);
    }
    public bool dmlsinglequery(string sql)
    {
        OleDbCommand dbcommand;
        OleDbTransaction dbtrans;
        NDS objNDS = new NDS();
        OleDbConnection ocon = new OleDbConnection(objNDS.con());
        try
        {
            if (ocon.State == ConnectionState.Closed)
            {
                ocon.Open();
            }

            dbcommand = new OleDbCommand(sql, ocon);
            //dbcommand.Transaction = dbtrans;
            dbcommand.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            if (ocon.State == ConnectionState.Open)
            {
                ocon.Close();
                ocon.Dispose();
            }
        }
    }

    [WebMethod]
    public DataSet ZBAPI_BILL_DET_API(string CA_NUMBER)
    {
        DataSet dsCAInfo = new DataSet();
        DataTable dt = new DataTable();
        string _sCircle = string.Empty, _sDivision = string.Empty, _sCompany = string.Empty, _sName = string.Empty;
        string _sSerReqDateTime = System.DateTime.Now.ToString();
        string _sSerReqOutDateTime = string.Empty;

        DelhiWSV2.WebService obj1 = new DelhiWSV2.WebService();
        dsCAInfo = new DataSet();
        dsCAInfo = obj1.ZBAPI_DISPLAY_BILL_WEB(CA_NUMBER.Length == 9 ? "000" + CA_NUMBER : CA_NUMBER, "");
        if (dsCAInfo.Tables[0].Rows.Count > 0)
        {
            dt = new DataTable();
            dt = dsCAInfo.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //CA_NUMBER = CA_NUMBER.ToString().Substring(3, 9);
                _sName = Convert.ToString(dt.Rows[0]["FIRSTNAME"]) + " " + Convert.ToString(dt.Rows[0]["MIDDLE_NAME"]) + " " + Convert.ToString(dt.Rows[0]["LASTNAME"]);
                _sCircle = Convert.ToString(dt.Rows[0]["CIRCLE_DESCR"]);
                _sDivision = Convert.ToString(dt.Rows[0]["UNIT_DESCR"]);
                _sCompany = Convert.ToString(dt.Rows[0]["COMPANY_CODE"]);

                Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, "", "");
            }
        }

        string str = "";
        DataSet ds = obj.Get_ZBAPI_BILL_DET(CA_NUMBER);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            str += ds.Tables[0].Rows[i][0].ToString().Trim() + Environment.NewLine;
        }

        Insert_Service_Log(CA_NUMBER, null, _sName, _sCircle, _sDivision, _sCompany, "", "");

        DataTable dtOutPut = new DataTable();
        DataColumn column = new DataColumn();
        dtOutPut.Columns.Add("OUT_PUT", typeof(string));
        dtOutPut.Rows.Add(str);
        ds.Tables.Add(dtOutPut);
        dtOutPut.AcceptChanges();

        return ds;
    }

    [WebMethod]
    public DataSet ZBAPI_BILL_DET_API_PDF(string CA_NUMBER, string _sMobileNo)
    {
        DataSet dsCAInfo = new DataSet();
        DataTable dt = new DataTable();
        string _sCircle = string.Empty, _sDivision = string.Empty, _sCompany = string.Empty, _sName = string.Empty;
        string _sSerReqDateTime = System.DateTime.Now.ToString();
        string _sSerReqOutDateTime = string.Empty;
        string str = "";

        DelhiWSV2.WebService obj1 = new DelhiWSV2.WebService();
        dsCAInfo = new DataSet();
        dsCAInfo = obj1.ZBAPI_DISPLAY_BILL_WEB(CA_NUMBER.Length == 9 ? "000" + CA_NUMBER : CA_NUMBER, "");
        if (dsCAInfo.Tables[0].Rows.Count > 0)
        {
            dt = new DataTable();
            dt = dsCAInfo.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //CA_NUMBER = CA_NUMBER.ToString().Substring(3, 9);
                _sName = Convert.ToString(dt.Rows[0]["FIRSTNAME"]) + " " + Convert.ToString(dt.Rows[0]["MIDDLE_NAME"]) + " " + Convert.ToString(dt.Rows[0]["LASTNAME"]);
                _sCircle = Convert.ToString(dt.Rows[0]["CIRCLE_DESCR"]);
                _sDivision = Convert.ToString(dt.Rows[0]["UNIT_DESCR"]);
                _sCompany = Convert.ToString(dt.Rows[0]["COMPANY_CODE"]);

                // Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, _sMobileNo, "");
                // 

                if (_sCompany.Trim() == "BRPL")
                {
                    str = "http://125.22.84.50:7850/DelhiV2/BillPDF_DTAPI.aspx?CA_NO=" + CA_NUMBER;
                    Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, _sMobileNo, str);
                }
                else
                {
                    str = "Details not available for CA No. " + CA_NUMBER + " .Please call us at 19123 (Toll-Free) or write to us at brpl.customercare@relianceada.com. Thank you.";
                    Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, _sMobileNo, str);
                }

            }
        }
        else
        {

            str = "Details not available for CA No. " + CA_NUMBER + " .Please call us at 19123 (Toll-Free) or write to us at brpl.customercare@relianceada.com. Thank you.";
            Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, _sMobileNo, str);
        }


        DataSet ds = new DataSet();
        DataTable dtOutPut = new DataTable();
        DataColumn column = new DataColumn();
        dtOutPut.Columns.Add("OUT_PUT", typeof(string));
        dtOutPut.Rows.Add(str);
        ds.Tables.Add(dtOutPut);
        dtOutPut.AcceptChanges();

        return ds;
    }

    [WebMethod]
    public DataSet ZBAPI_BILL_DET_64(string CA_NUMBER)
    {
        DataSet dsCAInfo = new DataSet();
        DataTable dt = new DataTable();
        string _sCircle = string.Empty, _sDivision = string.Empty, _sCompany = string.Empty, _sName = string.Empty;
        string _sSerReqDateTime = System.DateTime.Now.ToString();
        string _sSerReqOutDateTime = string.Empty;

        DelhiWSV2.WebService obj1 = new DelhiWSV2.WebService();
        dsCAInfo = new DataSet();
        dsCAInfo = obj1.ZBAPI_DISPLAY_BILL_WEB(CA_NUMBER.Length == 9 ? "000" + CA_NUMBER : CA_NUMBER, "");
        if (dsCAInfo.Tables[0].Rows.Count > 0)
        {
            dt = new DataTable();
            dt = dsCAInfo.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //CA_NUMBER = CA_NUMBER.ToString().Substring(3, 9);
                _sName = Convert.ToString(dt.Rows[0]["FIRSTNAME"]) + " " + Convert.ToString(dt.Rows[0]["MIDDLE_NAME"]) + " " + Convert.ToString(dt.Rows[0]["LASTNAME"]);
                _sCircle = Convert.ToString(dt.Rows[0]["CIRCLE_DESCR"]);
                _sDivision = Convert.ToString(dt.Rows[0]["UNIT_DESCR"]);
                _sCompany = Convert.ToString(dt.Rows[0]["COMPANY_CODE"]);

                Insert_Service_Log(CA_NUMBER, _sSerReqDateTime, _sName, _sCircle, _sDivision, _sCompany, "", "");
            }
        }

        DataSet Ds = obj.Get_ZBAPI_BILL_DET_64(CA_NUMBER);
        Insert_Service_Log(CA_NUMBER, null, _sName, _sCircle, _sDivision, _sCompany, "", "");

        return Ds;
    }

    [WebMethod]
    public DataSet ZBAPI_STREET_DET_UPD(string COMPANY, string CANUMBER, string DATA_PROCESS_DATE, string STLWATT, string NO_OF_POINT, string INSTALLATION_DATE, string MOVEOUT_DATE, string ACTIVATION, string DEACTIVATION, string REQUESTID, string REQUEST_DATE, string DOCUMENT_UPLOADED)//By Babalu Kumar
    {
        DataSet Ds = obj.Get_ZBAPI_STREET_DET_UPD(COMPANY, CANUMBER, DATA_PROCESS_DATE, STLWATT, NO_OF_POINT, INSTALLATION_DATE, MOVEOUT_DATE, ACTIVATION, DEACTIVATION, REQUESTID, REQUEST_DATE, DOCUMENT_UPLOADED);
        return Ds;
    }

    [WebMethod]
    public DataTable HES_GETLATESTBALANCE(string _sConsumerID, string _sMeterID)
    {
        DataSet dsCAInfo = new DataSet();
        DataTable dt = new DataTable();
        DataColumn column = new DataColumn();
        dt.Columns.Add("ErrorCode", typeof(string));
        dt.Columns.Add("Balance", typeof(string));
        dt.Columns.Add("MeterReading", typeof(string));
        dt.Columns.Add("MeterRTC", typeof(string));
        dt.Columns.Add("LastRechargeAmount", typeof(string));
        dt.Columns.Add("LastRechargeAmountDateTime", typeof(string));
        dt.Columns.Add("MeterID", typeof(string));

        string _sErrorCode = string.Empty, _sBalance = string.Empty, _sMeterReading = string.Empty;
        string _sMeterRTC = string.Empty, _sLastRechargeAmount = string.Empty, _sLastRechargeAmountDateTime = string.Empty, _sMeter_ID = string.Empty;

        HESWebReference.Service1 obj = new HESWebReference.Service1();
        HESWebReference.ConsumerLatestBalance objSer = new HESWebReference.ConsumerLatestBalance();
        objSer = obj.GetLatestBalance(_sConsumerID, _sMeterID);

        if (objSer.ErrorCode != null)
            _sErrorCode = objSer.ErrorCode;
        if (objSer.Balance != null)
            _sBalance = objSer.Balance.ToString();
        if (objSer.MeterReading != null)
            _sMeterReading = objSer.MeterReading.ToString();
        if (objSer.MeterRTC != null)
            _sMeterRTC = objSer.MeterRTC;
        if (objSer.LastRechargeAmount != null)
            _sLastRechargeAmount = objSer.LastRechargeAmount.ToString();
        if (objSer.LastRechargeAmountDateTime != null)
            _sLastRechargeAmountDateTime = objSer.LastRechargeAmountDateTime;
        if (objSer.MeterID != null)
            _sMeter_ID = objSer.MeterID;

        dt.TableName = "Table1";
        dt.Rows.Add(_sErrorCode, _sBalance, _sMeterReading, _sMeterRTC, _sLastRechargeAmount, _sLastRechargeAmountDateTime, _sMeter_ID);


        dt.AcceptChanges();

        return dt;
    }

    [WebMethod]
    public DataSet ZBAPI_ZBI_PREPAID_MTR(string CA_NUMBER)
    {
        DataSet ds = obj.Get_ZBI_PREPAID_MTR(CA_NUMBER);
        return ds;
    }

    [WebMethod]
    public DataTable ZBI_WEBBILL_HIST(string CA_NUMBER)
    {
        DataTable dt = new DataTable();
        DelhiWSV2.WebService obj = new DelhiWSV2.WebService();
        dt = obj.ZBI_WEBBILL_HIST(CA_NUMBER, "").Tables[0];
        return dt;
    }

    //[WebMethod]
    //public DataTable Z_BAPI_DSS_ISU_CA_DISPLAY(string CA_NUMBER)
    //{
    //    DataTable dt = new DataTable();
    //    DelhiWSV2.WebService obj = new DelhiWSV2.WebService();
    //    dt = obj.Z_BAPI_DSS_ISU_CA_DISPLAY(CA_NUMBER, "").Tables[0];
    //    return dt;
    //}

    #region By Babalu Kumar 07072021
    [WebMethod]
    public DataSet ZBAPI_ONLINE_BILL_PDF(string strCANumber, string strEBSKNO) 
    {
        DataSet Ds = obj.Get_ZBAPI_ONLINE_BILL_PDF(strCANumber, strEBSKNO);
        return Ds;
    }

    [WebMethod]
    public DataSet ZBAPI_DISPLAY_BILL_WEB_SAP(string strCANumber, string strBillMonth)
    {
        DataSet Ds = obj.Get_ZBAPI_DISPLAY_BILL_WEB(strCANumber, strBillMonth);
        return Ds;
    }

    //[WebMethod]
    //public DataSet ZBAPIDOCLIST(string strAufnr, string strC_001, string strC_002, string strC_003, string strC_004, string strC_005, string strC_007, string strC_008, string strC_009, string strC_010, string strC_011, string strC_012, string strC_013, string strC_014, string strC_015, string strC_016, string strC_017, string strC_018, string strC_019, string strC_020, string strC_021, string strC_022, string strC_023, string strC_024, string strC_025, string strC_026, string strC_027, string strC_028, string strC_029, string strC_030, string strC_031, string strC_032, string strC_033, string strC_034, string strC_035, string strC_036, string strC_037, string strC_038, string strC_039, string strC_040, string strC_041, string strC_070, string strR_Cdll, string strR_Occ, string strR_Own, string strZ_Appltype)
    //{
    //    DataSet Ds = obj.Get_ZBAPIDOCLIST(strAufnr, strC_001.ToUpper(), strC_002.ToUpper(), strC_003.ToUpper(), strC_004.ToUpper(), strC_005.ToUpper(), strC_007.ToUpper(), strC_008.ToUpper(), strC_009.ToUpper(), strC_010.ToUpper(),
    //     strC_011.ToUpper(), strC_012.ToUpper(), strC_013.ToUpper(), strC_014.ToUpper(), strC_015.ToUpper(), strC_016.ToUpper(), strC_017.ToUpper(), strC_018.ToUpper(), strC_019.ToUpper(), strC_020.ToUpper(), strC_021.ToUpper(), strC_022.ToUpper(),
    //     strC_023.ToUpper(), strC_024.ToUpper(), strC_025.ToUpper(), strC_026.ToUpper(), strC_027.ToUpper(), strC_028.ToUpper(), strC_029.ToUpper(), strC_030.ToUpper(), strC_031.ToUpper(), strC_032.ToUpper(), strC_033.ToUpper(), strC_034.ToUpper(),
    //     strC_035.ToUpper(), strC_036.ToUpper(), strC_037.ToUpper(), strC_038.ToUpper(), strC_039.ToUpper(), strC_040.ToUpper(), strC_041.ToUpper(), strC_070.ToUpper(), strR_Cdll.ToUpper(), strR_Occ.ToUpper(), strR_Own.ToUpper(), strZ_Appltype.ToUpper());
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_IVR_CREATESO_ISU(string strCANumber, string strCACrn, string strCAKNumber, string strMeterNumber, string strISUOrder, string strComplaintType, string strContractNumber, string strTelephoneNo, string strDescription)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_IVR_CREATESO_ISU(strCANumber, strCACrn, strCAKNumber, strMeterNumber, strISUOrder, strComplaintType, strContractNumber, strTelephoneNo, strDescription);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet Z_BAPI_CMS_ISU_CA_DISPLAY_ISU(string strCANumber, string strSerialNumber, string strConsumerNumber, string strTelephoneNumber, string strKNumber, string strContractNumber)
    //{
    //    DataSet Ds = obj.Get_Z_BAPI_CMS_ISU_CA_DISPLAY(strCANumber, strSerialNumber, strConsumerNumber, strTelephoneNumber, strKNumber, strContractNumber);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CREATESO_POST(string strPMAufart, string strPlanPlant, string strRegioGroup, string strShortText, string strILA, string strMFText, string strUserFieldCH20, string StrControkey, string strSerialNumber, string strComplaintGroup, string strCANumber, string strContract, string strMFText1)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_CREATESO_POST(strPMAufart, strPlanPlant, strRegioGroup, strShortText, strILA, strMFText, strUserFieldCH20, StrControkey,
    //                                                            strSerialNumber, strComplaintGroup, strCANumber, strContract, strMFText1);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CALERT(string strCompanyCode, string strDate, string strDivision, string strUnit)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_CALERT(strCompanyCode, strDate, strDivision, strUnit);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_DSS_SO(string PARTNERCATEGORY, string PARTNERTYPE, string TITLE_KEY, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string FATHERSNAME, string HOUSE_NO, string BUILDING, string STR_SUPPL1, string STR_SUPPL2, string STR_SUPPL3, string POSTL_COD1, string CITY, string E_MAIL, string LANDLINE, string MOBILE, string FEMALE, string MALE, string JOBGR, string LEGITTYPE, string IDNUMBER, string ORDER_TYPE, string SHORTTEXT, string PLANNINGPLANT, string WORKCENTRE, string SYSTEMCOND, string PMACTIVITYTYPE, string REQUESTNUM, string NNUMBER, string APPLIEDCAT, string APPLIEDLOAD, string CONNECTIONTYPE, string ORDERID, string FLAG)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_DSS_SO(PARTNERCATEGORY, PARTNERTYPE, TITLE_KEY, FIRSTNAME, LASTNAME, MIDDLENAME,
    //                             FATHERSNAME, HOUSE_NO, BUILDING, STR_SUPPL1, STR_SUPPL2, STR_SUPPL3, POSTL_COD1,
    //                             CITY, E_MAIL, LANDLINE, MOBILE, FEMALE, MALE, JOBGR, LEGITTYPE,
    //                             IDNUMBER, ORDER_TYPE, SHORTTEXT, PLANNINGPLANT, WORKCENTRE, SYSTEMCOND,
    //                             PMACTIVITYTYPE, REQUESTNUM, NNUMBER, APPLIEDCAT, APPLIEDLOAD, CONNECTIONTYPE,
    //                             ORDERID, FLAG);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_DSS_SO_ECC(string PARTNERCATEGORY, string PARTNERTYPE, string TITLE_KEY, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string FATHERSNAME, string HOUSE_NO, string BUILDING, string STR_SUPPL1, string STR_SUPPL2, string STR_SUPPL3, string POSTL_COD1, string CITY, string E_MAIL, string LANDLINE, string MOBILE, string FEMALE, string MALE, string JOBGR, string IDTYPE, string IDNUMBER, string ORDER_TYPE, string SHORTTEXT, string PLANNINGPLANT, string WORKCENTRE, string SYSTEMCOND, string PMACTIVITYTYPE, string REQUESTNUM, string NNUMBER, string APPLIEDCAT, string APPLIEDLOAD, string CONNECTIONTYPE, string ORDERID, string FLAG)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_DSS_SO_ECC(PARTNERCATEGORY, PARTNERTYPE, TITLE_KEY, FIRSTNAME, LASTNAME, MIDDLENAME,
    //                             FATHERSNAME, HOUSE_NO, BUILDING, STR_SUPPL1, STR_SUPPL2, STR_SUPPL3, POSTL_COD1,
    //                             CITY, E_MAIL, LANDLINE, MOBILE, FEMALE, MALE, JOBGR, IDTYPE,
    //                             IDNUMBER, ORDER_TYPE, SHORTTEXT, PLANNINGPLANT, WORKCENTRE, SYSTEMCOND,
    //                             PMACTIVITYTYPE, REQUESTNUM, NNUMBER, APPLIEDCAT, APPLIEDLOAD, CONNECTIONTYPE,
    //                             ORDERID, FLAG);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet Z_BAPI_ZDSS_WEB_LINK(string I_ILART, string I_VKONT, string I_VKONA, string PARTNERCATEGORY, string PARTNERTYPE, string TITLE_KEY, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string FATHERSNAME, string HOUSE_NO, string BUILDING, string STR_SUPPL1, string STR_SUPPL2, string STR_SUPPL3, string POSTL_COD1, string CITY, string E_MAIL, string LANDLINE, string MOBILE, string FEMALE, string MALE, string JOBGR, string IDTYPE, string IDNUMBER, string PLANNINGPLANT, string WORKCENTRE, string SYSTEMCOND, string APPLIEDCAT, string APPLIEDLOAD, string APPLIEDLOADKVA, string CONNECTIONTYPE, string STATEMENT_CA, string START_DATE, string START_TIME, string FINISH_DATE, string FINISH_TIME, string SORTFIELD, string ABKRS)
    //{
    //    DataSet Ds = obj.Get_Z_BAPI_ZDSS_WEB_LINK(I_ILART, I_VKONT, I_VKONA, PARTNERCATEGORY, PARTNERTYPE, TITLE_KEY, FIRSTNAME,
    //                                 LASTNAME, MIDDLENAME, FATHERSNAME, HOUSE_NO, BUILDING, STR_SUPPL1, STR_SUPPL2,
    //                                 STR_SUPPL3, POSTL_COD1, CITY, E_MAIL, LANDLINE, MOBILE, FEMALE, MALE,
    //                                 JOBGR, IDTYPE, IDNUMBER, PLANNINGPLANT, WORKCENTRE, SYSTEMCOND, APPLIEDCAT,
    //                                 APPLIEDLOAD, APPLIEDLOADKVA, CONNECTIONTYPE, STATEMENT_CA, START_DATE, START_TIME,
    //                                 FINISH_DATE, FINISH_TIME, SORTFIELD, ABKRS);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_ENFORCEMENT(string strCANumber, string strContract)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_ENFORCEMENT(strCANumber, strContract);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBI_WEBBILL_HIST(string strCANumber, string strBillMonth)
    //{
    //    DataSet Ds = obj.Get_ZBI_WEBBILL_HIST(strCANumber, strBillMonth);
    //    return Ds;
    //}

    [WebMethod]
    public DataSet Z_BAPI_IVRS(string strContractAccountNumber)
    {
        DataSet dsBAPIOutput = obj.Get_Z_BAPI_IVRS(strContractAccountNumber);
        return dsBAPIOutput;
    }

    [WebMethod]
    public DataSet Z_BAPI_DSS_ISU_CA_DISPLAY(string strCANumber, string strCRNNumber)
    {
        DataSet dsBAPIOutput = obj.Get_Z_BAPI_DSS_ISU_CA_DISPLAY(strCANumber, strCRNNumber);

        return dsBAPIOutput;
    }

    [WebMethod]
    public DataSet ZBAPI_CS_GET_KIT_DETAILS()
    {
        DataSet dsBAPIOutput = obj.Get_ZBAPI_CS_GET_KIT_DETAILS();
        return dsBAPIOutput;
    }

    //[WebMethod]
    //public DataSet ZBAPIEBIZORDSTATUS(string stOrderNumber)
    //{
    //    DataSet dsBAPIOutput = obj.Get_Z_BAPI_EBIZ_ORD_STATUS(stOrderNumber);

    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_UPDATE_TNO(string strCA_no, string strTelephone, string strMobile, string strEmail, string strLandmark, string strDISPATCH_CTRL)
    //{
    //    DataSet _dsBapiResult = obj.Get_ZBAPI_UPDATE_TNO(strCA_no, strTelephone, strMobile, strEmail, strLandmark, strDISPATCH_CTRL);
    //    return _dsBapiResult;
    //}

    //[WebMethod]
    //public DataSet Update_Dispatch_Control(string strCA_no, string strTelephone, string strMobile, string strEmail, string strLandmark, string strDISPATCH_CTRL)
    //{
    //    DataSet _dsBapiResult = obj.Get_Update_Dispatch_Control(strCA_no, strTelephone, strMobile, strEmail, strLandmark, strDISPATCH_CTRL);
    //    return _dsBapiResult;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_IDENTIFICATION(string strBP_NO, string strType_ID, string strID_Num)
    //{
    //    DataSet _dsBapiResult = obj.Get_ZBAPI_IDENTIFICATION(strBP_NO, strType_ID, strID_Num);
    //    return _dsBapiResult;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_ZCS_CLI_WEB(string strTelephoneNumber)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_ZCS_CLI_WEB(strTelephoneNumber);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_TEAM_ALLOCATION(string strIEMINumber, string strILART, string strDate, string strTime)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_TEAM_ALLOCATION(strIEMINumber, strILART, strDate, strTime);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_BI_EMAIL_COUNT(string strCRONAM, string strOBJTP, string strDateYYYYMMDD, string strTime)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_BI_EMAIL_COUNT(strCRONAM, strOBJTP, strDateYYYYMMDD, strTime);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_EDISTRICT(string strCANumber, string strCRNNumber)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_EDISTRICT(strCANumber, strCRNNumber);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet Z_BAPI_INPUT_CP_DETAILS(string New_Ca, string Old_Ca, string Theft_Type, string Zbilled_Ratcat, string Zbill_Days, string Zbill_Type, string Zcaseid, string Zcomp_Id, string Zconn_Load, string Zinsp_Date, string Zinsp_Mtrread, string Znew_Meterno, string Zold_Meterno, string Zphase, DataSet DsInputTable)
    //{
    //    DataSet dsBAPIOutput = obj.get_Z_BAPI_INPUT_CP_DETAILS(New_Ca, Old_Ca, Theft_Type, Zbilled_Ratcat, Zbill_Days, Zbill_Type, Zcaseid, Zcomp_Id, Zconn_Load, Zinsp_Date, Zinsp_Mtrread, Znew_Meterno, Zold_Meterno, Zphase, DsInputTable);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_DEMAND_NOTE_ONLINE(string strOrder)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_DEMAND_NOTE_ONLINE(strOrder);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_ISUACCOUNT_CHANGE(string strCONTRACT_ACCOUNT, string strPartner, string strValidDAte, string strCONTRACTACCOUNTDATA, string strCONTRACTACCOUNTDATAX)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_ISUACCOUNT_CHANGE(strCONTRACT_ACCOUNT, strPartner, strValidDAte, strCONTRACTACCOUNTDATA, strCONTRACTACCOUNTDATAX);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_FICA_DEMAND_NOTE(string strORDER_NO)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_FICA_DEMAND_NOTE(strORDER_NO);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CNT_APP_DETAIL_MOB(string strORDER_TYPE, string strDIVISION, string strAPPOINTMENT_START_DATE, string strAPPOINTMENT_TIME, string strREC_COUNT)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_CNT_APP_DETAIL_MOB(strORDER_TYPE, strDIVISION, strAPPOINTMENT_START_DATE, strAPPOINTMENT_TIME, strREC_COUNT);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_STATUS163(string strVKONT)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_STATUS163(strVKONT);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_DFKKOP_PUSH(string strZAUFNR, string strZBUKRS, string strZVKONT, string strZBETRW, string strZTRAN_ID, string strZTRAN_DT, string strFLAG, string strPay_Type, string strPay_Method)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_DFKKOP_PUSH(strZAUFNR, strZBUKRS, strZVKONT, strZBETRW, strZTRAN_ID, strZTRAN_DT, strFLAG, strPay_Type, strPay_Method);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_DISPLAY_BILL_WEB_EXT(string strCA_Number, string strBillMmonth)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_DISPLAY_BILL_WEB_EXT(strCA_Number, strBillMmonth);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CS_ORD_STAT(string strAufnr)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_CS_ORD_STAT(strAufnr);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CS_MOBILE_APPCNT(string strMobileNO, string strPM_Activity, string strPriod, string strVAPLZ)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_CS_MOBILE_APPCNT(strMobileNO, strPM_Activity, strPriod, strVAPLZ);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBI_BAPI_CA_DUES_NIC(string strCA_number)
    //{
    //    if (strCA_number.Length != 12)
    //        strCA_number = strCA_number.PadLeft(12, '0');
    //    DataSet dsBAPIOutput = obj.get_ZBI_BAPI_CA_DUES_NIC(strCA_number);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CS_NIC_UPDT_DET(string strPARTNER, string strNAME_FIRST, string strNAMEMIDDLE, string strNAME_LAST, string strNAME_LST2, string strNAME_ORG1, string strNAME_ORG2, string strNAME_ORG3, string strNAME_ORG4, string strTEL_NUMBER, string strSMTP_ADDR)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_CS_NIC_UPDT_DET(strPARTNER, strNAME_FIRST, strNAMEMIDDLE, strNAME_LAST, strNAME_LST2, strNAME_ORG1, strNAME_ORG2, strNAME_ORG3, strNAME_ORG4, strTEL_NUMBER, strSMTP_ADDR);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_PREPAID_RTGS(string strCOMP_CODE, string strCONTRACT_ACCOUNT, string strACCOUNT_TYPE, string strAMOUNT, string strFLAG)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_PREPAID_RTGS(strCOMP_CODE, strCONTRACT_ACCOUNT, strACCOUNT_TYPE, strAMOUNT, strFLAG);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_PREPAID_RTGS_Common(string strCOMP_CODE, string strCONTRACT_ACCOUNT, string strACCOUNT_TYPE, string strAMOUNT, string strFLAG)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_PREPAID_RTGS_Common(strCOMP_CODE, strCONTRACT_ACCOUNT, strACCOUNT_TYPE, strAMOUNT, strFLAG);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_FICA_PREPAID_MTR(string strDOC_ID, string strTRANS_ID, string strCA, string strCOMPANY, string strCONSUMER_TYPE, string strMETER_MANFR, string strCONTRACT, string strCA_VALID_ISU, string strENTRY_DATE, string strS_ENC_TKN_1, string strS_ENC_TKN_2, string strS_ENC_TKN_3, string strS_ENC_TKN_4, string strGENUS_RESP_CODE, string strMETER_NO, string strACC_CLASS, string strAMNT_BANK, string strAMNT_ISU, string strADDRESS, string strTARIFTYP, string strTARIFID, string strPAY_METHOD)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_FICA_PREPAID_MTR(strDOC_ID, strTRANS_ID, strCA, strCOMPANY, strCONSUMER_TYPE, strMETER_MANFR, strCONTRACT, strCA_VALID_ISU, strENTRY_DATE, strS_ENC_TKN_1, strS_ENC_TKN_2, strS_ENC_TKN_3, strS_ENC_TKN_4, strGENUS_RESP_CODE, strMETER_NO, strACC_CLASS, strAMNT_BANK, strAMNT_ISU, strADDRESS, strTARIFTYP, strTARIFID, strPAY_METHOD);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_MDI_USER_CON(string strVKONT)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_MDI_USER_CON(strVKONT);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_MDI_RES_ORDER(string strVKONT)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_MDI_RES_ORDER(strVKONT);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CS_FETCH_LOAD(string strINORDERNO, string strINBUSINESSPART, string strINCONTRACTACCNT, string strINMETERNUM)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_CS_FETCH_LOAD(strINORDERNO, strINBUSINESSPART, strINCONTRACTACCNT, strINMETERNUM);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_FICA_ENF_CONS(string strCOMPANY_CODE, string strCONTRACT_ACCOUNT)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_FICA_ENF_CONS(strCOMPANY_CODE, strCONTRACT_ACCOUNT);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_MSO_POST_DET(string strCA_Number)
    //{
    //    DataSet Ds = obj.get_ZBAPI_MSO_POST_DET(strCA_Number);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_FETCH_ENFCA(string strBPNo)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_FETCH_ENFCA(strBPNo);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet BAPI_ZBAPI_BI_NOC(string strCA)
    //{
    //    DataSet Ds = obj.Get_BAPI_ZBAPI_BI_NOC(strCA);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_REAPPOINT_FETCH(string strOrderNo)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_REAPPOINT_FETCH(strOrderNo);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_ADD_IDENTIFICATION(string IV_CONTRACT_ACCOUNT, string IV_PARTNER_GUID, string IV_IDENTIFICATIONCATEGORY, string IV_IDENTIFICATIONNUMBER, string IV_X_SAVE, string IV_IDENTIFICATIONTYPE)//By Babalu Kumar
    //{
    //    DataSet Ds = obj.Get_ZBAPI_ADD_IDENTIFICATION(IV_CONTRACT_ACCOUNT, IV_PARTNER_GUID, IV_IDENTIFICATIONCATEGORY, IV_IDENTIFICATIONNUMBER, IV_X_SAVE, IV_IDENTIFICATIONTYPE);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet Z_BI_BAPI_SMART_MTR_DTL(string strIn_Run_Date, string strInCompany, string strInManuf)
    //{
    //    DataSet Ds = obj.get_Z_BI_BAPI_SMART_MTR_DTL(strIn_Run_Date, strInCompany, strInManuf);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet Z_BI_BAPI_SMART_MTR_UPDT(string strCANumber, string strOPBEL, string strReturnCode)
    //{
    //    DataSet Ds = obj.get_Z_BI_BAPI_SMART_MTR_UPDT(strCANumber, strOPBEL, strReturnCode);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_CREATE_ORDER_WIFI(string strPARTNERCATEGORY, string strPARTNERTYPE, string strTITLE_KEY, string strFIRSTNAME, string strLASTNAME, string strMIDDLENAME, string strFATHERSNAME, string strHOUSE_NO, string strBUILDING, string strSTR_SUPPL1, string strSTR_SUPPL2, string strSTR_SUPPL3, string strPOSTL_COD1, string strCITY, string strE_MAIL, string strLANDLINE, string strMOBILE, string strFEMALE, string strMALE, string strJOBGR, string strIDTYPE, string strIDNUMBER,
    //    string strI_VKONT, string strI_ILART, string strI_VAPLZ,
    //    string strPLANNINGPLANT, string strWORKCENTRE, string strSYSTEMCOND, string strAPPLIEDCAT, string strAPPLIEDLOAD, string strAPPLIEDLOADKVA, string strCONNECTIONTYPE, string strSTATEMENT_CA, string strSTART_DATE, string strSTART_TIME, string strFINISH_DATE, string strFINISH_TIME, string strSORTFIELD, string strABKRS)
    //{
    //    DataSet Ds = obj.get_ZBAPI_CREATE_ORDER_WIFI(strPARTNERCATEGORY, strPARTNERTYPE, strTITLE_KEY, strFIRSTNAME, strLASTNAME, strMIDDLENAME, strFATHERSNAME, strHOUSE_NO, strBUILDING, strSTR_SUPPL1, strSTR_SUPPL2, strSTR_SUPPL3, strPOSTL_COD1, strCITY, strE_MAIL, strLANDLINE, strMOBILE, strFEMALE, strMALE, strJOBGR, strIDTYPE, strIDNUMBER,
    //    strI_VKONT, strI_ILART, strI_VAPLZ,
    //    strPLANNINGPLANT, strWORKCENTRE, strSYSTEMCOND, strAPPLIEDCAT, strAPPLIEDLOAD, strAPPLIEDLOADKVA, strCONNECTIONTYPE, strSTATEMENT_CA, strSTART_DATE, strSTART_TIME, strFINISH_DATE, strFINISH_TIME, strSORTFIELD, strABKRS);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZCSUPDAT_PERSONAL_DETAILS(string strPARTNER, string strNAME_FIRST, string strNAMEMIDDLE, string strNAME_LAST, string strNAME_LST2, string strSTR_SUPPL1, string strSTR_SUPPL2, string strHOUSE_NUM1, string strSTREET, string strSTR_SUPPL3, string strTEL_NUMBER, string strSMTP_ADDR, string strFAX_NUMBER)
    //{
    //    DataSet Ds = obj.get_ZCSUPDAT_PERSONAL_DETAILS(strPARTNER, strNAME_FIRST, strNAMEMIDDLE, strNAME_LAST, strNAME_LST2, strSTR_SUPPL1, strSTR_SUPPL2, strHOUSE_NUM1, strSTREET, strSTR_SUPPL3, strTEL_NUMBER, strSMTP_ADDR, strFAX_NUMBER);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet Z_BAPI_CA_DISPLAY_WHATSAPP(string strCA_NUMBER, string strCONTRACT, string strSERIALNO, string strIMPORT_CRNNUMBER, string strIMPORT_TELEPHONE_NO, string strIMPORT_KNUMBER)
    //{
    //    DataSet Ds = obj.get_Z_BAPI_CA_DISPLAY_WHATSAPP(strCA_NUMBER, strCONTRACT, strSERIALNO, strIMPORT_CRNNUMBER, strIMPORT_TELEPHONE_NO, strIMPORT_KNUMBER);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_EXEMPT_MOBILE(string strMobileNo)
    //{
    //    DataSet Ds = obj.get_ZBAPI_EXEMPT_MOBILE(strMobileNo);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_USTATUS(string strAufnr, string strTXT_04)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_USTATUS(strAufnr, strTXT_04);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet Z_BAPI_ZDSS_WEB_LINK_NIC(string I_ILART, string I_VKONT, string I_VKONA, string PARTNERCATEGORY, string PARTNERTYPE, string TITLE_KEY, string FIRSTNAME, string LASTNAME, string MIDDLENAME, string FATHERSNAME, string HOUSE_NO, string BUILDING, string STR_SUPPL1, string STR_SUPPL2, string STR_SUPPL3, string POSTL_COD1, string CITY, string E_MAIL, string LANDLINE, string MOBILE, string FEMALE, string MALE, string JOBGR, string IDTYPE, string IDNUMBER, string PLANNINGPLANT, string WORKCENTRE, string SYSTEMCOND, string APPLIEDCAT, string APPLIEDLOAD, string APPLIEDLOADKVA, string CONNECTIONTYPE, string STATEMENT_CA, string START_DATE, string START_TIME, string FINISH_DATE, string FINISH_TIME, string SORTFIELD, string ABKRS)
    //{
    //    DataSet Ds = obj.Get_Z_BAPI_ZDSS_WEB_LINK_NIC(I_ILART, I_VKONT, I_VKONA, PARTNERCATEGORY, PARTNERTYPE, TITLE_KEY, FIRSTNAME,
    //                                 LASTNAME, MIDDLENAME, FATHERSNAME, HOUSE_NO, BUILDING, STR_SUPPL1, STR_SUPPL2,
    //                                 STR_SUPPL3, POSTL_COD1, CITY, E_MAIL, LANDLINE, MOBILE, FEMALE, MALE,
    //                                 JOBGR, IDTYPE, IDNUMBER, PLANNINGPLANT, WORKCENTRE, SYSTEMCOND, APPLIEDCAT,
    //                                 APPLIEDLOAD, APPLIEDLOADKVA, CONNECTIONTYPE, STATEMENT_CA, START_DATE, START_TIME,
    //                                 FINISH_DATE, FINISH_TIME, SORTFIELD, ABKRS);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet Z_BI_BAPI_ONLINE_BILL(string strCANumber, string strInvoiceNo)
    //{
    //    DataSet Ds = obj.get_Z_BI_BAPI_ONLINE_BILL(strCANumber, strInvoiceNo);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_SMARTMTR_TBL(string COMPCODE, DateTime rundate, string newcon, string masterdata)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_SMARTMTR_TBL(COMPCODE, rundate, newcon, masterdata);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_SMARTMTR_upd(string COMPCODE, DateTime rundate, string flag, string contract, string meterno)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_SMARTMTR_upd_New(COMPCODE, rundate, flag, contract, meterno);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_WHATSAPP_INTEGRATION(string strOrderID, string strIFlag)
    //{
    //    DataSet Ds = obj.get_ZBAPI_WHATSAPP_INTEGRATION(strOrderID, strIFlag);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_DUNNING_NOTICE_WHATSAPP(string strBUKRS, string strVKONT)
    //{
    //    DataSet Ds = obj.get_ZBAPI_DUNNING_NOTICE_WHATSAPP(strBUKRS, strVKONT);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_WHATSAPP_STATUS(string strOrd_Date, string strCom_Code, string strIFlag)
    //{
    //    DataSet Ds = obj.get_ZBAPI_WHATSAPP_STATUS(strOrd_Date, strCom_Code, strIFlag);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_SMARTMTR_TBL_BYPL(string COMPCODE, string rundate, string newcon, string masterdata)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_SMARTMTR_TBL_BYPL(COMPCODE, rundate, newcon, masterdata);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_FICA_DEMAND_DUE_DATE(string strORDER_NO)
    //{
    //    DataSet dsBAPIOutput = obj.get_ZBAPI_FICA_DEMAND_DUE_DATE(strORDER_NO);
    //    return dsBAPIOutput;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_ZCAL_HIGH_AVG_MDI(string CA_NUMBER, string AppDate, string AppLoad)
    //{
    //    DataSet ds = obj.Get_ZCAL_HIGHEST_AVG_MDI(CA_NUMBER, AppDate, AppLoad);
    //    return ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_IDENTIFY_DUES(string CA_NUMBER)
    //{
    //    DataSet ds = obj.Get_ZBAPI_IDENTIFY_DUES(CA_NUMBER);
    //    return ds;
    //}

    //[WebMethod]
    //public DataSet ZBAPI_ELNOTICE_WHATSAPP(string CompanyCode, string CANumber)
    //{
    //    DataSet Ds = obj.Get_ZBAPI_ELNOTICE_WHATSAPP(CompanyCode, CANumber);
    //    return Ds;
    //}

    //[WebMethod]
    //public DataTable KYS(string CANO)//By Sajid Ali
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(CANO))
    //            dt = DAL.getCAWISESCHEDULEa(CANO);
    //    }
    //    catch (Exception exx)
    //    {

    //    }
    //    return dt;
    //}
    #endregion
}
