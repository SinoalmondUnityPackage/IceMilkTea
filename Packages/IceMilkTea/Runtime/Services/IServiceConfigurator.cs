// zlib License
// 
// Copyright (c) 2025 Sinoa
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

using System;

namespace Foxtamp.IceMilkTea.Services
{
    /// <summary>
    /// ゲームサービスの設定を行うためのインターフェイスです
    /// </summary>
    public interface IServiceConfigurator
    {
        /// <summary>
        /// ゲームサービスの更新関数を設定します
        /// </summary>
        /// <param name="updateTiming">サービスの更新タイミング</param>
        /// <param name="updateFunction">設定するサービスの更新関数</param>
        void SetUpdateFunction(GameServiceUpdateTiming updateTiming, Action updateFunction);
    }
}