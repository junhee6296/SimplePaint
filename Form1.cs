using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        enum ToolType { Line, Rectangle, Circle } //도형타입

        private Bitmap canvasBitmap; //실제 그림 저장 비트맵
        private Graphics canvasGraphics; // 그리기 객체

        private bool isDrawing = false; //드래그 중 여부
        private Point startPoint; // 드래그 시작점
        private Point endPoint; // 드래그 끝점

        private ToolType currentTool = ToolType.Line; //현재 선택도형
        private Color currentColor = Color.Black; // 현재 색상
        private int currentLineWidth = 2; // 현재 선 두께

        public Form1()
        {
            InitializeComponent();

            // 1. 비트맵 초기화 (PictureBox 크기에 맞춰 생성)
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias; // 부드러운 선 표현
            canvasGraphics.Clear(Color.White);

            picCanvas.Image = canvasBitmap;

            // 2. 이벤트 연결
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;
            picCanvas.Paint += PicCanvas_Paint;

            btnLine.Click += btnLine_Click; 
            btnRectangle.Click += btnRectangle_Click; 
            btnCircle.Click += btnCircle_Click;

            // --- 색상 콤보박스 설정 및 이벤트 연결 ---
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;

            cmbColor.Items.Add("Black 검정"); 
            cmbColor.Items.Add("Red 빨강"); 
            cmbColor.Items.Add("Blue 파랑"); 
            cmbColor.Items.Add("Green 녹색");

            cmbColor.SelectedIndex = 0; // 기본값: Black

            // --- 선 두께 트랙바 설정 및 이벤트 연결 ---
            trbLineWidth.Minimum = 1; // 최소값
            trbLineWidth.Maximum = 10; // 최대값
            trbLineWidth.Value = 2; // 기본 두께
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged; 
        }

        // --- 마우스 이벤트 핸들러 ---

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            endPoint = e.Location;
            picCanvas.Invalidate(); // Paint 이벤트를 발생시켜 점선 미리보기를 그림
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            isDrawing = false;
            endPoint = e.Location;

            // 최종적으로 비트맵(실제 그림)에 그리기
            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate();
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            // 마우스를 드래그하는 동안 화면에만 보여줄 점선 미리보기
            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        // --- 공통 그리기 로직 ---

        private void DrawShape(Graphics g, Pen pen, Point start, Point end)
        {
            // 사각형이나 원의 경우 시작점과 끝점의 위치에 상관없이 정상적으로 그려지도록 계산
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);

            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, start, end);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, x, y, width, height);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, x, y, width, height);
                    break;
            }
        }

        // --- 도형 선택 버튼 이벤트 ---
        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line; 
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle; 
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle; 
        }

        // --- 색상 선택 이벤트 핸들러 ---
        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택된 인덱스에 따라 색상 변경
            switch (cmbColor.SelectedIndex)
            {
                case 0: // Black 검정
                    currentColor = Color.Black; 
            break; 
        case 1: // Red 빨강
                    currentColor = Color.Red; 
            break; 
        case 2: // Blue 파랑
                    currentColor = Color.Blue; 
            break; 
        case 3: // Green 녹색
                    currentColor = Color.Green; 
            break; 
        default:
                    currentColor = Color.Black; 
            break; 
    }
        }

        // --- 선 두께 조절 이벤트 핸들러 ---
        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            // 트랙바의 현재 값으로 선 두께 갱신
            currentLineWidth = trbLineWidth.Value; 
        }
    }
}