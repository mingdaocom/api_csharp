using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK;
using Open.MingdaoSDK.Common;
using Open.MingdaoSDK.Entity;
using System.Collections.Specialized;

namespace Open.MingdaoSDK
{
    public class Account : MDAPIBase
    {
        public Account(Parameter u_key) : base(u_key) { }
        /// <summary>
        ///  获取当前登陆用户基本信息
        /// </summary>
        /// <returns></returns>
        public UserInfoModel GetUserInfo()
        {
            string Result = base.SyncRequest(TypeOption.MD_PASSPORT_DETAIL, null, null);
            if (!string.IsNullOrEmpty(Result))
            {
                return XmlSerializationHelper.XmlToObject<UserInfoModel>(Result);
            }
            return null;
        }
        /// <summary>
        /// 修改当前用户登陆信息
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="department">部门</param>
        /// <param name="job">职位</param>
        /// <param name="mobile_phone">移动电话</param>
        /// <param name="work_phone">工作电话</param>
        /// <param name="email">邮箱</param>
        /// <param name="birth">生日，format：yyyy-MM-dd</param>
        /// <param name="gender">性别： 1表示男性；2表示女性</param>
        /// <returns></returns>
        public string Edit(string name, string department, string job, string mobile_phone, string work_phone, string email, string birth, string gender)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(department) || string.IsNullOrEmpty(job)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("name", name));
            Query.Add(new Parameter("dep", department));
            Query.Add(new Parameter("job", job));
            if (!string.IsNullOrEmpty(mobile_phone))
            {
                Query.Add(new Parameter("mobile_phone", mobile_phone));
            }
            if (!string.IsNullOrEmpty(work_phone))
            {
                Query.Add(new Parameter("work_phone", work_phone));
            }
            if (!string.IsNullOrEmpty(email))
            {
                Query.Add(new Parameter("email", email));
            }
            if (!string.IsNullOrEmpty(birth))
            {
                Query.Add(new Parameter("birth", birth));
            }
            if (!string.IsNullOrEmpty(gender))
            {
                Query.Add(new Parameter("gender", gender));
            }
            string Result = base.SyncRequest(TypeOption.MD_PASSPORT_EDIT, Query, null);
            return Result;
        }
        /// <summary>
        /// 修改当前登陆用户头像信息
        /// </summary>
        /// <param name="PimgURL">上传图片路径</param>
        /// <returns></returns>
        public string EditAvstar(string PimgURL)
        {
            if (string.IsNullOrEmpty(PimgURL)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_img", PimgURL));
            return base.SyncRequest(TypeOption.MD_PASSPORT_EDITAVSTAR, null, Query);
        }
    }
}
