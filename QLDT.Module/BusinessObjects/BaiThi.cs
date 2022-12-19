using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class BaiThi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public BaiThi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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


        private int _Diem;
        public int Diem
        {
            get { return _Diem; }
            set { SetPropertyValue<int>(nameof(Diem), ref _Diem, value); }
        }


    }
}