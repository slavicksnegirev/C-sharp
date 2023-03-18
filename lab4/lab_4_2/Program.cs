using Gtk;
using System;
using System.IO;

namespace lab_4_2
{
    class MainClass : Window
    {
        
        const int WIDTH = 250;
        const int HEIGHT = 250;
        const int SQUARE_SIDE = 10;

        int[,] matrixCat = new int[WIDTH/SQUARE_SIDE, HEIGHT/SQUARE_SIDE] {

            // 0 - фиолетовый
            // 1 - черный
            // 2 - белый
            // 3 - желтый

            { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },
            { 0,0,0,0,1, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 1,0,0,0,0, 0,0,0,0,0, 0,0,0,1,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 1,1,0,0,0, 0,0,0,0,0, 0,0,1,1,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 2,1,1,0,0, 0,0,0,0,0, 0,1,1,2,1, 0,0,0,0,0 },

            { 0,0,0,0,1, 2,2,1,1,1, 1,1,1,1,1, 1,1,2,2,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 2,2,1,1,1, 1,1,1,1,1, 1,1,2,2,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 1,1,1,1,1, 1,1,1,1,1, 1,1,1,1,1, 0,0,0,0,0 },
            { 0,0,0,0,0, 1,1,1,1,1, 1,1,1,1,1, 1,1,1,1,0, 0,0,0,0,0 },
            { 0,0,0,0,1, 1,3,3,3,1, 1,1,1,1,1, 3,3,3,1,1, 0,0,0,0,0 },

            { 0,0,0,0,1, 3,3,3,1,3, 1,1,1,1,3, 1,3,3,3,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 3,3,3,1,3, 3,1,1,3,3, 1,3,3,3,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 3,3,3,1,3, 3,1,1,3,3, 1,3,3,3,1, 0,0,0,0,0 },
            { 0,0,0,0,1, 1,1,1,1,1, 1,1,1,1,1, 1,1,1,1,1, 0,0,0,0,0 },
            { 0,0,1,1,1, 1,1,1,1,1, 1,2,2,1,1, 1,1,1,1,1, 1,1,0,0,0 },

            { 0,0,0,0,1, 1,1,1,1,1, 1,1,1,1,1, 1,1,1,1,1, 0,0,0,0,0 },
            { 0,0,0,1,0, 1,1,1,1,1, 1,1,1,1,1, 1,1,1,1,0, 1,0,0,0,0 },
            { 0,0,1,0,0, 0,0,1,1,1, 1,1,1,1,1, 1,1,0,0,0, 0,1,0,0,0 },
            { 0,0,0,0,0, 0,0,0,0,1, 1,1,1,1,1, 1,0,0,0,0, 0,0,0,0,0 },
            { 0,0,0,0,0, 0,0,0,0,1, 1,1,1,1,1, 1,1,0,0,0, 0,0,0,0,0 },

            { 0,0,0,0,0, 0,0,0,1,1, 1,1,1,1,1, 1,1,1,0,0, 0,0,0,0,0 },
            { 0,0,0,0,0, 0,0,0,1,1, 1,1,1,1,1, 1,1,1,1,0, 0,0,0,0,0 },
            { 0,0,0,0,0, 0,0,1,1,1, 1,1,1,1,1, 1,1,1,1,1, 0,0,0,0,0 },
            { 0,0,0,0,0, 0,1,1,1,1, 1,1,1,1,1, 1,1,1,1,1, 1,0,0,0,0 },
            { 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0 },            
        };

        public MainClass() : base("Kitty")
        {
            SetDefaultSize(WIDTH, HEIGHT);
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate { Application.Quit(); };

            Gdk.Color black;
            Gdk.Color violet;
            Gdk.Color white;
            Gdk.Color yellow;

            black = new Gdk.Color(0, 0, 0);
            violet = new Gdk.Color(139, 0, 255);
            white = new Gdk.Color(255, 255, 255);
            yellow = new Gdk.Color(255, 255, 100);


            Fixed fix = new Fixed();

            DrawingArea drawingArea;

            drawingArea = new DrawingArea();
            drawingArea.SetSizeRequest(WIDTH, HEIGHT);
            drawingArea.ModifyBg(StateType.Normal, violet);
            fix.Put(drawingArea, 0, 0);

            for (int i = 0; i < matrixCat.GetLength(0); i++)
            {
                for (int j = 0; j < matrixCat.GetLength(1); j++)
                {
                    if (matrixCat[i, j] == 1)
                    {
                        DrawingArea drawingArea2;

                        drawingArea2 = new DrawingArea();
                        drawingArea2.SetSizeRequest(10, 10);
                        drawingArea2.ModifyBg(StateType.Normal, black);
                        fix.Put(drawingArea2, j * SQUARE_SIDE, i * SQUARE_SIDE);
                    }

                    if (matrixCat[i, j] == 2)
                    {
                        DrawingArea drawingArea2;

                        drawingArea2 = new DrawingArea();
                        drawingArea2.SetSizeRequest(10, 10);
                        drawingArea2.ModifyBg(StateType.Normal, white);
                        fix.Put(drawingArea2, j * SQUARE_SIDE, i * SQUARE_SIDE);

                    }

                    if (matrixCat[i, j] == 3)
                    {
                        DrawingArea drawingArea2;

                        drawingArea2 = new DrawingArea();
                        drawingArea2.SetSizeRequest(10, 10);
                        drawingArea2.ModifyBg(StateType.Normal, yellow);
                        fix.Put(drawingArea2, j * SQUARE_SIDE, i * SQUARE_SIDE);

                    }
                }
            }

            Add(fix);
            ShowAll();
        }

        public static void Main()
        {
            Application.Init();
            new MainClass();
            Application.Run();
        }
    }
}