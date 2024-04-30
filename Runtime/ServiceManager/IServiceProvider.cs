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

namespace Foxtamp.IceMilkTea.ServiceManager
{
    /// <summary>
    /// サービスのインスタンスを取得する機能を提供するインターフェイスです
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// 指定されたサービスのインスタンスを取得します
        /// </summary>
        /// <typeparam name="TService">取得するサービスの型</typeparam>
        /// <returns>指定された型のサービスのインスタンスを返します</returns>
        /// <exception cref="ServiceNotFoundException">サービス'TService'を見つかりませんでした。</exception>
        TService GetService<TService>()
            where TService : class;

        /// <summary>
        /// 指定されたサービスのインスタンスを取得します
        /// </summary>
        /// <typeparam name="TService">取得するサービスの型</typeparam>
        /// <param name="service">サービスを取得できた場合はインスタンスの参照を、取得できなかった場合は null が設定されます</param>
        /// <returns>サービスの取得に成功した場合は true を、失敗した場合は false を返します</returns>
        bool TryGetService<TService>(out TService service)
            where TService : class;

        /// <summary>
        /// 指定されたサービスが存在するか確認します
        /// </summary>
        /// <typeparam name="TService">確認するサービスの型</typeparam>
        /// <returns>サービスが存在している場合は true を、存在しない場合は false を返します</returns>
        bool Exists<TService>()
            where TService : class;
    }
}