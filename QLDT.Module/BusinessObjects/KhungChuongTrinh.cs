using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Thêm Môn Học")]
    public class KhungChuongTrinh : BaseObject
    {
        public KhungChuongTrinh(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private ChuongTrinhDaoTao _ChuongTrinhDaoTao;
        [XafDisplayName("Chương Trình Đào Tạo")]
        [Association("ctdd-kct")]
        [VisibleInDetailView(false)]
        public ChuongTrinhDaoTao ChuongTrinhDaoTao
        {
            get { return _ChuongTrinhDaoTao; }
            set { SetPropertyValue<ChuongTrinhDaoTao>(nameof(ChuongTrinhDaoTao), ref _ChuongTrinhDaoTao, value); }
        }

        private MonHoc _MonHocKCT;
        [XafDisplayName("Môn Học")]
        [Association("kct-mh")]
        public MonHoc MonHocKCT
        {
            get { return _MonHocKCT; }
            set { SetPropertyValue<MonHoc>(nameof(MonHocKCT), ref _MonHocKCT, value); }
        }

        private string _GhiChu;
        [XafDisplayName("Ghi Chú")]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }



    }
}