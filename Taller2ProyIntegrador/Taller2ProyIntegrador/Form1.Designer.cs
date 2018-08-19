namespace Taller2ProyIntegrador
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControlMap = new System.Windows.Forms.TabPage();
            this.mapControl1 = new Taller2ProyIntegrador.MapControl();
            this.mapOptionsControl1 = new Taller2ProyIntegrador.MapOptionsControl();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabControlMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabControlMap);
            this.tabControl1.Controls.Add(this.tabRegister);
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabControlMap
            // 
            this.tabControlMap.Controls.Add(this.mapControl1);
            this.tabControlMap.Controls.Add(this.mapOptionsControl1);
            this.tabControlMap.Location = new System.Drawing.Point(4, 22);
            this.tabControlMap.Name = "tabControlMap";
            this.tabControlMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlMap.Size = new System.Drawing.Size(768, 412);
            this.tabControlMap.TabIndex = 0;
            this.tabControlMap.Text = "ControlMap";
            this.tabControlMap.UseVisualStyleBackColor = true;
            // 
            // mapControl1
            // 
            this.mapControl1.Location = new System.Drawing.Point(34, 6);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(563, 398);
            this.mapControl1.TabIndex = 1;
            this.mapControl1.Load += new System.EventHandler(this.mapControl1_Load);
            // 
            // mapOptionsControl1
            // 
            this.mapOptionsControl1.Location = new System.Drawing.Point(603, 6);
            this.mapOptionsControl1.Name = "mapOptionsControl1";
            this.mapOptionsControl1.Size = new System.Drawing.Size(159, 398);
            this.mapOptionsControl1.TabIndex = 0;
            // 
            // tabRegister
            // 
            this.tabRegister.Location = new System.Drawing.Point(4, 22);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(768, 412);
            this.tabRegister.TabIndex = 1;
            this.tabRegister.Text = "Register/Update";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabControlMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabControlMap;
        private System.Windows.Forms.TabPage tabRegister;
        private MapOptionsControl mapOptionsControl1;
        private MapControl mapControl1;

        
    }
}

