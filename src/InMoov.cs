using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using System.Linq;

namespace InMoov_GUI
{
    public partial class InMoov : Form
    {
        #region Initializer
#pragma warning disable CS0649, IDE0044
        private string portL, portR, baudL, baudR;
        private System.Timers.Timer TimerMain;
        private Func<int, int, int> GetModuleIndex = (col, row) => col - 1 + 2 * (row - 4);
#pragma warning restore CS0649, IDE0044
        private void InitializeUI()
        {
            for (int i = 1; i < PanelMain.ColumnCount; i++)
            {
                for (int j = 1; j < PanelMain.RowCount; j++)
                {
                    if (j < 3)
                    {
                        PanelMain.Controls.Add(new ComboBox()
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Name = (j == 1 ? "port" : "baud") + (i == 1 ? "L" : "R")
                        },
                        i, j);
                        ((ComboBox)PanelMain.GetControlFromPosition(i, j)).Items.AddRange((j == 1 ? Constant.Ports : Constant.Bauds).ToArray());
                        ((ComboBox)PanelMain.GetControlFromPosition(i, j)).SelectedIndexChanged += SerialPortChanged;
                    }
                    else
                    {
                        PanelMain.Controls.Add(new Button()
                        {
                            Enabled = j > 6,
                            Text = j == 3 ? "Connect" : Constant.Modules[GetModuleIndex(i, j)],
                            TextAlign = ContentAlignment.MiddleCenter
                        },
                            i, j);
                        ((Button)PanelMain.GetControlFromPosition(i, j)).Click += 
                            j == 3 ? new EventHandler(SerialPortConnect) : (j <= 6 ? new EventHandler(ActionOpen) : new EventHandler(PerceptionOpen));
                    }
                    PanelMain.GetControlFromPosition(i, j).Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    PanelMain.GetControlFromPosition(i, j).Margin = new Padding(20, 0, 20, 0);
                }
            }
            PanelMain.CellPaint += CellPaint;
        }
        private void InitializeTimer()
        {
            TimerMain = new System.Timers.Timer()
            {
                SynchronizingObject = this,
                Interval = 200,
                Enabled = false
            };
            TimerMain.Elapsed += TimerElapsed;
        }
        #endregion

        #region Event Handler
        private void SerialPortChanged(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            typeof(InMoov).GetField(box.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, box.Text);
            void UpdateSerialPort(SerialPort s, int col, string port, string baud)
            {
                if (PanelMain.GetColumn(box) == col)
                {
                    if (!string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(baud))
                    {
                        PanelMain.GetControlFromPosition(col, 3).Enabled = true;
                    }
                    if (s.IsOpen)
                    { 
                        s.Close();
                    }
                    for (int i = 4; i < PanelMain.RowCount - 2; i++)
                    {
                        PanelMain.GetControlFromPosition(col, i).Enabled = false;
                    }
                }
            }
            UpdateSerialPort(SerialPortL, 1, portL, baudL);
            UpdateSerialPort(SerialPortR, 2, portR, baudR);
        }
        private void SerialPortConnect(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            void UpdateConnection(SerialPort s, int col, string port, string baud)
            {
                if (PanelMain.GetColumn(button) == col)
                {
                    s.PortName = port;
                    s.BaudRate = int.Parse(baud);
                    if (!s.IsOpen)
                    {
                        try
                        {
                            s.Open();
                            TimerMain.Enabled = true;
                            for (int i = 4; i < PanelMain.RowCount - 2; i++)
                            {
                                PanelMain.GetControlFromPosition(col, i).Enabled = true;
                            }
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show("Port not connected. Please try again.");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            MessageBox.Show("Port already connected. Please choose a different port");
                        }
                    }
                }
            } 
            UpdateConnection(SerialPortL, 1, portL, baudL);
            UpdateConnection(SerialPortR, 2, portR, baudR);
        }
        private void ActionOpen(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            int port = GetModuleIndex(PanelMain.GetColumn(button), PanelMain.GetRow(button)) * 5;
            if (Constant.Names.TryGetValue(button.Text, out List<string> names) &&
                Constant.Limits.TryGetValue(button.Text, out List<int[]> limits) &&
                Constant.Values.TryGetValue(button.Text, out List<int> values))
            {
                InMoov_Action module = new InMoov_Action(names, port, limits, values, button.Text);
                module.FormClosed += (o, e0) => { button.Enabled = true; };
                module.Show();
            }
            else
            {
                MessageBox.Show("Module Not Initialized!");
            }
        }
        private void PerceptionOpen(object sender, EventArgs e)
        {}
        private void CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (new int[] {1, 4, 7}.Contains(e.Row))
            {
                e.Graphics.DrawLine(Pens.Gray, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
            }
            if (e.Column == 1 || (e.Column == 2 && e.Row != 7 && e.Row != 8))
            {
                e.Graphics.DrawLine(Pens.Gray, e.CellBounds.Location, new Point(e.CellBounds.Left, e.CellBounds.Bottom));
            }
        }
        private void TimerElapsed(object sender, EventArgs e)
        {
            int count = Constant.ModulesAction.Count / 2;
            var textL = Enumerable.Repeat("NA", count).ToArray();
            var textR = Enumerable.Repeat("NA", count).ToArray();
            var forms = Application.OpenForms.Cast<Form>().Select(f => f.Name);
            foreach (string s in Constant.ModulesAction)
            {
                if (forms.Contains(s))
                {
                    string s0 = Application.OpenForms[s].ToString();
                    int index = Constant.ModulesAction.IndexOf(s);
                    if (index % 2 == 0)
                    {
                        textL[index / 2] = s0;
                    }
                    else
                    {
                        textR[(index - 1)/ 2] = s0;
                    }
                }
            }
            if (SerialPortL.IsOpen)
            {
                SerialPortL.Write(string.Join("+", textL));
            }
            if (SerialPortR.IsOpen)
            {
                SerialPortR.Write(string.Join("+", textR));
            }
        }
        #endregion
        public InMoov()
        {
            InitializeComponent();
            InitializeUI();
            InitializeTimer();
        }
    }
}
