namespace AudioSender_Receiver1
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
            this.buttonStartCall = new System.Windows.Forms.Button();
            this.TextPanel = new System.Windows.Forms.TextBox();
            this.InputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFinishCall = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IPInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartCall
            // 
            this.buttonStartCall.Location = new System.Drawing.Point(52, 493);
            this.buttonStartCall.Name = "buttonStartCall";
            this.buttonStartCall.Size = new System.Drawing.Size(274, 48);
            this.buttonStartCall.TabIndex = 0;
            this.buttonStartCall.Text = "Start call";
            this.buttonStartCall.UseVisualStyleBackColor = true;
            this.buttonStartCall.Click += new System.EventHandler(this.buttonRecord_Click_1);
            // 
            // TextPanel
            // 
            this.TextPanel.Location = new System.Drawing.Point(52, 238);
            this.TextPanel.Multiline = true;
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(684, 238);
            this.TextPanel.TabIndex = 1;
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(52, 126);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputText.Size = new System.Drawing.Size(338, 33);
            this.InputText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(48, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Print something";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFinishCall
            // 
            this.buttonFinishCall.Enabled = false;
            this.buttonFinishCall.Location = new System.Drawing.Point(463, 493);
            this.buttonFinishCall.Name = "buttonFinishCall";
            this.buttonFinishCall.Size = new System.Drawing.Size(273, 48);
            this.buttonFinishCall.TabIndex = 5;
            this.buttonFinishCall.Text = "Finish call";
            this.buttonFinishCall.UseVisualStyleBackColor = true;
            this.buttonFinishCall.Click += new System.EventHandler(this.button2_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(506, 37);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(230, 22);
            this.userName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(396, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your name";
            // 
            // IPInput
            // 
            this.IPInput.Location = new System.Drawing.Point(78, 39);
            this.IPInput.Name = "IPInput";
            this.IPInput.Size = new System.Drawing.Size(159, 22);
            this.IPInput.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(48, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "    "});
            this.checkedListBox1.Location = new System.Drawing.Point(52, 175);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(185, 42);
            this.checkedListBox1.TabIndex = 10;
            // 
            // buttonAttach
            // 
            this.buttonAttach.Location = new System.Drawing.Point(243, 175);
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Size = new System.Drawing.Size(94, 24);
            this.buttonAttach.TabIndex = 12;
            this.buttonAttach.Text = "Attach file";
            this.buttonAttach.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 566);
            this.Controls.Add(this.buttonAttach);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.buttonFinishCall);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.buttonStartCall);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartCall;
        private System.Windows.Forms.TextBox TextPanel;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonFinishCall;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonAttach;
    }
}

