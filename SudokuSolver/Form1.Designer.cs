namespace SudokuSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btGenerar = new System.Windows.Forms.Button();
            this.btResolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btDetener = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comDific = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btGenerar
            // 
            this.btGenerar.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btGenerar.Image")));
            this.btGenerar.Location = new System.Drawing.Point(586, 251);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(82, 45);
            this.btGenerar.TabIndex = 0;
            this.btGenerar.Text = "Generar";
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btResolver
            // 
            this.btResolver.Enabled = false;
            this.btResolver.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResolver.Image = ((System.Drawing.Image)(resources.GetObject("btResolver.Image")));
            this.btResolver.Location = new System.Drawing.Point(586, 324);
            this.btResolver.Name = "btResolver";
            this.btResolver.Size = new System.Drawing.Size(82, 45);
            this.btResolver.TabIndex = 1;
            this.btResolver.Text = "Resolver";
            this.btResolver.UseVisualStyleBackColor = true;
            this.btResolver.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(605, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btDetener
            // 
            this.btDetener.Enabled = false;
            this.btDetener.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetener.Image = ((System.Drawing.Image)(resources.GetObject("btDetener.Image")));
            this.btDetener.Location = new System.Drawing.Point(586, 399);
            this.btDetener.Name = "btDetener";
            this.btDetener.Size = new System.Drawing.Size(82, 45);
            this.btDetener.TabIndex = 8;
            this.btDetener.Text = "Detener";
            this.btDetener.UseVisualStyleBackColor = true;
            this.btDetener.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(571, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Dificultad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comDific
            // 
            this.comDific.FormattingEnabled = true;
            this.comDific.Items.AddRange(new object[] {
            "Facil",
            "Medio",
            "Dificil"});
            this.comDific.Location = new System.Drawing.Point(559, 68);
            this.comDific.Name = "comDific";
            this.comDific.Size = new System.Drawing.Size(129, 21);
            this.comDific.TabIndex = 15;
            this.comDific.SelectedIndexChanged += new System.EventHandler(this.comDific_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(596, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Jugada";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(735, 516);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comDific);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btDetener);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btResolver);
            this.Controls.Add(this.btGenerar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGenerar;
        private System.Windows.Forms.Button btResolver;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btDetener;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comDific;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

