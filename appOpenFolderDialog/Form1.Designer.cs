namespace appOpenFolderDialog
{
    partial class Form1
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
            listView1 = new ListView();
            btnOpenDialog = new Button();
            btnOrganize = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 117);
            listView1.Name = "listView1";
            listView1.Size = new Size(700, 295);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnOpenDialog
            // 
            btnOpenDialog.Location = new Point(33, 27);
            btnOpenDialog.Name = "btnOpenDialog";
            btnOpenDialog.Size = new Size(118, 23);
            btnOpenDialog.TabIndex = 1;
            btnOpenDialog.Text = "Abrir Dialogo";
            btnOpenDialog.UseVisualStyleBackColor = true;
            btnOpenDialog.Click += btnOpenDialog_Click;
            // 
            // btnOrganize
            // 
            btnOrganize.Location = new Point(187, 27);
            btnOrganize.Name = "btnOrganize";
            btnOrganize.Size = new Size(75, 23);
            btnOrganize.TabIndex = 2;
            btnOrganize.Text = "Organizar";
            btnOrganize.UseVisualStyleBackColor = true;
            btnOrganize.Click += btnOrganize_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOrganize);
            Controls.Add(btnOpenDialog);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button btnOpenDialog;
        private Button btnOrganize;
    }
}
