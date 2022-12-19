using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Chương Trình Đào Tạo")]
    [DefaultProperty("TenChuongTrinh")]
    public class ChuongTrinhDaoTao : BaseObject
    {
        public ChuongTrinhDaoTao(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _TenChuongTrinh;
        [XafDisplayName("Tên Chương Trình")]
        public string TenChuongTrinh
        {
            get { return _TenChuongTrinh; }
            set { SetPropertyValue<string>(nameof(TenChuongTrinh), ref _TenChuongTrinh, value); }
        }

        private string _ThoiGianDaoTao;
        [XafDisplayName("Thời Gian Đào Tạo")]
        public string ThoiGianDaoTao
        {
            get { return _ThoiGianDaoTao; }
            set { SetPropertyValue<string>(nameof(ThoiGianDaoTao), ref _ThoiGianDaoTao, value); }
        }

        [XafDisplayName("Số Môn")]
        [ReadOnly(true)]
        public int SoMon
        {
            get
            {
                return KhungChuongTrinhs.Count;
            }
        }


        [Association("ctdd-kct"), DevExpress.Xpo.Aggregated]
        [XafDisplayName("Khung Chương Trình")]
        public XPCollection<KhungChuongTrinh> KhungChuongTrinhs
        {
            get { return GetCollection<KhungChuongTrinh>(nameof(KhungChuongTrinhs)); }
        }

        [Association("kh-ctdt"), DevExpress.Xpo.Aggregated]
        [XafDisplayName("Khóa Học")]
        public XPCollection<KhoaHoc> khoaHocs
        {
            get { return GetCollection<KhoaHoc>(nameof(khoaHocs)); }
        }


    }
}