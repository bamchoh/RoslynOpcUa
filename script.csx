using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpcUa;

void OpcUaRead(OpcUaClient opcua, string[] variables)
{
    var values = opcua.Read(variables);

    foreach (var key in values.Keys)
    {
        var dataValue = values[key];
        Console.WriteLine(string.Format("{0} - {1} - {2} - {3} - {4}",
            key,
            dataValue.StatusCode,
            dataValue.WrappedValue.TypeInfo,
            dataValue.ServerTimestamp,
            dataValue.Value));
    }
}

var var01 = "ns=2;s=Scalar_Static_Boolean";
var var02 = "ns=2;s=Scalar_Static_SByte";
var var03 = "ns=2;s=Scalar_Static_Int16";
var var04 = "ns=2;s=Scalar_Static_Int32";
var var05 = "ns=2;s=Scalar_Static_Int64";
var var06 = "ns=2;s=Scalar_Static_Byte";
var var07 = "ns=2;s=Scalar_Static_UInt16";
var var08 = "ns=2;s=Scalar_Static_UInt32";
var var09 = "ns=2;s=Scalar_Static_UInt64";
var var10 = "ns=2;s=Scalar_Static_Double";
var var11 = "ns=2;s=Scalar_Static_Float";
var var12 = "ns=2;s=Scalar_Static_String";

var variables = new string[] {
    var01,
    var02,
    var03,
    var04,
    var05,
    var06,
    var07,
    var08,
    var09,
    var10,
    var11,
    var12,
};

var opcua = new OpcUaClient(@"C:\Users\bamch\source\repos\RoslynOpcUa\Opc.Ua.Client.Roslyn.Config.xml");

opcua.Open("opc.tcp://localhost:62541/Quickstarts/ReferenceServer", true);

opcua.Write(new Dictionary<string, object> {
  { var01, true },
  { var02, (SByte)(-123) },
  { var03, (Int16)(-12345) },
  { var04, (Int32)(-1234567890) },
  { var05, (Int64)(-12345678901234) },
  { var06, (Byte)254 },
  { var07, (UInt16)65534 },
  { var08, (UInt32)4294967294 },
  { var09, (UInt64)12345678901234 },
  { var10, (Single)(-1.234) },
  { var11, (Double)(-2.3456789) },
  { var12, "abcdefghijklmnopqrstuvwxyz" },
});

OpcUaRead(opcua, variables);

opcua.Write(new Dictionary<string, object> {
  { var01, false },
  { var02, (SByte)(123) },
  { var03, (Int16)(12345) },
  { var04, (Int32)(1234567890) },
  { var05, (Int64)(12345678901234) },
  { var06, (Byte)123 },
  { var07, (UInt16)12345 },
  { var08, (UInt32)1234567890 },
  { var09, (UInt64)2345678901 },
  { var10, (Single)(1.234) },
  { var11, (Double)(2.3456789) },
  { var12, "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
});

OpcUaRead(opcua, variables);

opcua.Close();
