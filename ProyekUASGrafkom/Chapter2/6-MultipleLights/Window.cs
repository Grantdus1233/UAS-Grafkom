using System;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

//GRANT DUSTIN SURYAWAN - C14200147
namespace LearnOpenTK
{
    public class Window : GameWindow
    {
        private readonly float[] _vertices =
        {
            // Positions          Normals              Texture coords
            -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 1.0f,
            -0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 0.0f,

            -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
            -0.5f,  0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
            -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
            -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,

             0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,

            -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,

            -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f
        };

        private readonly Vector3[] _cubePositions =
        {
            //pagar
            new Vector3(10.0f, 0.0f, 10.0f),
            new Vector3(10.0f, 0.0f, 9.0f),
            new Vector3(10.0f, 0.0f, 8.0f),
            new Vector3(10.0f, 0.0f, 7.0f),
            new Vector3(10.0f, 0.0f, 6.0f),
            new Vector3(10.0f, 0.0f, 5.0f),
            new Vector3(10.0f, 0.0f, 4.0f),
            new Vector3(10.0f, 0.0f, 3.0f),
            new Vector3(10.0f, 0.0f, 2.0f),
            new Vector3(10.0f, 0.0f, 1.0f),
            new Vector3(10.0f, 0.0f, 0.0f),
            new Vector3(10.0f, 0.0f, -1.0f),
            new Vector3(10.0f, 0.0f, -2.0f),
            new Vector3(10.0f, 0.0f, -3.0f),
            new Vector3(10.0f, 0.0f, -4.0f),
            new Vector3(10.0f, 0.0f, -5.0f),
            new Vector3(10.0f, 0.0f, -6.0f),
            new Vector3(10.0f, 0.0f, -7.0f),
            new Vector3(10.0f, 0.0f, -8.0f),
            new Vector3(10.0f, 0.0f, -9.0f),
            new Vector3(10.0f, 0.0f, -10.0f),

            new Vector3(-10.0f, 0.0f, 10.0f),
            new Vector3(-10.0f, 0.0f, 9.0f),
            new Vector3(-10.0f, 0.0f, 8.0f),
            new Vector3(-10.0f, 0.0f, 7.0f),
            new Vector3(-10.0f, 0.0f, 6.0f),
            new Vector3(-10.0f, 0.0f, 5.0f),
            new Vector3(-10.0f, 0.0f, 4.0f),
            new Vector3(-10.0f, 0.0f, 3.0f),
            new Vector3(-10.0f, 0.0f, 2.0f),
            new Vector3(-10.0f, 0.0f, 1.0f),
            new Vector3(-10.0f, 0.0f, 0.0f),
            new Vector3(-10.0f, 0.0f, -1.0f),
            new Vector3(-10.0f, 0.0f, -2.0f),
            new Vector3(-10.0f, 0.0f, -3.0f),
            new Vector3(-10.0f, 0.0f, -4.0f),
            new Vector3(-10.0f, 0.0f, -5.0f),
            new Vector3(-10.0f, 0.0f, -6.0f),
            new Vector3(-10.0f, 0.0f, -7.0f),
            new Vector3(-10.0f, 0.0f, -8.0f),
            new Vector3(-10.0f, 0.0f, -9.0f),
            new Vector3(-10.0f, 0.0f, -10.0f),

            new Vector3(-9.0f, 0.0f, 10.0f),
            new Vector3(-8.0f, 0.0f, 10.0f),
            new Vector3(-7.0f, 0.0f, 10.0f),
            new Vector3(-6.0f, 0.0f, 10.0f),
            new Vector3(-5.0f, 0.0f, 10.0f),
            new Vector3(-4.0f, 0.0f, 10.0f),
            new Vector3(-3.0f, 0.0f, 10.0f),
            new Vector3(-2.0f, 0.0f, 10.0f),
            new Vector3(-1.0f, 0.0f, 10.0f),
            new Vector3(-0.0f, 0.0f, 10.0f),
            new Vector3(1.0f, 0.0f, 10.0f),
            new Vector3(2.0f, 0.0f, 10.0f),
            new Vector3(3.0f, 0.0f, 10.0f),
            new Vector3(4.0f, 0.0f, 10.0f),
            new Vector3(5.0f, 0.0f, 10.0f),
            new Vector3(6.0f, 0.0f, 10.0f),
            new Vector3(7.0f, 0.0f, 10.0f),
            new Vector3(8.0f, 0.0f, 10.0f),
            new Vector3(9.0f, 0.0f, 10.0f),

            new Vector3(-9.0f, 0.0f, -10.0f),
            new Vector3(-8.0f, 0.0f, -10.0f),
            new Vector3(-7.0f, 0.0f, -10.0f),
            new Vector3(-6.0f, 0.0f, -10.0f),
            new Vector3(-5.0f, 0.0f, -10.0f),
            new Vector3(-4.0f, 0.0f, -10.0f),
            new Vector3(-3.0f, 0.0f, -10.0f),
            new Vector3(-2.0f, 0.0f, -10.0f),
            new Vector3(-1.0f, 0.0f, -10.0f),
            new Vector3(-0.0f, 0.0f, -10.0f),
            new Vector3(1.0f, 0.0f, -10.0f),
            new Vector3(2.0f, 0.0f, -10.0f),
            new Vector3(3.0f, 0.0f, -10.0f),
            new Vector3(4.0f, 0.0f, -10.0f),
            new Vector3(5.0f, 0.0f, -10.0f),
            new Vector3(6.0f, 0.0f, -10.0f),
            new Vector3(7.0f, 0.0f, -10.0f),
            new Vector3(8.0f, 0.0f, -10.0f),
            new Vector3(9.0f, 0.0f, -10.0f),


        };

