namespace FinalProjectSVGEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            strokeColorDialog = new ColorDialog();
            strokeColorButton = new Button();
            filledCheckBox = new CheckBox();
            fillColorButton = new Button();
            label2 = new Label();
            typeOfShapeGroupBox = new GroupBox();
            lineRadioButton = new RadioButton();
            squareRadioButton = new RadioButton();
            circleRadioButton = new RadioButton();
            rectangleRadioButton = new RadioButton();
            ellipseRadioButton = new RadioButton();
            fillColorDialog = new ColorDialog();
            label1 = new Label();
            label3coordinate = new Label();
            strokeWidthTrackBar = new TrackBar();
            groupBoxPenstyle = new GroupBox();
            label3 = new Label();
            buttonPenStyle = new Button();
            pictureBoxDrawingArea = new PictureBox();
            logrichTextBox = new RichTextBox();
            logClearbutton = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem2 = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            sVGFileToolStripMenuItem = new ToolStripMenuItem();
            pNGFileToolStripMenuItem = new ToolStripMenuItem();
            pDFFileToolStripMenuItem = new ToolStripMenuItem();
            jPEGFileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            deleteLastShapeToolStripMenuItem = new ToolStripMenuItem();
            clearAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            sVGCodeViewToolStripMenuItem = new ToolStripMenuItem();
            sVGCodeViewLocationToolStripMenuItem = new ToolStripMenuItem();
            rightToolStripMenuItem = new ToolStripMenuItem();
            leftToolStripMenuItem = new ToolStripMenuItem();
            flowToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            viewInBrowserToolStripMenuItem = new ToolStripMenuItem();
            penStatus = new Label();
            labelWorkingOn = new Label();
            typeOfShapeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)strokeWidthTrackBar).BeginInit();
            groupBoxPenstyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDrawingArea).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // strokeColorButton
            // 
            strokeColorButton.Anchor = AnchorStyles.None;
            strokeColorButton.Location = new Point(118, 19);
            strokeColorButton.Margin = new Padding(3, 2, 3, 2);
            strokeColorButton.Name = "strokeColorButton";
            strokeColorButton.Size = new Size(114, 29);
            strokeColorButton.TabIndex = 2;
            strokeColorButton.Text = "LineColor";
            strokeColorButton.UseVisualStyleBackColor = true;
            strokeColorButton.Click += strokeColorButton_Click;
            // 
            // filledCheckBox
            // 
            filledCheckBox.Anchor = AnchorStyles.None;
            filledCheckBox.Location = new Point(238, 47);
            filledCheckBox.Margin = new Padding(3, 2, 3, 2);
            filledCheckBox.Name = "filledCheckBox";
            filledCheckBox.Size = new Size(57, 21);
            filledCheckBox.TabIndex = 3;
            filledCheckBox.Text = "Filled";
            filledCheckBox.UseVisualStyleBackColor = true;
            // 
            // fillColorButton
            // 
            fillColorButton.Anchor = AnchorStyles.None;
            fillColorButton.Location = new Point(118, 61);
            fillColorButton.Margin = new Padding(3, 2, 3, 2);
            fillColorButton.Name = "fillColorButton";
            fillColorButton.Size = new Size(114, 29);
            fillColorButton.TabIndex = 4;
            fillColorButton.Text = "Fill Color";
            fillColorButton.UseVisualStyleBackColor = true;
            fillColorButton.Click += fillColorButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(808, 26);
            label2.Name = "label2";
            label2.Size = new Size(158, 19);
            label2.TabIndex = 6;
            label2.Text = "Picture Drawing Area\r\n";
            // 
            // typeOfShapeGroupBox
            // 
            typeOfShapeGroupBox.Anchor = AnchorStyles.None;
            typeOfShapeGroupBox.Controls.Add(lineRadioButton);
            typeOfShapeGroupBox.Controls.Add(squareRadioButton);
            typeOfShapeGroupBox.Controls.Add(circleRadioButton);
            typeOfShapeGroupBox.Controls.Add(rectangleRadioButton);
            typeOfShapeGroupBox.Controls.Add(ellipseRadioButton);
            typeOfShapeGroupBox.Location = new Point(301, 11);
            typeOfShapeGroupBox.Margin = new Padding(3, 2, 3, 2);
            typeOfShapeGroupBox.Name = "typeOfShapeGroupBox";
            typeOfShapeGroupBox.Padding = new Padding(3, 2, 3, 2);
            typeOfShapeGroupBox.Size = new Size(291, 89);
            typeOfShapeGroupBox.TabIndex = 7;
            typeOfShapeGroupBox.TabStop = false;
            typeOfShapeGroupBox.Text = "Type Of Shape";
            // 
            // lineRadioButton
            // 
            lineRadioButton.AutoSize = true;
            lineRadioButton.Location = new Point(199, 23);
            lineRadioButton.Margin = new Padding(3, 2, 3, 2);
            lineRadioButton.Name = "lineRadioButton";
            lineRadioButton.Size = new Size(49, 21);
            lineRadioButton.TabIndex = 5;
            lineRadioButton.Text = "Line";
            lineRadioButton.UseVisualStyleBackColor = true;
            lineRadioButton.CheckedChanged += lineRadioButton_CheckedChanged;
            // 
            // squareRadioButton
            // 
            squareRadioButton.AutoSize = true;
            squareRadioButton.Location = new Point(101, 54);
            squareRadioButton.Margin = new Padding(3, 2, 3, 2);
            squareRadioButton.Name = "squareRadioButton";
            squareRadioButton.Size = new Size(67, 21);
            squareRadioButton.TabIndex = 3;
            squareRadioButton.Text = "Square";
            squareRadioButton.UseVisualStyleBackColor = true;
            squareRadioButton.CheckedChanged += squareRadioButton_CheckedChanged;
            // 
            // circleRadioButton
            // 
            circleRadioButton.AutoSize = true;
            circleRadioButton.Location = new Point(22, 54);
            circleRadioButton.Margin = new Padding(3, 2, 3, 2);
            circleRadioButton.Name = "circleRadioButton";
            circleRadioButton.Size = new Size(58, 21);
            circleRadioButton.TabIndex = 2;
            circleRadioButton.Text = "Circle";
            circleRadioButton.UseVisualStyleBackColor = true;
            circleRadioButton.CheckedChanged += circleRadioButton_CheckedChanged;
            // 
            // rectangleRadioButton
            // 
            rectangleRadioButton.AutoSize = true;
            rectangleRadioButton.Location = new Point(101, 23);
            rectangleRadioButton.Margin = new Padding(3, 2, 3, 2);
            rectangleRadioButton.Name = "rectangleRadioButton";
            rectangleRadioButton.Size = new Size(83, 21);
            rectangleRadioButton.TabIndex = 1;
            rectangleRadioButton.Text = "Rectangle";
            rectangleRadioButton.UseVisualStyleBackColor = true;
            rectangleRadioButton.CheckedChanged += rectangleRadioButton_CheckedChanged;
            // 
            // ellipseRadioButton
            // 
            ellipseRadioButton.AutoSize = true;
            ellipseRadioButton.Checked = true;
            ellipseRadioButton.Location = new Point(22, 23);
            ellipseRadioButton.Margin = new Padding(3, 2, 3, 2);
            ellipseRadioButton.Name = "ellipseRadioButton";
            ellipseRadioButton.Size = new Size(63, 21);
            ellipseRadioButton.TabIndex = 0;
            ellipseRadioButton.TabStop = true;
            ellipseRadioButton.Text = "Ellipse";
            ellipseRadioButton.UseVisualStyleBackColor = true;
            ellipseRadioButton.CheckedChanged += ellipseRadioButton_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(291, -6);
            label1.MaximumSize = new Size(600, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 15;
            // 
            // label3coordinate
            // 
            label3coordinate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3coordinate.AutoSize = true;
            label3coordinate.Location = new Point(0, 661);
            label3coordinate.Name = "label3coordinate";
            label3coordinate.Size = new Size(71, 17);
            label3coordinate.TabIndex = 16;
            label3coordinate.Text = "coordinate";
            // 
            // strokeWidthTrackBar
            // 
            strokeWidthTrackBar.Anchor = AnchorStyles.None;
            strokeWidthTrackBar.AutoSize = false;
            strokeWidthTrackBar.Location = new Point(6, 47);
            strokeWidthTrackBar.Minimum = 1;
            strokeWidthTrackBar.Name = "strokeWidthTrackBar";
            strokeWidthTrackBar.Size = new Size(106, 28);
            strokeWidthTrackBar.TabIndex = 17;
            strokeWidthTrackBar.Value = 1;
            // 
            // groupBoxPenstyle
            // 
            groupBoxPenstyle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPenstyle.Controls.Add(label3);
            groupBoxPenstyle.Controls.Add(strokeWidthTrackBar);
            groupBoxPenstyle.Controls.Add(typeOfShapeGroupBox);
            groupBoxPenstyle.Controls.Add(label1);
            groupBoxPenstyle.Controls.Add(strokeColorButton);
            groupBoxPenstyle.Controls.Add(filledCheckBox);
            groupBoxPenstyle.Controls.Add(fillColorButton);
            groupBoxPenstyle.FlatStyle = FlatStyle.System;
            groupBoxPenstyle.Location = new Point(12, 32);
            groupBoxPenstyle.Name = "groupBoxPenstyle";
            groupBoxPenstyle.Size = new Size(960, 105);
            groupBoxPenstyle.TabIndex = 18;
            groupBoxPenstyle.TabStop = false;
            groupBoxPenstyle.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Location = new Point(24, 27);
            label3.Name = "label3";
            label3.Size = new Size(65, 17);
            label3.TabIndex = 18;
            label3.Text = "LineWidth";
            // 
            // buttonPenStyle
            // 
            buttonPenStyle.Location = new Point(12, 6);
            buttonPenStyle.Name = "buttonPenStyle";
            buttonPenStyle.Size = new Size(75, 23);
            buttonPenStyle.TabIndex = 19;
            buttonPenStyle.Text = "PenStyle";
            buttonPenStyle.UseVisualStyleBackColor = true;
            buttonPenStyle.Click += buttonPenStyle_Click;
            // 
            // pictureBoxDrawingArea
            // 
            pictureBoxDrawingArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxDrawingArea.BackColor = SystemColors.ScrollBar;
            pictureBoxDrawingArea.Location = new Point(12, 53);
            pictureBoxDrawingArea.Margin = new Padding(3, 2, 3, 2);
            pictureBoxDrawingArea.Name = "pictureBoxDrawingArea";
            pictureBoxDrawingArea.Size = new Size(960, 440);
            pictureBoxDrawingArea.TabIndex = 0;
            pictureBoxDrawingArea.TabStop = false;
            pictureBoxDrawingArea.Click += pictureBoxDrawingArea_Click;
            pictureBoxDrawingArea.Paint += pictureBoxDrawingArea_Paint;
            pictureBoxDrawingArea.MouseDown += pictureBoxDrawingArea_MouseDown;
            pictureBoxDrawingArea.MouseMove += pictureBoxDrawingArea_MouseMove;
            pictureBoxDrawingArea.MouseUp += pictureBoxDrawingArea_MouseUp;
            // 
            // logrichTextBox
            // 
            logrichTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logrichTextBox.Location = new Point(12, 498);
            logrichTextBox.Name = "logrichTextBox";
            logrichTextBox.Size = new Size(960, 151);
            logrichTextBox.TabIndex = 20;
            logrichTextBox.Text = "";
            logrichTextBox.Click += logrichTextBox_Click;
            logrichTextBox.TextChanged += logrichTextBox_TextChanged;
            // 
            // logClearbutton
            // 
            logClearbutton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logClearbutton.Location = new Point(897, 652);
            logClearbutton.Margin = new Padding(3, 0, 3, 3);
            logClearbutton.Name = "logClearbutton";
            logClearbutton.Size = new Size(75, 26);
            logClearbutton.TabIndex = 21;
            logClearbutton.Text = "ClearLog";
            logClearbutton.UseVisualStyleBackColor = true;
            logClearbutton.Click += logClearbutton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem2, editToolStripMenuItem, toolStripMenuItem1, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(90, 5);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(188, 25);
            menuStrip1.TabIndex = 22;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exportToolStripMenuItem, exitToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(39, 21);
            toolStripMenuItem2.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(206, 22);
            newToolStripMenuItem.Text = "New Work";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(206, 22);
            openToolStripMenuItem.Text = "Open SVG File";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(206, 22);
            saveToolStripMenuItem.Text = "Save Work";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            saveAsToolStripMenuItem.Size = new Size(206, 22);
            saveAsToolStripMenuItem.Text = "Load Work";
            saveAsToolStripMenuItem.Click += loadWorkToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sVGFileToolStripMenuItem, pNGFileToolStripMenuItem, pDFFileToolStripMenuItem, jPEGFileToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(206, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // sVGFileToolStripMenuItem
            // 
            sVGFileToolStripMenuItem.Name = "sVGFileToolStripMenuItem";
            sVGFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D1;
            sVGFileToolStripMenuItem.Size = new Size(171, 22);
            sVGFileToolStripMenuItem.Text = "SVG File";
            sVGFileToolStripMenuItem.Click += svgFileToolStripMenuItem_Click;
            // 
            // pNGFileToolStripMenuItem
            // 
            pNGFileToolStripMenuItem.Name = "pNGFileToolStripMenuItem";
            pNGFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D2;
            pNGFileToolStripMenuItem.Size = new Size(171, 22);
            pNGFileToolStripMenuItem.Text = "PNG File";
            pNGFileToolStripMenuItem.Click += pngFileToolStripMenuItem_Click;
            // 
            // pDFFileToolStripMenuItem
            // 
            pDFFileToolStripMenuItem.Name = "pDFFileToolStripMenuItem";
            pDFFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D3;
            pDFFileToolStripMenuItem.Size = new Size(171, 22);
            pDFFileToolStripMenuItem.Text = "PDF File";
            pDFFileToolStripMenuItem.Click += pdfFileToolStripMenuItem_Click;
            // 
            // jPEGFileToolStripMenuItem
            // 
            jPEGFileToolStripMenuItem.Name = "jPEGFileToolStripMenuItem";
            jPEGFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D4;
            jPEGFileToolStripMenuItem.Size = new Size(171, 22);
            jPEGFileToolStripMenuItem.Text = "JPEG File";
            jPEGFileToolStripMenuItem.Click += jpegFileToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.X;
            exitToolStripMenuItem.Size = new Size(206, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, deleteLastShapeToolStripMenuItem, clearAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(42, 21);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(168, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // deleteLastShapeToolStripMenuItem
            // 
            deleteLastShapeToolStripMenuItem.Name = "deleteLastShapeToolStripMenuItem";
            deleteLastShapeToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteLastShapeToolStripMenuItem.Size = new Size(168, 22);
            deleteLastShapeToolStripMenuItem.Text = "Delete Last";
            deleteLastShapeToolStripMenuItem.Click += deleteLastShapeToolStripMenuItem_Click;
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            clearAllToolStripMenuItem.Size = new Size(168, 22);
            clearAllToolStripMenuItem.Text = "Clear All";
            clearAllToolStripMenuItem.Click += clearAllToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { sVGCodeViewToolStripMenuItem, sVGCodeViewLocationToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(47, 21);
            toolStripMenuItem1.Text = "View";
            // 
            // sVGCodeViewToolStripMenuItem
            // 
            sVGCodeViewToolStripMenuItem.Checked = true;
            sVGCodeViewToolStripMenuItem.CheckOnClick = true;
            sVGCodeViewToolStripMenuItem.CheckState = CheckState.Checked;
            sVGCodeViewToolStripMenuItem.Name = "sVGCodeViewToolStripMenuItem";
            sVGCodeViewToolStripMenuItem.ShortcutKeys = Keys.F1;
            sVGCodeViewToolStripMenuItem.Size = new Size(219, 22);
            sVGCodeViewToolStripMenuItem.Text = "SVG Code View";
            sVGCodeViewToolStripMenuItem.Click += sVGCodeViewToolStripMenuItem_Click;
            // 
            // sVGCodeViewLocationToolStripMenuItem
            // 
            sVGCodeViewLocationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rightToolStripMenuItem, leftToolStripMenuItem, flowToolStripMenuItem });
            sVGCodeViewLocationToolStripMenuItem.Name = "sVGCodeViewLocationToolStripMenuItem";
            sVGCodeViewLocationToolStripMenuItem.Size = new Size(219, 22);
            sVGCodeViewLocationToolStripMenuItem.Text = "SVG Code View Location";
            // 
            // rightToolStripMenuItem
            // 
            rightToolStripMenuItem.Checked = true;
            rightToolStripMenuItem.CheckState = CheckState.Checked;
            rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            rightToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
            rightToolStripMenuItem.Size = new Size(146, 22);
            rightToolStripMenuItem.Text = "Right";
            rightToolStripMenuItem.Click += rightToolStripMenuItem_Click;
            // 
            // leftToolStripMenuItem
            // 
            leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            leftToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.L;
            leftToolStripMenuItem.Size = new Size(146, 22);
            leftToolStripMenuItem.Text = "Left";
            leftToolStripMenuItem.Click += leftToolStripMenuItem_Click;
            // 
            // flowToolStripMenuItem
            // 
            flowToolStripMenuItem.Name = "flowToolStripMenuItem";
            flowToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F;
            flowToolStripMenuItem.Size = new Size(146, 22);
            flowToolStripMenuItem.Text = "Flow";
            flowToolStripMenuItem.Click += flowToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewInBrowserToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(52, 21);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // viewInBrowserToolStripMenuItem
            // 
            viewInBrowserToolStripMenuItem.CheckOnClick = true;
            viewInBrowserToolStripMenuItem.Name = "viewInBrowserToolStripMenuItem";
            viewInBrowserToolStripMenuItem.ShortcutKeys = Keys.F2;
            viewInBrowserToolStripMenuItem.Size = new Size(191, 22);
            viewInBrowserToolStripMenuItem.Text = "View In Browser";
            viewInBrowserToolStripMenuItem.Click += viewInBrowserToolStripMenuItem_Click;
            // 
            // penStatus
            // 
            penStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            penStatus.AutoSize = true;
            penStatus.ForeColor = Color.DarkGreen;
            penStatus.Location = new Point(82, 661);
            penStatus.Margin = new Padding(8, 0, 3, 0);
            penStatus.Name = "penStatus";
            penStatus.Size = new Size(39, 17);
            penStatus.TabIndex = 23;
            penStatus.Text = "Type:";
            // 
            // labelWorkingOn
            // 
            labelWorkingOn.AutoSize = true;
            labelWorkingOn.Location = new Point(433, 12);
            labelWorkingOn.Name = "labelWorkingOn";
            labelWorkingOn.Size = new Size(77, 17);
            labelWorkingOn.TabIndex = 24;
            labelWorkingOn.Text = "Working on";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(984, 681);
            Controls.Add(labelWorkingOn);
            Controls.Add(label2);
            Controls.Add(penStatus);
            Controls.Add(logClearbutton);
            Controls.Add(logrichTextBox);
            Controls.Add(groupBoxPenstyle);
            Controls.Add(buttonPenStyle);
            Controls.Add(label3coordinate);
            Controls.Add(pictureBoxDrawingArea);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "CS321 - FinalProject - SVGEditor - Student: JunwenHu";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            SizeChanged += MainForm_SizeChanged;
            Click += MainForm_Click;
            Move += MainForm_Move;
            typeOfShapeGroupBox.ResumeLayout(false);
            typeOfShapeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)strokeWidthTrackBar).EndInit();
            groupBoxPenstyle.ResumeLayout(false);
            groupBoxPenstyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDrawingArea).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColorDialog strokeColorDialog;
        private Button strokeColorButton;
        private CheckBox filledCheckBox;
        private Button fillColorButton;
        private Label label2;
        private GroupBox typeOfShapeGroupBox;
        private RadioButton rectangleRadioButton;
        private RadioButton ellipseRadioButton;
        private ColorDialog fillColorDialog;
        private Label label1;
        private Label label3coordinate;
        private TrackBar strokeWidthTrackBar;
        private GroupBox groupBoxPenstyle;
        private Label label3;
        private Button buttonPenStyle;
        private PictureBox pictureBoxDrawingArea;
        private RichTextBox logrichTextBox;
        private RadioButton lineRadioButton;
        private RadioButton squareRadioButton;
        private RadioButton circleRadioButton;
        private Button logClearbutton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem sVGCodeViewToolStripMenuItem;
        private ToolStripMenuItem sVGCodeViewLocationToolStripMenuItem;
        private ToolStripMenuItem rightToolStripMenuItem;
        private ToolStripMenuItem leftToolStripMenuItem;
        private ToolStripMenuItem flowToolStripMenuItem;
        private Label penStatus;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem deleteLastShapeToolStripMenuItem;
        private ToolStripMenuItem clearAllToolStripMenuItem;
        private ToolStripMenuItem sVGFileToolStripMenuItem;
        private ToolStripMenuItem pNGFileToolStripMenuItem;
        private ToolStripMenuItem pDFFileToolStripMenuItem;
        private ToolStripMenuItem jPEGFileToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        public ToolStripMenuItem viewInBrowserToolStripMenuItem;
        private Label labelWorkingOn;
    }
}