using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CaThi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public CaThi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _PhongThi;
        [XafDisplayName("Phòng Thi")]
        public string PhongThi
        {
            get { return _PhongThi; }
            set { SetPropertyValue<string>(nameof(PhongThi), ref _PhongThi, value); }
        }

        private DateTime _NgayThi;
        [XafDisplayName("Ngày Giờ Thi")]
        public DateTime NgayThi
        {
            get { return _NgayThi; }
            set { SetPropertyValue<DateTime>(nameof(NgayThi), ref _NgayThi, value); }
        }

        private int _ThoiGianThi;
        [XafDisplayName("Thời Gian Thi")]
        public int ThoiGianThi
        {
            get { return _ThoiGianThi; }
            set { SetPropertyValue<int>(nameof(ThoiGianThi), ref _ThoiGianThi, value); }
        }

        private GiangVien _GiangVienCT;
        [Association("ct-gv")]
        public GiangVien GiangVienCT
        {
            get { return _GiangVienCT; }
            set { SetPropertyValue<GiangVien>(nameof(GiangVienCT), ref _GiangVienCT, value); }
        }


        private string _GhiChu;
        [XafDisplayName("Ghi Chú")]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }

        private MonHoc _MonHocCT;
        [XafDisplayName("Môn Thi")]
        public MonHoc MonHocCT
        {
            get { return _MonHocCT; }
            set { SetPropertyValue<MonHoc>(nameof(MonHocCT), ref _MonHocCT, value); }
        }

        [Association("dst-ct")]
        [XafDisplayName("Danh Sách Thi")]
        public XPCollection<DanhSachThi> DanhSachThis
        {
            get { return GetCollection<DanhSachThi>(nameof(DanhSachThis)); }
        }


    }
}