        private readonly Vector3[] _groundPositions =
        {
            new Vector3(10.0f, -1.0f, 10.0f),
            new Vector3(10.0f, -1.0f, 9.0f),
            new Vector3(10.0f, -1.0f, 8.0f),
            new Vector3(10.0f, -1.0f, 7.0f),
            new Vector3(10.0f, -1.0f, 6.0f),
            new Vector3(10.0f, -1.0f, 5.0f),
            new Vector3(10.0f, -1.0f, 4.0f),
            new Vector3(10.0f, -1.0f, 3.0f),
            new Vector3(10.0f, -1.0f, 2.0f),
            new Vector3(10.0f, -1.0f, 1.0f),
            new Vector3(10.0f, -1.0f, 0.0f),
            new Vector3(10.0f, -1.0f, -1.0f),
            new Vector3(10.0f, -1.0f, -2.0f),
            new Vector3(10.0f, -1.0f, -3.0f),
            new Vector3(10.0f, -1.0f, -4.0f),
            new Vector3(10.0f, -1.0f, -5.0f),
            new Vector3(10.0f, -1.0f, -6.0f),
            new Vector3(10.0f, -1.0f, -7.0f),
            new Vector3(10.0f, -1.0f, -8.0f),
            new Vector3(10.0f, -1.0f, -9.0f),
            new Vector3(10.0f, -1.0f, -10.0f),

            new Vector3(9.0f, -1.0f, 10.0f),
            new Vector3(9.0f, -1.0f, 9.0f),
            new Vector3(9.0f, -1.0f, 8.0f),
            new Vector3(9.0f, -1.0f, 7.0f),
            new Vector3(9.0f, -1.0f, 6.0f),
            new Vector3(9.0f, -1.0f, 5.0f),
            new Vector3(9.0f, -1.0f, 4.0f),
            new Vector3(9.0f, -1.0f, 3.0f),
            new Vector3(9.0f, -1.0f, 2.0f),
            new Vector3(9.0f, -1.0f, 1.0f),
            new Vector3(9.0f, -1.0f, 0.0f),
            new Vector3(9.0f, -1.0f, -1.0f),
            new Vector3(9.0f, -1.0f, -2.0f),
            new Vector3(9.0f, -1.0f, -3.0f),
            new Vector3(9.0f, -1.0f, -4.0f),
            new Vector3(9.0f, -1.0f, -5.0f),
            new Vector3(9.0f, -1.0f, -6.0f),
            new Vector3(9.0f, -1.0f, -7.0f),
            new Vector3(9.0f, -1.0f, -8.0f),
            new Vector3(9.0f, -1.0f, -9.0f),
            new Vector3(9.0f, -1.0f, -10.0f),

            new Vector3(8.0f, -1.0f, 10.0f),
            new Vector3(8.0f, -1.0f, 9.0f),
            new Vector3(8.0f, -1.0f, 8.0f),
            new Vector3(8.0f, -1.0f, 7.0f),
            new Vector3(8.0f, -1.0f, 6.0f),
            new Vector3(8.0f, -1.0f, 5.0f),
            new Vector3(8.0f, -1.0f, 4.0f),
            new Vector3(8.0f, -1.0f, 3.0f),
            new Vector3(8.0f, -1.0f, 2.0f),
            new Vector3(8.0f, -1.0f, 1.0f),
            new Vector3(8.0f, -1.0f, 0.0f),
            new Vector3(8.0f, -1.0f, -1.0f),
            new Vector3(8.0f, -1.0f, -2.0f),
            new Vector3(8.0f, -1.0f, -3.0f),
            new Vector3(8.0f, -1.0f, -4.0f),
            new Vector3(8.0f, -1.0f, -5.0f),
            new Vector3(8.0f, -1.0f, -6.0f),
            new Vector3(8.0f, -1.0f, -7.0f),
            new Vector3(8.0f, -1.0f, -8.0f),
            new Vector3(8.0f, -1.0f, -9.0f),
            new Vector3(8.0f, -1.0f, -10.0f),

            new Vector3(7.0f, -1.0f, 10.0f),
            new Vector3(7.0f, -1.0f, 9.0f),
            new Vector3(7.0f, -1.0f, 8.0f),
            new Vector3(7.0f, -1.0f, 7.0f),
            new Vector3(7.0f, -1.0f, 6.0f),
            new Vector3(7.0f, -1.0f, 5.0f),
            new Vector3(7.0f, -1.0f, 4.0f),
            new Vector3(7.0f, -1.0f, 3.0f),
            new Vector3(7.0f, -1.0f, 2.0f),
            new Vector3(7.0f, -1.0f, 1.0f),
            new Vector3(7.0f, -1.0f, 0.0f),
            new Vector3(7.0f, -1.0f, -1.0f),
            new Vector3(7.0f, -1.0f, -2.0f),
            new Vector3(7.0f, -1.0f, -3.0f),
            new Vector3(7.0f, -1.0f, -4.0f),
            new Vector3(7.0f, -1.0f, -5.0f),
            new Vector3(7.0f, -1.0f, -6.0f),
            new Vector3(7.0f, -1.0f, -7.0f),
            new Vector3(7.0f, -1.0f, -8.0f),
            new Vector3(7.0f, -1.0f, -9.0f),
            new Vector3(7.0f, -1.0f, -10.0f),

            new Vector3(6.0f, -1.0f, 10.0f),
            new Vector3(6.0f, -1.0f, 9.0f),
            new Vector3(6.0f, -1.0f, 8.0f),
            new Vector3(6.0f, -1.0f, 7.0f),
            new Vector3(6.0f, -1.0f, 6.0f),
            new Vector3(6.0f, -1.0f, 5.0f),
            new Vector3(6.0f, -1.0f, 4.0f),
            new Vector3(6.0f, -1.0f, 3.0f),
            new Vector3(6.0f, -1.0f, 2.0f),
            new Vector3(6.0f, -1.0f, 1.0f),
            new Vector3(6.0f, -1.0f, 0.0f),
            new Vector3(6.0f, -1.0f, -1.0f),
            new Vector3(6.0f, -1.0f, -2.0f),
            new Vector3(6.0f, -1.0f, -3.0f),
            new Vector3(6.0f, -1.0f, -4.0f),
            new Vector3(6.0f, -1.0f, -5.0f),
            new Vector3(6.0f, -1.0f, -6.0f),
            new Vector3(6.0f, -1.0f, -7.0f),
            new Vector3(6.0f, -1.0f, -8.0f),
            new Vector3(6.0f, -1.0f, -9.0f),
            new Vector3(6.0f, -1.0f, -10.0f),

            new Vector3(5.0f, -1.0f, 10.0f),
            new Vector3(5.0f, -1.0f, 9.0f),
            new Vector3(5.0f, -1.0f, 8.0f),
            new Vector3(5.0f, -1.0f, 7.0f),
            new Vector3(5.0f, -1.0f, 6.0f),
            new Vector3(5.0f, -1.0f, 5.0f),
            new Vector3(5.0f, -1.0f, 4.0f),
            new Vector3(5.0f, -1.0f, 3.0f),
            new Vector3(5.0f, -1.0f, 2.0f),
            new Vector3(5.0f, -1.0f, 1.0f),
            new Vector3(5.0f, -1.0f, 0.0f),
            new Vector3(5.0f, -1.0f, -1.0f),
            new Vector3(5.0f, -1.0f, -2.0f),
            new Vector3(5.0f, -1.0f, -3.0f),
            new Vector3(5.0f, -1.0f, -4.0f),
            new Vector3(5.0f, -1.0f, -5.0f),
            new Vector3(5.0f, -1.0f, -6.0f),
            new Vector3(5.0f, -1.0f, -7.0f),
            new Vector3(5.0f, -1.0f, -8.0f),
            new Vector3(5.0f, -1.0f, -9.0f),
            new Vector3(5.0f, -1.0f, -10.0f),

            new Vector3(4.0f, -1.0f, 10.0f),
            new Vector3(4.0f, -1.0f, 9.0f),
            new Vector3(4.0f, -1.0f, 8.0f),
            new Vector3(4.0f, -1.0f, 7.0f),
            new Vector3(4.0f, -1.0f, 6.0f),
            new Vector3(4.0f, -1.0f, 5.0f),
            new Vector3(4.0f, -1.0f, 4.0f),
            new Vector3(4.0f, -1.0f, 3.0f),
            new Vector3(4.0f, -1.0f, 2.0f),
            new Vector3(4.0f, -1.0f, 1.0f),
            new Vector3(4.0f, -1.0f, 0.0f),
            new Vector3(4.0f, -1.0f, -1.0f),
            new Vector3(4.0f, -1.0f, -2.0f),
            new Vector3(4.0f, -1.0f, -3.0f),
            new Vector3(4.0f, -1.0f, -4.0f),
            new Vector3(4.0f, -1.0f, -5.0f),
            new Vector3(4.0f, -1.0f, -6.0f),
            new Vector3(4.0f, -1.0f, -7.0f),
            new Vector3(4.0f, -1.0f, -8.0f),
            new Vector3(4.0f, -1.0f, -9.0f),
            new Vector3(4.0f, -1.0f, -10.0f),

            new Vector3(3.0f, -1.0f, 10.0f),
            new Vector3(3.0f, -1.0f, 9.0f),
            new Vector3(3.0f, -1.0f, 8.0f),
            new Vector3(3.0f, -1.0f, 7.0f),
            new Vector3(3.0f, -1.0f, 6.0f),
            new Vector3(3.0f, -1.0f, 5.0f),
            new Vector3(3.0f, -1.0f, 4.0f),
            new Vector3(3.0f, -1.0f, 3.0f),
            new Vector3(3.0f, -1.0f, 2.0f),
            new Vector3(3.0f, -1.0f, 1.0f),
            new Vector3(3.0f, -1.0f, 0.0f),
            new Vector3(3.0f, -1.0f, -1.0f),
            new Vector3(3.0f, -1.0f, -2.0f),
            new Vector3(3.0f, -1.0f, -3.0f),
            new Vector3(3.0f, -1.0f, -4.0f),
            new Vector3(3.0f, -1.0f, -5.0f),
            new Vector3(3.0f, -1.0f, -6.0f),
            new Vector3(3.0f, -1.0f, -7.0f),
            new Vector3(3.0f, -1.0f, -8.0f),
            new Vector3(3.0f, -1.0f, -9.0f),
            new Vector3(3.0f, -1.0f, -10.0f),

            new Vector3(2.0f, -1.0f, 10.0f),
            new Vector3(2.0f, -1.0f, 9.0f),
            new Vector3(2.0f, -1.0f, 8.0f),
            new Vector3(2.0f, -1.0f, 7.0f),
            new Vector3(2.0f, -1.0f, 6.0f),
            new Vector3(2.0f, -1.0f, 5.0f),
            new Vector3(2.0f, -1.0f, 4.0f),
            new Vector3(2.0f, -1.0f, 3.0f),
            new Vector3(2.0f, -1.0f, 2.0f),
            new Vector3(2.0f, -1.0f, 1.0f),
            new Vector3(2.0f, -1.0f, 0.0f),
            new Vector3(2.0f, -1.0f, -1.0f),
            new Vector3(2.0f, -1.0f, -2.0f),
            new Vector3(2.0f, -1.0f, -3.0f),
            new Vector3(2.0f, -1.0f, -4.0f),
            new Vector3(2.0f, -1.0f, -5.0f),
            new Vector3(2.0f, -1.0f, -6.0f),
            new Vector3(2.0f, -1.0f, -7.0f),
            new Vector3(2.0f, -1.0f, -8.0f),
            new Vector3(2.0f, -1.0f, -9.0f),
            new Vector3(2.0f, -1.0f, -10.0f),

            new Vector3(1.0f, -1.0f, 10.0f),
            new Vector3(1.0f, -1.0f, 9.0f),
            new Vector3(1.0f, -1.0f, 8.0f),
            new Vector3(1.0f, -1.0f, 7.0f),
            new Vector3(1.0f, -1.0f, 6.0f),
            new Vector3(1.0f, -1.0f, 5.0f),
            new Vector3(1.0f, -1.0f, 4.0f),
            new Vector3(1.0f, -1.0f, 3.0f),
            new Vector3(1.0f, -1.0f, 2.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 0.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -2.0f),
            new Vector3(1.0f, -1.0f, -3.0f),
            new Vector3(1.0f, -1.0f, -4.0f),
            new Vector3(1.0f, -1.0f, -5.0f),
            new Vector3(1.0f, -1.0f, -6.0f),
            new Vector3(1.0f, -1.0f, -7.0f),
            new Vector3(1.0f, -1.0f, -8.0f),
            new Vector3(1.0f, -1.0f, -9.0f),
            new Vector3(1.0f, -1.0f, -10.0f),

            new Vector3(0.0f, -1.0f, 10.0f),
            new Vector3(0.0f, -1.0f, 9.0f),
            new Vector3(0.0f, -1.0f, 8.0f),
            new Vector3(0.0f, -1.0f, 7.0f),
            new Vector3(0.0f, -1.0f, 6.0f),
            new Vector3(0.0f, -1.0f, 5.0f),
            new Vector3(0.0f, -1.0f, 4.0f),
            new Vector3(0.0f, -1.0f, 3.0f),
            new Vector3(0.0f, -1.0f, 2.0f),
            new Vector3(0.0f, -1.0f, 1.0f),
            new Vector3(0.0f, -1.0f, 0.0f),
            new Vector3(0.0f, -1.0f, -1.0f),
            new Vector3(0.0f, -1.0f, -2.0f),
            new Vector3(0.0f, -1.0f, -3.0f),
            new Vector3(0.0f, -1.0f, -4.0f),
            new Vector3(0.0f, -1.0f, -5.0f),
            new Vector3(0.0f, -1.0f, -6.0f),
            new Vector3(0.0f, -1.0f, -7.0f),
            new Vector3(0.0f, -1.0f, -8.0f),
            new Vector3(0.0f, -1.0f, -9.0f),
            new Vector3(0.0f, -1.0f, -10.0f),

            new Vector3(-10.0f, -1.0f, 10.0f),
            new Vector3(-10.0f, -1.0f, 9.0f),
            new Vector3(-10.0f, -1.0f, 8.0f),
            new Vector3(-10.0f, -1.0f, 7.0f),
            new Vector3(-10.0f, -1.0f, 6.0f),
            new Vector3(-10.0f, -1.0f, 5.0f),
            new Vector3(-10.0f, -1.0f, 4.0f),
            new Vector3(-10.0f, -1.0f, 3.0f),
            new Vector3(-10.0f, -1.0f, 2.0f),
            new Vector3(-10.0f, -1.0f, 1.0f),
            new Vector3(-10.0f, -1.0f, 0.0f),
            new Vector3(-10.0f, -1.0f, -1.0f),
            new Vector3(-10.0f, -1.0f, -2.0f),
            new Vector3(-10.0f, -1.0f, -3.0f),
            new Vector3(-10.0f, -1.0f, -4.0f),
            new Vector3(-10.0f, -1.0f, -5.0f),
            new Vector3(-10.0f, -1.0f, -6.0f),
            new Vector3(-10.0f, -1.0f, -7.0f),
            new Vector3(-10.0f, -1.0f, -8.0f),
            new Vector3(-10.0f, -1.0f, -9.0f),
            new Vector3(-10.0f, -1.0f, -10.0f),

            new Vector3(-9.0f, -1.0f, 10.0f),
            new Vector3(-9.0f, -1.0f, 9.0f),
            new Vector3(-9.0f, -1.0f, 8.0f),
            new Vector3(-9.0f, -1.0f, 7.0f),
            new Vector3(-9.0f, -1.0f, 6.0f),
            new Vector3(-9.0f, -1.0f, 5.0f),
            new Vector3(-9.0f, -1.0f, 4.0f),
            new Vector3(-9.0f, -1.0f, 3.0f),
            new Vector3(-9.0f, -1.0f, 2.0f),
            new Vector3(-9.0f, -1.0f, 1.0f),
            new Vector3(-9.0f, -1.0f, 0.0f),
            new Vector3(-9.0f, -1.0f, -1.0f),
            new Vector3(-9.0f, -1.0f, -2.0f),
            new Vector3(-9.0f, -1.0f, -3.0f),
            new Vector3(-9.0f, -1.0f, -4.0f),
            new Vector3(-9.0f, -1.0f, -5.0f),
            new Vector3(-9.0f, -1.0f, -6.0f),
            new Vector3(-9.0f, -1.0f, -7.0f),
            new Vector3(-9.0f, -1.0f, -8.0f),
            new Vector3(-9.0f, -1.0f, -9.0f),
            new Vector3(-9.0f, -1.0f, -10.0f),

            new Vector3(-8.0f, -1.0f, 10.0f),
            new Vector3(-8.0f, -1.0f, 9.0f),
            new Vector3(-8.0f, -1.0f, 8.0f),
            new Vector3(-8.0f, -1.0f, 7.0f),
            new Vector3(-8.0f, -1.0f, 6.0f),
            new Vector3(-8.0f, -1.0f, 5.0f),
            new Vector3(-8.0f, -1.0f, 4.0f),
            new Vector3(-8.0f, -1.0f, 3.0f),
            new Vector3(-8.0f, -1.0f, 2.0f),
            new Vector3(-8.0f, -1.0f, 1.0f),
            new Vector3(-8.0f, -1.0f, 0.0f),
            new Vector3(-8.0f, -1.0f, -1.0f),
            new Vector3(-8.0f, -1.0f, -2.0f),
            new Vector3(-8.0f, -1.0f, -3.0f),
            new Vector3(-8.0f, -1.0f, -4.0f),
            new Vector3(-8.0f, -1.0f, -5.0f),
            new Vector3(-8.0f, -1.0f, -6.0f),
            new Vector3(-8.0f, -1.0f, -7.0f),
            new Vector3(-8.0f, -1.0f, -8.0f),
            new Vector3(-8.0f, -1.0f, -9.0f),
            new Vector3(-8.0f, -1.0f, -10.0f),

            new Vector3(-7.0f, -1.0f, 10.0f),
            new Vector3(-7.0f, -1.0f, 9.0f),
            new Vector3(-7.0f, -1.0f, 8.0f),
            new Vector3(-7.0f, -1.0f, 7.0f),
            new Vector3(-7.0f, -1.0f, 6.0f),
            new Vector3(-7.0f, -1.0f, 5.0f),
            new Vector3(-7.0f, -1.0f, 4.0f),
            new Vector3(-7.0f, -1.0f, 3.0f),
            new Vector3(-7.0f, -1.0f, 2.0f),
            new Vector3(-7.0f, -1.0f, 1.0f),
            new Vector3(-7.0f, -1.0f, 0.0f),
            new Vector3(-7.0f, -1.0f, -1.0f),
            new Vector3(-7.0f, -1.0f, -2.0f),
            new Vector3(-7.0f, -1.0f, -3.0f),
            new Vector3(-7.0f, -1.0f, -4.0f),
            new Vector3(-7.0f, -1.0f, -5.0f),
            new Vector3(-7.0f, -1.0f, -6.0f),
            new Vector3(-7.0f, -1.0f, -7.0f),
            new Vector3(-7.0f, -1.0f, -8.0f),
            new Vector3(-7.0f, -1.0f, -9.0f),
            new Vector3(-7.0f, -1.0f, -10.0f),

            new Vector3(-6.0f, -1.0f, 10.0f),
            new Vector3(-6.0f, -1.0f, 9.0f),
            new Vector3(-6.0f, -1.0f, 8.0f),
            new Vector3(-6.0f, -1.0f, 7.0f),
            new Vector3(-6.0f, -1.0f, 6.0f),
            new Vector3(-6.0f, -1.0f, 5.0f),
            new Vector3(-6.0f, -1.0f, 4.0f),
            new Vector3(-6.0f, -1.0f, 3.0f),
            new Vector3(-6.0f, -1.0f, 2.0f),
            new Vector3(-6.0f, -1.0f, 1.0f),
            new Vector3(-6.0f, -1.0f, 0.0f),
            new Vector3(-6.0f, -1.0f, -1.0f),
            new Vector3(-6.0f, -1.0f, -2.0f),
            new Vector3(-6.0f, -1.0f, -3.0f),
            new Vector3(-6.0f, -1.0f, -4.0f),
            new Vector3(-6.0f, -1.0f, -5.0f),
            new Vector3(-6.0f, -1.0f, -6.0f),
            new Vector3(-6.0f, -1.0f, -7.0f),
            new Vector3(-6.0f, -1.0f, -8.0f),
            new Vector3(-6.0f, -1.0f, -9.0f),
            new Vector3(-6.0f, -1.0f, -10.0f),

            new Vector3(-5.0f, -1.0f, 10.0f),
            new Vector3(-5.0f, -1.0f, 9.0f),
            new Vector3(-5.0f, -1.0f, 8.0f),
            new Vector3(-5.0f, -1.0f, 7.0f),
            new Vector3(-5.0f, -1.0f, 6.0f),
            new Vector3(-5.0f, -1.0f, 5.0f),
            new Vector3(-5.0f, -1.0f, 4.0f),
            new Vector3(-5.0f, -1.0f, 3.0f),
            new Vector3(-5.0f, -1.0f, 2.0f),
            new Vector3(-5.0f, -1.0f, 1.0f),
            new Vector3(-5.0f, -1.0f, 0.0f),
            new Vector3(-5.0f, -1.0f, -1.0f),
            new Vector3(-5.0f, -1.0f, -2.0f),
            new Vector3(-5.0f, -1.0f, -3.0f),
            new Vector3(-5.0f, -1.0f, -4.0f),
            new Vector3(-5.0f, -1.0f, -5.0f),
            new Vector3(-5.0f, -1.0f, -6.0f),
            new Vector3(-5.0f, -1.0f, -7.0f),
            new Vector3(-5.0f, -1.0f, -8.0f),
            new Vector3(-5.0f, -1.0f, -9.0f),
            new Vector3(-5.0f, -1.0f, -10.0f),

            new Vector3(-4.0f, -1.0f, 10.0f),
            new Vector3(-4.0f, -1.0f, 9.0f),
            new Vector3(-4.0f, -1.0f, 8.0f),
            new Vector3(-4.0f, -1.0f, 7.0f),
            new Vector3(-4.0f, -1.0f, 6.0f),
            new Vector3(-4.0f, -1.0f, 5.0f),
            new Vector3(-4.0f, -1.0f, 4.0f),
            new Vector3(-4.0f, -1.0f, 3.0f),
            new Vector3(-4.0f, -1.0f, 2.0f),
            new Vector3(-4.0f, -1.0f, 1.0f),
            new Vector3(-4.0f, -1.0f, 0.0f),
            new Vector3(-4.0f, -1.0f, -1.0f),
            new Vector3(-4.0f, -1.0f, -2.0f),
            new Vector3(-4.0f, -1.0f, -3.0f),
            new Vector3(-4.0f, -1.0f, -4.0f),
            new Vector3(-4.0f, -1.0f, -5.0f),
            new Vector3(-4.0f, -1.0f, -6.0f),
            new Vector3(-4.0f, -1.0f, -7.0f),
            new Vector3(-4.0f, -1.0f, -8.0f),
            new Vector3(-4.0f, -1.0f, -9.0f),
            new Vector3(-4.0f, -1.0f, -10.0f),

            new Vector3(-3.0f, -1.0f, 10.0f),
            new Vector3(-3.0f, -1.0f, 9.0f),
            new Vector3(-3.0f, -1.0f, 8.0f),
            new Vector3(-3.0f, -1.0f, 7.0f),
            new Vector3(-3.0f, -1.0f, 6.0f),
            new Vector3(-3.0f, -1.0f, 5.0f),
            new Vector3(-3.0f, -1.0f, 4.0f),
            new Vector3(-3.0f, -1.0f, 3.0f),
            new Vector3(-3.0f, -1.0f, 2.0f),
            new Vector3(-3.0f, -1.0f, 1.0f),
            new Vector3(-3.0f, -1.0f, 0.0f),
            new Vector3(-3.0f, -1.0f, -1.0f),
            new Vector3(-3.0f, -1.0f, -2.0f),
            new Vector3(-3.0f, -1.0f, -3.0f),
            new Vector3(-3.0f, -1.0f, -4.0f),
            new Vector3(-3.0f, -1.0f, -5.0f),
            new Vector3(-3.0f, -1.0f, -6.0f),
            new Vector3(-3.0f, -1.0f, -7.0f),
            new Vector3(-3.0f, -1.0f, -8.0f),
            new Vector3(-3.0f, -1.0f, -9.0f),
            new Vector3(-3.0f, -1.0f, -10.0f),

            new Vector3(-2.0f, -1.0f, 10.0f),
            new Vector3(-2.0f, -1.0f, 9.0f),
            new Vector3(-2.0f, -1.0f, 8.0f),
            new Vector3(-2.0f, -1.0f, 7.0f),
            new Vector3(-2.0f, -1.0f, 6.0f),
            new Vector3(-2.0f, -1.0f, 5.0f),
            new Vector3(-2.0f, -1.0f, 4.0f),
            new Vector3(-2.0f, -1.0f, 3.0f),
            new Vector3(-2.0f, -1.0f, 2.0f),
            new Vector3(-2.0f, -1.0f, 1.0f),
            new Vector3(-2.0f, -1.0f, 0.0f),
            new Vector3(-2.0f, -1.0f, -1.0f),
            new Vector3(-2.0f, -1.0f, -2.0f),
            new Vector3(-2.0f, -1.0f, -3.0f),
            new Vector3(-2.0f, -1.0f, -4.0f),
            new Vector3(-2.0f, -1.0f, -5.0f),
            new Vector3(-2.0f, -1.0f, -6.0f),
            new Vector3(-2.0f, -1.0f, -7.0f),
            new Vector3(-2.0f, -1.0f, -8.0f),
            new Vector3(-2.0f, -1.0f, -9.0f),
            new Vector3(-2.0f, -1.0f, -10.0f),

            new Vector3(-1.0f, -1.0f, 10.0f),
            new Vector3(-1.0f, -1.0f, 9.0f),
            new Vector3(-1.0f, -1.0f, 8.0f),
            new Vector3(-1.0f, -1.0f, 7.0f),
            new Vector3(-1.0f, -1.0f, 6.0f),
            new Vector3(-1.0f, -1.0f, 5.0f),
            new Vector3(-1.0f, -1.0f, 4.0f),
            new Vector3(-1.0f, -1.0f, 3.0f),
            new Vector3(-1.0f, -1.0f, 2.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 0.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, -2.0f),
            new Vector3(-1.0f, -1.0f, -3.0f),
            new Vector3(-1.0f, -1.0f, -4.0f),
            new Vector3(-1.0f, -1.0f, -5.0f),
            new Vector3(-1.0f, -1.0f, -6.0f),
            new Vector3(-1.0f, -1.0f, -7.0f),
            new Vector3(-1.0f, -1.0f, -8.0f),
            new Vector3(-1.0f, -1.0f, -9.0f),
            new Vector3(-1.0f, -1.0f, -10.0f),

        };

