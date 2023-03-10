using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using QLDT.Module.BusinessObjects;

namespace QLDT.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class QLDTModule : ModuleBase
{
    public static bool isHV = false;
    public QLDTModule()
    {
        // 
        // QLDTModule
        // 
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application)
    {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }

    public static Guid? GetCurrentUserHocVien(IObjectSpace objectSpace)
    {
        ApplicationUser Owner = objectSpace.FindObject<ApplicationUser>(CriteriaOperator.Parse("Oid=CurrentUserId()"));
        if (Owner.IsHV)
        {
            var hv = objectSpace.FindObject<HocVien>(CriteriaOperator.Parse("SoThe=?", Owner.UserName));
            if (hv != null)
            {
                isHV = true;
                return hv.Oid;
            }
        }

        if (Owner.IsGV)
        {
            var gv = objectSpace.FindObject<GiangVien>(CriteriaOperator.Parse("NameSort=?", Owner.UserName));
            if (gv != null)
            {
                isHV = false;
                return gv.Oid;
            }
        }
        return null;
    }
}
