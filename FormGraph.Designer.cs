
namespace CurveSolution
{
    partial class FormGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraph));
            this.panelSolution = new System.Windows.Forms.Panel();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.labelFigure = new System.Windows.Forms.Label();
            this.labelAphineX = new System.Windows.Forms.Label();
            this.labelAphineY = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.labelY2 = new System.Windows.Forms.Label();
            this.labelSignB = new System.Windows.Forms.Label();
            this.labelA2 = new System.Windows.Forms.Label();
            this.labelB2 = new System.Windows.Forms.Label();
            this.labelEquals = new System.Windows.Forms.Label();
            this.labelOne = new System.Windows.Forms.Label();
            this.labelSignA = new System.Windows.Forms.Label();
            this.pictureBoxLine1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLine2 = new System.Windows.Forms.PictureBox();
            this.panelSolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSolution
            // 
            this.panelSolution.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelSolution.Controls.Add(this.pictureBoxLine2);
            this.panelSolution.Controls.Add(this.pictureBoxLine1);
            this.panelSolution.Controls.Add(this.labelSignA);
            this.panelSolution.Controls.Add(this.labelOne);
            this.panelSolution.Controls.Add(this.labelEquals);
            this.panelSolution.Controls.Add(this.labelB2);
            this.panelSolution.Controls.Add(this.labelA2);
            this.panelSolution.Controls.Add(this.labelSignB);
            this.panelSolution.Controls.Add(this.labelY2);
            this.panelSolution.Controls.Add(this.labelX2);
            this.panelSolution.Controls.Add(this.labelAphineY);
            this.panelSolution.Controls.Add(this.labelAphineX);
            this.panelSolution.Controls.Add(this.labelFigure);
            this.panelSolution.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSolution.Location = new System.Drawing.Point(0, 350);
            this.panelSolution.Name = "panelSolution";
            this.panelSolution.Size = new System.Drawing.Size(800, 100);
            this.panelSolution.TabIndex = 0;
            // 
            // panelGraph
            // 
            this.panelGraph.AutoScroll = true;
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(0, 0);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(800, 350);
            this.panelGraph.TabIndex = 1;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint);
            // 
            // labelFigure
            // 
            this.labelFigure.AutoSize = true;
            this.labelFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFigure.Location = new System.Drawing.Point(22, 18);
            this.labelFigure.Name = "labelFigure";
            this.labelFigure.Size = new System.Drawing.Size(53, 73);
            this.labelFigure.TabIndex = 0;
            this.labelFigure.Text = "{";
            // 
            // labelAphineX
            // 
            this.labelAphineX.AutoSize = true;
            this.labelAphineX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAphineX.Location = new System.Drawing.Point(62, 40);
            this.labelAphineX.Name = "labelAphineX";
            this.labelAphineX.Size = new System.Drawing.Size(45, 16);
            this.labelAphineX.TabIndex = 1;
            this.labelAphineX.Text = "label2";
            // 
            // labelAphineY
            // 
            this.labelAphineY.AutoSize = true;
            this.labelAphineY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAphineY.Location = new System.Drawing.Point(62, 64);
            this.labelAphineY.Name = "labelAphineY";
            this.labelAphineY.Size = new System.Drawing.Size(45, 16);
            this.labelAphineY.TabIndex = 2;
            this.labelAphineY.Text = "label3";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX2.Location = new System.Drawing.Point(512, 27);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(35, 20);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "x\'^2";
            // 
            // labelY2
            // 
            this.labelY2.AutoSize = true;
            this.labelY2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY2.Location = new System.Drawing.Point(611, 27);
            this.labelY2.Name = "labelY2";
            this.labelY2.Size = new System.Drawing.Size(35, 20);
            this.labelY2.TabIndex = 4;
            this.labelY2.Text = "y\'^2";
            // 
            // labelSignB
            // 
            this.labelSignB.AutoSize = true;
            this.labelSignB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignB.Location = new System.Drawing.Point(563, 43);
            this.labelSignB.Name = "labelSignB";
            this.labelSignB.Size = new System.Drawing.Size(51, 20);
            this.labelSignB.TabIndex = 5;
            this.labelSignB.Text = "label4";
            // 
            // labelA2
            // 
            this.labelA2.AutoSize = true;
            this.labelA2.Location = new System.Drawing.Point(512, 64);
            this.labelA2.Name = "labelA2";
            this.labelA2.Size = new System.Drawing.Size(35, 13);
            this.labelA2.TabIndex = 6;
            this.labelA2.Text = "label5";
            this.labelA2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelB2
            // 
            this.labelB2.AutoSize = true;
            this.labelB2.Location = new System.Drawing.Point(611, 64);
            this.labelB2.Name = "labelB2";
            this.labelB2.Size = new System.Drawing.Size(35, 13);
            this.labelB2.TabIndex = 7;
            this.labelB2.Text = "label6";
            this.labelB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEquals
            // 
            this.labelEquals.AutoSize = true;
            this.labelEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEquals.Location = new System.Drawing.Point(668, 43);
            this.labelEquals.Name = "labelEquals";
            this.labelEquals.Size = new System.Drawing.Size(26, 24);
            this.labelEquals.TabIndex = 8;
            this.labelEquals.Text = "= ";
            // 
            // labelOne
            // 
            this.labelOne.AutoSize = true;
            this.labelOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOne.Location = new System.Drawing.Point(700, 43);
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(20, 24);
            this.labelOne.TabIndex = 9;
            this.labelOne.Text = "1";
            // 
            // labelSignA
            // 
            this.labelSignA.AutoSize = true;
            this.labelSignA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignA.Location = new System.Drawing.Point(464, 43);
            this.labelSignA.Name = "labelSignA";
            this.labelSignA.Size = new System.Drawing.Size(51, 20);
            this.labelSignA.TabIndex = 10;
            this.labelSignA.Text = "label9";
            // 
            // pictureBoxLine1
            // 
            this.pictureBoxLine1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLine1.Image")));
            this.pictureBoxLine1.Location = new System.Drawing.Point(505, 50);
            this.pictureBoxLine1.Name = "pictureBoxLine1";
            this.pictureBoxLine1.Size = new System.Drawing.Size(42, 6);
            this.pictureBoxLine1.TabIndex = 11;
            this.pictureBoxLine1.TabStop = false;
            // 
            // pictureBoxLine2
            // 
            this.pictureBoxLine2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLine2.Image")));
            this.pictureBoxLine2.Location = new System.Drawing.Point(604, 50);
            this.pictureBoxLine2.Name = "pictureBoxLine2";
            this.pictureBoxLine2.Size = new System.Drawing.Size(42, 6);
            this.pictureBoxLine2.TabIndex = 12;
            this.pictureBoxLine2.TabStop = false;
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.panelSolution);
            this.Name = "FormGraph";
            this.Text = "FormGraph";
            this.Load += new System.EventHandler(this.FormGraph_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGraph_Paint);
            this.panelSolution.ResumeLayout(false);
            this.panelSolution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLine2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSolution;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label labelAphineY;
        private System.Windows.Forms.Label labelAphineX;
        private System.Windows.Forms.Label labelFigure;
        private System.Windows.Forms.Label labelSignA;
        private System.Windows.Forms.Label labelOne;
        private System.Windows.Forms.Label labelEquals;
        private System.Windows.Forms.Label labelB2;
        private System.Windows.Forms.Label labelA2;
        private System.Windows.Forms.Label labelSignB;
        private System.Windows.Forms.Label labelY2;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.PictureBox pictureBoxLine2;
        private System.Windows.Forms.PictureBox pictureBoxLine1;
    }
}