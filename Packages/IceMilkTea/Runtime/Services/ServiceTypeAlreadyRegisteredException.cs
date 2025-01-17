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
    /// サービスの型が既に登録されている場合にスローされる例外です
    /// </summary>
    public class ServiceTypeAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// 既に登録されているサービスのキー型を取得します
        /// </summary>
        public Type KeyType { get; }

        /// <summary>
        /// 既に登録されているサービスの型を取得します
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// ServiceTypeAlreadyRegisteredException のインスタンスを初期化します
        /// </summary>
        /// <param name="keyType">登録済みサービスのキー型</param>
        /// <param name="serviceType">登録済みサービスの型</param>
        public ServiceTypeAlreadyRegisteredException(Type keyType, Type serviceType) : base($"Service of type '{serviceType.FullName}' already registered with key type '{keyType.FullName}'.")
        {
            KeyType = keyType;
            ServiceType = serviceType;
        }
    }
}