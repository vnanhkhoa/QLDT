using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Bảng điểm khóa học")]
    public class BangDiemKhoaHoc : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public BangDiemKhoaHoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private MonHoc _MoHocBD;
        [Association("bdkh-mh")]
        [XafDisplayName("Môn Học")]
        public MonHoc MoHocBD
        {
            get { return _MoHocBD; }
            set { SetPropertyValue<MonHoc>(nameof(MoHocBD), ref _MoHocBD, value); }
        }

        private double? _Diem;
        [XafDisplayName("Điểm")]
        public double? Diem
        {
            get { return _Diem; }
            set { SetPropertyValue<double?>(nameof(Diem), ref _Diem, value); }
        }

        private int _SoLanHoc;
        [XafDisplayName("Số Lần Học")]
        public int SoLanHoc
        {
            get { return _SoLanHoc; }
            set { SetPropertyValue<int>(nameof(SoLanHoc), ref _SoLanHoc, value); }
        }


        private string _GhiChu;
        [XafDisplayName("Ghi Chú")]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }

        private DangKyHoc _DangKyHocBDKH;
        [Association("bdkh-dkh")]
        [XafDisplayName("Bảng Điểm")]
        public DangKyHoc DangKyHocBDKH
        {
            get { return _DangKyHocBDKH; }
            set { SetPropertyValue<DangKyHoc>(nameof(DangKyHocBDKH), ref _DangKyHocBDKH, value); }
        }


    }
}