        private readonly Vector3[] _stonePositions =
        {
            //dinding depan
            new Vector3(-8.0f, 0.0f, -4.0f),
            new Vector3(-8.0f, 1.0f, -4.0f),
            new Vector3(-8.0f, 2.0f, -4.0f),
            new Vector3(-4.0f, 0.0f, -4.0f),
            new Vector3(-4.0f, 1.0f, -4.0f),
            new Vector3(-4.0f, 2.0f, -4.0f),

            new Vector3(-7.0f, 2.0f, -4.0f),
            new Vector3(-7.0f, 0.0f, -4.0f),
            new Vector3(-6.0f, 1.0f, -4.0f),
            new Vector3(-6.0f, 2.0f, -4.0f),
            new Vector3(-6.0f, 0.0f, -4.0f),
            new Vector3(-5.0f, 2.0f, -4.0f),

            //atap
            new Vector3(-8.0f, 3.0f, -4.0f),
            new Vector3(-7.0f, 3.0f, -4.0f),
            new Vector3(-6.0f, 3.0f, -4.0f),
            new Vector3(-5.0f, 3.0f, -4.0f),
            new Vector3(-4.0f, 3.0f, -4.0f),

            new Vector3(-8.0f, 3.0f, -5.0f),
            new Vector3(-6.0f, 3.0f, -5.0f),
            new Vector3(-5.0f, 3.0f, -5.0f),
            new Vector3(-4.0f, 3.0f, -5.0f),

            new Vector3(-8.0f, 3.0f, -6.0f),
            new Vector3(-6.0f, 3.0f, -6.0f),
            new Vector3(-5.0f, 3.0f, -6.0f),
            new Vector3(-4.0f, 3.0f, -6.0f),

            new Vector3(-8.0f, 3.0f, -7.0f),
            new Vector3(-5.0f, 3.0f, -7.0f),
            new Vector3(-4.0f, 3.0f, -7.0f),

            new Vector3(-8.0f, 3.0f, -8.0f),
            new Vector3(-7.0f, 3.0f, -8.0f),
            new Vector3(-6.0f, 3.0f, -8.0f),
            new Vector3(-5.0f, 3.0f, -8.0f),
            new Vector3(-4.0f, 3.0f, -8.0f),

            //tangga
            new Vector3(-7.0f, 0.0f, -6.0f),
            new Vector3(-7.0f, 1.0f, -7.0f),
            new Vector3(-6.0f, 2.0f, -7.0f),

            //dinding belakang
            new Vector3(-8.0f, 0.0f, -8.0f),
            new Vector3(-8.0f, 1.0f, -8.0f),
            new Vector3(-8.0f, 2.0f, -8.0f),
            new Vector3(-4.0f, 0.0f, -8.0f),
            new Vector3(-4.0f, 1.0f, -8.0f),
            new Vector3(-4.0f, 2.0f, -8.0f),

            new Vector3(-7.0f, 2.0f, -8.0f),
            new Vector3(-7.0f, 1.0f, -8.0f),
            new Vector3(-7.0f, 0.0f, -8.0f),
            new Vector3(-6.0f, 1.0f, -8.0f),
            new Vector3(-6.0f, 2.0f, -8.0f),
            new Vector3(-6.0f, 0.0f, -8.0f),
            new Vector3(-5.0f, 1.0f, -8.0f),
            new Vector3(-5.0f, 2.0f, -8.0f),
            new Vector3(-5.0f, 0.0f, -8.0f),

            //dinding samping kiri
            new Vector3(-8.0f, 2.0f, -7.0f),
            new Vector3(-8.0f, 1.0f, -7.0f),
            new Vector3(-8.0f, 0.0f, -7.0f),
            new Vector3(-8.0f, 1.0f, -6.0f),
            new Vector3(-8.0f, 2.0f, -6.0f),
            new Vector3(-8.0f, 0.0f, -6.0f),
            new Vector3(-8.0f, 1.0f, -5.0f),
            new Vector3(-8.0f, 2.0f, -5.0f),
            new Vector3(-8.0f, 0.0f, -5.0f),

            //dinding samping kanan 
            new Vector3(-4.0f, 2.0f, -7.0f),
            new Vector3(-4.0f, 1.0f, -7.0f),
            new Vector3(-4.0f, 0.0f, -7.0f),
            new Vector3(-4.0f, 2.0f, -6.0f),
            new Vector3(-4.0f, 0.0f, -6.0f),
            new Vector3(-4.0f, 2.0f, -5.0f),
            new Vector3(-4.0f, 1.0f, -5.0f),
            new Vector3(-4.0f, 0.0f, -5.0f),

            //dinding depan lantai 2
            new Vector3(-8.0f, 4.0f, -4.0f),
            new Vector3(-8.0f, 5.0f, -4.0f),
            new Vector3(-8.0f, 6.0f, -4.0f),
            new Vector3(-4.0f, 4.0f, -4.0f),
            new Vector3(-4.0f, 5.0f, -4.0f),
            new Vector3(-4.0f, 6.0f, -4.0f),

            new Vector3(-7.0f, 6.0f, -4.0f),
            new Vector3(-7.0f, 4.0f, -4.0f),
            new Vector3(-6.0f, 5.0f, -4.0f),
            new Vector3(-6.0f, 6.0f, -4.0f),
            new Vector3(-6.0f, 4.0f, -4.0f),
            new Vector3(-5.0f, 6.0f, -4.0f),
            new Vector3(-5.0f, 5.0f, -4.0f),
            new Vector3(-5.0f, 4.0f, -4.0f),

            //atap lantai 2
            new Vector3(-8.0f, 7.0f, -4.0f),
            new Vector3(-7.0f, 7.0f, -4.0f),
            new Vector3(-6.0f, 7.0f, -4.0f),
            new Vector3(-5.0f, 7.0f, -4.0f),
            new Vector3(-4.0f, 7.0f, -4.0f),

            new Vector3(-8.0f, 7.0f, -5.0f),
            new Vector3(-7.0f, 7.0f, -5.0f),
            new Vector3(-6.0f, 7.0f, -5.0f),
            new Vector3(-5.0f, 7.0f, -5.0f),
            new Vector3(-4.0f, 7.0f, -5.0f),

            new Vector3(-8.0f, 7.0f, -6.0f),
            new Vector3(-7.0f, 7.0f, -6.0f),
            new Vector3(-6.0f, 7.0f, -6.0f),
            new Vector3(-5.0f, 7.0f, -6.0f),
            new Vector3(-4.0f, 7.0f, -6.0f),

            new Vector3(-8.0f, 7.0f, -7.0f),
            new Vector3(-7.0f, 7.0f, -7.0f),
            new Vector3(-6.0f, 7.0f, -7.0f),
            new Vector3(-5.0f, 7.0f, -7.0f),
            new Vector3(-4.0f, 7.0f, -7.0f),

            new Vector3(-8.0f, 7.0f, -8.0f),
            new Vector3(-7.0f, 7.0f, -8.0f),
            new Vector3(-6.0f, 7.0f, -8.0f),
            new Vector3(-5.0f, 7.0f, -8.0f),
            new Vector3(-4.0f, 7.0f, -8.0f),

            //dinding belakang lantai 2
            new Vector3(-8.0f, 4.0f, -8.0f),
            new Vector3(-8.0f, 5.0f, -8.0f),
            new Vector3(-8.0f, 6.0f, -8.0f),
            new Vector3(-4.0f, 4.0f, -8.0f),
            new Vector3(-4.0f, 5.0f, -8.0f),
            new Vector3(-4.0f, 6.0f, -8.0f),

            new Vector3(-7.0f, 6.0f, -8.0f),
            new Vector3(-7.0f, 5.0f, -8.0f),
            new Vector3(-7.0f, 4.0f, -8.0f),
            new Vector3(-6.0f, 6.0f, -8.0f),
            new Vector3(-6.0f, 4.0f, -8.0f),
            new Vector3(-5.0f, 5.0f, -8.0f),
            new Vector3(-5.0f, 6.0f, -8.0f),
            new Vector3(-5.0f, 4.0f, -8.0f),

            //dinding samping kiri lantai 2
            new Vector3(-8.0f, 6.0f, -7.0f),
            new Vector3(-8.0f, 5.0f, -7.0f),
            new Vector3(-8.0f, 4.0f, -7.0f),
            new Vector3(-8.0f, 6.0f, -6.0f),
            new Vector3(-8.0f, 4.0f, -6.0f),
            new Vector3(-8.0f, 5.0f, -5.0f),
            new Vector3(-8.0f, 6.0f, -5.0f),
            new Vector3(-8.0f, 4.0f, -5.0f),

            //dinding samping kanan lantai 2
            new Vector3(-4.0f, 6.0f, -7.0f),
            new Vector3(-4.0f, 5.0f, -7.0f),
            new Vector3(-4.0f, 4.0f, -7.0f),
            new Vector3(-4.0f, 6.0f, -6.0f),
            new Vector3(-4.0f, 6.0f, -5.0f),
            new Vector3(-4.0f, 5.0f, -5.0f),
            new Vector3(-4.0f, 4.0f, -5.0f),

            //balkon
            new Vector3(-2.0f, 3.0f, -4.0f),
            new Vector3(-1.0f, 3.0f, -4.0f),
            new Vector3(0.0f, 3.0f, -4.0f),
            new Vector3(1.0f, 3.0f, -4.0f),
            new Vector3(2.0f, 3.0f, -4.0f),

            new Vector3(-2.0f, 3.0f, -5.0f),
            new Vector3(-1.0f, 3.0f, -5.0f),
            new Vector3(0.0f, 3.0f, -5.0f),
            new Vector3(1.0f, 3.0f, -5.0f),
            new Vector3(2.0f, 3.0f, -5.0f),

            new Vector3(-2.0f, 3.0f, -6.0f),
            new Vector3(-1.0f, 3.0f, -6.0f),
            new Vector3(0.0f, 3.0f, -6.0f),
            new Vector3(1.0f, 3.0f, -6.0f),
            new Vector3(2.0f, 3.0f, -6.0f),

            new Vector3(-2.0f, 3.0f, -7.0f),
            new Vector3(-1.0f, 3.0f, -7.0f),
            new Vector3(0.0f, 3.0f, -7.0f),
            new Vector3(1.0f, 3.0f, -7.0f),
            new Vector3(2.0f, 3.0f, -7.0f),

            new Vector3(-2.0f, 3.0f, -8.0f),
            new Vector3(-1.0f, 3.0f, -8.0f),
            new Vector3(0.0f, 3.0f, -8.0f),
            new Vector3(1.0f, 3.0f, -8.0f),
            new Vector3(2.0f, 3.0f, -8.0f),

        };

