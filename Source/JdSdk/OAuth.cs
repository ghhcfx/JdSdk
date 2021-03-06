#region CopyRight
/**************************************************************
   Copyright (c) 2012 StarPeng. All rights reserved.
   CLR版本        :    4.0.30319.269
   命名空间名称   :    JdSdk
   文件名         :    OAuth
   创建时间       :    2012/6/19 17:18:34
   用户所在的域   :    SWKEJIT410
   登录用户名     :    Star
   文件描述       :    
   版本           :    1.0.0
   历史           :    
   最后更新人     :   
   最后更新时间   :   
 **************************************************************/
#endregion CopyRight

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace JdSdk
{
    public class OAuth
    {
        //private const string LoginUrl = "http://auth.360buy.com/login.do";
        private string authorizeUrl = "http://auth.360buy.com/oauth/authorize";
        private string accessTokenUrl = "http://auth.360buy.com/oauth/token";

        /// <summary>
        /// 授权码获取地址
        /// </summary>
        public String AuthorizeUrl
        {
            get
            {
                return authorizeUrl;
            }

            set
            {
                authorizeUrl = value;
            }
        }

        /// <summary>
        /// 访问令牌获取
        /// </summary>
        public String AccessTokenUrl
        {
            get
            {
                return accessTokenUrl;
            }
            set
            {
                accessTokenUrl = value;
            }
        }

        /// <summary>
        /// 获取App Key
        /// </summary>
        public string AppKey
        {
            get;
            internal set;
        }
        /// <summary>
        /// 获取App Secret
        /// </summary>
        public string AppSecret
        {
            get;
            internal set;
        }

        /// <summary>
        /// 获取Access Token
        /// </summary>
        public string AccessToken
        {
            get;
            internal set;
        }

        /// <summary>
        /// 获取或设置回调地址
        /// </summary>
        public string CallbackUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Refresh Token 似乎目前没用
        /// </summary>
        public string RefreshToken
        {
            get;
            internal set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="callbackUrl"></param>
        public OAuth(string appKey, string appSecret, string callbackUrl = "http://jos.mylifeon.net/OAuth/login")
        {
            this.AppKey = appKey;
            this.AppSecret = appSecret;
            this.AccessToken = string.Empty;
            this.CallbackUrl = callbackUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="refreshToken"></param>
        public OAuth(string appKey, string appSecret, string accessToken, string refreshToken = null)
        {
            this.AppKey = appKey;
            this.AppSecret = appSecret;
            this.AccessToken = accessToken;
            this.CallbackUrl = "http://jos.mylifeon.net/OAuth/login";
            this.RefreshToken = refreshToken ?? string.Empty;
        }

        /// <summary>
        /// 获取认证网页链接
        /// <para>B/S程序打开</para>
        /// </summary>
        /// <returns></returns>
        public String GetAuthorizationUrl()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("response_type", "code");
            parameters.Add("client_id", this.AppKey);
            parameters.Add("redirect_uri", this.CallbackUrl);
            parameters.Add("state", "AuthorizationCode");
            parameters.Add("scope", "read");

            var authorUrl = AuthorizeUrl;
            if (authorUrl.Contains("?"))
            {
                authorUrl = authorUrl + "&" + WebUtils.BuildQuery(parameters);
            }
            else
            {
                authorUrl = authorUrl + "?" + WebUtils.BuildQuery(parameters);
            }

            return authorUrl;
        }

        #region 停用代码
        /*
        public String GetAuthorizationCode(string passport, string password)
        {
            CookieContainer cookieContainer = new CookieContainer();
            var authorUrl = GetAuthorizationUrl();
            HttpWebRequest req = GetWebRequest(authorUrl, "GET");
            req.CookieContainer = cookieContainer;
            String loginRefUrl = "";
            using (HttpWebResponse rsp = (HttpWebResponse)req.GetResponse())
            {
                loginRefUrl = rsp.ResponseUri.OriginalString;
            }

            req.Abort();
            req = GetWebRequest(LOGIN_URL, "POST");
            req.CookieContainer = cookieContainer;
            req.Referer = loginRefUrl;

            Dictionary<string, string> loginParameters = new Dictionary<string, string>();
            loginParameters.Add("j_username", passport);
            loginParameters.Add("j_password", password);
            byte[] postData = Encoding.UTF8.GetBytes(WebUtils.BuildQuery(loginParameters));
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();
            }

            using (HttpWebResponse rsp = (HttpWebResponse)req.GetResponse())
            {
            }

            req = GetWebRequest(AUTHORIZE_URL, "POST");
            req.CookieContainer = cookieContainer;
            req.Referer = authorUrl;
            req.AllowAutoRedirect = false;
            String redirectUrl = String.Empty;
            postData = Encoding.UTF8.GetBytes("user_oauth_approval=true");
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();
            }

            using (HttpWebResponse rsp = (HttpWebResponse)req.GetResponse())
            {
                if (rsp.StatusCode == HttpStatusCode.Redirect)
                {
                    redirectUrl = rsp.Headers[HttpResponseHeader.Location];
                }
            }

            if (!String.IsNullOrEmpty(redirectUrl))
            {
                Uri uri = new Uri(redirectUrl);
                IDictionary<String, String> query = JdUtils.SplitUrlQuery(uri.Query.TrimStart('?'));
                return query["code"];
            }

            return null;
        }
        */
        #endregion

        /// <summary>
        /// 通过 Authorization Code 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public AccessToken GetAccessTokenByAuthorizationCode(string code)
        {
            return GetAccessToken(GrantType.AuthorizationCode, new Dictionary<string, string> { 
				{"code",code},
				{"redirect_uri", CallbackUrl}
			});
        }

        /// <summary>
        /// 根据登录帐号密码获取AccessToken
        /// <para>商家C/S程序获取方式请联系京东，本SDK不提供，请自行修改</para>
        /// </summary>
        /// <param name="passport"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AccessToken GetAccessTokenByPassword(string passport, string password)
        {
            if (String.IsNullOrEmpty(passport))
                throw new ArgumentException("不能为空", "passport");

            if (String.IsNullOrEmpty(password))
                throw new ArgumentException("不能为空", "password");

            return GetAccessToken(GrantType.Password, new Dictionary<string, string> { 
				{"username",passport},
				{"password", EncryptPassword(password)}
			});
        }

        /// <summary>
        /// 通过RefreshToken获取AccessToken
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public AccessToken GetAccessTokenByRefreshToken(string refreshToken)
        {
            return GetAccessToken(GrantType.RefreshToken, new Dictionary<string, string> { 
				{"refresh_token",refreshToken}
			});
        }

        private AccessToken GetAccessToken(GrantType type, Dictionary<string, string> parameters)
        {
            parameters.Add("client_id", AppKey);
            parameters.Add("client_secret", AppSecret);
            parameters.Add("scope", "read");
            parameters.Add("state", "swkeji");

            switch (type)
            {
                case GrantType.AuthorizationCode:
                    parameters.Add("grant_type", "authorization_code");
                    break;
                case GrantType.Password:
                    parameters.Add("grant_type", "password");
                    break;
                case GrantType.RefreshToken:
                    parameters.Add("grant_type", "refresh_token");
                    break;
            }

            WebUtils webUtil = new WebUtils();
            var response = DoAccessTokenPost(parameters);
            if (!string.IsNullOrEmpty(response))
            {
                AccessToken token = JsonConvert.DeserializeObject<AccessToken>(response);
                token.CreateTime = DateTime.Now;
                AccessToken = token.Token;
                return token;
            }
            else
            {
                return null;
            }
        }

        public string DoAccessTokenPost(IDictionary<string, string> parameters)
        {
            String url = AccessTokenUrl;
            if (url.Contains("?"))
            {
                url = url + "&" + WebUtils.BuildQuery(parameters);
            }
            else
            {
                url = url + "?" + WebUtils.BuildQuery(parameters);
            }

            HttpWebRequest req = GetWebRequest(url, "POST");
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.UTF8;

            if (!String.IsNullOrEmpty(rsp.ContentEncoding) || !String.IsNullOrEmpty(rsp.CharacterSet))
            {
                try
                {
                    if (!String.IsNullOrEmpty(rsp.ContentEncoding))
                    {
                        encoding = Encoding.GetEncoding(rsp.ContentEncoding);
                    }
                    else
                    {
                        encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    }
                }
                catch { }
            }

            return WebUtils.GetResponseAsString(rsp, encoding);
        }

        public HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = method;
            req.KeepAlive = true;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            return req;
        }

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        protected virtual String EncryptPassword(String password)
        {
            throw new NotImplementedException("密码加密方式请与京东联系，源码中不提供！可在派生类中重写本方法（EncryptPassword）实现！");
        }
    }
}



