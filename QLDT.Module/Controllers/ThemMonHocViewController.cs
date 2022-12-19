using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using QLDT.Module.BusinessObjects;

namespace QLDT.Module.Controllers
{
    public partial class ThemMonHocViewController : ViewController<ListView>
    {
        private ChuongTrinhDaoTao chuongTrinhDaoTao;
        public ThemMonHocViewController()
        {
            TargetObjectType = typeof(KhungChuongTrinh);
            TargetViewId = "ChuongTrinhDaoTao_KhungChuongTrinhs_ListView";
            PopupWindowShowAction showNotesAction = new PopupWindowShowAction(this, "ThemMonHoc", PredefinedCategory.Edit)
            {
                Caption = "Thêm Môn Học"
            };

            showNotesAction.CustomizePopupWindowParams += ShowAction_CustomizePopupWindowParams;
            showNotesAction.Execute += ShowAction_Execute;
        }

        private void ShowAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            IObjectSpace os = this.ObjectSpace;
            foreach (MonHoc monHoc in e.PopupWindowViewSelectedObjects)
            {
                var mh = os.GetObject(monHoc);
                var khungChuongTrinh = os.CreateObject<KhungChuongTrinh>();
                khungChuongTrinh.MonHocKCT = mh;
                khungChuongTrinh.ChuongTrinhDaoTao = chuongTrinhDaoTao;
                foreach (KhoaHoc khoaHoc in chuongTrinhDaoTao.khoaHocs)
                {
                    foreach (DangKyHoc dangKyHoc in khoaHoc.HocViens)
                    {
                        var bangDiem = os.CreateObject<BangDiemKhoaHoc>();
                        bangDiem.DangKyHocBDKH = dangKyHoc;
                        bangDiem.MoHocBD = mh;
                    }
                }
            }
            os.CommitChanges();
            View.Refresh();
        }

        private void ShowAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            var list = chuongTrinhDaoTao.KhungChuongTrinhs.Select(k => k.MonHocKCT.Oid).ToList();
            CollectionSourceBase collection = new CollectionSource(objectSpace, typeof(MonHoc));
            collection.Criteria["Filter1"] = new NotOperator(new InOperator("Oid", list));
            e.View = Application.CreateListView("MonHoc_ListView", collection, true);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            chuongTrinhDaoTao = ((NestedFrame)Frame).ViewItem.View.CurrentObject as ChuongTrinhDaoTao;
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

    }
}
