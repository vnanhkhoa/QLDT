using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Đăng Ký Học")]
    [DefaultProperty("HocVienDKH")]
    public class DangKyHoc : BaseObject
    {
        public DangKyHoc(Session session) : base(session)
        { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private HocVien _HocVienDKH;
        [XafDisplayName("Học Viên")]
        [Association("dkh-hv")]
        public HocVien HocVienDKH
        {
            get { return _HocVienDKH; }
            set { SetPropertyValue<HocVien>(nameof(HocVienDKH), ref _HocVienDKH, value); }
        }

        private KhoaHoc _KhoahocDKH;
        [XafDisplayName("Khoá Học")]
        [Association("dkh-kh")]
        [VisibleInDetailView(false)]
        public KhoaHoc KhoahocDKH
        {
            get { return _KhoahocDKH; }
            set { SetPropertyValue<KhoaHoc>(nameof(KhoahocDKH), ref _KhoahocDKH, value); }
        }

        private DateTime _NgayDangKyHoc = DateTime.Now;
        [XafDisplayName("Ngày Đăng Ký Học")]
        [VisibleInDetailView(false)]
        public DateTime NgayDangKyHoc
        {
            get { return _NgayDangKyHoc; }
            set { SetPropertyValue<DateTime>(nameof(NgayDangKyHoc), ref _NgayDangKyHoc, value); }
        }

        private bool _HoanThanhKhoaHoc;
        [XafDisplayName("Hoàn Thành Khóa Học")]
        [VisibleInDetailView(false)]
        public bool HoanThanhKhoaHoc
        {
            get { return _HoanThanhKhoaHoc; }
            set { SetPropertyValue<bool>(nameof(HoanThanhKhoaHoc), ref _HoanThanhKhoaHoc, value); }
        }

        private float _DiemKhoaHoc;
        [XafDisplayName("Điểm Khóa Học")]
        [VisibleInDetailView(false)]
        public float DiemKhoaHoc
        {
            get { return _DiemKhoaHoc; }
            set { SetPropertyValue<float>(nameof(DiemKhoaHoc), ref _DiemKhoaHoc, value); }
        }

        private bool _HaBac;
        [XafDisplayName("Hạ Bậc")]
        [VisibleInDetailView(false)]
        public bool HaBac
        {
            get { return _HaBac; }
            set { SetPropertyValue<bool>(nameof(HaBac), ref _HaBac, value); }
        }

        private XepLoai _LoaiTN;
        [XafDisplayName("Loại Tốt Nghiệp")]
        [VisibleInDetailView(false)]
        public XepLoai LoaiTN
        {
            get { return _LoaiTN; }
            set { SetPropertyValue<XepLoai>(nameof(LoaiTN), ref _LoaiTN, value); }
        }

        private string _GhiChu;
        [XafDisplayName("Ghi Chú")]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }



        [Association("bdkh-dkh")]
        [XafDisplayName("Bảng Điểm")]
        public XPCollection<BangDiemKhoaHoc> BangDiemKhoaHocs
        {
            get { return GetCollection<BangDiemKhoaHoc>(nameof(BangDiemKhoaHocs)); }
        }


        [Association("bdlhp-dkh")]
        public XPCollection<BangDiemLopHP> BangDiemLopHPs
        {
            get { return GetCollection<BangDiemLopHP>(nameof(BangDiemLopHPs)); }
        }

        /*[Association("dst-dkh")]
        public XPCollection<DanhSachThi> DanhSachThis
        {
            get { return GetCollection<DanhSachThi>(nameof(DanhSachThis)); }
        }*/

    }
}