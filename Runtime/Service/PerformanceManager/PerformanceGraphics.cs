﻿// zlib/libpng License
//
// Copyright (c) 2020 Sinoa
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the authors be held liable for any damages arising from the use of this software.
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it freely,
// subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software.
//    If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.

using UnityEngine;

namespace IceMilkTea.Service
{
    public class PerformanceGraphics
    {
        private Material mat = new Material(Shader.Find("GUI/Text Shader"));
        private Font font;



        public PerformanceGraphics()
        {
            font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        }


        public void Render()
        {
            GL.PushMatrix();
            var sWidth = 720.0f;
            var sHeight = Screen.height * (sWidth / Screen.width);
            GL.LoadPixelMatrix(0.0f, sWidth, 0.0f, sHeight);
            GL.MultMatrix(Matrix4x4.identity);

            // バーの描画で必要な最低限の処理箇所
            {
                mat.SetPass(0);

                GL.MultMatrix(Matrix4x4.Translate(new Vector3(0.0f, sHeight - 15.0f, 0.0f)));

                GL.Begin(GL.QUADS);
                GL.Color(new Color(1.0f, 1.0f, 1.0f, 1.0f));
                GL.Vertex(new Vector3(5.0f, 0.0f, 0.0f));

                GL.Color(new Color(1.0f, 1.0f, 0.0f, 1.0f));
                GL.Vertex(new Vector3(5.0f, 10.0f, 0.0f));

                GL.Color(new Color(0.0f, 1.0f, 0.0f, 1.0f));
                GL.Vertex(new Vector3(sWidth - 5.0f, 10.0f, 0.0f));

                GL.Color(new Color(0.0f, 0.0f, 1.0f, 1.0f));
                GL.Vertex(new Vector3(sWidth - 5.0f, 0.0f, 0.0f));
                GL.End();
            }

            // テキスト描画で必要な最低限の処理箇所
            font.RequestCharactersInTexture("あいうえおかきくけこ", 20);
            font.material.SetPass(0);
            GL.MultMatrix(Matrix4x4.identity);
            GL.Begin(GL.QUADS);


            var text = new ImtOverlayText(font, 20);
            text.Render("あいうえお", 10.0f, new Vector2(100.0f, 100.0f), Color.white);
            text.Render("かきくけこ", 10.0f, new Vector2(200.0f, 200.0f), Color.red);


            GL.End();


            GL.PopMatrix();
        }
    }
}