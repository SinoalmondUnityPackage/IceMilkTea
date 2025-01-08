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

namespace Foxtamp.IceMilkTea.ServiceManager
{
    /// <summary>
    /// ServiceManager にサービスを登録する機能を提供するインターフェイスです
    /// </summary>
    public interface IServiceRegister
    {
        /// <summary>
        /// IServiceRegister が指定されたサービスの型を保持しているかどうかを確認します
        /// </summary>
        /// <typeparam name="TService">確認するサービスの型</typeparam>
        /// <returns>保持済みの場合は true を、保持していない場合は false を返します。</returns>
        bool HasService<TService>()
            where TService : class;

        /// <summary>
        /// 提供するサービスの型を登録します
        /// </summary>
        /// <typeparam name="TService">登録するサービスの型</typeparam>
        /// <returns>現在の IServiceRegister の参照を返します</returns>
        /// <exception cref="ServiceRegisteredAlreadyException">型'TService'は、既に登録済みです。</exception>
        IServiceRegister Register<TService>()
            where TService : class;

        /// <summary>
        /// 提供するサービスのインスタンスを登録します
        /// </summary>
        /// <typeparam name="TService">登録するサービスの型</typeparam>
        /// <param name="service">登録するサービスのインスタンス</param>
        /// <returns>現在の IServiceRegister の参照を返します</returns>
        /// <exception cref="ServiceRegisteredAlreadyException">型'TService'は、既に登録済みです。</exception>
        /// <exception cref="ArgumentNullException">service が null です。</exception>
        IServiceRegister Register<TService>(TService service)
            where TService : class;

        /// <summary>
        /// 提供するサービスのサービスファクトリを登録します
        /// </summary>
        /// <typeparam name="TService">登録するサービスの型</typeparam>
        /// <param name="serviceFactory">登録するサービスのファクトリ</param>
        /// <returns>現在の IServiceRegister の参照を返します</returns>
        /// <exception cref="ServiceRegisteredAlreadyException">型'TService'は、既に登録済みです。</exception>
        /// <exception cref="ArgumentNullException">serviceFactory が null です。</exception>
        IServiceRegister Register<TService>(Func<IServiceProvider, TService> serviceFactory)
            where TService : class;

        /// <summary>
        /// キーとなる型を指定して、提供するサービスの型を登録します
        /// </summary>
        /// <typeparam name="TKey">登録するサービスのキーとなる型</typeparam>
        /// <typeparam name="TService">登録するサービスの型</typeparam>
        /// <returns>現在の IServiceRegister の参照を返します</returns>
        /// <exception cref="ServiceRegisteredAlreadyException">型'TKey'は、既に登録済みです。</exception>
        IServiceRegister Register<TKey, TService>()
            where TKey : class
            where TService : class, TKey;

        /// <summary>
        /// キーとなる型を指定して、提供するサービスのインスタンスを登録します
        /// </summary>
        /// <typeparam name="TKey">登録するサービスのキーとなる型</typeparam>
        /// <typeparam name="TService">登録するサービスの型</typeparam>
        /// <param name="service">登録するサービスのインスタンス</param>
        /// <returns>現在の IServiceRegister の参照を返します</returns>
        /// <exception cref="ServiceRegisteredAlreadyException">型'TKey'は、既に登録済みです。</exception>
        /// <exception cref="ArgumentNullException">service が null です。</exception>
        IServiceRegister Register<TKey, TService>(TService service)
            where TKey : class
            where TService : class, TKey;

        /// <summary>
        /// キーとなる型を指定して、提供するサービスのファクトリを登録します
        /// </summary>
        /// <typeparam name="TKey">登録するサービスのキーとなる型</typeparam>
        /// <typeparam name="TService">登録するサービスの型</typeparam>
        /// <param name="serviceFactory">登録するサービスのファクトリ</param>
        /// <returns>現在の IServiceRegister の参照を返します</returns>
        /// <exception cref="ServiceRegisteredAlreadyException">型'TKey'は、既に登録済みです。</exception>
        /// <exception cref="ArgumentNullException">serviceFactory が null です。</exception>
        IServiceRegister Register<TKey, TService>(Func<IServiceProvider, TService> serviceFactory)
            where TKey : class
            where TService : class, TKey;
    }
}