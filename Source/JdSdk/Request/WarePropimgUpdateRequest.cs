#region head comment
/*
Code generate by JdSdkTool.
2013-06-03 12:29:13.28788 +08:00
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
    /// 通过api 根据商品Id，销售属性值Id设置图片 Request
    /// </summary>
    public class WarePropimgUpdateRequest : JdRequestBase<WarePropimgUpdateResponse>
    {
        /// <summary>
        /// 商品的id
        /// </summary>
        /// <example>1100000015</example>
        [XmlElement("ware_id")]
        [JsonProperty("ware_id")]
        public Int64 WareId
        {
            get;
            set;
        }

        /// <summary>
        /// 属性值Id(颜色值Id)
        /// </summary>
        /// <example>12345</example>
        [XmlElement("attribute_value_id")]
        [JsonProperty("attribute_value_id")]
        public String AttributeValueId
        {
            get;
            set;
        }

        /// <summary>
        /// 是否把当前图片设置为主图
        /// </summary>
        /// <example>true</example>
        [XmlElement("is_main_pic")]
        [JsonProperty("is_main_pic")]
        public Nullable<Boolean> IsMainPic
        {
            get;
            set;
        }

        /// <summary>
        /// 图片Id
        /// </summary>
        [XmlElement("image_id")]
        [JsonProperty("image_id")]
        public String ImageId
        {
            get;
            set;
        }

        public override String ApiName
        {
            get { return "360buy.ware.propimg.update"; }
        }

        protected override void PrepareParam(IDictionary<String, Object> paramters)
        {

            paramters.Add("ware_id", this.WareId);
            paramters.Add("attribute_value_id", this.AttributeValueId);
            paramters.Add("is_main_pic", this.IsMainPic);
            paramters.Add("image_id", this.ImageId);

        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("ware_id", this.WareId);
            RequestValidator.ValidateRequired("attribute_value_id", this.AttributeValueId);
            RequestValidator.ValidateRequired("image_id", this.ImageId);
        }

    }
}
