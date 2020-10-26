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

            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog1.Multiselect = false;

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            //openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileExcel = openFileDialog1.FileName;

                Excel.Application myExcel;
                Excel.Workbook myWorkbook;

                myExcel = new Excel.Application();
                if (myExcel == null)
                {
                    MessageBox.Show("Excel no esta propiamente instalado!!");
                    return;
                }
                myWorkbook = myExcel.Workbooks.Open(fileExcel);
                //myExcel.Visible = true;


                Excel.Worksheet excelSheet = myWorkbook.Worksheets[1];

                float minGrade = searchMinGrade(excelSheet);

                bool excelValid = true;

                Excel.Range objCell;
                string cellValue = "";
                char columName = 'A';
                int rowNumber = 1;
                int studentsCount = 0;
                int gradesCount = 0;
                Student[] studens;
                while (!cellValue.Equals("Alumno"))
                {
                    objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                    cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                    rowNumber++;
                    if (rowNumber > 10)
                    {
                        columName++;
                        rowNumber = 1;
                        if (columName.Equals('E'))
                        {
                            excelValid = false;
                            weightsOutput.AppendText("Excel no cumple con un formato valido1");
                            break;
                        }
                    }
                }
                if (excelValid)
                {
                    int aux = 0;
                    do
                    {
                        studentsCount = aux;
                        objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                        cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                        rowNumber++;
                    }
                    while (int.TryParse(cellValue, out aux));
                    studentsAmountOutput.Value = studentsCount;
                    rowNumber -= (studentsCount + 2);
                }
                studens = new Student[studentsCount];
                //weightsOutput.AppendText(columName + rowNumber.ToString() + ": " + cellValue + "\n");
                while (!cellValue.StartsWith("x"))
                {
                    columName++;
                    objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                    cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                    if (columName.Equals('S'))
                    {
                        excelValid = false;
                        weightsOutput.AppendText("Excel no cumple con un formato valido2");
                        break;
                    }
                }

                char auxColumName = columName;

                if (excelValid)
                {
                    while (cellValue.StartsWith("x"))
                    {
                        gradesCount++;
                        auxColumName++;
                        objCell = excelSheet.Range[auxColumName + rowNumber.ToString(), Type.Missing];
                        cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                    }
                }
                rowNumber++;
                int auxRowNumber = rowNumber;
                if (excelValid)
                {
                    float[] grades;
                    for (int i = 0; i < studentsCount; i++){
                        grades = new float[gradesCount];
                        auxColumName = columName;
                        for (int j = 0; j < gradesCount; j++)
                        {
                            objCell = excelSheet.Range[auxColumName + auxRowNumber.ToString(), Type.Missing];
                            cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                            if(!float.TryParse(cellValue, out grades[j]))
                            {
                                excelValid = false;
                                break;
                            }
                            auxColumName++;
                        }
                        studens[i] = new Student(grades);
                        objCell = excelSheet.Range[auxColumName + auxRowNumber.ToString(), Type.Missing];
                        cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                        studens[i].setAproved(cellValue.Equals("1"));
                        auxRowNumber++;
                    }
                }
                if (excelValid)
                {
                    foreach (Student student in studens)
                    {
                        //weightsOutput.AppendText("Estudiante:      ");
                        foreach (float grade in student.grades)
                        {
                            //weightsOutput.AppendText("Nota: " + grade + " ");
                        }
                       // weightsOutput.AppendText("Aprobado: " + student.isAproved() + "\n");
                    }
                    calculateWeihgtsPosibilities(studens, minGrade);
                }
            }
            else
            {
                return;
            }
        }
        private float searchMinGrade(Excel.Worksheet excelSheet)
        {
            float minGrade = 0;

            bool excelValid = true;

            Excel.Range objCell;
            string cellValue = "";
            char columName = 'A';
            int rowNumber = 1;
            while (!cellValue.Equals("Umbral"))
            {
                objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                rowNumber++;
                if (rowNumber > 10)
                {
                    columName++;
                    rowNumber = 1;
                    if (columName.Equals('P'))
                    {
                        excelValid = false;
                        //weightsOutput.ResetText();
                        weightsOutput.AppendText("Excel no cumple con un formato valido");
                        break;
                    }
                }
            }
            if (excelValid)
            {
                objCell = excelSheet.Range[columName + rowNumber.ToString(), Type.Missing];
                cellValue = objCell.Value == null ? "" : objCell.Value.ToString();
                float.TryParse(cellValue, out minGrade);
                //weightsOutput.AppendText(cellValue + "\n");
                minGradeOutput.Value = (decimal)minGrade;
            }
            return minGrade;
        }

        private void calculateWeihgtsPosibilities(Student[] students, float minGrade)
        {
            int gradesAmount = students[0].grades.Length;
            gradesAmountOutput.Value = gradesAmount;
            float[] weihgts = new float[gradesAmount];

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
            excelSheet.Range["A1:E1"].Value = "Pesos y umbral";
            // La tercera línea asigna negrita al titulo.
            excelSheet.Range["A1:E1"].Font.Bold = true;
            // La cuarta línea signa un Size a titulo de 15.
            excelSheet.Range["A1:E1"].Font.Size = 15;
            excelSheet.Range["A1:E1"].Font.Color = Color.Blue;

            Excel.Range objCell;


            objCell = excelSheet.Range["G1", Type.Missing];
            objCell.Value = "U";
            objCell = excelSheet.Range["G2", Type.Missing];
            objCell.Value = minGrade.ToString();


            char columName = 'A';
            int rowNumber = 4;
            for(int i = 0; i < gradesAmount; i++)
            {
                columName++;
            }
            columName++;

            printPosibleWeights(excelSheet, gradesAmount, gradesAmount + 2, rowNumber);
            printPosibleWeights(excelSheet, gradesAmount, gradesAmount + 102, rowNumber);
            printPosibleWeights(excelSheet, gradesAmount, gradesAmount + 202, rowNumber);
            rowNumber += 2;
            printHeadersPosible(excelSheet, gradesAmount, gradesAmount + 1, rowNumber);
            int columNumber = 1;
            int auxColumNumber;
            decimal cellValue;
            foreach (Student student in students)
            {
                auxColumNumber = columNumber;
                //decimal cellValue; 

                rowNumber++;
                cellValue = ((decimal)((decimal)student.grades[0] / 10m));
                excelSheet.Cells[rowNumber, auxColumNumber] = cellValue.ToString();
                auxColumNumber++;
                cellValue = ((decimal)((decimal)student.grades[1] / 10m));
                excelSheet.Cells[rowNumber, auxColumNumber] = cellValue.ToString();
                auxColumNumber++;
                cellValue = (student.isAproved() ? 1m : 0m);
                excelSheet.Cells[rowNumber, auxColumNumber] = cellValue.ToString();
                auxColumNumber++;
                for (int i = 0; i < 101; i++)
                {

                    cellValue = ((decimal)((decimal) student.grades[0] / 10m) * ((100m - ((decimal)i)) / 100m)) + ((decimal)((decimal)student.grades[1] / 10m) * (((decimal)i) / 100m));
                    excelSheet.Cells[rowNumber, auxColumNumber] = cellValue.ToString();
                    cellValue = ((Decimal.Compare(cellValue, ((decimal) minGrade / 10m)) < 0) ? 0m : 1m);
                    excelSheet.Cells[rowNumber, auxColumNumber + 101] = cellValue.ToString();
                    cellValue = ((Decimal.Compare(cellValue, (student.isAproved() ? 1m : 0m)) == 0) ? 1m : 0m);
                    excelSheet.Cells[rowNumber, auxColumNumber + 202] = cellValue.ToString();

                    auxColumNumber++;
                };
            }

            myExcel.Visible = true;
        }
        private void printPosibleWeights(Excel.Worksheet excelSheet, int gradesAmount, int columNumber, int rowNumber)
        {
            /*
             * Excel.Intersect(worksheet.Range["1:1"], worksheet.UsedRange).Style.Orientation = Excel.XlOrientation.xlUpwards;
             * just the cells, not the style
             * Excel.Intersect(worksheet.Range["1:1"], worksheet.UsedRange).Cells.Orientation = Excel.XlOrientation.xlUpwards;
            */
            int auxColumNumber = columNumber;
            decimal cellValue;
            for (int i = 0; i < 101; i++)
            {
                cellValue = ((100m - ((decimal)i)) / 100m);
                excelSheet.Cells[rowNumber, auxColumNumber] = "ω1 = " + cellValue.ToString();
                auxColumNumber++;
            };
            auxColumNumber = columNumber;
            rowNumber++;
            for (int i = 0; i < 101; i++)
            {
                cellValue = (((decimal)i) / 100m);
                excelSheet.Cells[rowNumber, auxColumNumber] = "ω2 = " + cellValue.ToString();
                auxColumNumber++;
            };
        }
        private void printHeadersPosible(Excel.Worksheet excelSheet, int gradesAmount, int columNumber, int rowNumber)
        {
            int auxColumNumber = columNumber;
            for (int i = 0; i < gradesAmount; i++)
            {
                excelSheet.Cells[rowNumber, auxColumNumber- gradesAmount] = "x" + (i + 1);
                auxColumNumber++;
            }
            auxColumNumber = columNumber;
            excelSheet.Cells[rowNumber, auxColumNumber] = "s";
            auxColumNumber++;
            for (int i = 0; i < 101; i++)
            {
                excelSheet.Cells[rowNumber, auxColumNumber] = "n" + (i + 1);
                auxColumNumber++;
            }
            for (int i = 0; i < 101; i++)
            {
                excelSheet.Cells[rowNumber, auxColumNumber] = "y" + (i + 1);
                auxColumNumber++;
            }
            for (int i = 0; i < 101; i++)
            {
                excelSheet.Cells[rowNumber, auxColumNumber] = "e" + (i + 1);
                auxColumNumber++;
            }
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
                    decimalGrade = (float) Math.Round((grade / 10f), 4);
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
            public void setAproved(bool aproved)
            {
                this.aproved = aproved;
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
