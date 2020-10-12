﻿// zlib/libpng License
//
// Copyright (c) 2018 Sinoa
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

using UnityEditor;
using UnityEngine;

namespace IceMilkTeaEditor.LayoutSystem
{
    /// <summary>
    /// UIをスクロール可能にレイアウトするUIレイアウトクラスです
    /// </summary>
    public class ImtEditorScrollView : ImtEditorUiRoot
    {
        // メンバ変数定義
        private Vector2 scrollPosition;



        /// <summary>
        /// ImtEditorScrollView クラスのインスタンスを初期化します
        /// </summary>
        /// <param name="ownerWindow">所属するオーナーウィンドウ</param>
        public ImtEditorScrollView(ImtEditorWindow ownerWindow) : base(ownerWindow)
        {
        }


        /// <summary>
        /// UIのレンダリングをします
        /// </summary>
        protected internal override void Render()
        {
            // スロールレイアウト関数で、子UI描画を挟む
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            base.Render();
            EditorGUILayout.EndScrollView();
        }
    }
}