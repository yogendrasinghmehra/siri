namespace VoiceRecognition
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
            this.commandsList = new System.Windows.Forms.ListBox();
            this.chatbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // commandsList
            // 
            this.commandsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandsList.BackColor = System.Drawing.Color.LightSlateGray;
            this.commandsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commandsList.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandsList.FormattingEnabled = true;
            this.commandsList.ItemHeight = 25;
            this.commandsList.Location = new System.Drawing.Point(1014, 3);
            this.commandsList.Name = "commandsList";
            this.commandsList.Size = new System.Drawing.Size(276, 550);
            this.commandsList.TabIndex = 0;
            this.commandsList.Visible = false;
            // 
            // chatbox
            // 
            this.chatbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chatbox.BackColor = System.Drawing.Color.Black;
            this.chatbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatbox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbox.ForeColor = System.Drawing.Color.White;
            this.chatbox.Location = new System.Drawing.Point(-4, 3);
            this.chatbox.Name = "chatbox";
            this.chatbox.Size = new System.Drawing.Size(316, 521);
            this.chatbox.TabIndex = 1;
            this.chatbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VoiceRecognition.Properties.Resources.robot_2167836_1920_1_;
            this.ClientSize = new System.Drawing.Size(1259, 520);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.commandsList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox commandsList;
        private System.Windows.Forms.RichTextBox chatbox;

    }
}

