#region head comment
/*
Code generate by JdSdkTool.
2013-08-02 16:22:53.71965 +08:00
*/
#endregion

using System.Xml.Serialization;
using JdSdk.Domain;
using Newtonsoft.Json;

namespace JdSdk.Response
{
    /// <summary>
    /// 查询月账单明细 Response
    /// </summary>
    public class JingdongKuaicheBillDetailsSearchResponse : JdResponse
    {
        /// <summary>
        /// 结算明细集合
        /// </summary>
        [XmlElement("list")]
        [JsonProperty("list")]
        public BillDetailVO[] List
        {
            get;
            set;
        }

    }
}
