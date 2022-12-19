using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using QLDT.Module.BusinessObjects;

namespace QLDT.Module.Controllers
{
    public partial class ThemSinhVienLopHPViewController : ViewController
    {
        private LopHocPhan lopHocPhan;
        private PopupWindowShowAction showNotesAction;
        public ThemSinhVienLopHPViewController()
        {
            InitializeComponent();
            TargetViewId = "LopHocPhan_BangDiemLopHPs_ListView";
            TargetObjectType = typeof(BangDiemLopHP);
            showNotesAction = new PopupWindowShowAction(this, "ThemHocVienLHP", PredefinedCategory.Edit)
            {
                Caption = "Thêm Học Viên"
            };

            showNotesAction.CustomizePopupWindowParams += ShowAction_CustomizePopupWindowParams;
            showNotesAction.Execute += ShowAction_Execute;
        }
        
        private void ShowAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            IObjectSpace os = this.ObjectSpace;
            foreach (DangKyHoc dk in e.PopupWindowViewSelectedObjects)
            {
                var dkh = os.GetObject(dk);
                var bd = os.CreateObject<BangDiemLopHP>();
                bd.LopHP = lopHocPhan;
                bd.DangKyHocBDLHP = dkh;
            }
            os.CommitChanges();
            View.Refresh();
        }

        private void ShowAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var hocViens = lopHocPhan.BangDiemLopHPs.Select(bd => bd.DangKyHocBDLHP.Oid).ToList();

            var bangDiemKh = lopHocPhan.Session.Query<BangDiemKhoaHoc>()
                .Where(b => b.MoHocBD.Oid == lopHocPhan.MonHocLHP.Oid && !hocViens.Contains(b.DangKyHocBDKH.Oid))
                .ToList().Select(bd => bd.DangKyHocBDKH.Oid);

            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(DangKyHoc));
            CollectionSourceBase collection = new CollectionSource(objectSpace, typeof(DangKyHoc));
            collection.Criteria["Filter1"] = CriteriaOperator.FromLambda<DangKyHoc>(d => bangDiemKh.Contains(d.Oid));
            e.View = Application.CreateListView("DangKyHoc_ListView", collection, true);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            lopHocPhan = ((NestedFrame)Frame).ViewItem.View.CurrentObject as LopHocPhan;
        }

        protected override void OnDeactivated()
        {
            showNotesAction.CustomizePopupWindowParams -= ShowAction_CustomizePopupWindowParams;
            showNotesAction.Execute -= ShowAction_Execute;
            base.OnDeactivated();
        }
    }
}
