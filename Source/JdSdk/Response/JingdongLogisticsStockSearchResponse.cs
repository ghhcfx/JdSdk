#region head comment
/*
Code generate by JdSdkTool.
2013-09-07 15:01:54.03466 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using JdSdk.Domain;

namespace JdSdk.Response
{
    /// <summary>
    /// 商家查询库存 Response
    /// </summary>
    public class JingdongLogisticsStockSearchResponse : JdResponse
    {
        /// <summary>
        /// 这个是注释生成doc用的
        /// </summary>
        [XmlElement("stock")]
        [JsonProperty("stock")]
        public ResponseStock Stock
        {
            get;
            set;
        }

    }
}