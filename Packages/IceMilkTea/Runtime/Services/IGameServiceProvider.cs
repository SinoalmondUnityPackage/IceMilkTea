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

#nullable enable

using System;

namespace Foxtamp.IceMilkTea.Services
{
    /// <summary>
    /// ゲームサービスプロバイダのインターフェイスです
    /// </summary>
    public interface IGameServiceProvider
    {
        /// <summary>
        /// 指定された型のサービスを取得します
        /// </summary>
        /// <typeparam name="T">取得するサービスの型</typeparam>
        /// <returns>サービスを取得できた場合は参照を返します</returns>
        /// <exception cref="ObjectDisposedException">このサービスマネージャが破棄されたか不正な状態です</exception>
        /// <exception cref="GameServiceNotFoundException">サービスの型 'T' が見つかりませんでした</exception>
        T GetRequiredService<T>() where T : class, IGameService;

        /// <summary>
        /// 指定された型のサービスを取得します
        /// </summary>
        /// <typeparam name="T">取得するサービスの型</typeparam>
        /// <returns>サービスを取得できた場合は参照を返しますが、取得できなかった場合は null を返します</returns>
        /// <exception cref="ObjectDisposedException">このサービスマネージャが破棄されたか不正な状態です</exception>
        T? GetService<T>() where T : class, IGameService;
    }
}