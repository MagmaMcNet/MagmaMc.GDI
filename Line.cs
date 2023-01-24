﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagmaMc.GDI.Utils;

namespace MagmaMc.GDI
{

    public class Line
    {

        #region Static
        public static IntPtr BaseWindow { get; private set; } = GetDesktopWindow();
        public static IntPtr Window { get; private set; }
        public static Graphics ScreenGraphics { get; private set; }
        private static Pen DrawingPen;

        public static void StartRender()
        {
            Window = GetDC(BaseWindow);
            ScreenGraphics = Graphics.FromHdc(Window);
        }
        public static void EndRender() => ReleaseDC(BaseWindow, Window);
        #endregion



        public Line(Pen Pen)
        {
            DrawingPen = Pen;

        }


        public void Render(Point p1, Point p2)
        {
            StartRender();
            ScreenGraphics.DrawLine(DrawingPen, p1, p2);
            EndRender();
        }

        public void Render(UInt16 x1, UInt16 y1, UInt16 x2, UInt16 y2)
        {
            StartRender();
            ScreenGraphics.DrawLine(DrawingPen, new Point(x1, y1), new Point(x2, y2));
            EndRender();
        }
        public static void Render(Pen Pen, Point p1, Point p2)
        {
            StartRender();
            ScreenGraphics.DrawLine(Pen, p1, p2);
            EndRender();

        }
        public static void Render(Color color, Point p1, Point p2) => Render(new Pen(color, 2), p1, p2);
        public static void Render(Color color, Byte Width, Point p1, Point p2) => Render(new Pen(color, Width), p1, p2);
        public static void Render(Pen Pen, UInt16 X1, UInt16 Y1, UInt16 X2, UInt16 Y2) => Render(Pen, new Point(X1, Y1), new Point(X2, Y2));
        public static void Render(Color color, UInt16 X1, UInt16 Y1, UInt16 X2, UInt16 Y2) => Render(new Pen(color, 2), new Point(X1, Y1), new Point(X2, Y2));
        public static void Render(Color color, Byte Width, UInt16 X1, UInt16 Y1, UInt16 X2, UInt16 Y2) => Render(new Pen(color, Width), new Point(X1, Y1), new Point(X2, Y2));
    }
}
