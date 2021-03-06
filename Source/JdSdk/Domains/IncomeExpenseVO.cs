#region head comment
/*
Code generate by JdSdkTool.
2013-08-02 16:22:56.15579 +08:00
*/
#endregion

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace JdSdk.Domain
{
    /// <summary>
    /// IncomeExpenseVO属性
    /// </summary>
    [Serializable]
    public class IncomeExpenseVO : JdObject
    {
        /// <summary>
        /// 流水单号
        /// </summary>
        [XmlElement("swift_number")]
        [JsonProperty("swift_number")]
        public Nullable<Decimal> SwiftNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        [XmlElement("creat_time")]
        [JsonProperty("creat_time")]
        public String CreatTime
        {
            get;
            set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        [XmlElement("amount")]
        [JsonProperty("amount")]
        public Nullable<Decimal> Amount
        {
            get;
            set;
        }

        /// <summary>
        /// 收支类型
        /// </summary>
        [XmlElement("in_out_type")]
        [JsonProperty("in_out_type")]
        public Nullable<Int64> InOutType
        {
            get;
            set;
        }

        /// <summary>
        /// 单据来源（计划ID）
        /// </summary>
        [XmlElement("order_from")]
        [JsonProperty("order_from")]
        public String OrderFrom
        {
            get;
            set;
        }

        /// <summary>
        /// 备注（计划名称，充值）
        /// </summary>
        [XmlElement("remark")]
        [JsonProperty("remark")]
        public String Remark
        {
            get;
            set;
        }

        /// <summary>
        /// 播放日期
        /// </summary>
        [XmlElement("show_date")]
        [JsonProperty("show_date")]
        public String ShowDate
        {
            get;
            set;
        }

    }
}
