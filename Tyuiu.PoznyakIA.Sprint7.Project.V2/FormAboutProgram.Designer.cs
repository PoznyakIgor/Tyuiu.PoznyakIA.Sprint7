
namespace Tyuiu.PoznyakIA.Sprint7.Project.V2
{
    partial class FormAboutProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutProgram));
            this.textBoxOProgramme_SAN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxOProgramme_SAN
            // 
            this.textBoxOProgramme_SAN.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxOProgramme_SAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOProgramme_SAN.Location = new System.Drawing.Point(12, 12);
            this.textBoxOProgramme_SAN.Multiline = true;
            this.textBoxOProgramme_SAN.Name = "textBoxOProgramme_SAN";
            this.textBoxOProgramme_SAN.ReadOnly = true;
            this.textBoxOProgramme_SAN.Size = new System.Drawing.Size(783, 426);
            this.textBoxOProgramme_SAN.TabIndex = 2;
            this.textBoxOProgramme_SAN.Text = resources.GetString("textBoxOProgramme_SAN.Text");
            // 
            // FormAboutProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 449);
            this.Controls.Add(this.textBoxOProgramme_SAN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAboutProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOProgramme_SAN;
    }
}