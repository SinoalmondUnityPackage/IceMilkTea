// Zlib License
//
// Copyright (c) 2024 Sinoa
//
// This software is provided ‘as-is’, without any express or implied
// warranty. In no event will the authors be held liable for any damages
// arising from the use of this software.
//
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
// claim that you wrote the original software. If you use this software
// in a product, an acknowledgment in the product documentation would be
// appreciated but is not required.
//
// 2. Altered source versions must be plainly marked as such, and must not be
// misrepresented as being the original software.
//
// 3. This notice may not be removed or altered from any source
// distribution.

using Foxtamp.IceMilkTea.Services;

namespace Foxtamp.IceMilkTea
{
    /// <summary>
    /// ゲームメインクラスの実装をするための抽象クラスです。
    /// IceMilkTea によるゲームのスタートアップからメインループを構築する場合は必ず継承し実装をして下さい。
    /// </summary>
    public abstract class GameMain
    {
        /// <summary>
        /// ゲームメインの現在のインスタンスを取得します
        /// </summary>
        public static GameMain Current { get; }

        /// <summary>
        /// ゲームメインのサービスプロバイダを取得します
        /// </summary>
        public IGameServiceProvider ServiceProvider { get; }

        /// <summary>
        /// ゲームメインを起動します
        /// </summary>
        protected void Run()
        {
        }
    }
}