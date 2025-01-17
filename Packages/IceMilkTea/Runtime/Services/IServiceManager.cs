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
    /// サービスマネージャのインターフェイスです
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// 指定された型のサービスを取得します
        /// </summary>
        /// <typeparam name="T">取得するサービスの型</typeparam>
        /// <returns>取得できたサービスのインスタンスを返します</returns>
        /// <exception cref="InvalidOperationException">このサービスマネージャが破棄されたか不正な状態です</exception>
        /// <exception cref="ServiceNotFoundException">サービスの型 'T' が見つかりませんでした</exception>
        T GetService<T>()
            where T : class;

        /// <summary>
        /// 指定された型のサービスを取得します
        /// </summary>
        /// <param name="serviceType">取得するサービスの型</param>
        /// <returns>取得できたサービスのインスタンスを返します</returns>
        /// <exception cref="InvalidOperationException">このサービスマネージャが破棄されたか不正な状態です</exception>
        /// <exception cref="ServiceNotFoundException">サービスの型 'serviceType' が見つかりませんでした</exception>
        object GetService(Type serviceType);

        /// <summary>
        /// 指定された型のサービスの取得を試みます
        /// </summary>
        /// <param name="service">取得できた場合に受け取る引数</param>
        /// <typeparam name="T">取得するサービスの型</typeparam>
        /// <returns>サービスの取得に成功した場合は true を、失敗した場合は false を返します</returns>
        /// <exception cref="InvalidOperationException">このサービスマネージャが破棄されたか不正な状態です</exception>
        bool TryGetService<T>(out T service)
            where T : class;

        /// <summary>
        /// 指定された型のサービスの取得を試みます
        /// </summary>
        /// <param name="serviceType">取得するサービスの型</param>
        /// <param name="service">取得できた場合に受け取る引数</param>
        /// <returns>サービスの取得に成功した場合は true を、失敗した場合は false を返します</returns>
        /// <exception cref="InvalidOperationException">このサービスマネージャが破棄されたか不正な状態です</exception>
        bool TryGetService(Type serviceType, out object service);
    }
}