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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        public Employees()
        {
            InitializeComponent();
            bindDatagrid();
        }

        private void bindDatagrid()
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.; Initial Catalog=BoutiqueDB; Integrated Security=True;");

            SqlDataAdapter da = new SqlDataAdapter("Select * from openquery([BOUTIQUENAIROBI], 'select * from boutique.public.employee1') UNION Select * from openquery([BOUTIQUEMOMBASA], 'select * from boutique.employee3') UNION Select * from dbo.employee2 ORDER by emp_id ASC", sqlCon);

            DataTable dt = new DataTable("Total");
            da.Fill(dt);


            user_view.ItemsSource = dt.DefaultView;



        }
    }
}
