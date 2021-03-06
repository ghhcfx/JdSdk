#region head comment
/*
Code generate by JdSdkTool.
2013-09-07 15:01:45.33616 +08:00
*/
#endregion

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using JdSdk.Domain;
using Newtonsoft.Json;

namespace JdSdk.Response
{
    /// <summary>
    /// 查询图片分类 Response
    /// </summary>
    public class JingdongImgzoneCategoryQueryResponse : JdResponse
    {
        /// <summary>
        /// 返回码：1，操作成功；0，操作失败
        /// </summary>
        [XmlElement("return_code")]
        [JsonProperty("return_code")]
        public Int64 ReturnCode
        {
            get;
            set;
        }

        /// <summary>
        /// 操作结果，返回码为1时为操作成功，返回码为0时为操作失败原因
        /// </summary>
        [XmlElement("desc")]
        [JsonProperty("desc")]
        public String Desc
        {
            get;
            set;
        }

        /// <summary>
        /// 分类List集合
        /// </summary>
        [XmlElement("cateList")]
        [JsonProperty("cateList")]
        public List<ImgzoneCategory> CateList
        {
            get;
            set;
        }

    }
}
