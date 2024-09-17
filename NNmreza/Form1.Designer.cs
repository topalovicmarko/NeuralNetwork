
namespace NNmreza
{
    partial class Form1
    {
        //PROJEKAT ZA ISPIT

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

        //PROJEKAT ZA ISPIT

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prikazMreze = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // prikazMreze
            // 
            this.prikazMreze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prikazMreze.FormattingEnabled = true;
            this.prikazMreze.ItemHeight = 25;
            this.prikazMreze.Location = new System.Drawing.Point(28, 24);
            this.prikazMreze.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prikazMreze.Name = "prikazMreze";
            this.prikazMreze.Size = new System.Drawing.Size(761, 429);
            this.prikazMreze.TabIndex = 0;
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 502);
            this.Controls.Add(this.prikazMreze);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox prikazMreze;
    }
}

