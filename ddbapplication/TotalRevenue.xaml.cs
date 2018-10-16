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
    /// Interaction logic for TotalRevenue.xaml
    /// </summary>
    public partial class TotalRevenue : Window
    {
        public TotalRevenue()
        {
            InitializeComponent();
            bindDatagrid();
        }

        private void bindDatagrid()
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=BoutiqueDB; Integrated Security=True;");

            SqlDataAdapter da = new SqlDataAdapter("Select item_summary.item_id, item_details.item_desc, item_summary.totalrevenue from (Select summary.item_id, sum(summary.revenue) as totalrevenue from (Select * from openquery([BOUTIQUEMOMBASA], 'select * from boutique.sales_made1') UNION Select * from openquery([BOUTIQUENAIROBI], 'select * from boutique.public.sales_made2') UNION Select * from dbo.sales_made3) summary Group by (summary.item_id)) as item_summary INNER JOIN openquery([BOUTIQUENAIROBI], 'select item_id, item_desc from boutique.public.inventory1') as item_details on item_summary.item_id = item_details.item_id", sqlCon);

            DataTable dt = new DataTable("Total");
            da.Fill(dt);


            user_view.ItemsSource = dt.DefaultView;



        }
    }
}
