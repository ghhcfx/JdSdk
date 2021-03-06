#region head comment
/*
Code generate by JdSdkTool.
2013-09-07 15:01:49.58540 +08:00
*/
#endregion

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using JdSdk.Response;
using Newtonsoft.Json;

namespace JdSdk.Request
{
    /// <summary>
    /// 创建搜索页推广 Request
    /// </summary>
    public class JingdongKuaicheZnPlanSearchCreateRequest : JdRequestBase<JingdongKuaicheZnPlanSearchCreateResponse>
    {
        /// <summary>
        /// 投放计划内容
        /// </summary>
        [XmlElement("plan_info")]
        [JsonProperty("plan_info")]
        public String PlanInfo
        {
            get;
            set;
        }

        public override String ApiName
        {
            get { return "jingdong.kuaiche.zn.plan.search.create"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {

            paramters.Add("plan_info", this.PlanInfo);

        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("plan_info", this.PlanInfo);
        }

    }
}
