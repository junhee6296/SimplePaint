namespace SimplePaint
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picCanvas = new PictureBox();
            lblAppName = new Label();
            DiaGroupBox = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            ColorGroupBox = new GroupBox();
            cmbColor = new ComboBox();
            LineGroupBox = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            DiaGroupBox.SuspendLayout();
            ColorGroupBox.SuspendLayout();
            LineGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            SuspendLayout();
            // 
            // picCanvas
            // 
            picCanvas.Location = new Point(12, 184);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(952, 397);
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("서울남산체 M", 48F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.FromArgb(128, 128, 255);
            lblAppName.Location = new Point(12, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(397, 76);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "Simple Paint";
            // 
            // DiaGroupBox
            // 
            DiaGroupBox.Controls.Add(btnCircle);
            DiaGroupBox.Controls.Add(btnRectangle);
            DiaGroupBox.Controls.Add(btnLine);
            DiaGroupBox.Font = new Font("서울남산체 M", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            DiaGroupBox.Location = new Point(12, 78);
            DiaGroupBox.Name = "DiaGroupBox";
            DiaGroupBox.Size = new Size(295, 100);
            DiaGroupBox.TabIndex = 2;
            DiaGroupBox.TabStop = false;
            DiaGroupBox.Text = "도형 선택";
            // 
            // btnCircle
            // 
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(199, 22);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(92, 64);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = (Image)resources.GetObject("btnRectangle.Image");
            btnRectangle.ImageAlign = ContentAlignment.TopCenter;
            btnRectangle.Location = new Point(102, 22);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(92, 64);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnLine
            // 
            btnLine.Image = (Image)resources.GetObject("btnLine.Image");
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(5, 22);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(92, 64);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // ColorGroupBox
            // 
            ColorGroupBox.Controls.Add(cmbColor);
            ColorGroupBox.Font = new Font("서울남산체 M", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            ColorGroupBox.Location = new Point(313, 78);
            ColorGroupBox.Name = "ColorGroupBox";
            ColorGroupBox.Size = new Size(177, 100);
            ColorGroupBox.TabIndex = 3;
            ColorGroupBox.TabStop = false;
            ColorGroupBox.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Location = new Point(6, 45);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(165, 27);
            cmbColor.TabIndex = 0;
            // 
            // LineGroupBox
            // 
            LineGroupBox.Controls.Add(trbLineWidth);
            LineGroupBox.Font = new Font("서울남산체 M", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            LineGroupBox.Location = new Point(496, 78);
            LineGroupBox.Name = "LineGroupBox";
            LineGroupBox.Size = new Size(223, 100);
            LineGroupBox.TabIndex = 4;
            LineGroupBox.TabStop = false;
            LineGroupBox.Text = "선 두께";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 34);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(211, 45);
            trbLineWidth.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = SystemColors.Info;
            btnOpenFile.Font = new Font("서울알림체 TTF Bold", 15.75F, FontStyle.Bold);
            btnOpenFile.Location = new Point(725, 99);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(114, 68);
            btnOpenFile.TabIndex = 5;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = SystemColors.ActiveCaption;
            btnSaveFile.Font = new Font("서울알림체 TTF Bold", 15.75F, FontStyle.Bold);
            btnSaveFile.Location = new Point(845, 99);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(114, 68);
            btnSaveFile.TabIndex = 6;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 593);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(LineGroupBox);
            Controls.Add(ColorGroupBox);
            Controls.Add(DiaGroupBox);
            Controls.Add(lblAppName);
            Controls.Add(picCanvas);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            DiaGroupBox.ResumeLayout(false);
            ColorGroupBox.ResumeLayout(false);
            LineGroupBox.ResumeLayout(false);
            LineGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCanvas;
        private Label lblAppName;
        private GroupBox DiaGroupBox;
        private GroupBox ColorGroupBox;
        private ComboBox cmbColor;
        private GroupBox LineGroupBox;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
    }
}
