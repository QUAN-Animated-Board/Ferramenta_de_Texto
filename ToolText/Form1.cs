using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToolText
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //layerContainer1.MasterWindow = this;
            ImageSize = new Size(800, 600);
            //ds = new DrawingSpace(new Size(800, 600));
            pen1.DashCap = DashCap.Round;
            pen1.DashPattern = new float[] { 4f, 2f, 2f, 3f };
            pen1_text.DashCap = DashCap.Round;
            pen1_text.DashPattern = new float[] { 4f, 2f, 3f, 4f };
            textBox1.Parent = this;
            TIB = new TextInputBox(this);

            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pictureBox1.Image = bm;

        }

        //DrawingSpace ds;
        Color _ForeColor, _BackColor;
        Point SLoc = Point.Empty, CPoint = Point.Empty, PCloc = new Point(128, 128), SCloc = new Point(128, 128), rulerLoc, Cpos = new Point(43, 41);
        Size ImageSize, resizedImageSize;
        DrawingSpace.Tool currentTool = DrawingSpace.Tool.Rectangle;
        DrawOperationType drawMode = DrawOperationType.Fill;
        Brush mainBrush = new SolidBrush(Color.Black);
        Rectangle WorkingSpace = Rectangle.Empty, AllocatedTextSpace = Rectangle.Empty, RescaledWorkingSpace = Rectangle.Empty;
        bool DrawOp = false, AllowedColorChange = true, Control = false, ChooseState = false, Shift = false;
        //ColorMode MainDrawMode, PickerMode = ColorMode.ForeColor;
        Pen pen1 = new Pen(Color.Black), pen1_text = new Pen(Color.BlueViolet);
        TextInputBox TIB;
        private Bitmap bmp_image;
        double ScaleFactor = 1;
        //FileDrag fd = new FileDrag();
        BrushType b_mode = BrushType.Circle_smooth;
        Bitmap color_bmp;
        //GradientColorPicker GCP;
        //GradientInformation GI;
        decimal difference = 1;

        Bitmap bm;
        Graphics g;


        public Color foreColor
        {
            get
            {
                return _ForeColor;
            }
            set
            {
                _ForeColor = value;
            }
        }

        public Size SpaceSize
        {
            get
            {
                return ImageSize;
            }
        }

        //public DrawingSpace Space{
            //get
            //{
            //    return ds;
            //}
        //}

        public Color backColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
            }
        }

        

        public enum DrawOperationType
        {
            Draw, Fill
        }

        public enum BrushType
        {
            Rect_smooth, Rect_sharp, Circle_smooth, Circle_sharp
        }

        public delegate void DelegateCaller();

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (AllocatedTextSpace != Rectangle.Empty && AllocatedTextSpace.Width <= 0 || AllocatedTextSpace.Height <= 0)
            {
                //using (Graphics gx = Graphics.FromImage(bmp_image)){
                    System.Diagnostics.Debug.WriteLine("Segunde Clique");
                    g.DrawString(textBox1.Text, TIB.ChoosenFont, mainBrush, SLoc);  
                //}
                textBox1.Text = "";
                TIB.Hide();
                DrawUpdater(true);
                AllocatedTextSpace = Rectangle.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DrawUpdater();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeselectAll();
            //Text_B.Checked = true;
            currentTool = DrawingSpace.Tool.Text;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Middle)
            {
                CPoint = new Point(e.X, e.Y);
                rulerLoc = new Point(e.X + pictureBox1.Left, e.Y + (pictureBox1.Top - 30));
                //pictureBox7.Invalidate(); pictureBox8.Invalidate();
                DrawUpdater();
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                pictureBox1.Left = MousePosition.X - this.PointToScreen(SLoc).X;
                pictureBox1.Top = MousePosition.Y - this.PointToScreen(SLoc).Y - 74;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            DrawOp = false;
            if (e.Button != System.Windows.Forms.MouseButtons.Middle)
            {
                SLoc = new Point(Convert.ToInt32(SLoc.X / ScaleFactor), Convert.ToInt32(SLoc.Y / ScaleFactor));
                Point endP = new Point(Convert.ToInt32(e.X / ScaleFactor), Convert.ToInt32(e.Y / ScaleFactor));
                //using (Graphics g = Graphics.FromImage(bmp_image)){
                    g.InterpolationMode = InterpolationMode.High;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    if (WorkingSpace != Rectangle.Empty)
                        g.SetClip(WorkingSpace);

                    switch (currentTool)
                    {
                        case DrawingSpace.Tool.Text:
                            if (endP.X - SLoc.X <= 3 && endP.Y - SLoc.Y <= 3)
                            {
                                AllocatedTextSpace = Rectangle.Empty;
                                
                                
                                //using (Graphics gx = Graphics.FromImage(bmp_image)){
                                    g.DrawString(textBox1.Text, TIB.ChoosenFont, mainBrush, SLoc);
                                    System.Diagnostics.Debug.WriteLine("Segunde Clique!!");
                                    
                                //}
                                textBox1.Text = "";
                                TIB.Hide();
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("Primeiro Clique");
                                TIB.Location = new Point(this.Location.X + SLoc.X, this.Location.Y + SLoc.Y); 
                                TIB.Show();
                                TIB.TopMost = true;
                                AllocatedTextSpace = new Rectangle(SLoc.X, SLoc.Y, endP.X - SLoc.X, endP.Y - SLoc.Y);
                                textBox1.Focus();
                            }
                            break;
                       
                    }
                    //ds.DrawnData();
                //}
                DrawUpdater();
            }
            else
                Cpos = new Point(pictureBox1.Left, pictureBox1.Top);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Middle)
            {
                
                if (currentTool == DrawingSpace.Tool.RectSelect)
                {
                    WorkingSpace = Rectangle.Empty;
                    using (Graphics g = pictureBox1.CreateGraphics())
                    {
                        g.Clear(pictureBox1.BackColor);
                        //g.DrawImage(ds.Final, new Point(0, 0));
                    }
                }
            }
            
            SLoc = new Point(e.X, e.Y);

            if (e.Button != System.Windows.Forms.MouseButtons.Middle)
                DrawOp = true;

            DrawUpdater();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs ex)
        {
            ex.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            ex.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Graphics g = ex.Graphics;
            //g.DrawImage(ds.Final, 0, 0, resizedImageSize.Width, resizedImageSize.Height);

            if (WorkingSpace != Rectangle.Empty)
            {
                g.DrawRectangle(new Pen(new HatchBrush(HatchStyle.SmallCheckerBoard, Color.Blue, Color.Transparent)), RescaledWorkingSpace);
                if (currentTool != DrawingSpace.Tool.RectSelect)
                    g.SetClip(RescaledWorkingSpace);
            }


            if (!DrawOp)
            {
                if (AllocatedTextSpace != Rectangle.Empty)
                {
                    g.DrawRectangle(pen1_text, AllocatedTextSpace);
                    g.DrawString(textBox1.Text, TIB.ChoosenFont, mainBrush, new PointF(AllocatedTextSpace.X, AllocatedTextSpace.Y));
                }
            }
            else
            {
                DrawUpdater();
                switch (currentTool)
                {
                    case DrawingSpace.Tool.Text:
                        g.DrawRectangle(new Pen(new HatchBrush(HatchStyle.DashedHorizontal, _ForeColor)), new Rectangle(SLoc.X, SLoc.Y, CPoint.X - SLoc.X, CPoint.Y - SLoc.Y));
                        break;
                }
            }
        }


        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //Cursor.Hide();
            if (AllocatedTextSpace != Rectangle.Empty && currentTool == DrawingSpace.Tool.Text)
                textBox1.Focus();
            else
                pictureBox1.Focus();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        public void DrawUpdater()
        {
            pictureBox1.Refresh();
            pictureBox1.Invalidate();
        }

        public void DrawUpdater(bool force_redraw)
        {
            //if (force_redraw) ds.DrawnData();
            pictureBox1.Invalidate();
        }

        public void Rescale(double d)
        {
            if (Control)
            {
                ScaleFactor = (d > 0) ? d : 0.1;

                //toolStripStatusLabel2.Text = "Zoom: " + (d * 100) + "%";

                int newW = (int)(ImageSize.Width * ScaleFactor);
                int newH = (int)(ImageSize.Height * ScaleFactor);

                int originalWidth = ImageSize.Width;
                int originalHeight = ImageSize.Height;
                float percentWidth = (float)newW / (float)originalWidth;
                float percentHeight = (float)newH / (float)originalHeight;
                float percent = (percentHeight < percentWidth) ? percentHeight : percentWidth;

                difference = Convert.ToDecimal(percent);

                newW = (int)(originalWidth * percent);
                newH = (int)(originalHeight * percent);

                if (WorkingSpace != Rectangle.Empty)
                    RescaledWorkingSpace = new Rectangle(Convert.ToInt32(WorkingSpace.X * difference), Convert.ToInt32(WorkingSpace.Y * difference), Convert.ToInt32(WorkingSpace.Width * difference), Convert.ToInt32(WorkingSpace.Height * difference));

                resizedImageSize = new Size(newW, newH);
                pictureBox1.Size = new Size(newW, newH);
                DrawUpdater(true);
            }
        }

        private void DeselectAll()
        {
            System.Diagnostics.Debug.WriteLine("Entrou");
            if (currentTool == DrawingSpace.Tool.Text)
            {
                AllocatedTextSpace = Rectangle.Empty;
                using (Graphics g = pictureBox1.CreateGraphics()){
                    g.DrawString(textBox1.Text, TIB.ChoosenFont, mainBrush, SLoc);
                }
                TIB.Hide();
                textBox1.Text = "";
                DrawUpdater(true);
                
            }
        }

    }
}