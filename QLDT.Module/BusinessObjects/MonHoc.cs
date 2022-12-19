using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Môn Học")]
    [DefaultProperty("TenMonHoc")]
    public class MonHoc : BaseObject
    {
        public MonHoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _TenMonHoc;
        [XafDisplayName("Tên Môn Học")]
        public string TenMonHoc
        {
            get { return _TenMonHoc; }
            set { SetPropertyValue<string>(nameof(TenMonHoc), ref _TenMonHoc, value); }
        }


        private int _SoTinChi;
        [XafDisplayName("Tin Chỉ")]
        public int SoTinChi
        {
            get { return _SoTinChi; }
            set { SetPropertyValue<int>(nameof(SoTinChi), ref _SoTinChi, value); }
        }


        private int _SoGio;
        [XafDisplayName("Số Giờ")]
        public int SoGio
        {
            get { return _SoGio; }
            set { SetPropertyValue<int>(nameof(SoGio), ref _SoGio, value); }
        }

        private int _SoBaiLyThuyet;
        [XafDisplayName("Lý Thuyết")]
        public int SoBaiLyThuyet
        {
            get { return _SoBaiLyThuyet; }
            set { SetPropertyValue<int>(nameof(SoBaiLyThuyet), ref _SoBaiLyThuyet, value); }
        }

        private int _SoBaiThucHanh;
        [XafDisplayName("Thực Hành")]
        public int SoBaiThucHanh
        {
            get { return _SoBaiThucHanh; }
            set { SetPropertyValue<int>(nameof(SoBaiThucHanh), ref _SoBaiThucHanh, value); }
        }

        private int _SoBaiTap;
        [XafDisplayName("Bài Tập")]
        public int SoBaiTap
        {
            get { return _SoBaiTap; }
            set { SetPropertyValue<int>(nameof(SoBaiTap), ref _SoBaiTap, value); }
        }

        private int _SoDuAn;
        [XafDisplayName("Dự Án")]
        public int SoDuAn
        {
            get { return _SoDuAn; }
            set { SetPropertyValue<int>(nameof(SoDuAn), ref _SoDuAn, value); }
        }

        private string _CongThucDiem;
        [XafDisplayName("Công Thức Điểm")]
        public string CongThucDiem
        {
            get { return _CongThucDiem; }
            set { SetPropertyValue<string>(nameof(CongThucDiem), ref _CongThucDiem, value); }
        }

        private string _Nganh;
        [XafDisplayName("Ngành")]
        public string Nganh
        {
            get { return _Nganh; }
            set { SetPropertyValue<string>(nameof(Nganh), ref _Nganh, value); }
        }

        [Association("bdkh-mh")]
        [XafDisplayName("Khóa Học")]
        //[PersistentAlias]
        public XPCollection<BangDiemKhoaHoc> BangDiemKhoaHocs
        {
            get { return GetCollection<BangDiemKhoaHoc>(nameof(BangDiemKhoaHocs)); }
        }

        [Association("kct-mh")]
        [XafDisplayName("Khung chương trình")]
        public XPCollection<KhungChuongTrinh> KhungChuongTrinhs
        {
            get { return GetCollection<KhungChuongTrinh>(nameof(KhungChuongTrinhs)); }
        }

        [Association("lhp-mh")]
        [XafDisplayName("Lớp học phần")]
        public XPCollection<LopHocPhan> LopHocPhans
        {
            get { return GetCollection<LopHocPhan>(nameof(LopHocPhans)); }
        }


        [Association("nhd-mh")]
        [XafDisplayName("Ngân hàng đề")]
        public XPCollection<NganHangDe> NganHangDes
        {
            get { return GetCollection<NganHangDe>(nameof(NganHangDes)); }
        }

    }
}