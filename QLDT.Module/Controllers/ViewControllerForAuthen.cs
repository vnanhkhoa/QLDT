using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using QLDT.Module.BusinessObjects;

namespace QLDT.Module.Controllers
{
    public partial class ViewControllerForAuthen : ViewController
    {
        public ViewControllerForAuthen()
        {
            InitializeComponent();
            TargetViewId = "HocVien_ListView;DangKyHoc_ListView;BangDiemKhoaHoc_ListView;" +
                "BangDiemLopHP_ListView;LopHocPhan_ListView;GiangVien_ListView";
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            SetFilter();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            this.ObjectSpace.Reloaded += ObjectSpace_Reloaded;
        }

        void ObjectSpace_Reloaded(object sender, EventArgs e)
        {
            SetFilter();
        }
        protected override void OnDeactivated()
        {
            this.ObjectSpace.Reloaded -= ObjectSpace_Reloaded;
            base.OnDeactivated();
        }
        private void SetFilter()
        {
            var id = QLDTModule.GetCurrentUserHocVien(ObjectSpace);
            if (id != null)
            {
                CriteriaOperator cri;
                switch (View.Id)
                {
                    case "HocVien_ListView":
                    case "GiangVien_ListView":
                        cri = CriteriaOperator.Parse("Oid=?", id);
                        break;
                    case "DangKyHoc_ListView":
                        cri = CriteriaOperator.Parse("HocVienDKH=?", id);
                        break;
                    case "BangDiemKhoaHoc_ListView":
                        var dkh = ObjectSpace.
                            GetObjects(typeof(DangKyHoc), CriteriaOperator.Parse("HocVienDKH=?", id))
                            .Cast<DangKyHoc>().Select(d => d.Oid);
                        if (dkh == null)
                        {
                            cri = null;
                            break;
                        }
                        cri = new InOperator("DangKyHocBDKH", dkh);
                        break;
                    case "BangDiemLopHP_ListView":
                        var dkh1 = ObjectSpace.
                            GetObjects(typeof(DangKyHoc), CriteriaOperator.Parse("HocVienDKH=?", id))
                            .Cast<DangKyHoc>().Select(d => d.Oid);
                        if (dkh1 == null)
                        {
                            cri = null;
                            break;
                        }
                        cri = new InOperator("DangKyHocBDLHP", dkh1);
                        break;
                    case "LopHocPhan_ListView":
                        if (QLDTModule.isHV)
                        {
                            var dkh2 = ObjectSpace.
                            GetObjects(typeof(DangKyHoc), CriteriaOperator.Parse("HocVienDKH=?", id))
                            .Cast<DangKyHoc>().Select(d => d.Oid);
                            if (dkh2 == null)
                            {
                                cri = null;
                                break;
                            }
                            var bd = ObjectSpace
                                .GetObjects<BangDiemLopHP>(new InOperator("DangKyHocBDLHP", dkh2))
                                .Cast<BangDiemLopHP>().Select(d => d.LopHP.Oid);
                            cri = new InOperator("Oid", bd);
                            break;
                        }

                        cri = CriteriaOperator.Parse("GiangVienLHP=?", id);
                        break;
                    default:
                        cri = null;
                        break;
                }
                if (cri != null)
                {
                    ((ListView)View).CollectionSource.Criteria["loc"] = cri;
                }

            }
            else
            {
                ((ListView)View).CollectionSource.Criteria.Remove("loc");
            }

        }
    }
}
