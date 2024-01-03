using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace harper_gui
{
    public partial class Action : Form
    {
        #region Initializer & Event Handler
        private void InitializePanelAction(List<string> names, int port, List<int[]> limits, List<int> values)
        {
            for (int i = 1; i < PanelAction.ColumnCount; i++)
            {
                var ListPanelAction = new List<Control>
            {
                new Label()
                {
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = names[i - 1]
                },
                new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 50,
                    Value = port + (i - 1)
                },
                new CheckBox()
                {
                    Appearance = Appearance.Button,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Red,
                    Checked = false,
                    Text = "Detached"
                },
                new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 3000,
                    Value = limits[i - 1][1],
                    Enabled = true
                },
                new TrackBar()
                {
                    Orientation = Orientation.Vertical,
                    Minimum = 0,
                    Maximum = 180,
                    SmallChange = 1,
                    LargeChange = 30,
                    TickFrequency = 18,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Value = values[i - 1],
                },
                new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 3000,
                    Value = limits[i - 1][0],
                    Enabled = true
                },
                new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 180,
                    Value = values[i - 1]
                },
                new CheckBox()
                {
                    Appearance = Appearance.Button,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Orange,
                    Checked = false,
                    Text = "Single",
                    Enabled = false
                },
            };
                foreach (Control control in ListPanelAction)
                {
                    PanelAction.Controls.Add(control, i, ListPanelAction.IndexOf(control));
                    control.Anchor = control is TrackBar ? Anchor = AnchorStyles.Top | AnchorStyles.Bottom : AnchorStyles.None;
                    if (ListPanelAction.IndexOf(control) == 2)
                    {
                        (control as CheckBox).CheckedChanged += (obj, evt) =>
                        {
                            CheckBox button = (CheckBox)obj;
                            button.BackColor = button.Checked ? Color.Green : Color.Red;
                            button.Text = button.Checked ? "Enabled" : "Disabled";
                            ListPanelAction[3].Enabled = !button.Checked;
                            ListPanelAction[5].Enabled = !button.Checked;
                            ControlBox = FormCloseAllowed();
                        };
                    }
                    if (ListPanelAction.IndexOf(control) == 7)
                    {
                        (control as CheckBox).CheckedChanged += (obj, evt) =>
                        {
                            CheckBox button = (CheckBox)obj;
                            button.BackColor = button.Checked ? Color.AliceBlue : Color.Orange;
                            button.Text = button.Checked ? "Multiple" : "Single";
                            ListPanelAction[4].Enabled = !button.Checked;
                            ListPanelAction[6].Enabled = !button.Checked;
                        };
                    }
                    if (control is TrackBar)
                    {
                        (control as TrackBar).Scroll += (obj, evt) => { (ListPanelAction[6] as NumericUpDown).Value = (obj as TrackBar).Value; };
                    }
                    if (ListPanelAction.IndexOf(control) == 6)
                    {
                        (control as NumericUpDown).ValueChanged += (obj, evt) => { (ListPanelAction[4] as TrackBar).Value = (int)(obj as NumericUpDown).Value; };
                    }
                }
            }
            PanelAction.BorderStyle = BorderStyle.FixedSingle;
        }
        private void InitializePanelMultipleAction()
        {
            var ListPanelMultipleAction = new List<Control>
            {
                new CheckBox()
                {
                    Appearance = Appearance.Button,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.MediumPurple,
                    Checked = false,
                    Text = "Disabled",
                },
                new TrackBar()
                {
                    Orientation = Orientation.Vertical,
                    Minimum = 0,
                    Maximum = 180,
                    SmallChange = 1,
                    LargeChange = 30,
                    TickFrequency = 18,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Value = 0,
                    Enabled = false
                },
                new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 180,
                    Value = 0,
                    Enabled = false
                }
            };
            foreach (Control control in ListPanelMultipleAction)
            {
                PanelMultipleAction.Controls.Add(control, 0, ListPanelMultipleAction.IndexOf(control) + 1);
                control.Anchor = control is TrackBar ? Anchor = AnchorStyles.Top | AnchorStyles.Bottom : AnchorStyles.None;
                if (control is CheckBox)
                {
                    control.Dock = DockStyle.Fill;
                    (control as CheckBox).CheckedChanged += (obj, evt) =>
                    {
                        CheckBox button = (CheckBox)obj;
                        button.BackColor = button.Checked ? Color.LightYellow : Color.MediumPurple;
                        button.Text = button.Checked ? "Enabled" : "Disabled";
                        ListPanelMultipleAction[1].Enabled = button.Checked;
                        ListPanelMultipleAction[2].Enabled = button.Checked;
                        for (int i = 1; i < PanelAction.ColumnCount; i++)
                        {
                            if (!button.Checked)
                            {
                                (PanelAction.GetControlFromPosition(i, 7) as CheckBox).Checked = button.Checked;
                            }
                            PanelAction.GetControlFromPosition(i, 7).Enabled = button.Checked;
                        }
                    };
                }
                if (control is TrackBar)
                {
                    (control as TrackBar).Scroll += (obj, evt) => { (ListPanelMultipleAction[2] as NumericUpDown).Value = (obj as TrackBar).Value; };
                }
                if (control is NumericUpDown)
                {
                    (control as NumericUpDown).ValueChanged += (obj, evt) =>
                    {
                        (ListPanelMultipleAction[1] as TrackBar).Value = (int)(obj as NumericUpDown).Value;
                        for (int i = 1; i < PanelAction.ColumnCount; i++)
                        {
                            if ((PanelAction.GetControlFromPosition(i, 7) as CheckBox).Checked)
                            {
                                (PanelAction.GetControlFromPosition(i, 6) as NumericUpDown).Value = (int)(obj as NumericUpDown).Value;
                            }
                        }
                    };
                }
            }
            PanelMultipleAction.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion
        public Action(List<string> names, int port, List<int[]> limits, List<int> values, string text)
        {
            InitializeComponent();
            InitializePanelAction(names, port, limits, values);
            InitializePanelMultipleAction();
            Name = Text = text;
        }
        public List<string> ToStringList()
        {
            int val(int col, int row)
            {
                Control control = PanelAction.GetControlFromPosition(col, row);
                if (control is CheckBox)
                {
                    return Convert.ToInt32((control as CheckBox).Checked);
                }
                else
                {
                    return (int)(control as NumericUpDown).Value;
                }
            }
            var ls = new List<String>();
            for (int i = 1; i < PanelAction.ColumnCount; i++)
            {
                ls.Add(string.Join(".", val(i, 1), val(i, 2), val(i, 5), val(i, 3), val(i, 6)) + "\n");
            }
            return ls;
        }
        private bool FormCloseAllowed()
        {
            for (int i = 1; i < PanelAction.ColumnCount; i++)
            {
                if ((PanelAction.GetControlFromPosition(i, 2) as CheckBox).Checked == true)
                {
                    return false;
                }
            }
                return true;
        }   
    }
}
