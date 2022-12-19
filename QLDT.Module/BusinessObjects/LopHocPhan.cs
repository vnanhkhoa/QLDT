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
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public LopHocPhan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _TenLopHocPhan;
        [XafDisplayName("Tên Lớp Học Phần")]
        public string TenLopHocPhan
        {
            get { return _TenLopHocPhan; }
            set { SetPropertyValue<string>(nameof(TenLopHocPhan), ref _TenLopHocPhan, value); }
        }

        private MonHoc _MonHocLHP;
        [XafDisplayName("Môn Học")]
        [Association("lhp-mh")]
        public MonHoc MonHocLHP
        {
            get { return _MonHocLHP; }
            set { SetPropertyValue(nameof(MonHocLHP), ref _MonHocLHP, value); }
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

        private Status _TrangThai;
        [XafDisplayName("Trạng Thái")]
        public Status TrangThai
        {
            get { return _TrangThai; }
            set { SetPropertyValue<Status>(nameof(TrangThai), ref _TrangThai, value); }
        }

        private string _LichHoc;
        [XafDisplayName("Lịch Học")]
        public string LichHoc
        {
            get { return _LichHoc; }
            set { SetPropertyValue<string>(nameof(LichHoc), ref _LichHoc, value); }
        }

        private DateTime _NgayBatDau;
        [XafDisplayName("Ngày Bắt Đầu")]
        public DateTime NgayBatDau
        {
            get { return _NgayBatDau; }
            set { SetPropertyValue<DateTime>(nameof(NgayBatDau), ref _NgayBatDau, value); }
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

        public enum Status
        {
            Start,
            Progress,
            End
        }
    }
}