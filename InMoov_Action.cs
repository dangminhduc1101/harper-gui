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
                    Text = "Attach"
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
            };
                foreach (Control c in l)
                {
                    PanelAction.Controls.Add(c, i, l.IndexOf(c));
                    c.Anchor = c is TrackBar ? Anchor = AnchorStyles.Top | AnchorStyles.Bottom : AnchorStyles.None;
                    if (c is CheckBox)
                    {
                        (c as CheckBox).CheckedChanged += (o, e) =>
                        {
                            CheckBox b = (CheckBox)o;
                            b.BackColor = b.Checked ? Color.Green : Color.Red;
                            b.Text = b.Checked ? "Detach" : "Attach";
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
                }
            }
        }
        public override string ToString()
        {
 
            string text(int col, int row)
            {
                Control c = PanelAction.GetControlFromPosition(col, row);
                if (c is CheckBox)
                {
                    return (c as CheckBox).Checked ? "A" : "D";
                }
                else
                {
                    return (c as NumericUpDown).Value.ToString();
                }
            }
            return string.Join("/", Enumerable.Range(1, PanelAction.ColumnCount - 1).Select(i => string.Join(".", text(i, 1), text(i, 2), text(i, 5), text(i, 3), text(i, 6))));
        }
    }
}
