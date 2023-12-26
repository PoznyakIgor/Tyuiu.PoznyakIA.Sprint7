
namespace Tyuiu.PoznyakIA.Sprint7.Project.V2
{
    partial class FormAboutDeveloper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutDeveloper));
            this.labelInfo_SAN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelInfo_SAN
            // 
            this.labelInfo_SAN.AutoSize = true;
            this.labelInfo_SAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo_SAN.Location = new System.Drawing.Point(12, 9);
            this.labelInfo_SAN.Name = "labelInfo_SAN";
            this.labelInfo_SAN.Size = new System.Drawing.Size(384, 198);
            this.labelInfo_SAN.TabIndex = 2;
            this.labelInfo_SAN.Text = resources.GetString("labelInfo_SAN.Text");
            // 
            // FormAboutDeveloper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 203);
            this.Controls.Add(this.labelInfo_SAN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAboutDeveloper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О разработчике";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo_SAN;
    }
}