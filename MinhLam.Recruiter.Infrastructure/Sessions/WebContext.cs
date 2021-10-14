using System;
using System.Web;

namespace MinhLam.Recruiter.Infrastructure.Sessions
{
    public class WebContext : IWebContext
    {
        public Guid RCUserId
        {
            get
            {
                if (ContainsInSession("RCUserId"))
                {
                    return (Guid)GetFromSession("RCUserId");
                }

                return Guid.Empty;
            }
            set
            {
                SetInSession("RCUserId", value);
            }
        }

        public string RCEmail
        {
            get
            {
                if (ContainsInSession("RCEmail"))
                {
                    return (string)GetFromSession("RCEmail");
                }

                return string.Empty;
            }
            set
            {
                SetInSession("RCEmail", value);
            }
        }

        public string RCCompanyName 
        {
            get
            {
                if (ContainsInSession("RCCompanyName"))
                {
                    return (string)GetFromSession("RCCompanyName");
                }

                return string.Empty;
            }
            set
            {
                SetInSession("RCCompanyName", value);
            }
        }

        public bool RCJobFree 
        {
            get
            {
                if (ContainsInSession("RCJobFree"))
                {
                    return (bool)GetFromSession("RCJobFree");
                }

                return false;
            }
            set
            {
                SetInSession("RCJobFree", value);
            }
        }

        public bool RCActive 
        {
            get
            {
                if (ContainsInSession("RCActive"))
                {
                    return (bool)GetFromSession("RCActive");
                }

                return false;
            }
            set
            {
                SetInSession("RCActive", value);
            }
        }

        public bool RCRemember
        {
            get
            {
                if (ContainsInCookie("RCRemember"))
                {
                    var value = GetFromCookie("RCRemember");
                    if (value.ToLower() == "yes")
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var valueString = value == true ? "yes" : "no";
                SetInCookie("RCRemember", valueString);
            }
        }

        public string RCRememberEmail
        {
            get
            {
                if (ContainsInCookie("RCRememberEmail"))
                {
                    var value = GetFromCookie("RCRememberEmail");
                    return value;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                SetInCookie("RCRememberEmail", value);
            }
        }

        public string RCTime
        {
            get
            {
                if (ContainsInCookie("RCTime"))
                {
                    var value = GetFromCookie("RCTime");
                    return value;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                SetInCookie("RCTime", value);
            }
        }

        public int RCLoginAttempts { 
            get 
            {
                if (ContainsInSession("RCLoginAttempts"))
                {
                    return (int)GetFromSession("RCLoginAttempts");
                }

                return 0;
            } 
            set
            {
                SetInSession("RCLoginAttempts", value);
            }
        }

        public Guid JobId
        {
            get
            {
                string jobId = GetQueryStringValue("JobId");
                if (string.IsNullOrEmpty(jobId))
                {
                    return Guid.Empty;
                }

                return Guid.Parse(jobId);
            }
        }


        private void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        private bool ContainsInSession(string key)
        {
            return HttpContext.Current.Session[key] != null;
        }

        private bool ContainsInCookie(string key)
        {
            return HttpContext.Current.Request.Cookies[key] != null;
        }

        private void RemoveFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        private void RemoveFromCookie(string key)
        {
            HttpCookie deleteCookie = new HttpCookie(key);
            HttpContext.Current.Response.Cookies.Add(deleteCookie);
            deleteCookie.Expires = DateTime.Now.AddDays(-1);
        }

        private string GetQueryStringValue(string key)
        {
            return HttpContext.Current.Request.QueryString.Get(key);
        }

        private void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpContext.Current.Session[key] = value;
        }

        private void SetInCookie(string key, string value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Response == null)
            {
                return;
            }

            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddMonths(1);
        }

        private object GetFromSession(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key];
        }

        private string GetFromCookie(string key)
        {
            return HttpContext.Current.Request.Cookies[key].Value;
        }

        private void UpdateInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}
