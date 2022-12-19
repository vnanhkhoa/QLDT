using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Giảng Viên")]
    [DefaultProperty("HoVaTen")]
    public class GiangVien : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public GiangVien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _HoVaTen;
        [XafDisplayName("Họ và Tên")]
        public string HoVaTen
        {
            get { return _HoVaTen; }
            set { SetPropertyValue<string>(nameof(HoVaTen), ref _HoVaTen, value); }
        }


        private DateTime _NgaySinh;
        [XafDisplayName("Ngày Sinh")]
        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { SetPropertyValue<DateTime>(nameof(NgaySinh), ref _NgaySinh, value); }
        }


        private bool _isMale;
        [XafDisplayName("Nam")]
        public bool isMale
        {
            get { return _isMale; }
            set { SetPropertyValue<bool>(nameof(isMale), ref _isMale, value); }
        }

        private string _SoDienThoai;
        [XafDisplayName("Số Điện Thoại")]
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { SetPropertyValue<string>(nameof(SoDienThoai), ref _SoDienThoai, value); }
        }


        [DevExpress.Xpo.Aggregated,Association("lhp-gv")]
        [XafDisplayName("Lớp Học Phần")]
        public XPCollection<LopHocPhan> LopHocPhans
        {
            get { return GetCollection<LopHocPhan>(nameof(LopHocPhans)); }
        }

        [Association("ct-gv")]
        [XafDisplayName("Lịch thi")]
        public XPCollection<CaThi> CaThis
        {
            get { return GetCollection<CaThi>(nameof(CaThis)); }
        }


    }
}