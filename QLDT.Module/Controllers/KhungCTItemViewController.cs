using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using QLDT.Module.BusinessObjects;

namespace QLDT.Module.Controllers
{
    public partial class KhungCTItemViewController : ObjectViewController<ListView, KhungChuongTrinh>
    {
        public KhungCTItemViewController()
        {
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ListViewProcessCurrentObjectController listProcessController = Frame.GetController<ListViewProcessCurrentObjectController>();
            if (listProcessController != null)
                listProcessController.CustomProcessSelectedItem += ProcessContactListViewRowController_CustomProcessSelectedItem;

        }
        void ProcessContactListViewRowController_CustomProcessSelectedItem(object sender, CustomProcessListViewSelectedItemEventArgs e)
        {
            KhungChuongTrinh current = (KhungChuongTrinh)e.InnerArgs.CurrentObject;
            MonHoc mh = current.MonHocKCT;
            IObjectSpace objectSpace = Application.CreateObjectSpace(mh.GetType());
            e.InnerArgs.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpace, "MonHoc_DetailView", true, objectSpace.GetObject(mh));
            e.Handled = true;

        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            Frame.GetController<ListViewProcessCurrentObjectController>().CustomProcessSelectedItem -= ProcessContactListViewRowController_CustomProcessSelectedItem;
        }
    }
}
