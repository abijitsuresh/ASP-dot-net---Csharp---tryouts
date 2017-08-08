using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartAppDemo
{
    public partial class Form1 : Form
    {
        private SqlConnection SqlCon;
        private SqlCommand SqlCmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idTextBox.Text);
                //Marks[] marks = null;
                //Marks mark = new Marks();
                int[] marks = new int[5];
                string ConnectionString = "server=.;Initial Catalog=AdventureWorks2016CTP3;Integrated Security=True";
                string Query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM Marks where ID = " + id;
                SqlCon = new SqlConnection(ConnectionString);

                using (var command = new SqlCommand(Query, SqlCon))
                {
                    SqlCon.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        //var list = new List<Marks>();
                        while (reader.Read())
                        {
                            for (int i = 0; i < marks.Length; i++)
                            {
                                marks[i] = reader.GetInt32(i);
                            }
                            //mark = new Marks
                            //{
                            //    Mark1 = reader.GetInt32(0),
                            //    Mark2 = reader.GetInt32(1),
                            //    Mark3 = reader.GetInt32(2),
                            //    Mark4 = reader.GetInt32(3),
                            //    Mark5 = reader.GetInt32(4)
                            //};
                            //list.Add(new Marks()
                            //{
                            //    Mark1 = reader.GetInt32(0),
                            //    Mark2 = reader.GetInt32(1),
                            //    Mark3 = reader.GetInt32(2),
                            //    Mark4 = reader.GetInt32(3),
                            //    Mark5 = reader.GetInt32(4)
                            //});
                            //marks = list.ToArray();
                        }
                    }
                }
                
                //string temp = null;
                chart1.Series["test1"].Points.Clear();
                for (int i = 0; i < 5; i++)
                {
                    //temp += marks[i].ToString() + " ";
                    chart1.Series["test1"].Points.AddXY(i, marks[i]);
                }



                //MessageBox.Show(temp);
                //MessageBox.Show(marks[0].Mark1.ToString());
                //MessageBox.Show(mark.Mark1.ToString());
                //        int[] numArray = new int[] { 3, 5, 2, 8, 6, 11, 1 };

                //    for(int i = 0; i < numArray.Length; i++)
                //    {
                //        chart1.Series["test1"].Points.AddXY(i, numArray[i]);
                //    }

                //    //Random rdn = new Random();
                //    //for (int i = 0; i < 10;i++)
                //    //{
                //    //    chart1.Series["test1"].Points.AddXY
                //    //                    (i+5, i+10);
                //    //}

                //    //chart1.Series["test1"].Points.AddXY(1, 3);
                //    //chart1.Series["test1"].Points.AddXY(3, 4);
                //    //chart1.Series["test1"].Points.AddXY(4, 9);
                //    //chart1.Series["test1"].Points.AddXY(5, 2);
                chart1.Series["test1"].ChartType = SeriesChartType.FastLine;
                chart1.Series["test1"].Color = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    //public class Marks
    //{
    //    public int Mark1 { get; set; }
    //    public int Mark2 { get; set; }
    //    public int Mark3 { get; set; }
    //    public int Mark4 { get; set; }
    //    public int Mark5 { get; set; }

    //}
}
