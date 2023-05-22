namespace BookManagement
{
    partial class AdminForm
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
            this.tbcAdmin = new System.Windows.Forms.TabControl();
            this.tbpUser = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAdmin = new System.Windows.Forms.RadioButton();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tbpBook = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUsersSearch = new System.Windows.Forms.TextBox();
            this.btnExportBackup = new System.Windows.Forms.Button();
            this.btnImportBackup = new System.Windows.Forms.Button();
            this.tbcAdmin.SuspendLayout();
            this.tbpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tbpBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcAdmin
            // 
            this.tbcAdmin.Controls.Add(this.tbpUser);
            this.tbcAdmin.Controls.Add(this.tbpBook);
            this.tbcAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAdmin.Location = new System.Drawing.Point(0, 0);
            this.tbcAdmin.Name = "tbcAdmin";
            this.tbcAdmin.SelectedIndex = 0;
            this.tbcAdmin.Size = new System.Drawing.Size(1469, 753);
            this.tbcAdmin.TabIndex = 1;
            this.tbcAdmin.SelectedIndexChanged += new System.EventHandler(this.tbcAdmin_SelectedIndexChanged);
            // 
            // tbpUser
            // 
            this.tbpUser.Controls.Add(this.splitContainer1);
            this.tbpUser.Location = new System.Drawing.Point(4, 28);
            this.tbpUser.Name = "tbpUser";
            this.tbpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUser.Size = new System.Drawing.Size(1461, 721);
            this.tbpUser.TabIndex = 0;
            this.tbpUser.Text = "User management";
            this.tbpUser.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvUsers);
            this.splitContainer1.Size = new System.Drawing.Size(1455, 715);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(200, 715);
            this.splitContainer2.SplitterDistance = 150;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAdmin);
            this.groupBox1.Controls.Add(this.rdbUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User type";
            // 
            // rdbAdmin
            // 
            this.rdbAdmin.AutoSize = true;
            this.rdbAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdbAdmin.Location = new System.Drawing.Point(3, 46);
            this.rdbAdmin.Name = "rdbAdmin";
            this.rdbAdmin.Size = new System.Drawing.Size(194, 22);
            this.rdbAdmin.TabIndex = 1;
            this.rdbAdmin.Text = "Administrator";
            this.rdbAdmin.UseVisualStyleBackColor = true;
            this.rdbAdmin.CheckedChanged += new System.EventHandler(this.rdbAdmin_CheckedChanged);
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.Checked = true;
            this.rdbUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.rdbUser.Location = new System.Drawing.Point(3, 24);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(194, 22);
            this.rdbUser.TabIndex = 0;
            this.rdbUser.TabStop = true;
            this.rdbUser.Text = "Normal User";
            this.rdbUser.UseVisualStyleBackColor = true;
            this.rdbUser.CheckedChanged += new System.EventHandler(this.rdbUser_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImportBackup);
            this.groupBox2.Controls.Add(this.btnExportBackup);
            this.groupBox2.Controls.Add(this.txbUsersSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 561);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operations";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdate.Location = new System.Drawing.Point(3, 24);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(194, 51);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 30;
            this.dgvUsers.Size = new System.Drawing.Size(1251, 715);
            this.dgvUsers.TabIndex = 0;
            // 
            // tbpBook
            // 
            this.tbpBook.Controls.Add(this.splitContainer3);
            this.tbpBook.Location = new System.Drawing.Point(4, 28);
            this.tbpBook.Name = "tbpBook";
            this.tbpBook.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBook.Size = new System.Drawing.Size(1461, 721);
            this.tbpBook.TabIndex = 1;
            this.tbpBook.Text = "Books management";
            this.tbpBook.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer3.Size = new System.Drawing.Size(1455, 715);
            this.splitContainer3.SplitterDistance = 200;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdateBook);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 715);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operations";
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdateBook.Location = new System.Drawing.Point(3, 24);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(194, 50);
            this.btnUpdateBook.TabIndex = 0;
            this.btnUpdateBook.Text = "Update";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1251, 715);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Username";
            // 
            // txbUsersSearch
            // 
            this.txbUsersSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txbUsersSearch.Location = new System.Drawing.Point(3, 93);
            this.txbUsersSearch.Name = "txbUsersSearch";
            this.txbUsersSearch.Size = new System.Drawing.Size(194, 28);
            this.txbUsersSearch.TabIndex = 4;
            this.txbUsersSearch.TextChanged += new System.EventHandler(this.txbUsersSearch_TextChanged);
            // 
            // btnExportBackup
            // 
            this.btnExportBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportBackup.Location = new System.Drawing.Point(3, 121);
            this.btnExportBackup.Name = "btnExportBackup";
            this.btnExportBackup.Size = new System.Drawing.Size(194, 51);
            this.btnExportBackup.TabIndex = 5;
            this.btnExportBackup.Text = "Export backup";
            this.btnExportBackup.UseVisualStyleBackColor = true;
            this.btnExportBackup.Click += new System.EventHandler(this.btnExportBackup_Click);
            // 
            // btnImportBackup
            // 
            this.btnImportBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImportBackup.Location = new System.Drawing.Point(3, 172);
            this.btnImportBackup.Name = "btnImportBackup";
            this.btnImportBackup.Size = new System.Drawing.Size(194, 51);
            this.btnImportBackup.TabIndex = 6;
            this.btnImportBackup.Text = "Import backup";
            this.btnImportBackup.UseVisualStyleBackColor = true;
            this.btnImportBackup.Click += new System.EventHandler(this.btnImportBackup_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 753);
            this.Controls.Add(this.tbcAdmin);
            this.Name = "AdminForm";
            this.ShowIcon = false;
            this.Text = "AdminForm";
            this.tbcAdmin.ResumeLayout(false);
            this.tbpUser.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tbpBook.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcAdmin;
        private System.Windows.Forms.TabPage tbpUser;
        private System.Windows.Forms.TabPage tbpBook;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAdmin;
        private System.Windows.Forms.RadioButton rdbUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txbUsersSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportBackup;
        private System.Windows.Forms.Button btnExportBackup;
    }
}