        private readonly Vector3[] _woodPositions =
        {
            //kayu bagian luar
            new Vector3(-3.0f, 0.0f, -3.0f),
            new Vector3(-3.0f, 1.0f, -3.0f),
            new Vector3(-3.0f, 2.0f, -3.0f),
            new Vector3(-3.0f, 3.0f, -3.0f),

            new Vector3(-9.0f, 0.0f, -3.0f),
            new Vector3(-9.0f, 1.0f, -3.0f),
            new Vector3(-9.0f, 2.0f, -3.0f),
            new Vector3(-9.0f, 3.0f, -3.0f),

            new Vector3(-3.0f, 0.0f, -9.0f),
            new Vector3(-3.0f, 1.0f, -9.0f),
            new Vector3(-3.0f, 2.0f, -9.0f),
            new Vector3(-3.0f, 3.0f, -9.0f),

            new Vector3(-9.0f, 0.0f, -9.0f),
            new Vector3(-9.0f, 1.0f, -9.0f),
            new Vector3(-9.0f, 2.0f, -9.0f),
            new Vector3(-9.0f, 3.0f, -9.0f),

            //kayu bagian luar lantai 2
            new Vector3(-3.0f, 7.0f, -3.0f),

            new Vector3(-9.0f, 4.0f, -3.0f),
            new Vector3(-9.0f, 5.0f, -3.0f),
            new Vector3(-9.0f, 6.0f, -3.0f),
            new Vector3(-9.0f, 7.0f, -3.0f),

            new Vector3(-3.0f, 7.0f, -9.0f),

            new Vector3(-9.0f, 4.0f, -9.0f),
            new Vector3(-9.0f, 5.0f, -9.0f),
            new Vector3(-9.0f, 6.0f, -9.0f),
            new Vector3(-9.0f, 7.0f, -9.0f),

            //kayu bagian atas
            new Vector3(-3.0f, 3.0f, -4.0f),
            new Vector3(-3.0f, 3.0f, -5.0f),
            new Vector3(-3.0f, 3.0f, -6.0f),
            new Vector3(-3.0f, 3.0f, -7.0f),
            new Vector3(-3.0f, 3.0f, -8.0f),

            new Vector3(-9.0f, 3.0f, -4.0f),
            new Vector3(-9.0f, 3.0f, -5.0f),
            new Vector3(-9.0f, 3.0f, -6.0f),
            new Vector3(-9.0f, 3.0f, -7.0f),
            new Vector3(-9.0f, 3.0f, -8.0f),

            new Vector3(-4.0f, 3.0f, -3.0f),
            new Vector3(-5.0f, 3.0f, -3.0f),
            new Vector3(-6.0f, 3.0f, -3.0f),
            new Vector3(-7.0f, 3.0f, -3.0f),
            new Vector3(-8.0f, 3.0f, -3.0f),

            new Vector3(-4.0f, 3.0f, -9.0f),
            new Vector3(-5.0f, 3.0f, -9.0f),
            new Vector3(-6.0f, 3.0f, -9.0f),
            new Vector3(-7.0f, 3.0f, -9.0f),
            new Vector3(-8.0f, 3.0f, -9.0f),

            //kayu bagian atas lantai 2
            new Vector3(-3.0f, 7.0f, -4.0f),
            new Vector3(-3.0f, 7.0f, -5.0f),
            new Vector3(-3.0f, 7.0f, -6.0f),
            new Vector3(-3.0f, 7.0f, -7.0f),
            new Vector3(-3.0f, 7.0f, -8.0f),

            new Vector3(-9.0f, 7.0f, -4.0f),
            new Vector3(-9.0f, 7.0f, -5.0f),
            new Vector3(-9.0f, 7.0f, -6.0f),
            new Vector3(-9.0f, 7.0f, -7.0f),
            new Vector3(-9.0f, 7.0f, -8.0f),

            new Vector3(-4.0f, 7.0f, -3.0f),
            new Vector3(-5.0f, 7.0f, -3.0f),
            new Vector3(-6.0f, 7.0f, -3.0f),
            new Vector3(-7.0f, 7.0f, -3.0f),
            new Vector3(-8.0f, 7.0f, -3.0f),

            new Vector3(-4.0f, 7.0f, -9.0f),
            new Vector3(-5.0f, 7.0f, -9.0f),
            new Vector3(-6.0f, 7.0f, -9.0f),
            new Vector3(-7.0f, 7.0f, -9.0f),
            new Vector3(-8.0f, 7.0f, -9.0f),

            //kayu balkon
            new Vector3(-2.0f, 3.0f, -3.0f),
            new Vector3(-1.0f, 3.0f, -3.0f),
            new Vector3(0.0f, 3.0f, -3.0f),
            new Vector3(1.0f, 3.0f, -3.0f),
            new Vector3(2.0f, 3.0f, -3.0f),

            new Vector3(-2.0f, 3.0f, -9.0f),
            new Vector3(-1.0f, 3.0f, -9.0f),
            new Vector3(0.0f, 3.0f, -9.0f),
            new Vector3(1.0f, 3.0f, -9.0f),
            new Vector3(2.0f, 3.0f, -9.0f),

            new Vector3(3.0f, 3.0f, -9.0f),
            new Vector3(3.0f, 3.0f, -8.0f),
            new Vector3(3.0f, 3.0f, -7.0f),
            new Vector3(3.0f, 3.0f, -6.0f),
            new Vector3(3.0f, 3.0f, -5.0f),
            new Vector3(3.0f, 3.0f, -4.0f),
            new Vector3(3.0f, 3.0f, -3.0f),

            new Vector3(3.0f, 2.0f, -9.0f),
            new Vector3(3.0f, 1.0f, -9.0f),
            new Vector3(3.0f, 0.0f, -9.0f),

            new Vector3(3.0f, 2.0f, -3.0f),
            new Vector3(3.0f, 1.0f, -3.0f),
            new Vector3(3.0f, 0.0f, -3.0f),

            //kayu balkon lantai 2
            new Vector3(-2.0f, 7.0f, -3.0f),
            new Vector3(-1.0f, 7.0f, -3.0f),
            new Vector3(0.0f, 7.0f, -3.0f),
            new Vector3(1.0f, 7.0f, -3.0f),
            new Vector3(2.0f, 7.0f, -3.0f),

            new Vector3(-2.0f, 7.0f, -9.0f),
            new Vector3(-1.0f, 7.0f, -9.0f),
            new Vector3(0.0f, 7.0f, -9.0f),
            new Vector3(1.0f, 7.0f, -9.0f),
            new Vector3(2.0f, 7.0f, -9.0f),

            new Vector3(3.0f, 7.0f, -9.0f),
            new Vector3(3.0f, 7.0f, -8.0f),
            new Vector3(3.0f, 7.0f, -7.0f),
            new Vector3(3.0f, 7.0f, -6.0f),
            new Vector3(3.0f, 7.0f, -5.0f),
            new Vector3(3.0f, 7.0f, -4.0f),
            new Vector3(3.0f, 7.0f, -3.0f),

            new Vector3(3.0f, 6.0f, -9.0f),
            new Vector3(3.0f, 5.0f, -9.0f),
            new Vector3(3.0f, 4.0f, -9.0f),

            new Vector3(3.0f, 6.0f, -3.0f),
            new Vector3(3.0f, 5.0f, -3.0f),
            new Vector3(3.0f, 4.0f, -3.0f),

            //batang pohon
            new Vector3(-7.0f, 0.0f, 8.0f),
            new Vector3(-6.0f, 0.0f, 8.0f),
            new Vector3(-8.0f, 0.0f, 7.0f),
            new Vector3(-7.0f, 0.0f, 7.0f),
            new Vector3(-7.0f, 1.0f, 7.0f),
            new Vector3(-7.0f, 2.0f, 7.0f),
            new Vector3(-7.0f, 3.0f, 6.0f),
            new Vector3(-7.0f, 3.0f, 8.0f),
            new Vector3(-7.0f, 4.0f, 6.0f),
            new Vector3(-6.0f, 5.0f, 6.0f),
            new Vector3(-7.0f, 5.0f, 7.0f),
            new Vector3(-7.0f, 0.0f, 6.0f),
            new Vector3(-6.0f, 0.0f, 7.0f),
            new Vector3(-6.0f, 1.0f, 7.0f),
            new Vector3(-5.0f, 0.0f, 7.0f),

            //batang pohon 2
            new Vector3(7.0f, 0.0f, 8.0f),
            new Vector3(6.0f, 0.0f, 8.0f),
            new Vector3(8.0f, 0.0f, 7.0f),
            new Vector3(7.0f, 0.0f, 7.0f),
            new Vector3(7.0f, 1.0f, 7.0f),
            new Vector3(7.0f, 2.0f, 7.0f),
            new Vector3(7.0f, 3.0f, 6.0f),
            new Vector3(7.0f, 3.0f, 8.0f),
            new Vector3(7.0f, 4.0f, 6.0f),
            new Vector3(6.0f, 5.0f, 6.0f),
            new Vector3(7.0f, 5.0f, 7.0f),
            new Vector3(7.0f, 0.0f, 6.0f),
            new Vector3(6.0f, 0.0f, 7.0f),
            new Vector3(6.0f, 1.0f, 7.0f),
            new Vector3(5.0f, 0.0f, 7.0f),

        };

