using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Svg;
using Spire.Pdf;
using ImageMagick;

namespace FinalProjectSVGEditor
{
    public partial class MainForm : Form
    {
        private SVGCodeViewForm svgCodeViewForm;
        private WebForm webForm;
        public List<Shape> Shapes = new List<Shape>();
        public List<Shape> Undo = new List<Shape>();
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing = false;
        private int mouseX, mouseY, mouseMoveWidth, mouseMoveHeight, size;
        private string log;
        private string loadWorkByUserPath;
        private bool existDatFile = false;
        private float scaleFactor = 1.0f;

        public MainForm()
        {
            InitializeComponent();
            StatusStrip statusStrip = new StatusStrip();
            ToolStripStatusLabel toolStripStatusLabel = new ToolStripStatusLabel();
            svgCodeViewForm = new SVGCodeViewForm();
            webForm = new WebForm();

            strokeColorDialog.Color = Color.Black;
            fillColorDialog.Color = Color.Aquamarine;
            this.MinimumSize = new Size(1000, 720);
            statusStrip.SizingGrip = true;
            toolStripStatusLabel.Spring = true;
            statusStrip.Items.Add(toolStripStatusLabel);
            toolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(statusStrip);

            strokeColorButton.BackColor = strokeColorDialog.Color;
            strokeColorButton.ForeColor = Color.White;
            fillColorButton.BackColor = fillColorDialog.Color;
            fillColorButton.ForeColor = Color.Black;

            penStatus.Text = "Type: Ellipse";
            using (File.Create("./SVGTempOutput.svg"))
            {
            }
            svgCodeViewForm.Visible = true;
            Point svgCodeViewFormLocation = new Point(this.Location.X + this.Width - 16, this.Location.Y);
            svgCodeViewForm.Location = svgCodeViewFormLocation;
            svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            undoToolStripMenuItem.Enabled = false;
            this.MouseWheel += new MouseEventHandler(MainForm_MouseWheel);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var file in Directory.GetFiles("./SAVEDATA"))
            {
                if (Path.GetExtension(file).ToLower() == ".dat")
                {
                    existDatFile = true;
                    break;
                }
            }
            labelWorkingOn.Text = "Working On: UnSaved File";
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (existDatFile)
            {
                if (MessageBox.Show("Found work savefile!\nDo you want to load£¿", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    loadWorkByUser();
                }
            }
            log = $"[{DateTime.Now.ToString("HH:mm:ss")}] InitializeComponent Success! ";
            logrichTextBox.AppendText(log + "\n");
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (rightToolStripMenuItem.Checked)
            {
                Point svgCodeViewFormLocation = new Point(this.Location.X + this.Width - 16, this.Location.Y);
                svgCodeViewForm.Location = svgCodeViewFormLocation;
                svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else if (leftToolStripMenuItem.Checked)
            {
                Point svgCodeViewFormLocation = new Point(this.Location.X - svgCodeViewForm.Width + 16, this.Location.Y);
                svgCodeViewForm.Location = svgCodeViewFormLocation;
                svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (leftToolStripMenuItem.Checked)
            {
                Point svgCodeViewFormLocation = new Point(this.Location.X - svgCodeViewForm.Width + 16, this.Location.Y);
                svgCodeViewForm.Location = svgCodeViewFormLocation;
                svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else if (rightToolStripMenuItem.Checked)
            {
                Point svgCodeViewFormLocation = new Point(this.Location.X + this.Width - 16, this.Location.Y);
                svgCodeViewForm.Location = svgCodeViewFormLocation;
                svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            groupBoxPenstyle.Visible = false;
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomIn();
            }
            else
            {
                zoomOut();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var filePath = "./SVGTempOutput.svg";
            var saved = checkSavedOrNot();
            if (saved)
            {
                if (File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty);
                }
            }
            else
            {
                if (MessageBox.Show("You do not save your work!\nDo you want to exit£¿", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (File.Exists(filePath))
                    {
                        File.WriteAllText(filePath, string.Empty);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void pictureBoxDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Get MouseDown positon as the graph start position.
                startPoint = e.Location;
                isDrawing = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                isDrawing = false;
                pictureBoxDrawingArea.Invalidate();
            }
        }

        private void pictureBoxDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            var mouseX = e.X;
            var mouseY = e.Y;
            label3coordinate.Text = "X: " + mouseX.ToString() + ", Y: " + mouseY.ToString();
            if (e.Button == MouseButtons.Left && isDrawing == true)
            {
                // Set Mouse move position to update the width and height of the graph.
                endPoint = e.Location;
                pictureBoxDrawingArea.Invalidate();
            }
        }

        private void pictureBoxDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDrawing == true)
            {
                // Set Mouse up position as the final position of the end position for the graph, and add the final data to List Shape.
                isDrawing = false;
                endPoint = e.Location;
                if (startPoint != endPoint)
                {
                    if (squareRadioButton.Checked)
                    {
                        addShapeIntoShapes(mouseX, mouseY, size, size);
                    }
                    else if (circleRadioButton.Checked)
                    {
                        addShapeIntoShapes(mouseX, mouseY, size, size);
                    }
                    else
                    {
                        addShapeIntoShapes(mouseX, mouseY, mouseMoveWidth, mouseMoveHeight);
                    }
                }
                pictureBoxDrawingArea.Invalidate();
            }
            else
            {
                if (Shapes.Count > 1)
                {
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Delete {Shapes[Shapes.Count - 1].Type} Success!(Filled: {Shapes[Shapes.Count - 1].Filled}, LineThickness: {Shapes[Shapes.Count - 1].StrokeThickness}, LineColor: {"#" + Shapes[Shapes.Count - 1].StrokeColor.ToArgb().ToString("X").Substring(2)})";
                    logrichTextBox.AppendText(log + "\n");
                    Undo.Add(Shapes[Shapes.Count - 1]);
                    Shapes.RemoveAt(Shapes.Count - 1);
                    pictureBoxDrawingArea.Invalidate();
                    deleteShapeIntoSvgFile();
                    undoToolStripMenuItem.Enabled = true;
                }
                else if (Shapes.Count == 1)
                {
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Delete {Shapes[Shapes.Count - 1].Type} Success!(Filled: {Shapes[Shapes.Count - 1].Filled}, LineThickness: {Shapes[Shapes.Count - 1].StrokeThickness}, LineColor: {"#" + Shapes[Shapes.Count - 1].StrokeColor.ToArgb().ToString("X").Substring(2)})";
                    logrichTextBox.AppendText(log + "\n");
                    File.WriteAllText("./SVGTempOutput.svg", string.Empty);
                    Undo.Add(Shapes[Shapes.Count - 1]);
                    Shapes.RemoveAt(Shapes.Count - 1);
                    pictureBoxDrawingArea.Invalidate();
                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
                    watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
                    watcher.Changed += (sender, e) =>
                    {
                    };
                    watcher.EnableRaisingEvents = true;
                    using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
                    {
                        string text = sr.ReadToEnd();
                        svgCodeViewForm.richTextBox1.Text = text;
                    }
                }
            }
        }

        private void pictureBoxDrawingArea_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing == true)
            {
                List<ShapeInDrawing> shapeInDrawing = new List<ShapeInDrawing>();
                shapeInDrawing.Add(new ShapeInDrawing()
                {
                    FillColor = fillColorDialog.Color,
                    StrokeThickness = strokeWidthTrackBar.Value,
                });
                Pen isDrawingPen = new Pen(Color.Red, shapeInDrawing[0].StrokeThickness);
                SolidBrush isDrawingBrush = new SolidBrush(shapeInDrawing[0].FillColor);
                isDrawingPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                mouseX = Math.Min(startPoint.X, endPoint.X);
                mouseY = Math.Min(startPoint.Y, endPoint.Y);
                mouseMoveWidth = Math.Abs(startPoint.X - endPoint.X);
                mouseMoveHeight = Math.Abs(startPoint.Y - endPoint.Y);
                size = Math.Max(Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
                if (ellipseRadioButton.Checked)
                {
                    if (filledCheckBox.Checked)
                    {
                        e.Graphics.FillEllipse(isDrawingBrush, mouseX, mouseY, mouseMoveWidth, mouseMoveHeight);
                    }
                    e.Graphics.DrawEllipse(isDrawingPen, mouseX, mouseY, mouseMoveWidth, mouseMoveHeight);
                }
                else if (circleRadioButton.Checked)
                {
                    if (filledCheckBox.Checked)
                    {
                        e.Graphics.FillEllipse(isDrawingBrush, mouseX, mouseY, size, size);
                    }
                    e.Graphics.DrawEllipse(isDrawingPen, mouseX, mouseY, size, size);
                }
                else if (rectangleRadioButton.Checked)
                {
                    if (filledCheckBox.Checked)
                    {
                        e.Graphics.FillRectangle(isDrawingBrush, mouseX, mouseY, mouseMoveWidth, mouseMoveHeight);
                    }
                    e.Graphics.DrawRectangle(isDrawingPen, mouseX, mouseY, mouseMoveWidth, mouseMoveHeight);
                }
                else if (squareRadioButton.Checked)
                {
                    if (filledCheckBox.Checked)
                    {
                        e.Graphics.FillRectangle(isDrawingBrush, mouseX, mouseY, size, size);
                    }
                    e.Graphics.DrawRectangle(isDrawingPen, mouseX, mouseY, size, size);
                }
                else if (lineRadioButton.Checked)
                {
                    if (filledCheckBox.Checked)
                    {
                        e.Graphics.DrawLine(isDrawingPen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                    }
                    e.Graphics.DrawLine(isDrawingPen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                }
                isDrawingPen.Dispose();
            }
            e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            foreach (var shape in Shapes)
            {
                using var pen = new Pen(shape.StrokeColor, shape.StrokeThickness);
                using var brush = new SolidBrush(shape.FillColor);
                if (shape.Type == ShapeType.Ellipse)
                {
                    if (shape.Filled)
                    {
                        e.Graphics.FillEllipse(brush, shape.X, shape.Y, shape.Width, shape.Height);
                    }
                    e.Graphics.DrawEllipse(pen, shape.X, shape.Y, shape.Width, shape.Height);
                }

                if (shape.Type == ShapeType.Circle)
                {
                    if (shape.Filled)
                    {
                        e.Graphics.FillEllipse(brush, shape.X, shape.Y, shape.Width, shape.Height);
                    }
                    e.Graphics.DrawEllipse(pen, shape.X, shape.Y, shape.Width, shape.Height);
                }

                if (shape.Type == ShapeType.Rect)
                {
                    if (shape.Filled)
                    {
                        e.Graphics.FillRectangle(brush, shape.X, shape.Y, shape.Width, shape.Height);
                    }
                    e.Graphics.DrawRectangle(pen, shape.X, shape.Y, shape.Width, shape.Height);
                }

                if (shape.Type == ShapeType.Square)
                {
                    if (shape.Filled)
                    {
                        e.Graphics.FillRectangle(brush, shape.X, shape.Y, shape.Width, shape.Height);
                    }
                    e.Graphics.DrawRectangle(pen, shape.X, shape.Y, shape.Width, shape.Height);
                }

                if (shape.Type == ShapeType.Line)
                {
                    if (shape.Filled)
                    {
                        e.Graphics.DrawLine(pen, shape.X, shape.Y, shape.Width, shape.Height);
                    }
                    e.Graphics.DrawLine(pen, shape.X, shape.Y, shape.Width, shape.Height);
                }
            }
        }

        private void pictureBoxDrawingArea_Click(object sender, EventArgs e)
        {
            groupBoxPenstyle.Visible = false;
        }

        private void ellipseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ellipseRadioButton.Checked)
            {
                penStatus.Text = "Type: Ellipse";
            }
        }

        private void circleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            penStatus.Text = "Type: Circle";
        }

        private void rectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            penStatus.Text = "Type: Rectangle";
        }

