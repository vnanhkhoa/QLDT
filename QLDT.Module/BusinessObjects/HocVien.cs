using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
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
        }


        private string _SoThe;
        [XafDisplayName("Số Thẻ"), ModelDefault("AllowEdit", "false")]
        public string SoThe
        {
            get { return _SoThe; }
            set { SetPropertyValue<string>(nameof(SoThe), ref _SoThe, value); }
        }

        private string _Ho;
        [XafDisplayName("Họ")]
        [VisibleInListView(false)]
        public string Ho
        {
            get { return _Ho; }
            set { SetPropertyValue<string>(nameof(Ho), ref _Ho, value); }
        }

        private string _Ten;
        [XafDisplayName("Tên")]
        [VisibleInListView(false)]
        public string Ten
        {
            get { return _Ten; }
            set { SetPropertyValue<string>(nameof(Ten), ref _Ten, value); }
        }

        [XafDisplayName("Họ và Tên")]
        [VisibleInDetailView(false)]
        public string HoVaTen
        {
            get { return String.Format("{0} {1}", Ho, Ten); }
        }


        private DateTime _NgaySinh;
        [XafDisplayName("Ngày Sinh")]
        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { SetPropertyValue<DateTime>(nameof(NgaySinh), ref _NgaySinh, value); }
        }

        private Gender _GioiTinh;
        [XafDisplayName("Giới Tính")]
        public Gender GioiTinh
        {
            get { return _GioiTinh; }
            set { SetPropertyValue<Gender>(nameof(GioiTinh), ref _GioiTinh, value); }
        }


        private string _CanCucCongDan;
        [XafDisplayName("Căn Cước Công Dân")]
        public string CanCucCongDan
        {
            get { return _CanCucCongDan; }
            set 
            {
                SetPropertyValue<string>(nameof(CanCucCongDan), ref _CanCucCongDan, value); 
                SoThe = value;
            }
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

        private string _DiaChi;
        [XafDisplayName("Địa Chỉ")]
        public string DiaChi
        {
            get { return _DiaChi; }
            set { SetPropertyValue<string>(nameof(DiaChi), ref _DiaChi, value); }
        }

        [Association("dkh-hv")]
        [XafDisplayName("Đăng Ký Học")]
        public XPCollection<DangKyHoc> DangKyHocs
        {
            get { return GetCollection<DangKyHoc>(nameof(DangKyHocs)); }
        }

        public enum Gender
        {
            [XafDisplayName("Nam")]
            MALE,
            [XafDisplayName("Nữ")]
            FEMALE
        }
    }

}