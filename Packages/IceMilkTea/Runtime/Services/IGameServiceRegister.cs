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

using System;

namespace Foxtamp.IceMilkTea.Services
{
    /// <summary>
    /// サービスを登録する機能を提供するインターフェイスです
    /// </summary>
    public interface IGameServiceRegister
    {
        /// <summary>
        /// 提供するサービスのインスタンスを登録します
        /// </summary>
        /// <typeparam name="TKey">登録するサービスのキー型</typeparam>
        /// <param name="service">登録するサービスのインスタンス</param>
        /// <returns>現在の IGameServiceRegister の参照を返します</returns>
        /// <exception cref="ArgumentNullException">service が null です。</exception>
        IGameServiceRegister Register<TKey>(IGameService service) where TKey : class, IGameService;

        /// <summary>
        /// 提供するサービスのインスタンスをファクトリーを用いて登録します
        /// </summary>
        /// <typeparam name="TKey">登録するサービスのキー型</typeparam>
        /// <param name="serviceFactory">登録するサービスのファクトリ</param>
        /// <returns>現在の IGameServiceRegister の参照を返します</returns>
        /// <exception cref="ArgumentNullException">serviceFactory が null です</exception>
        /// <exception cref="ArgumentException">serviceFactory がサービスのインスタンスを生成しませんでした</exception>
        IGameServiceRegister Register<TKey>(Func<IServiceProvider, IGameService> serviceFactory) where TKey : class, IGameService;
    }
}