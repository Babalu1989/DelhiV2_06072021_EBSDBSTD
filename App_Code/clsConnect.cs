using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;
using System.Configuration;

/// <summary>
/// Summary description for clsConnect
/// </summary>
public class clsConnect : IDestinationConfiguration
{
    public bool ChangeEventsSupported()
    {
        return false;
    }

    public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

    public RfcConfigParameters GetParameters(string destinationName)
    {

        RfcConfigParameters parms = new RfcConfigParameters();
        try
        {
            if (destinationName.Equals("mySAPdestination"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "10.8.54.176");
                parms.Add(RfcConfigParameters.SystemNumber, "01");
                parms.Add(RfcConfigParameters.SystemID, "UP3");
                parms.Add(RfcConfigParameters.User, "sys_iss");
                parms.Add(RfcConfigParameters.Password, "123456");
                parms.Add(RfcConfigParameters.Client, "100");
                parms.Add(RfcConfigParameters.Language, "en");
            }
            else if (destinationName.Equals("mySAPdestination1"))
            {
                //parms.Add(RfcConfigParameters.AppServerHost, "10.8.55.219");
                //parms.Add(RfcConfigParameters.SystemNumber, "01");
                //parms.Add(RfcConfigParameters.SystemID, "01");
                //parms.Add(RfcConfigParameters.User, "sys_iss");
                //parms.Add(RfcConfigParameters.Password, "123456");
                //parms.Add(RfcConfigParameters.Client, "102");
                //parms.Add(RfcConfigParameters.User, "sys_web");
                //parms.Add(RfcConfigParameters.Password, "123456");
                //parms.Add(RfcConfigParameters.Client, "100");
                //parms.Add(RfcConfigParameters.Language, "en");
                parms.Add(RfcConfigParameters.AppServerHost, "10.8.55.219");
                parms.Add(RfcConfigParameters.MessageServerHost, "10.8.55.219");
                parms.Add(RfcConfigParameters.MessageServerService, "sapmsP92,3601");
                parms.Add(RfcConfigParameters.SystemID, "P92");
                parms.Add(RfcConfigParameters.User, "sys_iss");
                parms.Add(RfcConfigParameters.Password, "123456");
                parms.Add(RfcConfigParameters.Client, "100");
                parms.Add(RfcConfigParameters.Language, "EN");
                parms.Add(RfcConfigParameters.LogonGroup, "P92REL");
                parms.Add(RfcConfigParameters.Trace, "False");
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, "1500");
            }
           else if (destinationName.Equals("P92"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "10.8.55.219");
                parms.Add(RfcConfigParameters.MessageServerHost, "10.8.55.219");
                parms.Add(RfcConfigParameters.MessageServerService, "sapmsP92,3601");
                parms.Add(RfcConfigParameters.SystemID, "P92");
                parms.Add(RfcConfigParameters.User, "sys_iss");
                parms.Add(RfcConfigParameters.Password, "123456");
                parms.Add(RfcConfigParameters.Client, "100");
                parms.Add(RfcConfigParameters.Language, "EN");
                parms.Add(RfcConfigParameters.LogonGroup, "P92REL");
                parms.Add(RfcConfigParameters.Trace, "False");
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, "1500");
            }
            else if(destinationName.Equals("mySAPdestination3"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "10.8.55.219");
                parms.Add(RfcConfigParameters.MessageServerHost, "10.8.55.219");
                parms.Add(RfcConfigParameters.MessageServerService, "sapmsP92,3601");
                parms.Add(RfcConfigParameters.SystemID, "P92");
                parms.Add(RfcConfigParameters.User, "sys_web");
                parms.Add(RfcConfigParameters.Password, "123456");
                parms.Add(RfcConfigParameters.Client, "100");
                parms.Add(RfcConfigParameters.Language, "EN");
                parms.Add(RfcConfigParameters.LogonGroup, "P92REL");
                parms.Add(RfcConfigParameters.Trace, "False");
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, "1500");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return parms;

    }
}