using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class NganHangDe : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NganHangDe(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _NoiDungCauHoi;
        public string NoiDungCauHoi
        {
            get { return _NoiDungCauHoi; }
            set { SetPropertyValue<string>(nameof(NoiDungCauHoi), ref _NoiDungCauHoi, value); }
        }

        private MonHoc _MonHocNHD;
        [Association("nhd-mh")]
        public MonHoc MonHocNHD
        {
            get { return _MonHocNHD; }
            set { SetPropertyValue<MonHoc>(nameof(MonHocNHD), ref _MonHocNHD, value); }
        }

        [Association("da-ngd")]
        public XPCollection<DapAn> DapAns
        {
            get { return GetCollection<DapAn>(nameof(DapAns)); }
        }

    }
}