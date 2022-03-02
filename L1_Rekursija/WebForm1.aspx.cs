using System;
using System.Drawing;
using System.Web.UI.WebControls;
using L1_Rekursija.Methods;

namespace L1_Rekursija
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string primaryDataFile = "dataIn.txt";
        private string resultsFile = "dataOut.txt";
        private string dataPath = "/Data/";
        protected void Page_Load(object sender, EventArgs e)
        {
           Matrix matr = InOut.ReadFile(Server.MapPath(dataPath + resultsFile));
           if(matr != null)
            {
                FillTable(matr);
                Label1.Text = "Radius: " + matr.GetArraySize()/2;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dataFromTextBox = TextBox1.Text;
            int radiusValidated = TaskUtils.NumberValidation(dataFromTextBox);
            if (radiusValidated > 0)
            {
                //Prints primary data (radius)
                InOut.PrintToFile(Server.MapPath(dataPath + primaryDataFile), null, radiusValidated);

                Matrix data = new Matrix(radiusValidated);
                if (data != null)
                {
                    Label1.Text = "Radius: " + radiusValidated;
                    double errorOffSet = 0.5;
                    double centerX = radiusValidated - errorOffSet;
                    double centerY = radiusValidated - errorOffSet;
                    int n = 0, x = 0, y = 0;

                    data.UpdateMatrix(radiusValidated, n, centerX, centerY, x, y, errorOffSet);

                    //Prints results to file
                    InOut.PrintToFile(Server.MapPath(dataPath + resultsFile), data, radiusValidated);
                    Response.Redirect(Request.RawUrl);
                }
                else return;
            }   
            else
            {
                Label1.Text = "Invalid radius..";
                Table1.Rows.Clear();
                InOut.DeleteFile(Server.MapPath(dataPath + resultsFile));
                InOut.DeleteFile(Server.MapPath(dataPath + primaryDataFile));
                return;
            }
        }

        /// <summary>
        /// Fills Table1 with data from Matrix
        /// </summary>
        /// <param name="matrix">Matrix</param>
        protected void FillTable(Matrix matrix)
        {
            //Table1.Rows.Clear();
            for (int i = 0; i < matrix.GetArraySize(); i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < matrix.GetArraySize(); j++)
                {
                    TableCell TableX = new TableCell();
                    TableX.Text = matrix[i, j].ToString();

                    if(TableX.Text != "0")
                        TableX.BackColor = Color.Red;

                    row.Cells.Add(TableX);
                }
                Table1.Rows.Add(row);
            }
        }

    }
}