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

        [XafDisplayName("Số Giờ")]
        public int SoGio
        {
            get { return SoGioLT + SoGioTH + SoGioBT + SoGioDA; }
        }

        private int _SoGioLT;
        [XafDisplayName("Số Giờ Lý Thuyết")]
        public int SoGioLT
        {
            get { return _SoGioLT; }
            set { SetPropertyValue<int>(nameof(SoGioLT), ref _SoGioLT, value); }
        }

        private int _SoGioTH;
        [XafDisplayName("Số Giờ Thực Hành")]
        public int SoGioTH
        {
            get { return _SoGioTH; }
            set { SetPropertyValue<int>(nameof(SoGioTH), ref _SoGioTH, value); }
        }

        private int _SoGioBT;
        [XafDisplayName("Số Giờ Bài Tập")]
        public int SoGioBT
        {
            get { return _SoGioBT; }
            set { SetPropertyValue<int>(nameof(SoGioBT), ref _SoGioBT, value); }
        }

        private int _SoGioDA;
        [XafDisplayName("Số Giờ Dự Án")]
        public int SoGioDA
        {
            get { return _SoGioDA; }
            set { SetPropertyValue<int>(nameof(SoGioDA), ref _SoGioDA, value); }
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