using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using QLDT.Module.BusinessObjects;

namespace QLDT.Module.Controllers
{
    public partial class ThemHocVienController : ViewController<ListView>
    {
        private KhoaHoc khoaHoc;
        public ThemHocVienController()
        {
            TargetObjectType = typeof(DangKyHoc);
            TargetViewId = "KhoaHoc_HocViens_ListView";
            PopupWindowShowAction showNotesAction = new PopupWindowShowAction(this, "ThemSinhVien", PredefinedCategory.Edit)
            {
                Caption = "Thêm Sinh Viên"
            };

            showNotesAction.CustomizePopupWindowParams += ShowAction_CustomizePopupWindowParams;
            showNotesAction.Execute += ShowAction_Execute;
        }

        private void ShowAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            IObjectSpace os = this.ObjectSpace;
            foreach (HocVien hv in e.PopupWindowViewSelectedObjects)
            {
                var h = os.GetObject(hv);
                var dangKyHoc = os.CreateObject<DangKyHoc>();
                dangKyHoc.HocVienDKH = h;
                dangKyHoc.KhoahocDKH = khoaHoc;
                foreach (KhungChuongTrinh khungChuongTrinh in khoaHoc.CTDT.KhungChuongTrinhs)
                {
                    var bangDiem = os.CreateObject<BangDiemKhoaHoc>();
                    bangDiem.DangKyHocBDKH = dangKyHoc;
                    bangDiem.MoHocBD = khungChuongTrinh.MonHocKCT;
                }
            }
            os.CommitChanges();
            View.Refresh();
        }

        private void ShowAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            var list = khoaHoc.HocViens.Select(d => d.HocVienDKH.Oid).ToList();
            CollectionSourceBase collection = new CollectionSource(objectSpace, typeof(HocVien));
            collection.Criteria["Filter1"] = new NotOperator(new InOperator("Oid", list));
            e.View = Application.CreateListView("HocVien_ListView", collection, true);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            khoaHoc = ((NestedFrame)Frame).ViewItem.View.CurrentObject as KhoaHoc;

        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

    }
}
