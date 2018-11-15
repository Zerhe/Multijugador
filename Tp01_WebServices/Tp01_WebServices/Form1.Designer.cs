namespace Tp01_WebServices
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textType = new System.Windows.Forms.Label();
            this.textYear = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.pictureBoxMovie = new System.Windows.Forms.PictureBox();
            this.textBoxDetails = new System.Windows.Forms.TextBox();
            this.listBoxSearchs = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBoxPlot = new System.Windows.Forms.CheckBox();
            this.linkWeb = new System.Windows.Forms.LinkLabel();
            this.linkImdb = new System.Windows.Forms.LinkLabel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textTamanioImagen = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textNumPages = new System.Windows.Forms.Label();
            this.textBoxImageDetails = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(744, 26);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(126, 46);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textTitle
            // 
            this.textTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitle.Location = new System.Drawing.Point(12, 33);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(55, 46);
            this.textTitle.TabIndex = 2;
            this.textTitle.Text = "Title:";
            this.textTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(73, 44);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(261, 26);
            this.textBoxTitle.TabIndex = 3;
            this.textBoxTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTitle_KeyDown);
            this.textBoxTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTitle_KeyPress);
            // 
            // textType
            // 
            this.textType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textType.Location = new System.Drawing.Point(343, 34);
            this.textType.Name = "textType";
            this.textType.Size = new System.Drawing.Size(55, 46);
            this.textType.TabIndex = 4;
            this.textType.Text = "Type:";
            this.textType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textYear
            // 
            this.textYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textYear.Location = new System.Drawing.Point(536, 33);
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(55, 46);
            this.textYear.TabIndex = 6;
            this.textYear.Text = "Year:";
            this.textYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYear.Location = new System.Drawing.Point(597, 43);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(126, 26);
            this.textBoxYear.TabIndex = 7;
            this.textBoxYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTitle_KeyDown);
            this.textBoxYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTitle_KeyPress);
            // 
            // pictureBoxMovie
            // 
            this.pictureBoxMovie.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMovie.Image")));
            this.pictureBoxMovie.Location = new System.Drawing.Point(919, 107);
            this.pictureBoxMovie.Name = "pictureBoxMovie";
            this.pictureBoxMovie.Size = new System.Drawing.Size(221, 332);
            this.pictureBoxMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMovie.TabIndex = 8;
            this.pictureBoxMovie.TabStop = false;
            // 
            // textBoxDetails
            // 
            this.textBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDetails.Location = new System.Drawing.Point(404, 107);
            this.textBoxDetails.Multiline = true;
            this.textBoxDetails.Name = "textBoxDetails";
            this.textBoxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDetails.Size = new System.Drawing.Size(466, 468);
            this.textBoxDetails.TabIndex = 9;
            // 
            // listBoxSearchs
            // 
            this.listBoxSearchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSearchs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBoxSearchs.FormattingEnabled = true;
            this.listBoxSearchs.ItemHeight = 24;
            this.listBoxSearchs.Location = new System.Drawing.Point(73, 107);
            this.listBoxSearchs.Name = "listBoxSearchs";
            this.listBoxSearchs.Size = new System.Drawing.Size(261, 460);
            this.listBoxSearchs.TabIndex = 10;
            this.listBoxSearchs.SelectedIndexChanged += new System.EventHandler(this.listBoxSearchs_SelectedIndexChanged);
            // 
            // checkBoxPlot
            // 
            this.checkBoxPlot.AutoSize = true;
            this.checkBoxPlot.Location = new System.Drawing.Point(744, 84);
            this.checkBoxPlot.Name = "checkBoxPlot";
            this.checkBoxPlot.Size = new System.Drawing.Size(71, 17);
            this.checkBoxPlot.TabIndex = 11;
            this.checkBoxPlot.Text = "Long Plot";
            this.checkBoxPlot.UseVisualStyleBackColor = true;
            this.checkBoxPlot.CheckedChanged += new System.EventHandler(this.checkBoxPlot_CheckedChanged);
            // 
            // linkWeb
            // 
            this.linkWeb.AutoSize = true;
            this.linkWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkWeb.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkWeb.Location = new System.Drawing.Point(401, 587);
            this.linkWeb.Name = "linkWeb";
            this.linkWeb.Size = new System.Drawing.Size(0, 17);
            this.linkWeb.TabIndex = 12;
            this.linkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWeb_LinkClicked);
            // 
            // linkImdb
            // 
            this.linkImdb.AutoSize = true;
            this.linkImdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkImdb.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkImdb.Location = new System.Drawing.Point(401, 617);
            this.linkImdb.Name = "linkImdb";
            this.linkImdb.Size = new System.Drawing.Size(0, 17);
            this.linkImdb.TabIndex = 13;
            this.linkImdb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImdb_LinkClicked);
            // 
            // comboBoxType
            // 
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "All",
            "movie",
            "series",
            "episode"});
            this.comboBoxType.Location = new System.Drawing.Point(404, 44);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(126, 28);
            this.comboBoxType.TabIndex = 14;
            this.comboBoxType.Text = "All";
            // 
            // textTamanioImagen
            // 
            this.textTamanioImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTamanioImagen.Location = new System.Drawing.Point(919, 442);
            this.textTamanioImagen.Name = "textTamanioImagen";
            this.textTamanioImagen.Size = new System.Drawing.Size(221, 25);
            this.textTamanioImagen.TabIndex = 15;
            this.textTamanioImagen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(259, 584);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 16;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(73, 584);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 17;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textNumPages
            // 
            this.textNumPages.AutoSize = true;
            this.textNumPages.Location = new System.Drawing.Point(175, 589);
            this.textNumPages.Name = "textNumPages";
            this.textNumPages.Size = new System.Drawing.Size(55, 13);
            this.textNumPages.TabIndex = 18;
            this.textNumPages.Text = "Page: 0/0";
            // 
            // textBoxImageDetails
            // 
            this.textBoxImageDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImageDetails.Location = new System.Drawing.Point(919, 470);
            this.textBoxImageDetails.Multiline = true;
            this.textBoxImageDetails.Name = "textBoxImageDetails";
            this.textBoxImageDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxImageDetails.Size = new System.Drawing.Size(221, 105);
            this.textBoxImageDetails.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 643);
            this.Controls.Add(this.textBoxImageDetails);
            this.Controls.Add(this.textNumPages);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textTamanioImagen);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.linkImdb);
            this.Controls.Add(this.linkWeb);
            this.Controls.Add(this.checkBoxPlot);
            this.Controls.Add(this.listBoxSearchs);
            this.Controls.Add(this.textBoxDetails);
            this.Controls.Add(this.pictureBoxMovie);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textYear);
            this.Controls.Add(this.textType);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.buttonSearch);
            this.Name = "Form1";
            this.Text = "Busca tu Peli";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label textTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label textType;
        private System.Windows.Forms.Label textYear;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.PictureBox pictureBoxMovie;
        private System.Windows.Forms.TextBox textBoxDetails;
        private System.Windows.Forms.ListBox listBoxSearchs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBoxPlot;
        private System.Windows.Forms.LinkLabel linkWeb;
        private System.Windows.Forms.LinkLabel linkImdb;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label textTamanioImagen;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label textNumPages;
        private System.Windows.Forms.TextBox textBoxImageDetails;
    }
}

