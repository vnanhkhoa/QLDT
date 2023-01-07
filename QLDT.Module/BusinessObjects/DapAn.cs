using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Câu Hỏi")]
    public class DapAn : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DapAn(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private NganHangDe _NganHangDeDA;
        [Association("da-ngd")]
        [XafDisplayName("Câu Hỏi")]
        public NganHangDe NganHangDeDA
        {
            get { return _NganHangDeDA; }
            set { SetPropertyValue<NganHangDe>(nameof(NganHangDeDA), ref _NganHangDeDA, value); }
        }


        private string _KyHieu;
        [XafDisplayName("Ký Hiệu")]
        [VisibleInListView(false)]
        public string KyHieu
        {
            get { return _KyHieu; }
            set { SetPropertyValue<string>(nameof(KyHieu), ref _KyHieu, value); }
        }

        private string _NoiDungDapAn;
        [XafDisplayName("Nội Dung Đáp Án")]
        [VisibleInListView(false)]
        public string NoiDungDapAn
        {
            get { return _NoiDungDapAn; }
            set { SetPropertyValue<string>(nameof(NoiDungDapAn), ref _NoiDungDapAn, value); }
        }

        [XafDisplayName("Đáp Án")]
        [VisibleInDetailView(false)]
        public string CDapan
        {
            get { return string.Format("{0}. {1}",KyHieu,NoiDungDapAn); }
        }

        private bool _Dung;
        [XafDisplayName("Đúng")]
        public bool Dung
        {
            get { return _Dung; }
            set { SetPropertyValue<bool>(nameof(Dung), ref _Dung, value); }
        }
    }
}
