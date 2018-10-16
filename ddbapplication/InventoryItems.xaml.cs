using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ddbapplication
{
    /// <summary>
    /// Interaction logic for InventoryItems.xaml
    /// </summary>
    public partial class InventoryItems : Window
    {
        public InventoryItems()
        {
            InitializeComponent();
            bindDatagrid();
        }

        private void bindDatagrid()
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=BoutiqueDB; Integrated Security=True;");

            SqlDataAdapter da = new SqlDataAdapter("Select INV1.item_id, item_price, item_desc, quantity from openquery([BOUTIQUENAIROBI], 'select * from boutique.public.inventory1') as INV1 FULL OUTER JOIN openquery([BOUTIQUEMOMBASA], 'select * from boutique.inventory2') as INV2 on INV1.item_id = INV2.item_id ORDER BY item_id ASC", sqlCon);

            DataTable dt = new DataTable("Total");
            da.Fill(dt);


            user_view.ItemsSource = dt.DefaultView;



        }
    }
}
