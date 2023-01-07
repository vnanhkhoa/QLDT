using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects;

[DeferredDeletion(false)]
[Persistent("PermissionPolicyUserLoginInfo")]
public class ApplicationUserLoginInfo : BaseObject, ISecurityUserLoginInfo {
    private string loginProviderName;
    private ApplicationUser user;
    private string providerUserKey;
    public ApplicationUserLoginInfo(Session session) : base(session) { }

    [Indexed("ProviderUserKey", Unique = true)]
    [Appearance("PasswordProvider", Enabled = false, Criteria = "!(IsNewObject(this)) and LoginProviderName == '" + SecurityDefaults.PasswordAuthentication + "'", Context = "DetailView")]
    public string LoginProviderName {
        get { return loginProviderName; }
        set { SetPropertyValue(nameof(LoginProviderName), ref loginProviderName, value); }
    }

    [Appearance("PasswordProviderUserKey", Enabled = false, Criteria = "!(IsNewObject(this)) and LoginProviderName == '" + SecurityDefaults.PasswordAuthentication + "'", Context = "DetailView")]
    public string ProviderUserKey {
        get { return providerUserKey; }
        set { SetPropertyValue(nameof(ProviderUserKey), ref providerUserKey, value); }
    }

    [Association("User-LoginInfo")]
    public ApplicationUser User {
        get { return user; }
        set { SetPropertyValue(nameof(User), ref user, value); }
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





    object ISecurityUserLoginInfo.User => User;
}
