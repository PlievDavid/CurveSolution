
namespace CurveSolution
{
    partial class FormEquation
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSolve = new System.Windows.Forms.Button();
            this.textBoxEquation = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.radioButtonAPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonAMinus = new System.Windows.Forms.RadioButton();
            this.groupBoxA = new System.Windows.Forms.GroupBox();
            this.groupBoxB = new System.Windows.Forms.GroupBox();
            this.radioButtonBPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonBMinus = new System.Windows.Forms.RadioButton();
            this.groupBoxC = new System.Windows.Forms.GroupBox();
            this.radioButtonCPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonCMinus = new System.Windows.Forms.RadioButton();
            this.groupBoxD = new System.Windows.Forms.GroupBox();
            this.radioButtonDPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonDMinus = new System.Windows.Forms.RadioButton();
            this.groupBoxE = new System.Windows.Forms.GroupBox();
            this.radioButtonEPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonEMinus = new System.Windows.Forms.RadioButton();
            this.groupBoxF = new System.Windows.Forms.GroupBox();
            this.radioButtonFPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonFMinus = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxA.SuspendLayout();
            this.groupBoxB.SuspendLayout();
            this.groupBoxC.SuspendLayout();
            this.groupBoxD.SuspendLayout();
            this.groupBoxE.SuspendLayout();
            this.groupBoxF.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSolve.Location = new System.Drawing.Point(377, 346);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(141, 59);
            this.buttonSolve.TabIndex = 0;
            this.buttonSolve.Text = "Решить";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // textBoxEquation
            // 
            this.textBoxEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEquation.Location = new System.Drawing.Point(-4, 293);
            this.textBoxEquation.Name = "textBoxEquation";
            this.textBoxEquation.ReadOnly = true;
            this.textBoxEquation.Size = new System.Drawing.Size(928, 35);
            this.textBoxEquation.TabIndex = 1;
            this.textBoxEquation.Text = "1 x^2 + 1 x*y + 1 y^2 + 1 x + 1 y + 1 = 0\r\n";
            this.textBoxEquation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(39, 109);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(100, 20);
            this.textBoxA.TabIndex = 2;
            this.textBoxA.Text = "1";
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(617, 109);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(100, 20);
            this.textBoxE.TabIndex = 3;
            this.textBoxE.Text = "1";
            this.textBoxE.TextChanged += new System.EventHandler(this.textBoxE_TextChanged);
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(478, 109);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(100, 20);
            this.textBoxD.TabIndex = 4;
            this.textBoxD.Text = "1";
            this.textBoxD.TextChanged += new System.EventHandler(this.textBoxD_TextChanged);
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(341, 109);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(100, 20);
            this.textBoxC.TabIndex = 5;
            this.textBoxC.Text = "1";
            this.textBoxC.TextChanged += new System.EventHandler(this.textBoxC_TextChanged);
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(191, 109);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(100, 20);
            this.textBoxB.TabIndex = 6;
            this.textBoxB.Text = "1";
            this.textBoxB.TextChanged += new System.EventHandler(this.textBoxB_TextChanged);
            // 
            // textBoxF
            // 
            this.textBoxF.Location = new System.Drawing.Point(762, 109);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(100, 20);
            this.textBoxF.TabIndex = 7;
            this.textBoxF.Text = "1";
            this.textBoxF.TextChanged += new System.EventHandler(this.textBoxF_TextChanged);
            // 
            // radioButtonAPlus
            // 
            this.radioButtonAPlus.AutoSize = true;
            this.radioButtonAPlus.Checked = true;
            this.radioButtonAPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAPlus.Location = new System.Drawing.Point(6, 23);
            this.radioButtonAPlus.Name = "radioButtonAPlus";
            this.radioButtonAPlus.Size = new System.Drawing.Size(39, 28);
            this.radioButtonAPlus.TabIndex = 8;
            this.radioButtonAPlus.TabStop = true;
            this.radioButtonAPlus.Text = "+";
            this.radioButtonAPlus.UseVisualStyleBackColor = true;
            this.radioButtonAPlus.CheckedChanged += new System.EventHandler(this.radioButtonAPlus_CheckedChanged);
            // 
            // radioButtonAMinus
            // 
            this.radioButtonAMinus.AutoSize = true;
            this.radioButtonAMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAMinus.Location = new System.Drawing.Point(6, 58);
            this.radioButtonAMinus.Name = "radioButtonAMinus";
            this.radioButtonAMinus.Size = new System.Drawing.Size(34, 28);
            this.radioButtonAMinus.TabIndex = 9;
            this.radioButtonAMinus.Text = "-";
            this.radioButtonAMinus.UseVisualStyleBackColor = true;
            // 
            // groupBoxA
            // 
            this.groupBoxA.Controls.Add(this.radioButtonAPlus);
            this.groupBoxA.Controls.Add(this.radioButtonAMinus);
            this.groupBoxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxA.Location = new System.Drawing.Point(39, 158);
            this.groupBoxA.Name = "groupBoxA";
            this.groupBoxA.Size = new System.Drawing.Size(67, 100);
            this.groupBoxA.TabIndex = 20;
            this.groupBoxA.TabStop = false;
            this.groupBoxA.Text = "Знак";
            // 
            // groupBoxB
            // 
            this.groupBoxB.Controls.Add(this.radioButtonBPlus);
            this.groupBoxB.Controls.Add(this.radioButtonBMinus);
            this.groupBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxB.Location = new System.Drawing.Point(191, 158);
            this.groupBoxB.Name = "groupBoxB";
            this.groupBoxB.Size = new System.Drawing.Size(67, 100);
            this.groupBoxB.TabIndex = 21;
            this.groupBoxB.TabStop = false;
            this.groupBoxB.Text = "Знак";
            // 
            // radioButtonBPlus
            // 
            this.radioButtonBPlus.AutoSize = true;
            this.radioButtonBPlus.Checked = true;
            this.radioButtonBPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonBPlus.Location = new System.Drawing.Point(6, 23);
            this.radioButtonBPlus.Name = "radioButtonBPlus";
            this.radioButtonBPlus.Size = new System.Drawing.Size(39, 28);
            this.radioButtonBPlus.TabIndex = 8;
            this.radioButtonBPlus.TabStop = true;
            this.radioButtonBPlus.Text = "+";
            this.radioButtonBPlus.UseVisualStyleBackColor = true;
            this.radioButtonBPlus.CheckedChanged += new System.EventHandler(this.radioButtonBPlus_CheckedChanged);
            // 
            // radioButtonBMinus
            // 
            this.radioButtonBMinus.AutoSize = true;
            this.radioButtonBMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonBMinus.Location = new System.Drawing.Point(6, 58);
            this.radioButtonBMinus.Name = "radioButtonBMinus";
            this.radioButtonBMinus.Size = new System.Drawing.Size(34, 28);
            this.radioButtonBMinus.TabIndex = 9;
            this.radioButtonBMinus.Text = "-";
            this.radioButtonBMinus.UseVisualStyleBackColor = true;
            // 
            // groupBoxC
            // 
            this.groupBoxC.Controls.Add(this.radioButtonCPlus);
            this.groupBoxC.Controls.Add(this.radioButtonCMinus);
            this.groupBoxC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxC.Location = new System.Drawing.Point(341, 158);
            this.groupBoxC.Name = "groupBoxC";
            this.groupBoxC.Size = new System.Drawing.Size(67, 100);
            this.groupBoxC.TabIndex = 21;
            this.groupBoxC.TabStop = false;
            this.groupBoxC.Text = "Знак";
            // 
            // radioButtonCPlus
            // 
            this.radioButtonCPlus.AutoSize = true;
            this.radioButtonCPlus.Checked = true;
            this.radioButtonCPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonCPlus.Location = new System.Drawing.Point(6, 23);
            this.radioButtonCPlus.Name = "radioButtonCPlus";
            this.radioButtonCPlus.Size = new System.Drawing.Size(39, 28);
            this.radioButtonCPlus.TabIndex = 8;
            this.radioButtonCPlus.TabStop = true;
            this.radioButtonCPlus.Text = "+";
            this.radioButtonCPlus.UseVisualStyleBackColor = true;
            this.radioButtonCPlus.CheckedChanged += new System.EventHandler(this.radioButtonCPlus_CheckedChanged);
            // 
            // radioButtonCMinus
            // 
            this.radioButtonCMinus.AutoSize = true;
            this.radioButtonCMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonCMinus.Location = new System.Drawing.Point(6, 58);
            this.radioButtonCMinus.Name = "radioButtonCMinus";
            this.radioButtonCMinus.Size = new System.Drawing.Size(34, 28);
            this.radioButtonCMinus.TabIndex = 9;
            this.radioButtonCMinus.Text = "-";
            this.radioButtonCMinus.UseVisualStyleBackColor = true;
            // 
            // groupBoxD
            // 
            this.groupBoxD.Controls.Add(this.radioButtonDPlus);
            this.groupBoxD.Controls.Add(this.radioButtonDMinus);
            this.groupBoxD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxD.Location = new System.Drawing.Point(478, 158);
            this.groupBoxD.Name = "groupBoxD";
            this.groupBoxD.Size = new System.Drawing.Size(67, 100);
            this.groupBoxD.TabIndex = 22;
            this.groupBoxD.TabStop = false;
            this.groupBoxD.Text = "Знак";
            // 
            // radioButtonDPlus
            // 
            this.radioButtonDPlus.AutoSize = true;
            this.radioButtonDPlus.Checked = true;
            this.radioButtonDPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDPlus.Location = new System.Drawing.Point(6, 23);
            this.radioButtonDPlus.Name = "radioButtonDPlus";
            this.radioButtonDPlus.Size = new System.Drawing.Size(39, 28);
            this.radioButtonDPlus.TabIndex = 8;
            this.radioButtonDPlus.TabStop = true;
            this.radioButtonDPlus.Text = "+";
            this.radioButtonDPlus.UseVisualStyleBackColor = true;
            this.radioButtonDPlus.CheckedChanged += new System.EventHandler(this.radioButtonDPlus_CheckedChanged);
            // 
            // radioButtonDMinus
            // 
            this.radioButtonDMinus.AutoSize = true;
            this.radioButtonDMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonDMinus.Location = new System.Drawing.Point(6, 58);
            this.radioButtonDMinus.Name = "radioButtonDMinus";
            this.radioButtonDMinus.Size = new System.Drawing.Size(34, 28);
            this.radioButtonDMinus.TabIndex = 9;
            this.radioButtonDMinus.Text = "-";
            this.radioButtonDMinus.UseVisualStyleBackColor = true;
            // 
            // groupBoxE
            // 
            this.groupBoxE.Controls.Add(this.radioButtonEPlus);
            this.groupBoxE.Controls.Add(this.radioButtonEMinus);
            this.groupBoxE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxE.Location = new System.Drawing.Point(617, 158);
            this.groupBoxE.Name = "groupBoxE";
            this.groupBoxE.Size = new System.Drawing.Size(67, 100);
            this.groupBoxE.TabIndex = 22;
            this.groupBoxE.TabStop = false;
            this.groupBoxE.Text = "Знак";
            // 
            // radioButtonEPlus
            // 
            this.radioButtonEPlus.AutoSize = true;
            this.radioButtonEPlus.Checked = true;
            this.radioButtonEPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEPlus.Location = new System.Drawing.Point(6, 23);
            this.radioButtonEPlus.Name = "radioButtonEPlus";
            this.radioButtonEPlus.Size = new System.Drawing.Size(39, 28);
            this.radioButtonEPlus.TabIndex = 8;
            this.radioButtonEPlus.TabStop = true;
            this.radioButtonEPlus.Text = "+";
            this.radioButtonEPlus.UseVisualStyleBackColor = true;
            this.radioButtonEPlus.CheckedChanged += new System.EventHandler(this.radioButtonEPlus_CheckedChanged);
            // 
            // radioButtonEMinus
            // 
            this.radioButtonEMinus.AutoSize = true;
            this.radioButtonEMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonEMinus.Location = new System.Drawing.Point(6, 58);
            this.radioButtonEMinus.Name = "radioButtonEMinus";
            this.radioButtonEMinus.Size = new System.Drawing.Size(34, 28);
            this.radioButtonEMinus.TabIndex = 9;
            this.radioButtonEMinus.Text = "-";
            this.radioButtonEMinus.UseVisualStyleBackColor = true;
            // 
            // groupBoxF
            // 
            this.groupBoxF.Controls.Add(this.radioButtonFPlus);
            this.groupBoxF.Controls.Add(this.radioButtonFMinus);
            this.groupBoxF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxF.Location = new System.Drawing.Point(762, 158);
            this.groupBoxF.Name = "groupBoxF";
            this.groupBoxF.Size = new System.Drawing.Size(67, 100);
            this.groupBoxF.TabIndex = 22;
            this.groupBoxF.TabStop = false;
            this.groupBoxF.Text = "Знак";
            // 
            // radioButtonFPlus
            // 
            this.radioButtonFPlus.AutoSize = true;
            this.radioButtonFPlus.Checked = true;
            this.radioButtonFPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonFPlus.Location = new System.Drawing.Point(6, 23);
            this.radioButtonFPlus.Name = "radioButtonFPlus";
            this.radioButtonFPlus.Size = new System.Drawing.Size(39, 28);
            this.radioButtonFPlus.TabIndex = 8;
            this.radioButtonFPlus.TabStop = true;
            this.radioButtonFPlus.Text = "+";
            this.radioButtonFPlus.UseVisualStyleBackColor = true;
            this.radioButtonFPlus.CheckedChanged += new System.EventHandler(this.radioButtonFPlus_CheckedChanged);
            // 
            // radioButtonFMinus
            // 
            this.radioButtonFMinus.AutoSize = true;
            this.radioButtonFMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonFMinus.Location = new System.Drawing.Point(6, 58);
            this.radioButtonFMinus.Name = "radioButtonFMinus";
            this.radioButtonFMinus.Size = new System.Drawing.Size(34, 28);
            this.radioButtonFMinus.TabIndex = 9;
            this.radioButtonFMinus.Text = "-";
            this.radioButtonFMinus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(341, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 33);
            this.label1.TabIndex = 23;
            this.label1.Text = "Коэффиценты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(71, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "x^2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(230, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "x*y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(378, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "y^2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(520, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(659, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(803, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "F";
            // 
            // FormEquation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxF);
            this.Controls.Add(this.groupBoxE);
            this.Controls.Add(this.groupBoxD);
            this.Controls.Add(this.groupBoxB);
            this.Controls.Add(this.groupBoxC);
            this.Controls.Add(this.groupBoxA);
            this.Controls.Add(this.textBoxF);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxC);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.textBoxE);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.textBoxEquation);
            this.Controls.Add(this.buttonSolve);
            this.Name = "FormEquation";
            this.Load += new System.EventHandler(this.FormEquation_Load);
            this.groupBoxA.ResumeLayout(false);
            this.groupBoxA.PerformLayout();
            this.groupBoxB.ResumeLayout(false);
            this.groupBoxB.PerformLayout();
            this.groupBoxC.ResumeLayout(false);
            this.groupBoxC.PerformLayout();
            this.groupBoxD.ResumeLayout(false);
            this.groupBoxD.PerformLayout();
            this.groupBoxE.ResumeLayout(false);
            this.groupBoxE.PerformLayout();
            this.groupBoxF.ResumeLayout(false);
            this.groupBoxF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.TextBox textBoxEquation;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.RadioButton radioButtonAPlus;
        private System.Windows.Forms.RadioButton radioButtonAMinus;
        private System.Windows.Forms.GroupBox groupBoxA;
        private System.Windows.Forms.GroupBox groupBoxB;
        private System.Windows.Forms.RadioButton radioButtonBPlus;
        private System.Windows.Forms.RadioButton radioButtonBMinus;
        private System.Windows.Forms.GroupBox groupBoxC;
        private System.Windows.Forms.RadioButton radioButtonCPlus;
        private System.Windows.Forms.RadioButton radioButtonCMinus;
        private System.Windows.Forms.GroupBox groupBoxD;
        private System.Windows.Forms.RadioButton radioButtonDPlus;
        private System.Windows.Forms.RadioButton radioButtonDMinus;
        private System.Windows.Forms.GroupBox groupBoxE;
        private System.Windows.Forms.RadioButton radioButtonEPlus;
        private System.Windows.Forms.RadioButton radioButtonEMinus;
        private System.Windows.Forms.GroupBox groupBoxF;
        private System.Windows.Forms.RadioButton radioButtonFPlus;
        private System.Windows.Forms.RadioButton radioButtonFMinus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

