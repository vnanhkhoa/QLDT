using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Xếp Loại")]
    [DefaultProperty("TenLoai")]
    public class XepLoai : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public XepLoai(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _TenLoai;
        [XafDisplayName("Tên Loại")]
        public string TenLoai
        {
            get { return _TenLoai; }
            set { SetPropertyValue<string>(nameof(TenLoai), ref _TenLoai, value); }
        }

        private float _TuDiem;
        [XafDisplayName("Từ Điểm")]
        public float TuDiem
        {
            get { return _TuDiem; }
            set { SetPropertyValue<float>(nameof(TuDiem), ref _TuDiem, value); }
        }


        private float _DenDiem;
        [XafDisplayName("Đến Điểm")]
        public float DenDiem
        {
            get { return _DenDiem; }
            set { SetPropertyValue<float>(nameof(DenDiem), ref _DenDiem, value); }
        }
    }
}