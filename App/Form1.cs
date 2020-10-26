using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace App
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            generateExcel();
        }

        private void btnReadExcel_Click(object sender, EventArgs e)
        {
            readExcel();
        }
        private void numericGradesAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void readExcel()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Seleccione el archivo excel";

            //openFileDialog1.DefaultExt = "xlsx";

            //openFileDialog1.Filter = "Excel Worksheets|*.xls|*.xlsx";
            openFileDialog1.Multiselect = false;

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            //openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    int size = text.Length;
                }
                catch (IOException)
                {
                }
            }

            /*using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"sandbox_test.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    DataTable table = result.Tables[0];
                    DataRow row = table.Rows[0];
                    string cell = row[0].ToString();
                }
            }*/
        }
        private void generateExcel()
        {
            string excelName = txtFileName.Text;
            int studentsAmount = (int) numericStuendsAmount.Value;
            int gradesAmount = (int) numericGradesAmount.Value;
            float minGrade = (float) numericMinGrade.Value;

            float[] randomWeights = generateRandomWeighing(gradesAmount);
            Student[] students = new Student[studentsAmount];
            for(int i = 0; i < studentsAmount; i++)
            {
                students[i] = new Student(gradesAmount);
                students[i].calculateAverage(randomWeights);
                students[i].setAproved(minGrade);
            }

            Excel.Application myExcel = new Excel.Application();
            if (myExcel == null)
            {
                MessageBox.Show("Excel no esta propiamente instalado!!");
                return;
            }

            Excel.Workbook excelBook = myExcel.Workbooks.Add();

            Excel.Worksheet excelSheet = excelBook.Worksheets[1];

            // La primera línea une las celdas y las convierte un en una sola.            
            excelSheet.Range["A1:E1"].Merge();
            // La segunda línea Asigna el nombre del encabezado.
            excelSheet.Range["A1:E1"].Value = "Calificaciones de alumnos";
            // La tercera línea asigna negrita al titulo.
            excelSheet.Range["A1:E1"].Font.Bold = true;
            // La cuarta línea signa un Size a titulo de 15.
            excelSheet.Range["A1:E1"].Font.Size = 15;

            Excel.Range objCell = excelSheet.Range["A3", Type.Missing];


            objCell = excelSheet.Range["A7", Type.Missing];
            objCell.Value = "Alumno";


            char columName = 'B';
            for (int i = 0; i < gradesAmount; i++)
            {
                objCell = excelSheet.Range[columName + "4", Type.Missing];
                objCell.Value = "ω" + (i + 1);
                objCell = excelSheet.Range[columName + "5", Type.Missing];
                objCell.Value = "%" + (randomWeights[i] * 100);
                objCell = excelSheet.Range[columName + "7", Type.Missing];
                objCell.Value = "Nota " + (i + 1);
                columName++;
            }

            objCell = excelSheet.Range[columName + "7", Type.Missing];
            objCell.Value = "Nota final";
            columName++;

            objCell = excelSheet.Range[columName + "4", Type.Missing];
            objCell.Value = "Umbral";
            objCell = excelSheet.Range[columName + "5", Type.Missing];
            objCell.Value = minGrade;
            objCell = excelSheet.Range[columName + "7", Type.Missing];
            objCell.Value = "Aprobado";
            columName++;

            for (int i = 0; i < gradesAmount; i++)
            {
                objCell = excelSheet.Range[columName + "7", Type.Missing];
                objCell.Value = "x" + (i + 1);
                columName++;
            }


            objCell = excelSheet.Range[columName + "7", Type.Missing];
            objCell.Value = "s";
            columName++;

            int rowNumber = 8;
            foreach(Student student in students)
            {
                columName = 'A';
                objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                objCell.Value = (rowNumber - 7);
                columName++;
                foreach (int grade in student.grades)
                {
                    objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                    objCell.Value = grade;
                    columName++;
                }
                objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                objCell.Value = student.finalGrade;
                columName++;
                objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                objCell.Value = (student.isAproved() ? "Verdadero" : "Falso");
                columName++;
                float decimalGrade;
                foreach (int grade in student.grades)
                {
                    objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                    decimalGrade = grade / 10;
                    objCell.Value = decimalGrade;
                    columName++;
                }
                objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                objCell.Value = (student.isAproved() ? 1 : 0);
                rowNumber++;
            }

            myExcel.Visible = true;
        }

        private float[,] generateRandomGrades(int studentsAmount, int gradesAmount)
        {
            float[,] studentsGrades = new float[studentsAmount, gradesAmount];
            Random rdn = new Random();
            for (int i = 0; i < studentsAmount; i++)
            {
                for (int j = 0; j < gradesAmount; j++)
                {
                    studentsGrades[i, j] = rdn.Next(1001) / 100;
                }
            }
            return studentsGrades;
        }

        private float[] generateRandomWeighing(int n)
        {
            float[] randomWeights = new float[n];
            Random rdn = new Random();
            float total = 0;
            for (int i = 0; i < n; i++)
            {
                randomWeights[i] = (float )Math.Round(rdn.NextDouble(), 2);
                total += randomWeights[i];
            }

            for (int i = 0; i < n; i++)
            {
                randomWeights[i] = randomWeights[i] / total;
            }

            return randomWeights;
        }

        private class Student
        {
            public float[] grades;
            public float finalGrade;
            bool aproved;
            public Student(int gradesAmount)
            {
                generateRandomGrades(gradesAmount);
            }
            public Student(float[] grades)
            {
                this.grades = grades;
            }

            public void generateRandomGrades(int gradesAmount)
            {
                grades = new float[gradesAmount];
                Random rdn = new Random();
                for (int i = 0; i < gradesAmount; i++)
                {
                    grades[i] = rdn.Next(1001) / 100;
                }
            }

            public void calculateAverage(float[] weights)
            {
                finalGrade = 0;
                for(int i = 0; i < grades.Length; i++)
                {
                    finalGrade += grades[i] * weights[i];
                }
            }
            public void setAproved(float minGrade)
            {
                aproved = (finalGrade >= minGrade);
            }
            public bool isAproved()
            {
                return aproved;
            }
        }
    }
}
