using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Đáp Án")]
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
        public NganHangDe NganHangDeDA
        {
            get { return _NganHangDeDA; }
            set { SetPropertyValue<NganHangDe>(nameof(NganHangDeDA), ref _NganHangDeDA, value); }
        }


        private string _NoiDungDapAn;
        public string NoiDungDapAn
        {
            get { return _NoiDungDapAn; }
            set { SetPropertyValue<string>(nameof(NoiDungDapAn), ref _NoiDungDapAn, value); }
        }

        private bool _isDung;
        public bool isDung
        {
            get { return _isDung; }
            set { SetPropertyValue<bool>(nameof(isDung), ref _isDung, value); }
        }


    }
}