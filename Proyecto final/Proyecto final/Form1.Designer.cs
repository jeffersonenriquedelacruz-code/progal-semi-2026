namespace Proyecto_final
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
            btnProbar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnProbar
            // 
            btnProbar.Location = new Point(238, 115);
            btnProbar.Margin = new Padding(3, 2, 3, 2);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(82, 22);
            btnProbar.TabIndex = 0;
            btnProbar.Text = "Probar conecxion";
            btnProbar.UseVisualStyleBackColor = true;
            btnProbar.Click += btnProbar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 39);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 1;
            label1.Text = "EMPLEO LOCAL";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label1);
            Controls.Add(btnProbar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "EmpleoLocal";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProbar;
        private Label label1;
    }
}
