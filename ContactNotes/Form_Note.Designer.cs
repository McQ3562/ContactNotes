namespace ContactNotes
{
    partial class Form_Note
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
            this.textBox_NoteTitle = new System.Windows.Forms.TextBox();
            this.listView_Note = new System.Windows.Forms.ListView();
            this.columnHeader_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_NoteDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Note = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_LastEdit = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_CreateDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBox_NoteTitle
            // 
            this.textBox_NoteTitle.Location = new System.Drawing.Point(12, 25);
            this.textBox_NoteTitle.Name = "textBox_NoteTitle";
            this.textBox_NoteTitle.Size = new System.Drawing.Size(254, 20);
            this.textBox_NoteTitle.TabIndex = 0;
            // 
            // listView_Note
            // 
            this.listView_Note.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Title,
            this.columnHeader_NoteDate,
            this.columnHeader_ID});
            this.listView_Note.FullRowSelect = true;
            this.listView_Note.GridLines = true;
            this.listView_Note.Location = new System.Drawing.Point(272, 25);
            this.listView_Note.Name = "listView_Note";
            this.listView_Note.Size = new System.Drawing.Size(257, 445);
            this.listView_Note.TabIndex = 1;
            this.listView_Note.UseCompatibleStateImageBehavior = false;
            this.listView_Note.View = System.Windows.Forms.View.Details;
            this.listView_Note.DoubleClick += new System.EventHandler(this.listView_Note_DoubleClick);
            // 
            // columnHeader_Title
            // 
            this.columnHeader_Title.Text = "Title";
            this.columnHeader_Title.Width = 184;
            // 
            // columnHeader_NoteDate
            // 
            this.columnHeader_NoteDate.Text = "Date";
            this.columnHeader_NoteDate.Width = 69;
            // 
            // columnHeader_ID
            // 
            this.columnHeader_ID.Text = "ID";
            this.columnHeader_ID.Width = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Note Title";
            // 
            // textBox_Note
            // 
            this.textBox_Note.Location = new System.Drawing.Point(12, 64);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.textBox_Note.Size = new System.Drawing.Size(254, 406);
            this.textBox_Note.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Note";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(454, 487);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 5;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(292, 487);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(373, 487);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 7;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Note List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Last Edit Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Create Date";
            // 
            // dateTimePicker_LastEdit
            // 
            this.dateTimePicker_LastEdit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_LastEdit.Location = new System.Drawing.Point(12, 491);
            this.dateTimePicker_LastEdit.Name = "dateTimePicker_LastEdit";
            this.dateTimePicker_LastEdit.Size = new System.Drawing.Size(118, 20);
            this.dateTimePicker_LastEdit.TabIndex = 11;
            // 
            // dateTimePicker_CreateDate
            // 
            this.dateTimePicker_CreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_CreateDate.Location = new System.Drawing.Point(136, 491);
            this.dateTimePicker_CreateDate.Name = "dateTimePicker_CreateDate";
            this.dateTimePicker_CreateDate.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker_CreateDate.TabIndex = 12;
            // 
            // Form_Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 523);
            this.Controls.Add(this.dateTimePicker_CreateDate);
            this.Controls.Add(this.dateTimePicker_LastEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Note);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_Note);
            this.Controls.Add(this.textBox_NoteTitle);
            this.Name = "Form_Note";
            this.Text = "Add Edit Note";
            this.Load += new System.EventHandler(this.Form_Note_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_NoteTitle;
        private System.Windows.Forms.ListView listView_Note;
        private System.Windows.Forms.ColumnHeader columnHeader_Title;
        private System.Windows.Forms.ColumnHeader columnHeader_NoteDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader_ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_LastEdit;
        private System.Windows.Forms.DateTimePicker dateTimePicker_CreateDate;
    }
}