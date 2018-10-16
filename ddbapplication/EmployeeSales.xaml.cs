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
    /// Interaction logic for EmployeeSales.xaml
    /// </summary>
    public partial class EmployeeSales : Window
    {
        public EmployeeSales()
        {
            InitializeComponent();
            bindDatagrid();
        }

        private void bindDatagrid()
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=BoutiqueDB; Integrated Security=True;");

            SqlDataAdapter da = new SqlDataAdapter("Select employee_details.emp_name, employee_details.emp_role, item_summary.totalrevenue, employee_details.emp_location from (Select sum(summary.revenue) as totalrevenue, summary.emp_id from (Select * from openquery([BOUTIQUEMOMBASA], 'select * from boutique.sales_made1') UNION Select * from openquery([BOUTIQUENAIROBI], 'select * from boutique.public.sales_made2') UNION Select * from dbo.sales_made3) summary Group by(summary.emp_id)) as item_summary INNER JOIN (Select * from openquery([BOUTIQUENAIROBI], 'select * from boutique.public.employee1') UNION Select * from openquery([BOUTIQUEMOMBASA], 'select * from boutique.employee3') UNION Select * from dbo.employee2) as employee_details on item_summary.emp_id = employee_details.emp_id ORDER BY totalrevenue DESC", sqlCon);

            DataTable dt = new DataTable("Total");
            da.Fill(dt);


            user_view.ItemsSource = dt.DefaultView;



        }


    }
}
