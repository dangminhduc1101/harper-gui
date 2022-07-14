namespace InMoov_GUI
{
    partial class InMoov
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
            this.components = new System.ComponentModel.Container();
            this.PanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.LabelSerialPortL = new System.Windows.Forms.Label();
            this.LabelSerialPortR = new System.Windows.Forms.Label();
            this.LabelPort = new System.Windows.Forms.Label();
            this.LabelBaud = new System.Windows.Forms.Label();
            this.LabelAction = new System.Windows.Forms.Label();
            this.LabelPerception = new System.Windows.Forms.Label();
            this.SerialPortL = new System.IO.Ports.SerialPort(this.components);
            this.SerialPortR = new System.IO.Ports.SerialPort(this.components);
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.ColumnCount = 3;
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.PanelMain.Controls.Add(this.LabelSerialPortL, 1, 0);
            this.PanelMain.Controls.Add(this.LabelSerialPortR, 2, 0);
            this.PanelMain.Controls.Add(this.LabelPort, 0, 1);
            this.PanelMain.Controls.Add(this.LabelBaud, 0, 2);
            this.PanelMain.Controls.Add(this.LabelAction, 0, 5);
            this.PanelMain.Controls.Add(this.LabelPerception, 0, 7);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.RowCount = 9;
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.PanelMain.Size = new System.Drawing.Size(424, 432);
            this.PanelMain.TabIndex = 0;
            // 
            // LabelSerialPortL
            // 
            this.LabelSerialPortL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelSerialPortL.AutoSize = true;
            this.LabelSerialPortL.Location = new System.Drawing.Point(125, 14);
            this.LabelSerialPortL.Name = "LabelSerialPortL";
            this.LabelSerialPortL.Size = new System.Drawing.Size(87, 15);
            this.LabelSerialPortL.TabIndex = 0;
            this.LabelSerialPortL.Text = "Left Serial Port";
            this.LabelSerialPortL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelSerialPortR
            // 
            this.LabelSerialPortR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelSerialPortR.AutoSize = true;
            this.LabelSerialPortR.Location = new System.Drawing.Point(290, 14);
            this.LabelSerialPortR.Name = "LabelSerialPortR";
            this.LabelSerialPortR.Size = new System.Drawing.Size(96, 15);
            this.LabelSerialPortR.TabIndex = 1;
            this.LabelSerialPortR.Text = "Right Serial Port";
            this.LabelSerialPortR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPort
            // 
            this.LabelPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelPort.AutoSize = true;
            this.LabelPort.Location = new System.Drawing.Point(27, 57);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(29, 15);
            this.LabelPort.TabIndex = 2;
            this.LabelPort.Text = "Port";
            this.LabelPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBaud
            // 
            this.LabelBaud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelBaud.AutoSize = true;
            this.LabelBaud.Location = new System.Drawing.Point(24, 100);
            this.LabelBaud.Name = "LabelBaud";
            this.LabelBaud.Size = new System.Drawing.Size(36, 15);
            this.LabelBaud.TabIndex = 3;
            this.LabelBaud.Text = "Baud";
            this.LabelBaud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelAction
            // 
            this.LabelAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelAction.AutoSize = true;
            this.LabelAction.Location = new System.Drawing.Point(22, 241);
            this.LabelAction.Name = "LabelAction";
            this.LabelAction.Size = new System.Drawing.Size(40, 15);
            this.LabelAction.TabIndex = 4;
            this.LabelAction.Text = "Action";
            this.LabelAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPerception
            // 
            this.LabelPerception.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelPerception.AutoSize = true;
            this.LabelPerception.Location = new System.Drawing.Point(9, 371);
            this.LabelPerception.Name = "LabelPerception";
            this.PanelMain.SetRowSpan(this.LabelPerception, 2);
            this.LabelPerception.Size = new System.Drawing.Size(66, 15);
            this.LabelPerception.TabIndex = 5;
            this.LabelPerception.Text = "Perception";
            this.LabelPerception.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InMoov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 432);
            this.Controls.Add(this.PanelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InMoov";
            this.Text = "InMoov";
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelMain;
        private System.Windows.Forms.Label LabelSerialPortL;
        private System.Windows.Forms.Label LabelSerialPortR;
        private System.Windows.Forms.Label LabelPort;
        private System.Windows.Forms.Label LabelBaud;
        private System.Windows.Forms.Label LabelAction;
        private System.IO.Ports.SerialPort SerialPortL;
        private System.IO.Ports.SerialPort SerialPortR;
        private System.Windows.Forms.Label LabelPerception;
    }
}