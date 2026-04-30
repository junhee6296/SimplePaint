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

            // 확대/축소
            trbZoom.ValueChanged += trbZoom_ValueChanged;
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

        // --- 이미지 저장 핸들러 ---
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // 1. 파일 저장을 위한 대화상자 생성
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "그림 저장하기";

                // 2. 저장할 파일 포맷 3가지 설정 (.png, .jpg, .bmp)
                saveFileDialog.Filter = "PNG 이미지 (*.png)|*.png|JPEG 이미지 (*.jpg)|*.jpg|비트맵 이미지 (*.bmp)|*.bmp";
                saveFileDialog.DefaultExt = "png"; // 기본 확장자 지정
                saveFileDialog.AddExtension = true;

                // 3. 대화상자를 띄우고 사용자가 '저장'을 눌렀는지 확인
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 사용자가 선택한 확장자 확인
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                    ImageFormat format = ImageFormat.Png; // 기본 포맷 (무손실 압축)

                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ImageFormat.Jpeg; // (손실 압축)
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp; // (압축 없음)
                            break;
                    }

                    // 4. 캔버스의 이미지를 선택한 포맷으로 지정된 경로에 저장
                    if (canvasBitmap != null)
                    {
                        canvasBitmap.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("그림이 성공적으로 저장되었습니다!", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // 1. 파일 읽기를 위한 대화상자 생성
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "이미지 불러오기";
                openFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|모든 파일 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 2. 외부 이미지 파일 읽기
                    Image loadedImage = Image.FromFile(openFileDialog.FileName);

                    // 3. 읽어 들인 이미지를 바탕으로 새로운 캔버스(비트맵) 생성
                    canvasBitmap = new Bitmap(loadedImage);

                    // 4. 새 캔버스에 그리기 도구(Graphics) 다시 연결
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    // 5. 픽쳐박스에 이미지 반영 및 크기 동기화
                    picCanvas.Image = canvasBitmap;
                    picCanvas.Width = canvasBitmap.Width;
                    picCanvas.Height = canvasBitmap.Height;

                    // 줌 배율 초기화
                    trbZoom.Value = 100;
                }
            }
        }

        private void trbZoom_ValueChanged(object sender, EventArgs e)
        {
            if (canvasBitmap != null)
            {
                // 트랙바 값(1~500)을 백분율(0.01~5.0)로 변환
                float scaleFactor = trbZoom.Value / 100f;

                // 확대/축소 비율에 맞춰 PictureBox 크기 조정
                picCanvas.Width = (int)(canvasBitmap.Width * scaleFactor);
                picCanvas.Height = (int)(canvasBitmap.Height * scaleFactor);
            }
        }
    }
}