        private void squareRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            penStatus.Text = "Type: Square";
        }

        private void lineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            penStatus.Text = "Type: Line";
        }

        private void strokeColorButton_Click(object sender, EventArgs e)
        {
            var brightness = strokeColorDialog.Color.GetBrightness();
            strokeColorDialog.ShowDialog();
            strokeColorButton.BackColor = strokeColorDialog.Color;
            if (brightness < 0.5)
            {
                strokeColorButton.ForeColor = Color.White;
            }
            else
            {
                strokeColorButton.ForeColor = Color.Black;
            }
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            var brightness = fillColorDialog.Color.GetBrightness();
            fillColorDialog.ShowDialog();
            fillColorButton.BackColor = fillColorDialog.Color;
            if (brightness < 0.5)
            {
                fillColorButton.ForeColor = Color.White;
            }
            else
            {
                fillColorButton.ForeColor = Color.Black;
            }
        }

        // Method for the data add to List
        private void addShapeIntoShapes(int x, int y, int width, int height)
        {
            if (ellipseRadioButton.Checked)
            {
                Shapes.Add(new Shape()
                {
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = ShapeType.Ellipse
                });
                if (filledCheckBox.Checked)
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2), filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Ellipse);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Ellipse Success!(Filled: YES, FillColor: {"#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2)}, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                else
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "none", filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Ellipse);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Ellipse Success!(Filled: NO, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                logrichTextBox.AppendText(log + "\n");
            }
            else if (circleRadioButton.Checked)
            {
                Shapes.Add(new Shape()
                {
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = ShapeType.Circle

                });
                if (filledCheckBox.Checked)
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2), filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Circle);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Circle Success!(Filled: YES, FillColor: {"#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2)}, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                else
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "none", filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Circle);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Circle Success!(Filled: NO, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                logrichTextBox.AppendText(log + "\n");
            }
            else if (rectangleRadioButton.Checked)
            {
                Shapes.Add(new Shape()
                {
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = ShapeType.Rect
                });
                if (filledCheckBox.Checked)
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2), filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Rect);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Rectangle Success!(Filled: YES, FillColor: {"#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2)}, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                else
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "none", filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Rect);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Rectangle Success!(Filled: NO, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                logrichTextBox.AppendText(log + "\n");
            }
            else if (squareRadioButton.Checked)
            {
                Shapes.Add(new Shape()
                {
                    X = x,
                    Y = y,
                    Width = width,
                    Height = height,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = ShapeType.Square
                });
                if (filledCheckBox.Checked)
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2), filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Square);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Square Success!(Filled: YES, FillColor: {"#" + fillColorDialog.Color.ToArgb().ToString("X").Substring(2)}, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                else
                {
                    outputSVGFile(x, y, width, height, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "none", filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Square);
                    log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Square Success!(Filled: NO, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Width: {width}, Height: {height})";
                }
                logrichTextBox.AppendText(log + "\n");
            }
            else if (lineRadioButton.Checked)
            {
                Shapes.Add(new Shape()
                {
                    X = startPoint.X,
                    Y = startPoint.Y,
                    Width = endPoint.X,
                    Height = endPoint.Y,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = ShapeType.Line
                });
                outputSVGFile(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, "#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2), "none", filledCheckBox.Checked, strokeWidthTrackBar.Value, ShapeType.Line);
                log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Draw Line Success!(Filled: NO, LineThickness: {strokeWidthTrackBar.Value}, LineColor: {"#" + strokeColorDialog.Color.ToArgb().ToString("X").Substring(2)}, Length: {Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2))}";
                logrichTextBox.AppendText(log + "\n");
            }
        }

        private void undoShape()
        {
            if (Undo.Count > 0)
            {
                var fillColorHex = "";
                var lastItem = Undo[Undo.Count - 1];
                Undo.RemoveAt(Undo.Count - 1);
                Shapes.Add(lastItem);
                pictureBoxDrawingArea.Invalidate();
                var strokeColorHex = $"#{Shapes[Shapes.Count - 1].StrokeColor.R:X2}{Shapes[Shapes.Count - 1].StrokeColor.G:X2}{Shapes[Shapes.Count - 1].StrokeColor.B:X2}";
                if (!Shapes[Shapes.Count - 1].Filled)
                {
                    fillColorHex = "none";
                }
                else
                {
                    fillColorHex = $"#{Shapes[Shapes.Count - 1].FillColor.R:X2}{Shapes[Shapes.Count - 1].FillColor.G:X2}{Shapes[Shapes.Count - 1].FillColor.B:X2}";
                }
                outputSVGFile(Shapes[Shapes.Count - 1].X, Shapes[Shapes.Count - 1].Y, Shapes[Shapes.Count - 1].Width, Shapes[Shapes.Count - 1].Height, strokeColorHex, fillColorHex, Shapes[Shapes.Count - 1].Filled, Shapes[Shapes.Count - 1].StrokeThickness, Shapes[Shapes.Count - 1].Type);

            }
        }

        private void deleteShapeIntoSvgFile()
        {
            string filePath = "./SVGTempOutput.svg";
            string svgContent = File.ReadAllText(filePath);
            var svgDoc = SvgDocument.FromSvg<SvgDocument>(svgContent);
            var lastElement = svgDoc.Children.LastOrDefault();
            if (lastElement != null && lastElement is SvgVisualElement)
            {
                svgDoc.Children.Remove(lastElement);
            }
            svgDoc.Write(filePath);
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
            watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
            watcher.Changed += (sender, e) =>
            {
            };
            watcher.EnableRaisingEvents = true;
            using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
            {
                string text = sr.ReadToEnd();
                svgCodeViewForm.richTextBox1.Text = text;
            }
        }

        private void outputSVGFile(float x, float y, float width, float height, string strokeColor, string fillColor, bool filled, float strokeThickness, ShapeType type)
        {
            var centerX = x + (width / 2);
            var centerY = y + (height / 2);
            var radiusX = width / 2;
            var radiusY = height / 2;
            var filePath = "./SVGTempOutput.svg";
            var content = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(content))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlElement svg = doc.DocumentElement;
                XmlElement lastShape = null;
                foreach (XmlElement element in svg.ChildNodes)
                {
                    if (element.Name == "rect" || element.Name == "circle" || element.Name == "ellipse" || element.Name == "line" || element.Name == "polygon" || element.Name == "polyline")
                    {
                        lastShape = element;
                    }
                }
                if (lastShape != null)
                {
                    if (type == ShapeType.Ellipse)
                    {
                        XmlElement ellipse = doc.CreateElement("ellipse", svg.NamespaceURI);
                        ellipse.SetAttribute("cx", $"{centerX}");
                        ellipse.SetAttribute("cy", $"{centerY}");
                        ellipse.SetAttribute("rx", $"{radiusX}");
                        ellipse.SetAttribute("ry", $"{radiusY}");
                        ellipse.SetAttribute("fill", $"{fillColor}");
                        ellipse.SetAttribute("stroke-width", $"{strokeThickness}");
                        ellipse.SetAttribute("stroke", $"{strokeColor}");
                        svg.InsertAfter(ellipse, lastShape);
                    }
                    else if (type == ShapeType.Circle)
                    {
                        XmlElement circle = doc.CreateElement("ellipse", svg.NamespaceURI);
                        circle.SetAttribute("cx", $"{centerX}");
                        circle.SetAttribute("cy", $"{centerY}");
                        circle.SetAttribute("rx", $"{radiusX}");
                        circle.SetAttribute("ry", $"{radiusY}");
                        circle.SetAttribute("fill", $"{fillColor}");
                        circle.SetAttribute("stroke-width", $"{strokeThickness}");
                        circle.SetAttribute("stroke", $"{strokeColor}");
                        svg.InsertAfter(circle, lastShape);
                    }
                    else if (type == ShapeType.Rect)
                    {
                        XmlElement rectangle = doc.CreateElement("rect", svg.NamespaceURI);
                        rectangle.SetAttribute("x", $"{x}");
                        rectangle.SetAttribute("y", $"{y}");
                        rectangle.SetAttribute("width", $"{width}");
                        rectangle.SetAttribute("height", $"{height}");
                        rectangle.SetAttribute("fill", $"{fillColor}");
                        rectangle.SetAttribute("stroke-width", $"{strokeThickness}");
                        rectangle.SetAttribute("stroke", $"{strokeColor}");
                        svg.InsertAfter(rectangle, lastShape);
                    }
                    else if (type == ShapeType.Square)
                    {
                        XmlElement rectangle = doc.CreateElement("rect", svg.NamespaceURI);
                        rectangle.SetAttribute("x", $"{x}");
                        rectangle.SetAttribute("y", $"{y}");
                        rectangle.SetAttribute("width", $"{width}");
                        rectangle.SetAttribute("height", $"{height}");
                        rectangle.SetAttribute("fill", $"{fillColor}");
                        rectangle.SetAttribute("stroke-width", $"{strokeThickness}");
                        rectangle.SetAttribute("stroke", $"{strokeColor}");
                        svg.InsertAfter(rectangle, lastShape);
                    }
                    else if (type == ShapeType.Line)
                    {
                        XmlElement line = doc.CreateElement("line", svg.NamespaceURI);
                        line.SetAttribute("x1", $"{x}");
                        line.SetAttribute("y1", $"{y}");
                        line.SetAttribute("x2", $"{width}");
                        line.SetAttribute("y2", $"{height}");
                        line.SetAttribute("stroke-width", $"{strokeThickness}");
                        line.SetAttribute("stroke", $"{strokeColor}");
                        svg.InsertAfter(line, lastShape);
                    }
                }
                doc.Save(filePath);
            }
            else
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(filePath, settings);

                writer.WriteStartDocument();
                writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");
                writer.WriteAttributeString("version", "1.1");
                writer.WriteAttributeString("width", "1920");
                writer.WriteAttributeString("height", "1080");

                if (type == ShapeType.Ellipse)
                {
                    writer.WriteStartElement("ellipse");
                    writer.WriteAttributeString("cx", $"{centerX}");
                    writer.WriteAttributeString("cy", $"{centerY}");
                    writer.WriteAttributeString("rx", $"{radiusX}");
                    writer.WriteAttributeString("ry", $"{radiusY}");
                    writer.WriteAttributeString("fill", $"{fillColor}");
                    writer.WriteAttributeString("stroke-width", $"{strokeThickness}");
                    writer.WriteAttributeString("stroke", $"{strokeColor}");
                    writer.WriteEndElement();
                }
                else if (type == ShapeType.Circle)
                {
                    writer.WriteStartElement("ellipse");
                    writer.WriteAttributeString("cx", $"{centerX}");
                    writer.WriteAttributeString("cy", $"{centerY}");
                    writer.WriteAttributeString("rx", $"{radiusX}");
                    writer.WriteAttributeString("ry", $"{radiusY}");
                    writer.WriteAttributeString("fill", $"{fillColor}");
                    writer.WriteAttributeString("stroke-width", $"{strokeThickness}");
                    writer.WriteAttributeString("stroke", $"{strokeColor}");
                    writer.WriteEndElement();
                }
                else if (type == ShapeType.Rect)
                {
                    writer.WriteStartElement("rect");
                    writer.WriteAttributeString("x", $"{x}");
                    writer.WriteAttributeString("y", $"{y}");
                    writer.WriteAttributeString("width", $"{width}");
                    writer.WriteAttributeString("height", $"{height}");
                    writer.WriteAttributeString("fill", $"{fillColor}");
                    writer.WriteAttributeString("stroke-width", $"{strokeThickness}");
                    writer.WriteAttributeString("stroke", $"{strokeColor}");
                    writer.WriteEndElement();
                }
                else if (type == ShapeType.Square)
                {
                    writer.WriteStartElement("rect");
                    writer.WriteAttributeString("x", $"{x}");
                    writer.WriteAttributeString("y", $"{y}");
                    writer.WriteAttributeString("width", $"{width}");
                    writer.WriteAttributeString("height", $"{height}");
                    writer.WriteAttributeString("fill", $"{fillColor}");
                    writer.WriteAttributeString("stroke-width", $"{strokeThickness}");
                    writer.WriteAttributeString("stroke", $"{strokeColor}");
                    writer.WriteEndElement();
                }
                else if (type == ShapeType.Line)
                {
                    writer.WriteStartElement("line");
                    writer.WriteAttributeString("x1", $"{x}");
                    writer.WriteAttributeString("y1", $"{y}");
                    writer.WriteAttributeString("x2", $"{width}");
                    writer.WriteAttributeString("y2", $"{height}");
                    writer.WriteAttributeString("stroke-width", $"{strokeThickness}");
                    writer.WriteAttributeString("stroke", $"{strokeColor}");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
            watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
            watcher.Changed += (sender, e) =>
            {
            };
            watcher.EnableRaisingEvents = true;
            using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
            {
                string text = sr.ReadToEnd();
                svgCodeViewForm.richTextBox1.Text = text;
            }
        }

        private void buttonPenStyle_Click(object sender, EventArgs e)
        {
            var penStyleVisible = groupBoxPenstyle.Visible;
            if (!penStyleVisible)
            {
                groupBoxPenstyle.Visible = true;
            }
            else
            {
                groupBoxPenstyle.Visible = false;
            }
        }

        private void logrichTextBox_Click(object sender, EventArgs e)
        {
            groupBoxPenstyle.Visible = false;
        }

        private void logrichTextBox_TextChanged(object sender, EventArgs e)
        {
            logrichTextBox.SelectionStart = logrichTextBox.Text.Length;
            logrichTextBox.ScrollToCaret();
        }

        private async void logClearbutton_Click(object sender, EventArgs e)
        {
            for (var i = logrichTextBox.Lines.Length - 1; i >= 0; i--)
            {
                logrichTextBox.Lines = logrichTextBox.Lines.Take(i).ToArray();
                await Task.Delay(30);
            }
            log = $"[{DateTime.Now.ToString("HH:mm:ss")}] InitializeComponent Success! ";
            logrichTextBox.AppendText(log + "\n");
        }

        private void sVGCodeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sVGCodeViewToolStripMenuItem.Checked)
            {
                svgCodeViewForm.Visible = true;
                if (leftToolStripMenuItem.Checked)
                {
                    Point svgCodeViewFormLocation = new Point(this.Location.X - svgCodeViewForm.Width + 16, this.Location.Y);
                    svgCodeViewForm.Location = svgCodeViewFormLocation;
                    svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
                }
                else if (rightToolStripMenuItem.Checked)
                {
                    Point svgCodeViewFormLocation = new Point(this.Location.X + this.Width - 16, this.Location.Y);
                    svgCodeViewForm.Location = svgCodeViewFormLocation;
                    svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
            else
            {
                svgCodeViewForm.Visible = false;
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!rightToolStripMenuItem.Checked)
            {
                leftToolStripMenuItem.Checked = false;
                flowToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = true;
                Point svgCodeViewFormLocation = new Point(this.Location.X + this.Width - 16, this.Location.Y);
                svgCodeViewForm.Location = svgCodeViewFormLocation;
                svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!leftToolStripMenuItem.Checked)
            {
                rightToolStripMenuItem.Checked = false;
                flowToolStripMenuItem.Checked = false;
                leftToolStripMenuItem.Checked = true;
                Point svgCodeViewFormLocation = new Point(this.Location.X - svgCodeViewForm.Width + 16, this.Location.Y);
                svgCodeViewForm.Location = svgCodeViewFormLocation;
                svgCodeViewForm.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void flowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flowToolStripMenuItem.Checked)
            {
                rightToolStripMenuItem.Checked = false;
                leftToolStripMenuItem.Checked = false;
                flowToolStripMenuItem.Checked = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saved = checkSavedOrNot();
            if (saved)
            {
                Application.Exit();
            }
            else
            {
                if (MessageBox.Show("You do not save your work!\nDo you want to exit£¿", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveWork();
            }
            catch (Exception ex)
            {
                log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Failed to save! " + ex.Message;
                logrichTextBox.AppendText(log + "\n");
            }
        }

        private void loadWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadWorkByUser();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Undo.Count > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                undoShape();
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
            }
        }

        //Users can open a exist SVG file to continue work
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "SVG File|*.svg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Shapes.Clear();
                Undo.Clear();
                var openSvgFilePath = openFileDialog.FileName;
                log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Opened SVG file: {Path.GetFileName(openSvgFilePath)}";
                logrichTextBox.AppendText(log + "\n");
                labelWorkingOn.Text = $"Working On: {Path.GetFileName(openSvgFilePath)}";
                string svgContent = File.ReadAllText(openSvgFilePath);
                string newFilePath = "./SVGTempOutput.svg";
                File.WriteAllText(newFilePath, svgContent);
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
                watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
                watcher.Changed += (sender, e) =>
                {
                };
                watcher.EnableRaisingEvents = true;
                using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
                {
                    string text = sr.ReadToEnd();
                    svgCodeViewForm.richTextBox1.Text = text;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load("./SVGTempOutput.svg");
                XmlElement root = doc.DocumentElement;
                XmlNodeList ellipseElements = root.GetElementsByTagName("ellipse");
                XmlNodeList rectElements = root.GetElementsByTagName("rect");
                XmlNodeList lineElements = root.GetElementsByTagName("line");
                foreach (XmlNode ellipseElement in ellipseElements)
                {
                    var filled = false;
                    Color filledValue = Color.Red;
                    XmlElement ellipse = (XmlElement)ellipseElement;
                    var cxValue = float.Parse(ellipse.GetAttribute("cx"));
                    logrichTextBox.AppendText(cxValue + " ");
                    var cyValue = float.Parse(ellipse.GetAttribute("cy"));
                    logrichTextBox.AppendText(cyValue + " ");
                    var rxValue = float.Parse(ellipse.GetAttribute("rx"));
                    logrichTextBox.AppendText(rxValue + " ");
                    var ryValue = float.Parse(ellipse.GetAttribute("ry"));
                    logrichTextBox.AppendText(ryValue + " ");
                    var fillValue = ellipse.GetAttribute("fill");
                    if (fillValue != "none")
                    {
                        filled = true;
                        filledValue = ColorTranslator.FromHtml(ellipse.GetAttribute("fill"));
                    }
                    else
                    {
                        filled = false;
                        filledValue = Color.Red;
                    }
                    logrichTextBox.AppendText(filledValue + " ");
                    var strokeWidthValue = float.Parse(ellipse.GetAttribute("stroke-width"));
                    logrichTextBox.AppendText(strokeWidthValue + " ");
                    var strokeValue = ColorTranslator.FromHtml(ellipse.GetAttribute("stroke"));
                    logrichTextBox.AppendText(strokeWidthValue + "\n");
                    Shapes.Add(new Shape()
                    {
                        X = cxValue - ((rxValue * 2) / 2),
                        Y = cyValue - ((ryValue * 2) / 2),
                        Width = rxValue * 2,
                        Height = ryValue * 2,
                        StrokeColor = strokeValue,
                        FillColor = filledValue,
                        Filled = filled,
                        StrokeThickness = strokeWidthValue,
                        Type = ShapeType.Ellipse
                    });
                    pictureBoxDrawingArea.Invalidate();
                }
                foreach (XmlNode rectElement in rectElements)
                {
                    var filled = false;
                    Color filledValue = Color.Red;
                    XmlElement rect = (XmlElement)rectElement;
                    var xValue = float.Parse(rect.GetAttribute("x"));
                    logrichTextBox.AppendText(xValue + " ");
                    var yValue = float.Parse(rect.GetAttribute("y"));
                    logrichTextBox.AppendText(yValue + " ");
                    var widthValue = float.Parse(rect.GetAttribute("width"));
                    logrichTextBox.AppendText(widthValue + " ");
                    var heightValue = float.Parse(rect.GetAttribute("height"));
                    logrichTextBox.AppendText(heightValue + " ");
                    var fillValue = rect.GetAttribute("fill");
                    if (fillValue != "none")
                    {
                        filled = true;
                        filledValue = ColorTranslator.FromHtml(rect.GetAttribute("fill"));
                    }
                    else
                    {
                        filled = false;
                        filledValue = Color.Red;
                    }
                    logrichTextBox.AppendText(filledValue + " ");
                    var strokeWidthValue = float.Parse(rect.GetAttribute("stroke-width"));
                    logrichTextBox.AppendText(strokeWidthValue + " ");
                    var strokeValue = ColorTranslator.FromHtml(rect.GetAttribute("stroke"));
                    logrichTextBox.AppendText(strokeWidthValue + "\n");
                    Shapes.Add(new Shape()
                    {
                        X = xValue,
                        Y = yValue,
                        Width = widthValue,
                        Height = heightValue,
                        StrokeColor = strokeValue,
                        FillColor = filledValue,
                        Filled = filled,
                        StrokeThickness = strokeWidthValue,
                        Type = ShapeType.Rect
                    });
                    pictureBoxDrawingArea.Invalidate();
                }
                foreach (XmlNode lineElement in lineElements)
                {
                    var filled = false;
                    Color filledValue = Color.Red;
                    XmlElement rect = (XmlElement)lineElement;
                    var x1Value = float.Parse(rect.GetAttribute("x1"));
                    logrichTextBox.AppendText(x1Value + " ");
                    var y1Value = float.Parse(rect.GetAttribute("y1"));
                    logrichTextBox.AppendText(y1Value + " ");
                    var x2Value = float.Parse(rect.GetAttribute("x2"));
                    logrichTextBox.AppendText(x2Value + " ");
                    var y2Value = float.Parse(rect.GetAttribute("y2"));
                    logrichTextBox.AppendText(y2Value + " ");
                    var fillValue = rect.GetAttribute("fill");
                    if (fillValue != "none")
                    {
                        filled = true;
                        filledValue = ColorTranslator.FromHtml(rect.GetAttribute("fill"));
                    }
                    else
                    {
                        filled = false;
                        filledValue = Color.Red;
                    }
                    logrichTextBox.AppendText(filledValue + " ");
                    var strokeWidthValue = float.Parse(rect.GetAttribute("stroke-width"));
                    logrichTextBox.AppendText(strokeWidthValue + " ");
                    var strokeValue = ColorTranslator.FromHtml(rect.GetAttribute("stroke"));
                    logrichTextBox.AppendText(strokeWidthValue + "\n");
                    Shapes.Add(new Shape()
                    {
                        X = x1Value,
                        Y = y1Value,
                        Width = x2Value,
                        Height = y2Value,
                        StrokeColor = strokeValue,
                        FillColor = filledValue,
                        Filled = filled,
                        StrokeThickness = strokeWidthValue,
                        Type = ShapeType.Line
                    });
                    pictureBoxDrawingArea.Invalidate();
                }
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            pictureBoxDrawingArea.Invalidate();
            File.WriteAllText("./SVGTempOutput.svg", string.Empty);
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
            watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
            watcher.Changed += (sender, e) =>
            {
            };
            watcher.EnableRaisingEvents = true;
            using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
            {
                string text = sr.ReadToEnd();
                svgCodeViewForm.richTextBox1.Text = text;
            }
        }

        private void deleteLastShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Shapes.Count > 1)
            {
                Undo.Add(Shapes[Shapes.Count - 1]);
                Shapes.RemoveAt(Shapes.Count - 1);
                pictureBoxDrawingArea.Invalidate();
                deleteShapeIntoSvgFile();
                undoToolStripMenuItem.Enabled = true;
            }
            else if (Shapes.Count == 1)
            {
                File.WriteAllText("./SVGTempOutput.svg", string.Empty);
                Undo.Add(Shapes[Shapes.Count - 1]);
                Shapes.RemoveAt(Shapes.Count - 1);
                pictureBoxDrawingArea.Invalidate();
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
                watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
                watcher.Changed += (sender, e) =>
                {
                };
                watcher.EnableRaisingEvents = true;
                using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
                {
                    string text = sr.ReadToEnd();
                    svgCodeViewForm.richTextBox1.Text = text;
                }
            }
        }

        private void svgFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export To SVG File";
            saveFileDialog.Filter = "SVG File|*.svg";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var savedFileName = saveFileDialog.FileName;
                File.Copy("./SVGTempOutput.svg", savedFileName);
                log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Exported {Path.GetFileName(savedFileName)} As SVG File Successfully! ";
                logrichTextBox.AppendText(log + "\n");
            }
        }

        private void pngFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Export PNG Image|*.png";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var svgDocument = SvgDocument.Open("./SVGTempOutput.svg");
                var width = (int)svgDocument.Width.Value;
                var height = (int)svgDocument.Height.Value;
                var bitmap = svgDocument.Draw(width, height);
                bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void pdfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export To PDF File";
            saveFileDialog.Filter = "PDF File|*.pdf";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PdfDocument doc = new PdfDocument();
                doc.LoadFromSvg("./SVGTempOutput.svg");
                doc.SaveToFile(saveFileDialog.FileName);
            }
        }

        private void jpegFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export To JPEG File";
            saveFileDialog.Filter = "JPEG File|*.jpg";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var svgData = File.ReadAllBytes("./SVGTempOutput.svg");
                var svgImage = new MagickImage(svgData);
                var jpegFormat = MagickFormat.Jpeg;
                var jpegQuality = 100;
                svgImage.Format = jpegFormat;
                svgImage.Quality = jpegQuality;
                svgImage.Write(saveFileDialog.FileName);
            }
        }

        private void viewInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewInBrowserToolStripMenuItem.Checked)
            {
                webForm.Visible = true;
            }
            else
            {
                webForm.Visible = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saved = checkSavedOrNot();
            if (saved)
            {
                Shapes.Clear();
                pictureBoxDrawingArea.Invalidate();
                File.WriteAllText("./SVGTempOutput.svg", string.Empty);
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
                watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
                watcher.Changed += (sender, e) =>
                {

                };
                watcher.EnableRaisingEvents = true;
                using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
                {
                    string text = sr.ReadToEnd();
                    svgCodeViewForm.richTextBox1.Text = text;
                }
                labelWorkingOn.Text = "Working On: UnSaved File";
            }
            else
            {
                if (MessageBox.Show("You do not save your work!\nDo you want to create a new work£¿", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Shapes.Clear();
                    pictureBoxDrawingArea.Invalidate();
                    File.WriteAllText("./SVGTempOutput.svg", string.Empty);
                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = Path.GetDirectoryName("./SVGTempOutput.svg");
                    watcher.Filter = Path.GetFileName("./SVGTempOutput.svg");
                    watcher.Changed += (sender, e) =>
                    {
                    };
                    watcher.EnableRaisingEvents = true;
                    using (StreamReader sr = new StreamReader("./SVGTempOutput.svg"))
                    {
                        string text = sr.ReadToEnd();
                        svgCodeViewForm.richTextBox1.Text = text;
                    }
                    labelWorkingOn.Text = "Working On: UnSaved File";
                }
            }
            Undo.Clear();
        }

        private void saveWork()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Work SaveFile";
            saveFileDialog.Filter = "WorkSaveFile|*.dat";
            saveFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "SAVEDATA");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var savedFileName = saveFileDialog.FileName;
                using (FileStream stream = new FileStream(savedFileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, Shapes);
                }
                log = $"[{DateTime.Now.ToString("HH:mm:ss")}] Saved {Path.GetFileName(savedFileName)} Successfully! ";
                logrichTextBox.AppendText(log + "\n");
                labelWorkingOn.Text = $"Working On: {Path.GetFileName(savedFileName)}";
            }
        }

        private void loadWorkByUser()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "SAVEDATA");
            openFileDialog.Filter = "WorkSaveFile|*.dat";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxDrawingArea.Image = null;
                Undo.Clear();
                Shapes.Clear();
                svgCodeViewForm.richTextBox1.Clear();
                loadWorkByUserPath = openFileDialog.FileName;
                log = $"[{DateTime.Now.ToString("HH:mm:ss")}] You have loaded work savefile: {Path.GetFileName(loadWorkByUserPath)}";
                logrichTextBox.AppendText(log + "\n");
                labelWorkingOn.Text = $"Working On: {Path.GetFileName(loadWorkByUserPath)}";
                using (FileStream stream = new FileStream(loadWorkByUserPath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Shapes = (List<Shape>)formatter.Deserialize(stream);
                }
                pictureBoxDrawingArea.Invalidate();
                foreach (var data in Shapes)
                {
                    var fillColorHex = "";
                    var strokeColorHex = $"#{data.StrokeColor.R:X2}{data.StrokeColor.G:X2}{data.StrokeColor.B:X2}";
                    if (!data.Filled)
                    {
                        fillColorHex = "none";
                    }
                    else
                    {
                        fillColorHex = $"#{data.FillColor.R:X2}{data.FillColor.G:X2}{data.FillColor.B:X2}";
                    }
                    outputSVGFile(data.X, data.Y, data.Width, data.Height, strokeColorHex, fillColorHex, data.Filled, data.StrokeThickness, data.Type);
                }
            }
        }

        private bool checkSavedOrNot()
        {
            List<Shape> savedShapes = null;
            var folderPath = "./SAVEDATA";
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            FileInfo[] files = directory.GetFiles();
            FileInfo newestFile = null;
            DateTime newestDate = DateTime.MinValue;
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > newestDate)
                {
                    newestFile = file;
                    newestDate = file.LastWriteTime;
                }
            }
            if (newestFile != null)
            {
                using (FileStream stream = new FileStream($"./SAVEDATA/{newestFile.Name}", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    savedShapes = (List<Shape>)formatter.Deserialize(stream);
                }
                bool equaled = savedShapes.SequenceEqual(Shapes);
                return equaled;
            }
            else
            {
                return false;
            }
        }

        private void zoomIn()
        {
            scaleFactor += 0.1f;
            pictureBoxDrawingArea.Invalidate();
        }

        private void zoomOut()
        {
            if (scaleFactor > 0.1f)
            {
                scaleFactor -= 0.1f;
                pictureBoxDrawingArea.Invalidate();
            }
        }
    }
}