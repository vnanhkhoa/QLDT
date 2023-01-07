using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Lớp Học Phần")]
    [DefaultProperty("TenLopHocPhan")]
    public class LopHocPhan : BaseObject
    {
        public LopHocPhan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        private string _MaLHP;
        [XafDisplayName("Mã Lớp Học Phần")]
        public string MaLHP
        {
            get { return _MaLHP; }
            set { SetPropertyValue<string>(nameof(MaLHP), ref _MaLHP, value); }
        }

        private string _LichHoc;
        [XafDisplayName("Lịch Học")]
        public string LichHoc
        {
            get { return _LichHoc; }
            set { SetPropertyValue<string>(nameof(LichHoc), ref _LichHoc, value); }
        }

        private MonHoc _MonHocLHP;
        [XafDisplayName("Môn Học")]
        [Association("lhp-mh")]
        public MonHoc MonHocLHP
        {
            get { return _MonHocLHP; }
            set { SetPropertyValue(nameof(MonHocLHP), ref _MonHocLHP, value); }
        }

        private int _SoBuoi;
        [XafDisplayName("Số Buổi")]
        public int SoBuoi
        {
            get { return _SoBuoi; }
            set { SetPropertyValue<int>(nameof(SoBuoi), ref _SoBuoi, value); }
        }

        private DateTime? _NgayBatDau;
        [XafDisplayName("Ngày Bắt Đầu")]
        public DateTime? NgayBatDau
        {
            get { return _NgayBatDau; }
            set { SetPropertyValue<DateTime?>(nameof(NgayBatDau), ref _NgayBatDau, value); }
        }

        private KhoaHoc _KhoaHocLHP;
        [XafDisplayName("Khóa Học")]
        [Association("lhp-kh")]
        public KhoaHoc KhoaHocLHP
        {
            get { return _KhoaHocLHP; }
            set { SetPropertyValue<KhoaHoc>(nameof(KhoaHocLHP), ref _KhoaHocLHP, value); }
        }

        private string _CongThucDieuKienDiem;
        [XafDisplayName("Công Thức Điều Kiện")]
        public string CongThucDieuKienDiem
        {
            get { return _CongThucDieuKienDiem; }
            set { SetPropertyValue<string>(nameof(CongThucDieuKienDiem), ref _CongThucDieuKienDiem, value); }
        }

        private string _CongThucDiem;
        [XafDisplayName("Công Thức Điểm")]
        public string CongThucDiem
        {
            get { return _CongThucDiem; }
            set { SetPropertyValue<string>(nameof(CongThucDiem), ref _CongThucDiem, value); }
        }

        private GiangVien _GiangVienLHP;
        [XafDisplayName("Giảng Viên")]
        [Association("lhp-gv")]
        public GiangVien GiangVienLHP
        {
            get { return _GiangVienLHP; }
            set { SetPropertyValue<GiangVien>(nameof(GiangVienLHP), ref _GiangVienLHP, value); }
        }

        [Association("bdlhp-lophp")]
        [XafDisplayName("Bảng Điểm")]
        public XPCollection<BangDiemLopHP> BangDiemLopHPs
        {
            get { return GetCollection<BangDiemLopHP>(nameof(BangDiemLopHPs)); }
        }

        [XafDisplayName("Số HV")]
        [ReadOnly(true)]
        public int? SoHV
        {
            get { return BangDiemLopHPs?.Count; }
        }

        [XafDisplayName("Tên Lớp Học Phần")]
        public string TenLopHocPhan
        {
            get
            {   
                if (MonHocLHP == null) return "";
                return NgayBatDau != null ? string.Format("{0}({1})", MonHocLHP.TenMonHoc, NgayBatDau) : string.Format("{0}", MonHocLHP.TenMonHoc);
            }
        }
    }
}
