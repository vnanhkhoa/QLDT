using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects;

[MapInheritance(MapInheritanceType.ParentTable)]
[DefaultProperty(nameof(UserName))]
public class ApplicationUser : PermissionPolicyUser, ISecurityUserWithLoginInfo
{
    public ApplicationUser(Session session) : base(session) { }

    [Browsable(false)]
    [DevExpress.Xpo.Aggregated, Association("User-LoginInfo")]
    public XPCollection<ApplicationUserLoginInfo> LoginInfo
    {
        get { return GetCollection<ApplicationUserLoginInfo>(nameof(LoginInfo)); }
    }

    [XafDisplayName("Học Viên")]
    private bool _IsHV;
    public bool IsHV
    {
        get { return _IsHV; }
        set { SetPropertyValue<bool>(nameof(IsHV), ref _IsHV, value); }
    }

    [XafDisplayName("Giảng Viên")]

    private bool _IsGV;
    public bool IsGV
    {
        get { return _IsGV; }
        set { SetPropertyValue<bool>(nameof(IsGV), ref _IsGV, value); }
    }

    IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

    ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey)
    {
        ApplicationUserLoginInfo result = new ApplicationUserLoginInfo(Session);
        result.LoginProviderName = loginProviderName;
        result.ProviderUserKey = providerUserKey;
        result.User = this;
        return result;
    }

    /*[Action(Caption = "Cập nhật", AutoCommit = true)]
    public void add()
    {
        var ois = this.Session.Query<ApplicationUserLoginInfo>().Select(al => al.User.Oid);
        var pU = this.Session.Query<ApplicationUser>()
            .Where(p => !ois.Contains(p.Oid));

        foreach (ApplicationUser o in pU)
        {
            ApplicationUserLoginInfo result = new ApplicationUserLoginInfo(Session);
            result.LoginProviderName = "Password";
            result.ProviderUserKey = o.Oid.ToString();
            result.User = o;
            result.Save();
        }
    }*/
}