        private readonly Vector3[] _leavesPositions =
        {
            //Daun layer 3 kanan
            new Vector3(-7.0f, 8.0f, 6.0f),
            new Vector3(-6.0f, 8.0f, 6.0f),

            new Vector3(-7.0f, 8.0f, 7.0f),
            new Vector3(-6.0f, 8.0f, 7.0f),

            new Vector3(-7.0f, 8.0f, 8.0f),
            new Vector3(-6.0f, 8.0f, 8.0f),

            //Daun layer 2 kanan
            new Vector3(-7.0f, 7.0f, 5.0f),
            new Vector3(-6.0f, 7.0f, 5.0f),

            new Vector3(-8.0f, 7.0f, 6.0f),
            new Vector3(-7.0f, 7.0f, 6.0f),
            new Vector3(-6.0f, 7.0f, 6.0f),
            new Vector3(-5.0f, 7.0f, 6.0f),

            new Vector3(-8.0f, 7.0f, 7.0f),
            new Vector3(-7.0f, 7.0f, 7.0f),
            new Vector3(-6.0f, 7.0f, 7.0f),
            new Vector3(-5.0f, 7.0f, 7.0f),

            new Vector3(-8.0f, 7.0f, 8.0f),
            new Vector3(-7.0f, 7.0f, 8.0f),
            new Vector3(-6.0f, 7.0f, 8.0f),
            new Vector3(-5.0f, 7.0f, 8.0f),

            new Vector3(-7.0f, 7.0f, 9.0f),
            new Vector3(-6.0f, 7.0f, 9.0f),

            //Daun layer 1 kanan
            new Vector3(-7.0f, 6.0f, 4.0f),
            new Vector3(-6.0f, 6.0f, 4.0f),

            new Vector3(-8.0f, 6.0f, 5.0f),
            new Vector3(-7.0f, 6.0f, 5.0f),
            new Vector3(-6.0f, 6.0f, 5.0f),
            new Vector3(-5.0f, 6.0f, 5.0f),

            new Vector3(-9.0f, 6.0f, 6.0f),
            new Vector3(-8.0f, 6.0f, 6.0f),
            new Vector3(-7.0f, 6.0f, 6.0f),
            new Vector3(-6.0f, 6.0f, 6.0f),
            new Vector3(-5.0f, 6.0f, 6.0f),
            new Vector3(-4.0f, 6.0f, 6.0f),

            new Vector3(-9.0f, 6.0f, 7.0f),
            new Vector3(-8.0f, 6.0f, 7.0f),
            new Vector3(-7.0f, 6.0f, 7.0f),
            new Vector3(-6.0f, 6.0f, 7.0f),
            new Vector3(-5.0f, 6.0f, 7.0f),
            new Vector3(-4.0f, 6.0f, 7.0f),

            new Vector3(-9.0f, 6.0f, 8.0f),
            new Vector3(-8.0f, 6.0f, 8.0f),
            new Vector3(-7.0f, 6.0f, 8.0f),
            new Vector3(-6.0f, 6.0f, 8.0f),
            new Vector3(-5.0f, 6.0f, 8.0f),
            new Vector3(-4.0f, 6.0f, 8.0f),

            new Vector3(-8.0f, 6.0f, 9.0f),
            new Vector3(-7.0f, 6.0f, 9.0f),
            new Vector3(-6.0f, 6.0f, 9.0f),
            new Vector3(-5.0f, 6.0f, 9.0f),

            new Vector3(-7.0f, 6.0f, 10.0f),
            new Vector3(-6.0f, 6.0f, 10.0f),

            //Daun layer 0 kanan
            new Vector3(-8.0f, 5.0f, 5.0f),
            new Vector3(-7.0f, 5.0f, 5.0f),
            new Vector3(-6.0f, 5.0f, 5.0f),
            new Vector3(-5.0f, 5.0f, 5.0f),

            new Vector3(-9.0f, 5.0f, 6.0f),
            new Vector3(-8.0f, 5.0f, 6.0f),
            new Vector3(-7.0f, 5.0f, 6.0f),
            new Vector3(-6.0f, 5.0f, 6.0f),
            new Vector3(-5.0f, 5.0f, 6.0f),
            new Vector3(-4.0f, 5.0f, 6.0f),

            new Vector3(-9.0f, 5.0f, 7.0f),
            new Vector3(-8.0f, 5.0f, 7.0f),
            new Vector3(-7.0f, 5.0f, 7.0f),
            new Vector3(-6.0f, 5.0f, 7.0f),
            new Vector3(-5.0f, 5.0f, 7.0f),
            new Vector3(-4.0f, 5.0f, 7.0f),
        
            new Vector3(-9.0f, 5.0f, 8.0f),
            new Vector3(-8.0f, 5.0f, 8.0f),
            new Vector3(-7.0f, 5.0f, 8.0f),
            new Vector3(-6.0f, 5.0f, 8.0f),
            new Vector3(-5.0f, 5.0f, 8.0f),
            new Vector3(-4.0f, 5.0f, 8.0f),

            new Vector3(-8.0f, 5.0f, 9.0f),
            new Vector3(-7.0f, 5.0f, 9.0f),
            new Vector3(-6.0f, 5.0f, 9.0f),
            new Vector3(-5.0f, 5.0f, 9.0f),

            //Daun layer-1 kanan
            new Vector3(-7.0f, 4.0f, 5.0f),
            new Vector3(-6.0f, 4.0f, 5.0f),

            new Vector3(-8.0f, 4.0f, 6.0f),
            new Vector3(-7.0f, 4.0f, 6.0f),
            new Vector3(-6.0f, 4.0f, 6.0f),
            new Vector3(-5.0f, 4.0f, 6.0f),

            new Vector3(-8.0f, 4.0f, 7.0f),
            new Vector3(-7.0f, 4.0f, 7.0f),
            new Vector3(-6.0f, 4.0f, 7.0f),
            new Vector3(-5.0f, 4.0f, 7.0f),

            new Vector3(-8.0f, 4.0f, 8.0f),
            new Vector3(-7.0f, 4.0f, 8.0f),
            new Vector3(-6.0f, 4.0f, 8.0f),
            new Vector3(-5.0f, 4.0f, 8.0f),

            new Vector3(-7.0f, 4.0f, 9.0f),
            new Vector3(-6.0f, 4.0f, 9.0f),

            //Daun layer 3 kiri
            new Vector3(7.0f, 8.0f, 6.0f),
            new Vector3(6.0f, 8.0f, 6.0f),

            new Vector3(7.0f, 8.0f, 7.0f),
            new Vector3(6.0f, 8.0f, 7.0f),

            new Vector3(7.0f, 8.0f, 8.0f),
            new Vector3(6.0f, 8.0f, 8.0f),

            //Daun layer 2 kiri
            new Vector3(7.0f, 7.0f, 5.0f),
            new Vector3(6.0f, 7.0f, 5.0f),

            new Vector3(8.0f, 7.0f, 6.0f),
            new Vector3(7.0f, 7.0f, 6.0f),
            new Vector3(6.0f, 7.0f, 6.0f),
            new Vector3(5.0f, 7.0f, 6.0f),

            new Vector3(8.0f, 7.0f, 7.0f),
            new Vector3(7.0f, 7.0f, 7.0f),
            new Vector3(6.0f, 7.0f, 7.0f),
            new Vector3(5.0f, 7.0f, 7.0f),

            new Vector3(8.0f, 7.0f, 8.0f),
            new Vector3(7.0f, 7.0f, 8.0f),
            new Vector3(6.0f, 7.0f, 8.0f),
            new Vector3(5.0f, 7.0f, 8.0f),

            new Vector3(7.0f, 7.0f, 9.0f),
            new Vector3(6.0f, 7.0f, 9.0f),

            //Daun layer 1 kiri
            new Vector3(7.0f, 6.0f, 4.0f),
            new Vector3(6.0f, 6.0f, 4.0f),

            new Vector3(8.0f, 6.0f, 5.0f),
            new Vector3(7.0f, 6.0f, 5.0f),
            new Vector3(6.0f, 6.0f, 5.0f),
            new Vector3(5.0f, 6.0f, 5.0f),

            new Vector3(9.0f, 6.0f, 6.0f),
            new Vector3(8.0f, 6.0f, 6.0f),
            new Vector3(7.0f, 6.0f, 6.0f),
            new Vector3(6.0f, 6.0f, 6.0f),
            new Vector3(5.0f, 6.0f, 6.0f),
            new Vector3(4.0f, 6.0f, 6.0f),

            new Vector3(9.0f, 6.0f, 7.0f),
            new Vector3(8.0f, 6.0f, 7.0f),
            new Vector3(7.0f, 6.0f, 7.0f),
            new Vector3(6.0f, 6.0f, 7.0f),
            new Vector3(5.0f, 6.0f, 7.0f),
            new Vector3(4.0f, 6.0f, 7.0f),

            new Vector3(9.0f, 6.0f, 8.0f),
            new Vector3(8.0f, 6.0f, 8.0f),
            new Vector3(7.0f, 6.0f, 8.0f),
            new Vector3(6.0f, 6.0f, 8.0f),
            new Vector3(5.0f, 6.0f, 8.0f),
            new Vector3(4.0f, 6.0f, 8.0f),

            new Vector3(8.0f, 6.0f, 9.0f),
            new Vector3(7.0f, 6.0f, 9.0f),
            new Vector3(6.0f, 6.0f, 9.0f),
            new Vector3(5.0f, 6.0f, 9.0f),

            new Vector3(7.0f, 6.0f, 10.0f),
            new Vector3(6.0f, 6.0f, 10.0f),

            //Daun layer 0 kiri
            new Vector3(8.0f, 5.0f, 5.0f),
            new Vector3(7.0f, 5.0f, 5.0f),
            new Vector3(6.0f, 5.0f, 5.0f),
            new Vector3(5.0f, 5.0f, 5.0f),

            new Vector3(9.0f, 5.0f, 6.0f),
            new Vector3(8.0f, 5.0f, 6.0f),
            new Vector3(7.0f, 5.0f, 6.0f),
            new Vector3(6.0f, 5.0f, 6.0f),
            new Vector3(5.0f, 5.0f, 6.0f),
            new Vector3(4.0f, 5.0f, 6.0f),

            new Vector3(9.0f, 5.0f, 7.0f),
            new Vector3(8.0f, 5.0f, 7.0f),
            new Vector3(7.0f, 5.0f, 7.0f),
            new Vector3(6.0f, 5.0f, 7.0f),
            new Vector3(5.0f, 5.0f, 7.0f),
            new Vector3(4.0f, 5.0f, 7.0f),

            new Vector3(9.0f, 5.0f, 8.0f),
            new Vector3(8.0f, 5.0f, 8.0f),
            new Vector3(7.0f, 5.0f, 8.0f),
            new Vector3(6.0f, 5.0f, 8.0f),
            new Vector3(5.0f, 5.0f, 8.0f),
            new Vector3(4.0f, 5.0f, 8.0f),

            new Vector3(8.0f, 5.0f, 9.0f),
            new Vector3(7.0f, 5.0f, 9.0f),
            new Vector3(6.0f, 5.0f, 9.0f),
            new Vector3(5.0f, 5.0f, 9.0f),

            //Daun layer-1 kiri
            new Vector3(7.0f, 4.0f, 5.0f),
            new Vector3(6.0f, 4.0f, 5.0f),

            new Vector3(8.0f, 4.0f, 6.0f),
            new Vector3(7.0f, 4.0f, 6.0f),
            new Vector3(6.0f, 4.0f, 6.0f),
            new Vector3(5.0f, 4.0f, 6.0f),

            new Vector3(8.0f, 4.0f, 7.0f),
            new Vector3(7.0f, 4.0f, 7.0f),
            new Vector3(6.0f, 4.0f, 7.0f),
            new Vector3(5.0f, 4.0f, 7.0f),

            new Vector3(8.0f, 4.0f, 8.0f),
            new Vector3(7.0f, 4.0f, 8.0f),
            new Vector3(6.0f, 4.0f, 8.0f),
            new Vector3(5.0f, 4.0f, 8.0f),

            new Vector3(7.0f, 4.0f, 9.0f),
            new Vector3(6.0f, 4.0f, 9.0f),


        };

