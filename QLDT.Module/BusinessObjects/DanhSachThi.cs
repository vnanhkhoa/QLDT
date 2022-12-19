using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(DangKyHocDST))]
    public class DanhSachThi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DanhSachThi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private DangKyHoc _DangKyHocDST;
        [Association("dst-dkh")]
        public DangKyHoc DangKyHocDST
        {
            get { return _DangKyHocDST; }
            set { SetPropertyValue<DangKyHoc>(nameof(DangKyHocDST), ref _DangKyHocDST, value); }
        }

        private CaThi _CaThiDST;
        [Association("dst-ct")]
        public CaThi CaThiDST
        {
            get { return _CaThiDST; }
            set { SetPropertyValue<CaThi>(nameof(CaThiDST), ref _CaThiDST, value); }
        }

        private bool _VangMat;
        public bool VangMat
        {
            get { return _VangMat; }
            set { SetPropertyValue<bool>(nameof(VangMat), ref _VangMat, value); }
        }
    }
}