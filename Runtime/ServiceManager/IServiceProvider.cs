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

#nullable enable

using System;

namespace Foxtamp.IceMilkTea.ServiceManager
{
    /// <summary>
    /// サービスのインスタンスを取得する機能を提供します
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// 指定された型とサービスキーからサービスのインスタンスを取得します
        /// </summary>
        /// <typeparam name="TService">取得するサービスの型</typeparam>
        /// <param name="serviceKey">取得するサービスのキー。型のみの場合は null を指定出来ます。</param>
        /// <returns>指定された型のサービスを返します</returns>
        /// <exception cref="ServiceNotFoundException">サービスを見つけられませんでした。</exception>
        TService GetService<TService>(long? serviceKey = null);

        /// <summary>
        /// 指定された型とサービスキーからサービスのインスタンスを取得します
        /// </summary>
        /// <param name="serviceType">取得するサービスの型</param>
        /// <param name="serviceKey">取得するサービスのキー。型のみの場合は null を指定出来ます。</param>
        /// <returns>指定された型のサービスを返します</returns>
        /// <exception cref="ServiceNotFoundException">サービスを見つけられませんでした。</exception>
        object GetService(Type serviceType, long? serviceKey = null);

        bool TryGetService<TService>(out TService? service, long? serviceKey = null);

        bool TryGetService(Type serviceType, out object? service, long? serviceKey = null);

        bool Exists<TService>(long? serviceKey = null);

        bool Exists(Type serviceType, long? serviceKey = null);
    }
}