        private readonly Vector3[] _pointLightPositions =
        {
            new Vector3(10.0f, 0.8f, 10.0f),
            new Vector3(-10.0f, 0.8f, -10.0f),
            new Vector3(-6.0f, 6.2f, -6.0f),
            new Vector3(-6.0f, 2.2f, -6.0f)
        };

        private int _vertexBufferObject;
        private int _vaoModel;
        private int _vaoLamp;

        private Shader _lampShader;
        private Shader _lightingShader;
        private Shader _groundShader;
        private Shader _stoneShader;
        private Shader _woodShader;
        private Shader _leavesShader;

        private Texture _groundMap;
        private Texture _diffuseMap;
        private Texture _specularMap;
        private Texture _stoneMap;
        private Texture _woodMap;
        private Texture _leavesMap;

        private Camera _camera;

        private bool _firstMove = true;

        private Vector2 _lastPos;
        

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.0f, 0.0f, 0.1f, 0.0f);

            GL.Enable(EnableCap.DepthTest);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _lightingShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");
            _stoneShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");
            _groundShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");
            _woodShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");
            _leavesShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");

            _lampShader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");

            {
                _vaoModel = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel);

                //box
                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                var texCoordLocation = _lightingShader.GetAttribLocation("aTexCoords");
                GL.EnableVertexAttribArray(texCoordLocation);
                GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

