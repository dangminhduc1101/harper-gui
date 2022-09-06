using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InMoov_GUI
{
    public partial class InMoov_Action : Form
    {
        public InMoov_Action(List<string> names, int port, List<int[]> limits, List<int> values, string text)
        {
            InitializeComponent();
            Name = Text = text;
            for (int i = 1; i < PanelAction.ColumnCount; i++)
            {
                var l = new List<Control>
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
                    Value = limits[i - 1][1]
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
                    Value = limits[i - 1][0]
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
                    Text = "Single"
                },
            };
                foreach (Control c in l)
                {
                    PanelAction.Controls.Add(c, i, l.IndexOf(c));
                    c.Anchor = c is TrackBar ? Anchor = AnchorStyles.Top | AnchorStyles.Bottom : AnchorStyles.None;
                    if (l.IndexOf(c) == 2)
                    {
                        (c as CheckBox).CheckedChanged += (o, e) =>
                        {
                            CheckBox b = (CheckBox)o;
                            b.BackColor = b.Checked ? Color.Green : Color.Red;
                            b.Text = b.Checked ? "Attached" : "Detached";
                        };
                    }
                    if (c is TrackBar)
                    {
                        (c as TrackBar).Scroll += (o, e) => { (l[6] as NumericUpDown).Value = (o as TrackBar).Value; };
                    }
                    if (l.IndexOf(c) == 6)
                    {
                        (c as NumericUpDown).ValueChanged += (o, e) => { (l[4] as TrackBar).Value = (int)(o as NumericUpDown).Value; };
                    }
                    if (l.IndexOf(c) == 7)
                    {
                        (c as CheckBox).CheckedChanged += (o, e) =>
                        {
                            CheckBox b = (CheckBox)o;
                            b.BackColor = b.Checked ? Color.Blue : Color.Orange;
                            b.Text = b.Checked ? "Multiple" : "Single";
                        };
                    }
                }
            }
        }
        public override string ToString()
        {
            int val(int col, int row)
            {
                Control c = PanelAction.GetControlFromPosition(col, row);
                if (c is CheckBox)
                {
                    return Convert.ToInt32((c as CheckBox).Checked);
                }
                else
                {
                    return (int)(c as NumericUpDown).Value;
                }
            }
            return string.Join("/", Enumerable.Range(1, PanelAction.ColumnCount - 1).Select(i => string.Join(".", val(i, 1), val(i, 2), val(i, 5), val(i, 3), val(i, 6))));
        }
    }
}
