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
            SuspendLayout();
            // 
            // btnProbar
            // 
            btnProbar.Location = new Point(116, 83);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(94, 29);
            btnProbar.TabIndex = 0;
            btnProbar.Text = "Probar conecxion";
            btnProbar.UseVisualStyleBackColor = true;
            btnProbar.Click += btnProbar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProbar);
            Name = "Form1";
            Text = "EmpleoLocal";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnProbar;
    }
}
