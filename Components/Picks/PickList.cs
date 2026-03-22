using KioskByGT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Components.Picks
{
    public partial class PickList : UserControl
    {
        private List<PickItem> _pickItems = new();
        public PickList()
        {
            InitializeComponent();
        }

        public void AddItem(Product product)
        {
            // PickItem이 존재하지 않는 경우
            // 상품이 존재하는데 동일 상품을 다시 누르게 되면 다시 담기는 상황이 발생함.
            PickItem pickItem = new PickItem
            {
                ID = product.ID,
                Title = product.Title,
                DefaultPrice = product.Price,
                Image = product.Image!,
                Count = 1,
            };

            _pickItems.Add(pickItem);
            flpnl.Controls.Add(pickItem);   

        }

    }
}
