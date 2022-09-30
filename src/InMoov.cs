using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.IO;

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
                        ((ComboBox)PanelMain.GetControlFromPosition(i, 1)).DropDown += (obj, evt) =>
                        {
                            ComboBox box = (ComboBox)obj;
                            box.Items.Clear();
                            box.Items.AddRange(SerialPort.GetPortNames());
                            box.Items.Remove(((ComboBox)PanelMain.GetControlFromPosition((i + 1) % 2, 1)).Text);
                        };
                        ((ComboBox)PanelMain.GetControlFromPosition(i, 2)).Items.AddRange(Constant.Bauds);
                        ((ComboBox)PanelMain.GetControlFromPosition(i, 2)).Text = "115200";
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
            PanelMain.BorderStyle = BorderStyle.FixedSingle;
            PanelMain.CellPaint += CellPaintMain;
            BoxGesture.BackColor = Color.MediumVioletRed;
            BoxGesture.CheckedChanged += (obj, evt) =>
            {
                CheckBox button = (CheckBox)obj;
                bool check = button.Checked;
                button.BackColor = check ? Color.GreenYellow : Color.MediumVioletRed;
                button.Text = check ? "Enabled" : "Disabled";
                ButtonRead.Enabled = check;
                ButtonWrite.Enabled = check;
                if (check)
                {
                    var forms = Application.OpenForms.Cast<Form>().Select(f => f.Name);
                    foreach (string s in Constant.ModulesAction)
                    {
                        if (forms.Contains(s))
                        {
                            Application.OpenForms[s].Close();
                        }
                    }
                }
                for (int i = 1; i < PanelMain.ColumnCount; i++)
                {
                    for (int j = 4; j < PanelMain.RowCount - 2; j++)
                    {
                        PanelMain.GetControlFromPosition(i, j).Enabled = !check;
                    }
                }
            };
            PanelGesture.BorderStyle = BorderStyle.FixedSingle;
            PanelGesture.CellPaint += CellPaintGesture;
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
        private void SerialPortChanged(object sender, EventArgs evt)
        {
            var box = (ComboBox)sender;
            typeof(InMoov).GetField(box.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(this, box.Text);
            void UpdateSerialPort(SerialPort serial, int col, string port, string baud)
            {
                if (PanelMain.GetColumn(box) == col)
                {
                    if (!string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(baud))
                    {
                        PanelMain.GetControlFromPosition(col, 3).Enabled = true;
                    }
                    if (serial.IsOpen)
                    { 
                        serial.Close();
                    }
                    for (int i = 4; i < PanelMain.RowCount - 2; i++)
                    {
                        PanelMain.GetControlFromPosition(col, i).Enabled = false;
                    }
                    PanelGesture.Enabled = false;
                }
            }
            UpdateSerialPort(SerialPortL, 1, portL, baudL);
            UpdateSerialPort(SerialPortR, 2, portR, baudR);
        }
        private void SerialPortConnect(object sender, EventArgs evt)
        {
            var button = (Button)sender;
            button.Enabled = false;
            void UpdateConnection(SerialPort serial, int col, string port, string baud)
            {
                if (PanelMain.GetColumn(button) == col)
                {
                    serial.PortName = port;
                    serial.BaudRate = int.Parse(baud);
                    if (!serial.IsOpen)
                    {
                        try
                        {
                            serial.Open();
                            for (int i = 4; i < PanelMain.RowCount - 2; i++)
                            {
                                PanelMain.GetControlFromPosition(col, i).Enabled = true;
                            }
                            PanelGesture.Enabled = true;
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
        private void ActionOpen(object sender, EventArgs evt)
        {
            var button = (Button)sender;
            button.Enabled = false;
            int port = GetModuleIndex(PanelMain.GetColumn(button), PanelMain.GetRow(button)) * 5;
            bool CheckAnyActionOpen()
            {
                var forms = Application.OpenForms.Cast<Form>().Select(f => f.Name);
                foreach (string s in Constant.ModulesAction)
                {
                    if (forms.Contains(s))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (Constant.Names.TryGetValue(button.Text, out List<string> names) &&
                Constant.Limits.TryGetValue(button.Text, out List<int[]> limits) &&
                Constant.Values.TryGetValue(button.Text, out List<int> values))
            {
                InMoov_Action module = new InMoov_Action(names, port, limits, values, button.Text);
                module.FormClosed += (obj, evt0) => 
                { 
                    button.Enabled = true;
                    if (!CheckAnyActionOpen())
                    {
                        TimerMain.Enabled = false;
                    }
                };
                module.Show();
                TimerMain.Enabled = true;
            }
            else
            {
                MessageBox.Show("Module Not Initialized!");
            }
        }
        private void PerceptionOpen(object sender, EventArgs evt)
        {}
        private void CellPaintMain(object sender, TableLayoutCellPaintEventArgs evt)
        {
            if (new int[] {0, 1, 4, 7}.Contains(evt.Row))
            {
                evt.Graphics.DrawLine(Pens.Gray, evt.CellBounds.Location, new Point(evt.CellBounds.Right, evt.CellBounds.Top));
            }
            if (evt.Column == 1 || (evt.Column == 2 && evt.Row != 7 && evt.Row != 8))
            {
                evt.Graphics.DrawLine(Pens.Gray, evt.CellBounds.Location, new Point(evt.CellBounds.Left, evt.CellBounds.Bottom));
            }
        }
        private void CellPaintGesture(object sender, TableLayoutCellPaintEventArgs evt)
        {
            if (evt.Row == 1 || evt.Row == 2)
            {
                evt.Graphics.DrawLine(Pens.Gray, evt.CellBounds.Location, new Point(evt.CellBounds.Right, evt.CellBounds.Top));
            }
            if (evt.Column == 1 && evt.Row != 0 && evt.Row != 1)
            {
                evt.Graphics.DrawLine(Pens.Gray, evt.CellBounds.Location, new Point(evt.CellBounds.Left, evt.CellBounds.Bottom));
            }
        }
        private void TimerElapsed(object sender, EventArgs evt)
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
        private void ReadGesture(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\gestures\\",
                Filter = "Gesture files (*.gesture)|*.gesture",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (file.ShowDialog() == DialogResult.OK)
            {
                string filePath = file.FileName;
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
