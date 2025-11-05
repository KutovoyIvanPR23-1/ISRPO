namespace CezarShiphr
{
    partial class s
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblLengua = new System.Windows.Forms.Label();
            this.cbxLengua = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.nudShift = new System.Windows.Forms.NumericUpDown();
            this.btnShifr = new System.Windows.Forms.Button();
            this.btnDeshifr = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudShift)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblText.Location = new System.Drawing.Point(29, 26);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(143, 21);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Исходный текст:";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInput.Location = new System.Drawing.Point(187, 23);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(601, 114);
            this.txtInput.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOutput.Location = new System.Drawing.Point(187, 164);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(601, 114);
            this.txtOutput.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(82, 167);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(90, 21);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Результат:";
            // 
            // lblLengua
            // 
            this.lblLengua.AutoSize = true;
            this.lblLengua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLengua.Location = new System.Drawing.Point(24, 326);
            this.lblLengua.Name = "lblLengua";
            this.lblLengua.Size = new System.Drawing.Size(57, 21);
            this.lblLengua.TabIndex = 4;
            this.lblLengua.Text = "Язык:";
            // 
            // cbxLengua
            // 
            this.cbxLengua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLengua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxLengua.FormattingEnabled = true;
            this.cbxLengua.Items.AddRange(new object[] {
            "русский",
            "английский"});
            this.cbxLengua.Location = new System.Drawing.Point(86, 322);
            this.cbxLengua.Name = "cbxLengua";
            this.cbxLengua.Size = new System.Drawing.Size(147, 29);
            this.cbxLengua.TabIndex = 5;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShift.Location = new System.Drawing.Point(17, 368);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(64, 21);
            this.lblShift.TabIndex = 6;
            this.lblShift.Text = "Сдвиг:";
            // 
            // nudShift
            // 
            this.nudShift.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudShift.Location = new System.Drawing.Point(87, 365);
            this.nudShift.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudShift.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudShift.Name = "nudShift";
            this.nudShift.ReadOnly = true;
            this.nudShift.Size = new System.Drawing.Size(146, 29);
            this.nudShift.TabIndex = 7;
            this.nudShift.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnShifr
            // 
            this.btnShifr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShifr.Location = new System.Drawing.Point(297, 326);
            this.btnShifr.Name = "btnShifr";
            this.btnShifr.Size = new System.Drawing.Size(135, 43);
            this.btnShifr.TabIndex = 8;
            this.btnShifr.Text = "Зашифровать";
            this.btnShifr.UseVisualStyleBackColor = true;
            this.btnShifr.Click += new System.EventHandler(this.btnShifr_Click);
            // 
            // btnDeshifr
            // 
            this.btnDeshifr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeshifr.Location = new System.Drawing.Point(462, 326);
            this.btnDeshifr.Name = "btnDeshifr";
            this.btnDeshifr.Size = new System.Drawing.Size(135, 43);
            this.btnDeshifr.TabIndex = 8;
            this.btnDeshifr.Text = "Дешифровать";
            this.btnDeshifr.UseVisualStyleBackColor = true;
            this.btnDeshifr.Click += new System.EventHandler(this.btnDeshifr_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(627, 326);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 43);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDeshifr);
            this.Controls.Add(this.btnShifr);
            this.Controls.Add(this.nudShift);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cbxLengua);
            this.Controls.Add(this.lblLengua);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblText);
            this.Name = "s";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudShift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblLengua;
        private System.Windows.Forms.ComboBox cbxLengua;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.NumericUpDown nudShift;
        private System.Windows.Forms.Button btnShifr;
        private System.Windows.Forms.Button btnDeshifr;
        private System.Windows.Forms.Button btnClear;
    }
}

