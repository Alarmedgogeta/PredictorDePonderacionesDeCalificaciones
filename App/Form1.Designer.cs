namespace App
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPane = new System.Windows.Forms.Panel();
            this.mainMenuPane = new System.Windows.Forms.SplitContainer();
            this.numericMinGrade = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericGradesAmount = new System.Windows.Forms.NumericUpDown();
            this.randomWeighing = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericStuendsAmount = new System.Windows.Forms.NumericUpDown();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateExcel = new System.Windows.Forms.Button();
            this.paneReadOutput = new System.Windows.Forms.Panel();
            this.weightsOutput = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.minGradeOutput = new System.Windows.Forms.NumericUpDown();
            this.studentsAmountOutput = new System.Windows.Forms.NumericUpDown();
            this.gradesAmountOutput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReadExcel = new System.Windows.Forms.Button();
            this.mainPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuPane)).BeginInit();
            this.mainMenuPane.Panel1.SuspendLayout();
            this.mainMenuPane.Panel2.SuspendLayout();
            this.mainMenuPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStuendsAmount)).BeginInit();
            this.paneReadOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minGradeOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsAmountOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradesAmountOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.BackColor = System.Drawing.SystemColors.Control;
            this.mainPane.Controls.Add(this.mainMenuPane);
            this.mainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Margin = new System.Windows.Forms.Padding(4);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(604, 461);
            this.mainPane.TabIndex = 0;
            // 
            // mainMenuPane
            // 
            this.mainMenuPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuPane.IsSplitterFixed = true;
            this.mainMenuPane.Location = new System.Drawing.Point(0, 0);
            this.mainMenuPane.Margin = new System.Windows.Forms.Padding(4);
            this.mainMenuPane.Name = "mainMenuPane";
            // 
            // mainMenuPane.Panel1
            // 
            this.mainMenuPane.Panel1.Controls.Add(this.numericMinGrade);
            this.mainMenuPane.Panel1.Controls.Add(this.label4);
            this.mainMenuPane.Panel1.Controls.Add(this.panel1);
            this.mainMenuPane.Panel1.Controls.Add(this.numericGradesAmount);
            this.mainMenuPane.Panel1.Controls.Add(this.randomWeighing);
            this.mainMenuPane.Panel1.Controls.Add(this.label3);
            this.mainMenuPane.Panel1.Controls.Add(this.label2);
            this.mainMenuPane.Panel1.Controls.Add(this.numericStuendsAmount);
            this.mainMenuPane.Panel1.Controls.Add(this.txtFileName);
            this.mainMenuPane.Panel1.Controls.Add(this.label1);
            this.mainMenuPane.Panel1.Controls.Add(this.btnGenerateExcel);
            this.mainMenuPane.Panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // mainMenuPane.Panel2
            // 
            this.mainMenuPane.Panel2.Controls.Add(this.paneReadOutput);
            this.mainMenuPane.Panel2.Controls.Add(this.btnReadExcel);
            this.mainMenuPane.Size = new System.Drawing.Size(604, 461);
            this.mainMenuPane.SplitterDistance = 285;
            this.mainMenuPane.SplitterWidth = 1;
            this.mainMenuPane.TabIndex = 0;
            this.mainMenuPane.Text = "splitContainer1";
            // 
            // numericMinGrade
            // 
            this.numericMinGrade.Location = new System.Drawing.Point(148, 229);
            this.numericMinGrade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinGrade.Name = "numericMinGrade";
            this.numericMinGrade.Size = new System.Drawing.Size(100, 25);
            this.numericMinGrade.TabIndex = 4;
            this.numericMinGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericMinGrade.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 43);
            this.label4.TabIndex = 2;
            this.label4.Text = "Calificacion minima aprobatoria:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 154);
            this.panel1.TabIndex = 6;
            // 
            // numericGradesAmount
            // 
            this.numericGradesAmount.Location = new System.Drawing.Point(148, 172);
            this.numericGradesAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGradesAmount.Name = "numericGradesAmount";
            this.numericGradesAmount.Size = new System.Drawing.Size(100, 25);
            this.numericGradesAmount.TabIndex = 4;
            this.numericGradesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericGradesAmount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericGradesAmount.ValueChanged += new System.EventHandler(this.numericGradesAmount_ValueChanged);
            // 
            // randomWeighing
            // 
            this.randomWeighing.AutoSize = true;
            this.randomWeighing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.randomWeighing.Checked = true;
            this.randomWeighing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomWeighing.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.randomWeighing.Location = new System.Drawing.Point(50, 280);
            this.randomWeighing.Name = "randomWeighing";
            this.randomWeighing.Size = new System.Drawing.Size(181, 21);
            this.randomWeighing.TabIndex = 5;
            this.randomWeighing.Text = "Ponderaciones aleatorias";
            this.randomWeighing.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(42, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad de calificaciones:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de alumnos:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericStuendsAmount
            // 
            this.numericStuendsAmount.Location = new System.Drawing.Point(148, 130);
            this.numericStuendsAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericStuendsAmount.Name = "numericStuendsAmount";
            this.numericStuendsAmount.Size = new System.Drawing.Size(100, 25);
            this.numericStuendsAmount.TabIndex = 4;
            this.numericStuendsAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericStuendsAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(148, 67);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 25);
            this.txtFileName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(80, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGenerateExcel
            // 
            this.btnGenerateExcel.BackColor = System.Drawing.Color.Aquamarine;
            this.btnGenerateExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateExcel.Location = new System.Drawing.Point(0, 0);
            this.btnGenerateExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateExcel.Name = "btnGenerateExcel";
            this.btnGenerateExcel.Size = new System.Drawing.Size(285, 42);
            this.btnGenerateExcel.TabIndex = 1;
            this.btnGenerateExcel.Text = "Generar Excel";
            this.btnGenerateExcel.UseVisualStyleBackColor = false;
            this.btnGenerateExcel.Click += new System.EventHandler(this.btnGenerateExcel_Click);
            // 
            // paneReadOutput
            // 
            this.paneReadOutput.Controls.Add(this.weightsOutput);
            this.paneReadOutput.Controls.Add(this.label8);
            this.paneReadOutput.Controls.Add(this.label7);
            this.paneReadOutput.Controls.Add(this.minGradeOutput);
            this.paneReadOutput.Controls.Add(this.studentsAmountOutput);
            this.paneReadOutput.Controls.Add(this.gradesAmountOutput);
            this.paneReadOutput.Controls.Add(this.label6);
            this.paneReadOutput.Controls.Add(this.label5);
            this.paneReadOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneReadOutput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.paneReadOutput.Location = new System.Drawing.Point(0, 42);
            this.paneReadOutput.Name = "paneReadOutput";
            this.paneReadOutput.Size = new System.Drawing.Size(318, 419);
            this.paneReadOutput.TabIndex = 2;
            // 
            // weightsOutput
            // 
            this.weightsOutput.Location = new System.Drawing.Point(5, 275);
            this.weightsOutput.Name = "weightsOutput";
            this.weightsOutput.ReadOnly = true;
            this.weightsOutput.Size = new System.Drawing.Size(310, 105);
            this.weightsOutput.TabIndex = 6;
            this.weightsOutput.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(88, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ponderaciones posibles:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(9, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 43);
            this.label7.TabIndex = 2;
            this.label7.Text = "Calificacion minima aprobatoria:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minGradeOutput
            // 
            this.minGradeOutput.Enabled = false;
            this.minGradeOutput.Location = new System.Drawing.Point(145, 187);
            this.minGradeOutput.Name = "minGradeOutput";
            this.minGradeOutput.ReadOnly = true;
            this.minGradeOutput.Size = new System.Drawing.Size(100, 25);
            this.minGradeOutput.TabIndex = 4;
            this.minGradeOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // studentsAmountOutput
            // 
            this.studentsAmountOutput.Enabled = false;
            this.studentsAmountOutput.Location = new System.Drawing.Point(145, 88);
            this.studentsAmountOutput.Name = "studentsAmountOutput";
            this.studentsAmountOutput.ReadOnly = true;
            this.studentsAmountOutput.Size = new System.Drawing.Size(100, 25);
            this.studentsAmountOutput.TabIndex = 4;
            this.studentsAmountOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gradesAmountOutput
            // 
            this.gradesAmountOutput.Enabled = false;
            this.gradesAmountOutput.Location = new System.Drawing.Point(145, 130);
            this.gradesAmountOutput.Name = "gradesAmountOutput";
            this.gradesAmountOutput.ReadOnly = true;
            this.gradesAmountOutput.Size = new System.Drawing.Size(100, 25);
            this.gradesAmountOutput.TabIndex = 4;
            this.gradesAmountOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gradesAmountOutput.ValueChanged += new System.EventHandler(this.numericGradesAmount_ValueChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(47, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 41);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cantidad de alumnos:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(39, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 43);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cantidad de calificaciones:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReadExcel
            // 
            this.btnReadExcel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnReadExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReadExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadExcel.Location = new System.Drawing.Point(0, 0);
            this.btnReadExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadExcel.Name = "btnReadExcel";
            this.btnReadExcel.Size = new System.Drawing.Size(318, 42);
            this.btnReadExcel.TabIndex = 1;
            this.btnReadExcel.Text = "Leer Excel";
            this.btnReadExcel.UseVisualStyleBackColor = false;
            this.btnReadExcel.Click += new System.EventHandler(this.btnReadExcel_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.mainPane);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Predictor de Ponderaciones";
            this.mainPane.ResumeLayout(false);
            this.mainMenuPane.Panel1.ResumeLayout(false);
            this.mainMenuPane.Panel1.PerformLayout();
            this.mainMenuPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuPane)).EndInit();
            this.mainMenuPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMinGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStuendsAmount)).EndInit();
            this.paneReadOutput.ResumeLayout(false);
            this.paneReadOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minGradeOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsAmountOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradesAmountOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPane;
        private System.Windows.Forms.SplitContainer mainMenuPane;
        private System.Windows.Forms.Button btnGenerateExcel;
        private System.Windows.Forms.Button btnReadExcel;
        private System.Windows.Forms.Panel paneReadOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericStuendsAmount;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericMinGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericGradesAmount;
        private System.Windows.Forms.CheckBox randomWeighing;
        private System.Windows.Forms.RichTextBox weightsOutput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown minGradeOutput;
        private System.Windows.Forms.NumericUpDown studentsAmountOutput;
        private System.Windows.Forms.NumericUpDown gradesAmountOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

