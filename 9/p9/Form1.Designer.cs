namespace p9
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bDetectar = new System.Windows.Forms.Button();
            this.bSubir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();

            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(506, 489);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;

            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(552, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(506, 489);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;

            // 
            // bDetectar
            // 
            this.bDetectar.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.bDetectar.Location = new System.Drawing.Point(1086, 131);
            this.bDetectar.Name = "bDetectar";
            this.bDetectar.Size = new System.Drawing.Size(103, 71);
            this.bDetectar.TabIndex = 3;
            this.bDetectar.Text = "Detectar Bordes";
            this.bDetectar.UseVisualStyleBackColor = true;
            this.bDetectar.Click += bDetectar_Click;

            // 
            // bSubir
            // 
            this.bSubir.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.bSubir.Location = new System.Drawing.Point(1086, 32);
            this.bSubir.Name = "bSubir";
            this.bSubir.Size = new System.Drawing.Size(103, 71);
            this.bSubir.TabIndex = 4;
            this.bSubir.Text = "Subir Imagen";
            this.bSubir.UseVisualStyleBackColor = true;
            this.bSubir.Click += bSubir_Click;

            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 517);
            this.Controls.Add(this.bSubir);
            this.Controls.Add(this.bDetectar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button bSubir;
        private System.Windows.Forms.Button bDetectar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

