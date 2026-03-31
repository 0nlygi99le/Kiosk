using KioskByGT.Components.Products;

namespace KioskByGT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void produstList1_ItemClicked(object sender, KioskByGT.Models.Product e)
        {
            pickList.AddItem(e);
        }

        private void pickList_ItemValueChanged(System.Collections.Generic.List<KioskByGT.Components.Picks.PickItem> pickItems)
        {

        }
    }
}
