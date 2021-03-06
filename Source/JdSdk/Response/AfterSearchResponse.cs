#region head comment
/*
Code generate by JdSdkTool.
2013-01-31 10:56:47:238 +08:00
*/
#endregion

using System.Xml.Serialization;
using JdSdk.Domain;
using Newtonsoft.Json;

namespace JdSdk.Response
{
    /// <summary>
    /// 根据条件检索订单信息 Response
    /// </summary>
    public class AfterSearchResponse : JdResponse
    {
        /// <summary>
        /// 退货信息
        /// </summary>
        [XmlElement("after")]
        [JsonProperty("after")]
        public AfterSearch After
        {
            get;
            set;
        }

    }
}
