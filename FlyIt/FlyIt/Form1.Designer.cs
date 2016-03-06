namespace FlyIt
{
    partial class bntPlaneAdd
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
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.cbxRegions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAirports = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxViews = new System.Windows.Forms.ComboBox();
            this.checkVors = new System.Windows.Forms.CheckBox();
            this.checkFixes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSession = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnPlaneAdd = new System.Windows.Forms.Button();
            this.btnPlaneRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBrowser.Location = new System.Drawing.Point(1, 49);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(1325, 570);
            this.pnlBrowser.TabIndex = 0;
            // 
            // cbxRegions
            // 
            this.cbxRegions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRegions.FormattingEnabled = true;
            this.cbxRegions.Location = new System.Drawing.Point(65, 12);
            this.cbxRegions.Name = "cbxRegions";
            this.cbxRegions.Size = new System.Drawing.Size(121, 24);
            this.cbxRegions.TabIndex = 1;
            this.cbxRegions.SelectedIndexChanged += new System.EventHandler(this.cbxRegions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Region:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Airport:";
            // 
            // cbxAirports
            // 
            this.cbxAirports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAirports.FormattingEnabled = true;
            this.cbxAirports.Location = new System.Drawing.Point(251, 12);
            this.cbxAirports.Name = "cbxAirports";
            this.cbxAirports.Size = new System.Drawing.Size(121, 24);
            this.cbxAirports.TabIndex = 3;
            this.cbxAirports.SelectedIndexChanged += new System.EventHandler(this.cbxAirports_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(680, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "View:";
            // 
            // cbxViews
            // 
            this.cbxViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxViews.FormattingEnabled = true;
            this.cbxViews.Location = new System.Drawing.Point(718, 9);
            this.cbxViews.Name = "cbxViews";
            this.cbxViews.Size = new System.Drawing.Size(144, 24);
            this.cbxViews.TabIndex = 5;
            this.cbxViews.SelectedIndexChanged += new System.EventHandler(this.cbxViews_SelectedIndexChanged);
            // 
            // checkVors
            // 
            this.checkVors.AutoSize = true;
            this.checkVors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkVors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVors.Location = new System.Drawing.Point(859, 11);
            this.checkVors.Name = "checkVors";
            this.checkVors.Size = new System.Drawing.Size(94, 21);
            this.checkVors.TabIndex = 7;
            this.checkVors.Text = "Show Vors";
            this.checkVors.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkVors.UseVisualStyleBackColor = true;
            this.checkVors.CheckedChanged += new System.EventHandler(this.checkVors_CheckedChanged);
            // 
            // checkFixes
            // 
            this.checkFixes.AutoSize = true;
            this.checkFixes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkFixes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFixes.Location = new System.Drawing.Point(955, 11);
            this.checkFixes.Name = "checkFixes";
            this.checkFixes.Size = new System.Drawing.Size(97, 21);
            this.checkFixes.TabIndex = 8;
            this.checkFixes.Text = "Show Fixes";
            this.checkFixes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkFixes.UseVisualStyleBackColor = true;
            this.checkFixes.CheckedChanged += new System.EventHandler(this.checkFixes_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Session:";
            // 
            // cbxSession
            // 
            this.cbxSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSession.FormattingEnabled = true;
            this.cbxSession.Location = new System.Drawing.Point(68, 9);
            this.cbxSession.Name = "cbxSession";
            this.cbxSession.Size = new System.Drawing.Size(121, 24);
            this.cbxSession.TabIndex = 9;
            this.cbxSession.SelectedIndexChanged += new System.EventHandler(this.cbxSession_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.cbxAirports);
            this.groupBox1.Controls.Add(this.cbxRegions);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(195, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 46);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.Enabled = false;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(379, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 27);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnPlaneAdd
            // 
            this.btnPlaneAdd.Location = new System.Drawing.Point(1084, 9);
            this.btnPlaneAdd.Name = "btnPlaneAdd";
            this.btnPlaneAdd.Size = new System.Drawing.Size(75, 23);
            this.btnPlaneAdd.TabIndex = 12;
            this.btnPlaneAdd.Text = "Add";
            this.btnPlaneAdd.UseVisualStyleBackColor = true;
            this.btnPlaneAdd.Visible = false;
            this.btnPlaneAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPlaneRemove
            // 
            this.btnPlaneRemove.Location = new System.Drawing.Point(1165, 9);
            this.btnPlaneRemove.Name = "btnPlaneRemove";
            this.btnPlaneRemove.Size = new System.Drawing.Size(75, 23);
            this.btnPlaneRemove.TabIndex = 13;
            this.btnPlaneRemove.Text = "Remove";
            this.btnPlaneRemove.UseVisualStyleBackColor = true;
            this.btnPlaneRemove.Visible = false;
            this.btnPlaneRemove.Click += new System.EventHandler(this.btnPlaneRemove_Click);
            // 
            // bntPlaneAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 617);
            this.Controls.Add(this.btnPlaneRemove);
            this.Controls.Add(this.btnPlaneAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxSession);
            this.Controls.Add(this.checkFixes);
            this.Controls.Add(this.checkVors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxViews);
            this.Controls.Add(this.pnlBrowser);
            this.Name = "bntPlaneAdd";
            this.Text = "FlyIt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.ComboBox cbxRegions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAirports;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxViews;
        private System.Windows.Forms.CheckBox checkVors;
        private System.Windows.Forms.CheckBox checkFixes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnPlaneAdd;
        private System.Windows.Forms.Button btnPlaneRemove;
    }
}

