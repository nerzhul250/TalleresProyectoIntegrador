using System;
using System.Windows.Forms;

namespace Taller2ProyIntegrador
{
    partial class MapOptionsControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDane = new System.Windows.Forms.TextBox();
            this.txtGeneral = new System.Windows.Forms.TextBox();
            this.txtSpecific = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(4, 21);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(7, 48);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(97, 23);
            this.Search.TabIndex = 2;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Foundation Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Group Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "DANE code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "General Research Area:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Specific Research Area:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Category:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(3, 122);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 9;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(4, 171);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 10;
            // 
            // txtDane
            // 
            this.txtDane.Location = new System.Drawing.Point(3, 230);
            this.txtDane.Name = "txtDane";
            this.txtDane.Size = new System.Drawing.Size(100, 20);
            this.txtDane.TabIndex = 11;
            // 
            // txtGeneral
            // 
            this.txtGeneral.Location = new System.Drawing.Point(4, 279);
            this.txtGeneral.Name = "txtGeneral";
            this.txtGeneral.Size = new System.Drawing.Size(100, 20);
            this.txtGeneral.TabIndex = 12;
            // 
            // txtSpecific
            // 
            this.txtSpecific.Location = new System.Drawing.Point(3, 327);
            this.txtSpecific.Name = "txtSpecific";
            this.txtSpecific.Size = new System.Drawing.Size(100, 20);
            this.txtSpecific.TabIndex = 13;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(4, 378);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 20);
            this.txtCategory.TabIndex = 14;
            // 
            // MapOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtSpecific);
            this.Controls.Add(this.txtGeneral);
            this.Controls.Add(this.txtDane);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Name = "MapOptionsControl";
            this.Size = new System.Drawing.Size(153, 415);
            this.Load += new System.EventHandler(this.MapOptionsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDane;
        private System.Windows.Forms.TextBox txtGeneral;
        private System.Windows.Forms.TextBox txtSpecific;
        private System.Windows.Forms.TextBox txtCategory;

        public String TxtCode { get => txtCode.Text; set => txtCode.Text = value; }
        public String TxtDate { get => txtDate.Text; set => txtDate.Text = value; }
        public String TxtName { get => txtName.Text; set => txtName.Text = value; }
        public String TxtDane { get => txtDane.Text; set => txtDane.Text = value; }
        public String TxtGeneral { get => txtGeneral.Text; set => txtGeneral.Text = value; }
        public String TxtSpecific { get => txtSpecific.Text; set => txtSpecific.Text = value; }
        public String TxtCategory { get => txtCategory.Text; set => txtCategory.Text = value; }
    }
}
