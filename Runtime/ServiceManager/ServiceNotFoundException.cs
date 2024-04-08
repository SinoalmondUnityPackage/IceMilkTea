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
    /// サービスを見つけられなかった場合の例外です
    /// </summary>
    public class ServiceNotFoundException : Exception
    {
        private string? _message;

        /// <summary>
        /// 見つけられなかったサービスの型
        /// </summary>
        public Type? ServiceType { get; }

        /// <summary>
        /// 例外メッセージ
        /// </summary>
        public override string Message
        {
            get
            {
                if (_message == null)
                {
                    SetMessage();
                }

                return _message!;
            }
        }

        public ServiceNotFoundException()
        {
            _message = null;
            ServiceType = null;
        }

        public ServiceNotFoundException(string? message) : base(message)
        {
            _message = message;
            ServiceType = null;
        }

        public ServiceNotFoundException(string? message, Exception innerException) : base(message, innerException)
        {
            _message = message;
            ServiceType = null;
        }

        public ServiceNotFoundException(Type serviceType)
        {
            _message = null;
            ServiceType = serviceType;
        }

        public ServiceNotFoundException(string? message, Type serviceType) : base(message)
        {
            _message = message;
            ServiceType = serviceType;
        }

        public ServiceNotFoundException(string? message, Type serviceType, Exception innerException) : base(message, innerException)
        {
            _message = message;
            ServiceType = serviceType;
        }

        private void SetMessage()
        {
            if (ServiceType != null)
            {
                _message = $"サービス'{ServiceType.FullName}'が見つかりませんでした。";
                return;
            }

            _message = "サービスが見つかりませんでした。";
        }
    }
}