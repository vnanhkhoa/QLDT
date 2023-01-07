using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    /*[DefaultProperty(nameof(ThiSinh))]*/
    public class DanhSachThi : BaseObject
    { 
        public DanhSachThi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /*private BangDiemLopHP _BangDiemLopHPDST;
        [XafDisplayName("Thí Sinh")]
        [Association("dst-bdlhp")]
        public BangDiemLopHP BangDiemLopHPDST
        {
            get { return _BangDiemLopHPDST; }
            set { SetPropertyValue<BangDiemLopHP>(nameof(BangDiemLopHPDST), ref _BangDiemLopHPDST, value); }
        }*/

        private CaThi _CaThiDST;
        [Association("dst-ct")]
        public CaThi CaThiDST
        {
            get { return _CaThiDST; }
            set { SetPropertyValue<CaThi>(nameof(CaThiDST), ref _CaThiDST, value); }
        }

        private bool _DaNop;
        [XafDisplayName("Đã Nộp")]
        public bool DaNop
        {
            get { return _DaNop; }
            set { SetPropertyValue<bool>(nameof(DaNop), ref _DaNop, value); }
        }

        private float? _Diem;
        [XafDisplayName("Điểm")]
        public float? Diem
        {
            get { return _Diem; }
            set { SetPropertyValue(nameof(Diem), ref _Diem, value); }
        }

        private string _Note;
        [XafDisplayName("Ghi Chú")]
        public string Note
        {
            get { return _Note; }
            set { SetPropertyValue<string>(nameof(Note), ref _Note, value); }
        }


    }
}