                //ground
                var positionLocation2 = _groundShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation2);
                GL.VertexAttribPointer(positionLocation2, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                var normalLocation2 = _groundShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation2);
                GL.VertexAttribPointer(normalLocation2, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                var texCoordLocation2 = _groundShader.GetAttribLocation("aTexCoords");
                GL.EnableVertexAttribArray(texCoordLocation2);
                GL.VertexAttribPointer(texCoordLocation2, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

                //stone
                var positionLocation3 = _stoneShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation3);
                GL.VertexAttribPointer(positionLocation3, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                var normalLocation3 = _stoneShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation3);
                GL.VertexAttribPointer(normalLocation3, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                var texCoordLocation3 = _stoneShader.GetAttribLocation("aTexCoords");
                GL.EnableVertexAttribArray(texCoordLocation3);
                GL.VertexAttribPointer(texCoordLocation3, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

                //wood
                var positionLocation4 = _woodShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation4);
                GL.VertexAttribPointer(positionLocation4, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                var normalLocation4 = _woodShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation4);
                GL.VertexAttribPointer(normalLocation4, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                var texCoordLocation4 = _woodShader.GetAttribLocation("aTexCoords");
                GL.EnableVertexAttribArray(texCoordLocation4);
                GL.VertexAttribPointer(texCoordLocation4, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

                //leaves
                var positionLocation5 = _leavesShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation5);
                GL.VertexAttribPointer(positionLocation5, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

                var normalLocation5 = _leavesShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation5);
                GL.VertexAttribPointer(normalLocation5, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

                var texCoordLocation5 = _leavesShader.GetAttribLocation("aTexCoords");
                GL.EnableVertexAttribArray(texCoordLocation5);
                GL.VertexAttribPointer(texCoordLocation5, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

            }

            {
                _vaoLamp = GL.GenVertexArray();
                GL.BindVertexArray(_vaoLamp);

                var positionLocation = _lampShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            }

            _leavesMap = Texture.LoadFromFile("Resources/leaves.png");
            _woodMap = Texture.LoadFromFile("Resources/wood.jpg");
            _stoneMap = Texture.LoadFromFile("Resources/stone.jpg");
            _groundMap = Texture.LoadFromFile("Resources/grass.jpg");
            _diffuseMap = Texture.LoadFromFile("Resources/container2.png");
            _specularMap = Texture.LoadFromFile("Resources/container2_specular.png");

            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);

            CursorGrabbed = true;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(_vaoModel);

            //ground texture
            _groundMap.Use(TextureUnit.Texture2);
            _groundShader.Use();
            _groundShader.SetMatrix4("view", _camera.GetViewMatrix());
            _groundShader.SetMatrix4("projection", _camera.GetProjectionMatrix());
            _groundShader.SetVector3("viewPos", _camera.Position);
            _groundShader.SetInt("material.diffuse", 2); 
            _groundShader.SetInt("material.specular", 2); //membuat objek memantulkan cahaya
            _groundShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _groundShader.SetFloat("material.shininess", 32.0f);

            _groundShader.SetVector3("dirLight.direction", new Vector3(-0.2f, -1.0f, -0.3f));
            _groundShader.SetVector3("dirLight.ambient", new Vector3(0.05f, 0.05f, 0.05f));
            _groundShader.SetVector3("dirLight.diffuse", new Vector3(0.4f, 0.4f, 0.4f));
            _groundShader.SetVector3("dirLight.specular", new Vector3(0.5f, 0.5f, 0.5f));

            //stone texture
            _stoneMap.Use(TextureUnit.Texture3);
            _stoneShader.Use();
            _stoneShader.SetMatrix4("view", _camera.GetViewMatrix());
            _stoneShader.SetMatrix4("projection", _camera.GetProjectionMatrix());
            _stoneShader.SetVector3("viewPos", _camera.Position);
            _stoneShader.SetInt("material.diffuse", 3);
            _stoneShader.SetInt("material.specular", 3);
            _stoneShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _stoneShader.SetFloat("material.shininess", 32.0f);

            _stoneShader.SetVector3("dirLight.direction", new Vector3(-0.2f, -1.0f, -0.3f));
            _stoneShader.SetVector3("dirLight.ambient", new Vector3(0.05f, 0.05f, 0.05f));
            _stoneShader.SetVector3("dirLight.diffuse", new Vector3(0.4f, 0.4f, 0.4f));
            _stoneShader.SetVector3("dirLight.specular", new Vector3(0.5f, 0.5f, 0.5f));

            //wood texture
            _woodMap.Use(TextureUnit.Texture4);
            _woodShader.Use();
            _woodShader.SetMatrix4("view", _camera.GetViewMatrix());
            _woodShader.SetMatrix4("projection", _camera.GetProjectionMatrix());
            _woodShader.SetVector3("viewPos", _camera.Position);
            _woodShader.SetInt("material.diffuse", 4);
            _woodShader.SetInt("material.specular", 4); //membuat objek memantulkan cahaya
            _woodShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _woodShader.SetFloat("material.shininess", 32.0f);

            _woodShader.SetVector3("dirLight.direction", new Vector3(-0.2f, -1.0f, -0.3f));
            _woodShader.SetVector3("dirLight.ambient", new Vector3(0.05f, 0.05f, 0.05f));
            _woodShader.SetVector3("dirLight.diffuse", new Vector3(0.4f, 0.4f, 0.4f));
            _woodShader.SetVector3("dirLight.specular", new Vector3(0.5f, 0.5f, 0.5f));

            //leaves texture
            _leavesMap.Use(TextureUnit.Texture5);
            _leavesShader.Use();
            _leavesShader.SetMatrix4("view", _camera.GetViewMatrix());
            _leavesShader.SetMatrix4("projection", _camera.GetProjectionMatrix());
            _leavesShader.SetVector3("viewPos", _camera.Position);
            _leavesShader.SetInt("material.diffuse", 5);
            _leavesShader.SetInt("material.specular", 5); //membuat objek memantulkan cahaya
            _leavesShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _leavesShader.SetFloat("material.shininess", 32.0f);

            _leavesShader.SetVector3("dirLight.direction", new Vector3(-0.2f, -1.0f, -0.3f));
            _leavesShader.SetVector3("dirLight.ambient", new Vector3(0.05f, 0.05f, 0.05f));
            _leavesShader.SetVector3("dirLight.diffuse", new Vector3(0.4f, 0.4f, 0.4f));
            _leavesShader.SetVector3("dirLight.specular", new Vector3(0.5f, 0.5f, 0.5f));

            //box
            _diffuseMap.Use(TextureUnit.Texture0);
            _specularMap.Use(TextureUnit.Texture1);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("viewPos", _camera.Position);

            _lightingShader.SetInt("material.diffuse", 0);
            _lightingShader.SetInt("material.specular", 1);
            _lightingShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
            _lightingShader.SetFloat("material.shininess", 32.0f);

            //directional light
            _lightingShader.SetVector3("dirLight.direction", new Vector3(-0.2f, -1.0f, -0.3f));
            _lightingShader.SetVector3("dirLight.ambient", new Vector3(0.05f, 0.05f, 0.05f));
            _lightingShader.SetVector3("dirLight.diffuse", new Vector3(0.4f, 0.4f, 0.4f));
            _lightingShader.SetVector3("dirLight.specular", new Vector3(0.5f, 0.5f, 0.5f));

            //point lights
            for (int i = 0; i < _pointLightPositions.Length; i++)
            {
                _groundShader.SetVector3($"pointLights[{i}].position", _pointLightPositions[i]);
                _groundShader.SetVector3($"pointLights[{i}].ambient", new Vector3(0.05f, 0.05f, 0.05f));
                _groundShader.SetVector3($"pointLights[{i}].diffuse", new Vector3(0.8f, 0.8f, 0.8f));
                _groundShader.SetVector3($"pointLights[{i}].specular", new Vector3(1.0f, 1.0f, 1.0f));
                _groundShader.SetFloat($"pointLights[{i}].constant", 1.0f);
                _groundShader.SetFloat($"pointLights[{i}].linear", 0.09f);
                _groundShader.SetFloat($"pointLights[{i}].quadratic", 0.032f);

                _stoneShader.SetVector3($"pointLights[{i}].position", _pointLightPositions[i]);
                _stoneShader.SetVector3($"pointLights[{i}].ambient", new Vector3(0.05f, 0.05f, 0.05f));
                _stoneShader.SetVector3($"pointLights[{i}].diffuse", new Vector3(0.8f, 0.8f, 0.8f));
                _stoneShader.SetVector3($"pointLights[{i}].specular", new Vector3(1.0f, 1.0f, 1.0f));
                _stoneShader.SetFloat($"pointLights[{i}].constant", 1.0f);
                _stoneShader.SetFloat($"pointLights[{i}].linear", 0.09f);
                _stoneShader.SetFloat($"pointLights[{i}].quadratic", 0.032f);

                _woodShader.SetVector3($"pointLights[{i}].position", _pointLightPositions[i]);
                _woodShader.SetVector3($"pointLights[{i}].ambient", new Vector3(0.05f, 0.05f, 0.05f));
                _woodShader.SetVector3($"pointLights[{i}].diffuse", new Vector3(0.8f, 0.8f, 0.8f));
                _woodShader.SetVector3($"pointLights[{i}].specular", new Vector3(1.0f, 1.0f, 1.0f));
                _woodShader.SetFloat($"pointLights[{i}].constant", 1.0f);
                _woodShader.SetFloat($"pointLights[{i}].linear", 0.09f);
                _woodShader.SetFloat($"pointLights[{i}].quadratic", 0.032f);

                _leavesShader.SetVector3($"pointLights[{i}].position", _pointLightPositions[i]);
                _leavesShader.SetVector3($"pointLights[{i}].ambient", new Vector3(0.05f, 0.05f, 0.05f));
                _leavesShader.SetVector3($"pointLights[{i}].diffuse", new Vector3(0.8f, 0.8f, 0.8f));
                _leavesShader.SetVector3($"pointLights[{i}].specular", new Vector3(1.0f, 1.0f, 1.0f));
                _leavesShader.SetFloat($"pointLights[{i}].constant", 1.0f);
                _leavesShader.SetFloat($"pointLights[{i}].linear", 0.09f);
                _leavesShader.SetFloat($"pointLights[{i}].quadratic", 0.032f);

                _lightingShader.SetVector3($"pointLights[{i}].position", _pointLightPositions[i]);
                _lightingShader.SetVector3($"pointLights[{i}].ambient", new Vector3(0.05f, 0.05f, 0.05f));
                _lightingShader.SetVector3($"pointLights[{i}].diffuse", new Vector3(0.8f, 0.8f, 0.8f));
                _lightingShader.SetVector3($"pointLights[{i}].specular", new Vector3(1.0f, 1.0f, 1.0f));
                _lightingShader.SetFloat($"pointLights[{i}].constant", 1.0f);
                _lightingShader.SetFloat($"pointLights[{i}].linear", 0.09f);
                _lightingShader.SetFloat($"pointLights[{i}].quadratic", 0.032f);
            }

            //spot light
            _groundShader.SetVector3("spotLight.ambient", new Vector3(0.0f, 0.0f, 0.0f));
            _groundShader.SetVector3("spotLight.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _groundShader.SetVector3("spotLight.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _groundShader.SetFloat("spotLight.constant", 1.0f);
            _groundShader.SetFloat("spotLight.linear", 0.09f);
            _groundShader.SetFloat("spotLight.quadratic", 0.032f);
            _groundShader.SetFloat("spotLight.cutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));
            _groundShader.SetFloat("spotLight.outerCutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));

            _stoneShader.SetVector3("spotLight.ambient", new Vector3(0.0f, 0.0f, 0.0f));
            _stoneShader.SetVector3("spotLight.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _stoneShader.SetVector3("spotLight.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _stoneShader.SetFloat("spotLight.constant", 1.0f);
            _stoneShader.SetFloat("spotLight.linear", 0.09f);
            _stoneShader.SetFloat("spotLight.quadratic", 0.032f);
            _stoneShader.SetFloat("spotLight.cutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));
            _stoneShader.SetFloat("spotLight.outerCutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));

            _woodShader.SetVector3("spotLight.ambient", new Vector3(0.0f, 0.0f, 0.0f));
            _woodShader.SetVector3("spotLight.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _woodShader.SetVector3("spotLight.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _woodShader.SetFloat("spotLight.constant", 1.0f);
            _woodShader.SetFloat("spotLight.linear", 0.09f);
            _woodShader.SetFloat("spotLight.quadratic", 0.032f);
            _woodShader.SetFloat("spotLight.cutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));
            _woodShader.SetFloat("spotLight.outerCutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));

            _leavesShader.SetVector3("spotLight.ambient", new Vector3(0.0f, 0.0f, 0.0f));
            _leavesShader.SetVector3("spotLight.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _leavesShader.SetVector3("spotLight.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _leavesShader.SetFloat("spotLight.constant", 1.0f);
            _leavesShader.SetFloat("spotLight.linear", 0.09f);
            _leavesShader.SetFloat("spotLight.quadratic", 0.032f);
            _leavesShader.SetFloat("spotLight.cutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));
            _leavesShader.SetFloat("spotLight.outerCutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));

            _lightingShader.SetVector3("spotLight.ambient", new Vector3(0.0f, 0.0f, 0.0f));
            _lightingShader.SetVector3("spotLight.diffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("spotLight.specular", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetFloat("spotLight.constant", 1.0f);
            _lightingShader.SetFloat("spotLight.linear", 0.09f);
            _lightingShader.SetFloat("spotLight.quadratic", 0.032f);
            _lightingShader.SetFloat("spotLight.cutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));
            _lightingShader.SetFloat("spotLight.outerCutOff", MathF.Cos(MathHelper.DegreesToRadians(12.5f)));

            for (int i = 0; i < _cubePositions.Length; i++)
            {
                Matrix4 model = Matrix4.CreateScale(1f); //besar kecil ukuran kotak
                model = model * Matrix4.CreateTranslation(_cubePositions[i]);
                float angle = 1.0f * i;
                _lightingShader.SetMatrix4("model", model);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }

            for (int i = 0; i < _groundPositions.Length; i++)
            {
                Matrix4 model = Matrix4.CreateScale(1f); //besar kecil ukuran kotak
                model = model * Matrix4.CreateTranslation(_groundPositions[i]);
                float angle = 1.0f * i;
                _groundShader.SetMatrix4("model", model);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }

            for (int i = 0; i < _stonePositions.Length; i++)
            {
                Matrix4 model = Matrix4.CreateScale(1f); //besar kecil ukuran kotak
                model = model * Matrix4.CreateTranslation(_stonePositions[i]);
                float angle = 1.0f * i;
                _stoneShader.SetMatrix4("model", model);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }

            for (int i = 0; i < _woodPositions.Length; i++)
            {
                Matrix4 model = Matrix4.CreateScale(1f); //besar kecil ukuran kotak
                model = model * Matrix4.CreateTranslation(_woodPositions[i]);
                float angle = 1.0f * i;
                _woodShader.SetMatrix4("model", model);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }

            for (int i = 0; i < _leavesPositions.Length; i++)
            {
                Matrix4 model = Matrix4.CreateScale(1f); //besar kecil ukuran kotak
                model = model * Matrix4.CreateTranslation(_leavesPositions[i]);
                float angle = 1.0f * i;
                _leavesShader.SetMatrix4("model", model);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }

            GL.BindVertexArray(_vaoLamp);

            _lampShader.Use();

            _lampShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            for (int i = 0; i < _pointLightPositions.Length; i++)
            {
                Matrix4 lampMatrix = Matrix4.CreateScale(0.2f);
                lampMatrix = lampMatrix * Matrix4.CreateTranslation(_pointLightPositions[i]);

                _lampShader.SetMatrix4("model", lampMatrix);

                GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (!IsFocused)
            {
                return;
            }

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;

            if (input.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)e.Time; // Forward
            }
            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Keys.Up))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.Down))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            var mouse = MouseState;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            _camera.Fov -= e.OffsetY;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }
    }
}
