using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace QLDT.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Giảng Viên")]
    [DefaultProperty("HoVaTen")]
    public class GiangVien : BaseObject
    {
        public GiangVien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _HoDem;
        [XafDisplayName("Họ Đệm")]
        [VisibleInListView(false)]
        public string HoDem
        {
            get { return _HoDem; }
            set
            {
                var isModified = SetPropertyValue<string>(nameof(HoDem), ref _HoDem, value);
                if (isModified && !IsLoading && !IsSaving && !IsDeleted) HanlderNameSort();
            }
        }

        private string _Ten;
        [XafDisplayName("Tên")]
        [VisibleInListView(false)]
        public string Ten
        {
            get { return _Ten; }
            set
            {
                var isModified = SetPropertyValue<string>(nameof(Ten), ref _Ten, value);
                if (isModified && !IsLoading && !IsSaving && !IsDeleted) HanlderNameSort();
            }
        }

        [XafDisplayName("Họ Và Tên")]
        [VisibleInDetailView(false)]
        public string HoVaTen
        {
            get { return string.Format("{0} {1}", HoDem, Ten); }
        }

        private HocVien.Gender _GioiTinh;
        [XafDisplayName("Giới Tính")]
        public HocVien.Gender GioiTinh
        {
            get { return _GioiTinh; }
            set { SetPropertyValue(nameof(GioiTinh), ref _GioiTinh, value); }
        }

        private DateTime _NgaySinh;
        [XafDisplayName("Ngày Sinh")]
        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { SetPropertyValue<DateTime>(nameof(NgaySinh), ref _NgaySinh, value); }
        }

        private string _DiaChi;
        [XafDisplayName("Địa Chỉ")]
        public string DiaChi
        {
            get { return _DiaChi; }
            set { SetPropertyValue<string>(nameof(DiaChi), ref _DiaChi, value); }
        }

        private string _SoDienThoai;
        [XafDisplayName("Số Điện Thoại")]
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { SetPropertyValue<string>(nameof(SoDienThoai), ref _SoDienThoai, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("lhp-gv")]
        [XafDisplayName("Lớp Học Phần")]
        public XPCollection<LopHocPhan> LopHocPhans
        {
            get { return GetCollection<LopHocPhan>(nameof(LopHocPhans)); }
        }

        [Association("ct-gv")]
        [XafDisplayName("Lịch thi")]
        public XPCollection<CaThi> CaThis
        {
            get { return GetCollection<CaThi>(nameof(CaThis)); }
        }

        private string _NameSort;
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public string NameSort
        {
            get { return _NameSort; }
            set { SetPropertyValue<string>(nameof(NameSort), ref _NameSort, value); }
        }

        public void HanlderNameSort()
        {
            if (Ten != null && HoDem != null)
            {
                var sort = string.Join("", HoDem.Trim().Split(" ").Select(d => d[0]));
                NameSort = (Ten + sort).ToUpper();
                NameSort = LoaiDau(NameSort);
                XPCollection<GiangVien> gvs = new XPCollection<GiangVien>(Session,
                    CriteriaOperator.FromLambda<GiangVien>(g => g.NameSort.ToLower().Contains(NameSort)));
                if (gvs != null && gvs.Count > 0)
                {
                    NameSort += gvs.Count;
                }
            }
        }

        public string LoaiDau(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('đ', 'd').Replace('Đ', 'D');
        }

        /*[Action(Caption = "Cập Name Sort", AutoCommit = true)]
        public void ActionMethod()
        {
            XPCollection<GiangVien> khung = new XPCollection<GiangVien>(Session);
            foreach (GiangVien dong in khung)
            {
                dong.HanlderNameSort();
                dong.Save();
            }
        }*/

    }
}