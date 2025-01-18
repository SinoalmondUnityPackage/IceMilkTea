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

namespace Foxtamp.IceMilkTea.Services
{
    /// <summary>
    /// ゲームサービスの基底クラスです
    /// </summary>
    /// <remarks>
    /// ゲームサービスを実装するとき必ずこのクラスを継承する必要はありませんが、起動と終了のどちらかの実装が不要な場合にこのクラスを継承することを推奨します。
    /// </remarks>
    public abstract class GameService : IGameService
    {
        void IGameService.Startup(IServiceConfigurator configurator)
        {
            Startup(configurator);
        }

        /// <summary>
        /// ゲームサービスの起動処理を行います
        /// </summary>
        /// <param name="configurator">ゲームサービスの動作を設定するコンフィギュレーター</param>
        protected virtual void Startup(IServiceConfigurator configurator)
        {
        }

        void IGameService.Shutdown()
        {
            Shutdown();
        }

        /// <summary>
        /// ゲームサービスの終了処理を行います
        /// </summary>
        protected virtual void Shutdown()
        {
        }
    }
}