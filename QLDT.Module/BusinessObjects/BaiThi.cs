using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BaiThi : BaseObject
    { 
        public BaiThi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private DanhSachThi _SoBaoDanh;
        public DanhSachThi SoBaoDanh
        {
            get { return _SoBaoDanh; }
            set { SetPropertyValue<DanhSachThi>(nameof(SoBaoDanh), ref _SoBaoDanh, value); }
        }

        private NganHangDe _CauHoi;
        public NganHangDe CauHoi
        {
            get { return _CauHoi; }
            set { SetPropertyValue<NganHangDe>(nameof(CauHoi), ref _CauHoi, value); }
        }

        private int _CauSo;
        public int CauSo
        {
            get { return _CauSo; }
            set { SetPropertyValue<int>(nameof(CauSo), ref _CauSo, value); }
        }

        private DapAn _DapAnCuaSV;
        public DapAn DapAnCuaSV
        {
            get { return _DapAnCuaSV; }
            set { SetPropertyValue<DapAn>(nameof(DapAnCuaSV), ref _DapAnCuaSV, value); }
        }

        private float? _Diem;
        public float? Diem
        {
            get { return _Diem; }
            set { SetPropertyValue<float?>(nameof(Diem), ref _Diem, value); }
        }


    }
}