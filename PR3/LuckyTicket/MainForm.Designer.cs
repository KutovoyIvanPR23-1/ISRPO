namespace LuckyTicket
{
    partial class MainForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lbldescription1 = new System.Windows.Forms.Label();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.lblOutputNumber = new System.Windows.Forms.Label();
            this.lblOutputIsLucky = new System.Windows.Forms.Label();
            this.lblClue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblInfo.Location = new System.Drawing.Point(36, 54);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(538, 31);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Генератор и проверка счастливых билетов";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenerate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerate.Location = new System.Drawing.Point(217, 125);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(176, 74);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Сгенерировать билет";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lbldescription1
            // 
            this.lbldescription1.AutoSize = true;
            this.lbldescription1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbldescription1.Location = new System.Drawing.Point(158, 367);
            this.lbldescription1.Name = "lbldescription1";
            this.lbldescription1.Size = new System.Drawing.Size(295, 19);
            this.lbldescription1.TabIndex = 2;
            this.lbldescription1.Text = "Счастливым называется билет, у которого";
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription2.Location = new System.Drawing.Point(117, 387);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(377, 19);
            this.lblDescription2.TabIndex = 2;
            this.lblDescription2.Text = "сумма первых трех чисел равна сумме трех последних";
            // 
            // lblOutputNumber
            // 
            this.lblOutputNumber.AutoSize = true;
            this.lblOutputNumber.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOutputNumber.Location = new System.Drawing.Point(256, 238);
            this.lblOutputNumber.Name = "lblOutputNumber";
            this.lblOutputNumber.Size = new System.Drawing.Size(0, 31);
            this.lblOutputNumber.TabIndex = 3;
            this.lblOutputNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutputIsLucky
            // 
            this.lblOutputIsLucky.AutoSize = true;
            this.lblOutputIsLucky.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOutputIsLucky.Location = new System.Drawing.Point(178, 268);
            this.lblOutputIsLucky.Name = "lblOutputIsLucky";
            this.lblOutputIsLucky.Size = new System.Drawing.Size(0, 31);
            this.lblOutputIsLucky.TabIndex = 3;
            this.lblOutputIsLucky.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClue
            // 
            this.lblClue.AutoSize = true;
            this.lblClue.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClue.Location = new System.Drawing.Point(103, 253);
            this.lblClue.Name = "lblClue";
            this.lblClue.Size = new System.Drawing.Size(405, 33);
            this.lblClue.TabIndex = 4;
            this.lblClue.Text = "Нажмите кнопку для генерации";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 455);
            this.Controls.Add(this.lblClue);
            this.Controls.Add(this.lblOutputIsLucky);
            this.Controls.Add(this.lblOutputNumber);
            this.Controls.Add(this.lblDescription2);
            this.Controls.Add(this.lbldescription1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblInfo);
            this.Name = "MainForm";
            this.Text = "Проверка счастливого билета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lbldescription1;
        private System.Windows.Forms.Label lblDescription2;
        private System.Windows.Forms.Label lblOutputNumber;
        private System.Windows.Forms.Label lblOutputIsLucky;
        private System.Windows.Forms.Label lblClue;
    }
}

