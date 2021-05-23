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
            this.SuspendLayout();
            // 
            // buttonStartCall
            // 
            this.buttonStartCall.Location = new System.Drawing.Point(52, 480);
            this.buttonStartCall.Name = "buttonStartCall";
            this.buttonStartCall.Size = new System.Drawing.Size(253, 48);
            this.buttonStartCall.TabIndex = 0;
            this.buttonStartCall.Text = "Start call";
            this.buttonStartCall.UseVisualStyleBackColor = true;
            this.buttonStartCall.Click += new System.EventHandler(this.buttonRecord_Click_1);
            // 
            // TextPanel
            // 
            this.TextPanel.Location = new System.Drawing.Point(52, 209);
            this.TextPanel.Multiline = true;
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(684, 238);
            this.TextPanel.TabIndex = 1;
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(52, 136);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(347, 22);
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
            this.buttonFinishCall.Location = new System.Drawing.Point(481, 480);
            this.buttonFinishCall.Name = "buttonFinishCall";
            this.buttonFinishCall.Size = new System.Drawing.Size(255, 48);
            this.buttonFinishCall.TabIndex = 5;
            this.buttonFinishCall.Text = "Finish call";
            this.buttonFinishCall.UseVisualStyleBackColor = true;
            this.buttonFinishCall.Click += new System.EventHandler(this.button2_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(506, 39);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.buttonFinishCall);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.buttonStartCall);
            this.Name = "Form1";
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
    }
}

