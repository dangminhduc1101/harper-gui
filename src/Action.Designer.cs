namespace harper_gui
{
    partial class Action
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
            this.PanelAction = new System.Windows.Forms.TableLayoutPanel();
            this.LabelControl = new System.Windows.Forms.Label();
            this.LabelCurrent = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelPIN = new System.Windows.Forms.Label();
            this.LabelConnection = new System.Windows.Forms.Label();
            this.LabelMax = new System.Windows.Forms.Label();
            this.LabelValue = new System.Windows.Forms.Label();
            this.LabelMin = new System.Windows.Forms.Label();
            this.PanelMultipleAction = new System.Windows.Forms.TableLayoutPanel();
            this.LabelMultipleAction = new System.Windows.Forms.Label();
            this.PanelAction.SuspendLayout();
            this.PanelMultipleAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelAction
            // 
            this.PanelAction.ColumnCount = 6;
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.PanelAction.Controls.Add(this.LabelControl, 0, 7);
            this.PanelAction.Controls.Add(this.LabelCurrent, 0, 6);
            this.PanelAction.Controls.Add(this.LabelName, 0, 0);
            this.PanelAction.Controls.Add(this.LabelPIN, 0, 1);
            this.PanelAction.Controls.Add(this.LabelConnection, 0, 2);
            this.PanelAction.Controls.Add(this.LabelMax, 0, 3);
            this.PanelAction.Controls.Add(this.LabelValue, 0, 4);
            this.PanelAction.Controls.Add(this.LabelMin, 0, 5);
            this.PanelAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelAction.Location = new System.Drawing.Point(0, 0);
            this.PanelAction.Margin = new System.Windows.Forms.Padding(0);
            this.PanelAction.Name = "PanelAction";
            this.PanelAction.RowCount = 8;
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelAction.Size = new System.Drawing.Size(580, 661);
            this.PanelAction.TabIndex = 0;
            // 
            // LabelControl
            // 
            this.LabelControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelControl.AutoSize = true;
            this.LabelControl.Location = new System.Drawing.Point(6, 636);
            this.LabelControl.Margin = new System.Windows.Forms.Padding(0);
            this.LabelControl.Name = "LabelControl";
            this.LabelControl.Size = new System.Drawing.Size(75, 15);
            this.LabelControl.TabIndex = 7;
            this.LabelControl.Text = "Control Type";
            this.LabelControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelCurrent
            // 
            this.LabelCurrent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelCurrent.AutoSize = true;
            this.LabelCurrent.Location = new System.Drawing.Point(3, 603);
            this.LabelCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.LabelCurrent.Name = "LabelCurrent";
            this.LabelCurrent.Size = new System.Drawing.Size(81, 15);
            this.LabelCurrent.TabIndex = 6;
            this.LabelCurrent.Text = "Current Value";
            this.LabelCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelName
            // 
            this.LabelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(23, 9);
            this.LabelName.Margin = new System.Windows.Forms.Padding(0);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(41, 15);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Name";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPIN
            // 
            this.LabelPIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelPIN.AutoSize = true;
            this.LabelPIN.Location = new System.Drawing.Point(30, 42);
            this.LabelPIN.Margin = new System.Windows.Forms.Padding(0);
            this.LabelPIN.Name = "LabelPIN";
            this.LabelPIN.Size = new System.Drawing.Size(27, 15);
            this.LabelPIN.TabIndex = 1;
            this.LabelPIN.Text = "PIN";
            this.LabelPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelConnection
            // 
            this.LabelConnection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelConnection.AutoSize = true;
            this.LabelConnection.Location = new System.Drawing.Point(9, 75);
            this.LabelConnection.Margin = new System.Windows.Forms.Padding(0);
            this.LabelConnection.Name = "LabelConnection";
            this.LabelConnection.Size = new System.Drawing.Size(69, 15);
            this.LabelConnection.TabIndex = 2;
            this.LabelConnection.Text = "Connection";
            this.LabelConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelMax
            // 
            this.LabelMax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelMax.AutoSize = true;
            this.LabelMax.Location = new System.Drawing.Point(28, 108);
            this.LabelMax.Margin = new System.Windows.Forms.Padding(0);
            this.LabelMax.Name = "LabelMax";
            this.LabelMax.Size = new System.Drawing.Size(31, 15);
            this.LabelMax.TabIndex = 3;
            this.LabelMax.Text = "Max";
            this.LabelMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelValue
            // 
            this.LabelValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelValue.AutoSize = true;
            this.LabelValue.Location = new System.Drawing.Point(24, 339);
            this.LabelValue.Margin = new System.Windows.Forms.Padding(0);
            this.LabelValue.Name = "LabelValue";
            this.LabelValue.Size = new System.Drawing.Size(38, 15);
            this.LabelValue.TabIndex = 4;
            this.LabelValue.Text = "Value";
            this.LabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelMin
            // 
            this.LabelMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelMin.AutoSize = true;
            this.LabelMin.Location = new System.Drawing.Point(29, 570);
            this.LabelMin.Margin = new System.Windows.Forms.Padding(0);
            this.LabelMin.Name = "LabelMin";
            this.LabelMin.Size = new System.Drawing.Size(28, 15);
            this.LabelMin.TabIndex = 5;
            this.LabelMin.Text = "Min";
            this.LabelMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelMultipleAction
            // 
            this.PanelMultipleAction.ColumnCount = 1;
            this.PanelMultipleAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMultipleAction.Controls.Add(this.LabelMultipleAction, 0, 0);
            this.PanelMultipleAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelMultipleAction.Location = new System.Drawing.Point(584, 0);
            this.PanelMultipleAction.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMultipleAction.Name = "PanelMultipleAction";
            this.PanelMultipleAction.RowCount = 4;
            this.PanelMultipleAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelMultipleAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelMultipleAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.PanelMultipleAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.PanelMultipleAction.Size = new System.Drawing.Size(200, 661);
            this.PanelMultipleAction.TabIndex = 1;
            // 
            // LabelMultipleAction
            // 
            this.LabelMultipleAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelMultipleAction.AutoSize = true;
            this.LabelMultipleAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMultipleAction.Location = new System.Drawing.Point(23, 24);
            this.LabelMultipleAction.Margin = new System.Windows.Forms.Padding(0);
            this.LabelMultipleAction.Name = "LabelMultipleAction";
            this.LabelMultipleAction.Size = new System.Drawing.Size(154, 18);
            this.LabelMultipleAction.TabIndex = 2;
            this.LabelMultipleAction.Text = "Multiple Servo Control";
            this.LabelMultipleAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InMoov_Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.PanelMultipleAction);
            this.Controls.Add(this.PanelAction);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "InMoov_Action";
            this.Text = "InMoov_Action";
            this.PanelAction.ResumeLayout(false);
            this.PanelAction.PerformLayout();
            this.PanelMultipleAction.ResumeLayout(false);
            this.PanelMultipleAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelAction;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelPIN;
        private System.Windows.Forms.Label LabelConnection;
        private System.Windows.Forms.Label LabelCurrent;
        private System.Windows.Forms.Label LabelMax;
        private System.Windows.Forms.Label LabelValue;
        private System.Windows.Forms.Label LabelMin;
        private System.Windows.Forms.Label LabelControl;
        private System.Windows.Forms.TableLayoutPanel PanelMultipleAction;
        private System.Windows.Forms.Label LabelMultipleAction;
    }
}