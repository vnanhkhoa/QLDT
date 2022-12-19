using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Học Viên")]
    [DefaultProperty("HoVaTen")]
    public class HocVien : BaseObject
    { 
        public HocVien(Session session)
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


        private string _CanCucCongDan;
        [XafDisplayName("Căn Cước Công Dân")]
        public string CanCucCongDan
        {
            get { return _CanCucCongDan; }
            set { SetPropertyValue<string>(nameof(CanCucCongDan), ref _CanCucCongDan, value); }
        }


        private string _SoDienThoai;
        [XafDisplayName("Số Điện Thoại")]
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { SetPropertyValue<string>(nameof(SoDienThoai), ref _SoDienThoai, value); }
        }


        private string _HoKhau;
        [XafDisplayName("Hộ Khẩu")]
        public string HoKhau
        {
            get { return _HoKhau; }
            set { SetPropertyValue<string>(nameof(HoKhau), ref _HoKhau, value); }
        }

        private string _GhiChu;
        [XafDisplayName("Ghi Chú")]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }


        [Association("dkh-hv")]
        public XPCollection<DangKyHoc> DangKyHocs
        {
            get { return GetCollection<DangKyHoc>(nameof(DangKyHocs)); }
        }

    }
}