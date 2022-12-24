﻿using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Khóa Học")]
    [DefaultProperty("TenKhoaHoc")]
    public class KhoaHoc : BaseObject
    {
        public KhoaHoc(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [XafDisplayName("Tên Khoá Học")]
        public string TenKhoaHoc
        {
            get { return String.Format("{0}({1})",CTDT.TenChuongTrinh,NgayBatDau); }
        }

        private DateTime _NgayBatDau;
        [XafDisplayName("Ngày Bắt Đầu")]
        public DateTime NgayBatDau
        {
            get { return _NgayBatDau; }
            set { SetPropertyValue<DateTime>(nameof(NgayBatDau), ref _NgayBatDau, value); }
        }

        private DateTime _NgayKetThuc;
        [XafDisplayName("Ngày Kết Thúc")]
        public DateTime NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { SetPropertyValue<DateTime>(nameof(NgayKetThuc), ref _NgayKetThuc, value); }
        }

        private ChuongTrinhDaoTao _CTDT;
        [XafDisplayName("Chương trình đào tạo")]
        [Association("kh-ctdt")]
        public ChuongTrinhDaoTao CTDT
        {
            get { return _CTDT; }
            set { SetPropertyValue<ChuongTrinhDaoTao>(nameof(CTDT), ref _CTDT, value); }
        }

        [XafDisplayName("Học Viên")]
        [Association("dkh-kh")]
        public XPCollection<DangKyHoc> HocViens
        {
            get { return GetCollection<DangKyHoc>(nameof(HocViens)); }
        }

        [Association("lhp-kh")]
        public XPCollection<LopHocPhan> LopHocPhans
        {
            get { return GetCollection<LopHocPhan>(nameof(LopHocPhans)); }
        }


        [XafDisplayName("Số HV")]
        [ReadOnly(true)]
        public int? SoHV
        {
            get
            {
                return HocViens?.Count;
            }
        }
    }
}