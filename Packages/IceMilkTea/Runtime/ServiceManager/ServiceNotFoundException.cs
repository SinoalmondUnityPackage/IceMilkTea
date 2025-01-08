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
    /// サービスを見つけられなかった場合の例外です
    /// </summary>
    public class ServiceNotFoundException : Exception
    {
        /// <summary>
        /// 見つけられなかったサービスの型
        /// </summary>
        public Type ServiceType { get; }


        /// <summary>
        /// ServiceNotFoundException のインスタンスを初期化します
        /// </summary>
        public ServiceNotFoundException()
        {
        }

        /// <summary>
        /// ServiceNotFoundException のインスタンスを初期化します
        /// </summary>
        /// <param name="message">例外として表示するメッセージ</param>
        public ServiceNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// ServiceNotFoundException のインスタンスを初期化します
        /// </summary>
        /// <param name="message">例外として表示するメッセージ</param>
        /// <param name="innerException">この例外の原因となった例外</param>
        public ServiceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// ServiceNotFoundException のインスタンスを初期化します
        /// </summary>
        /// <param name="message">例外として表示するメッセージ</param>
        /// <param name="serviceType">見つけられなかったサービスの型</param>
        public ServiceNotFoundException(string message, Type serviceType) : base(message)
        {
            ServiceType = serviceType;
        }

        /// <summary>
        /// ServiceNotFoundException のインスタンスを初期化します
        /// </summary>
        /// <param name="message">例外として表示するメッセージ</param>
        /// <param name="serviceType">見つけられなかったサービスの型</param>
        /// <param name="innerException">この例外の原因となった例外</param>
        public ServiceNotFoundException(string message, Type serviceType, Exception innerException) : base(message, innerException)
        {
            ServiceType = serviceType;
        }
    }
}