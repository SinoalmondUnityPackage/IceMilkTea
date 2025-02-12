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
    /// ゲームサービスの更新タイミングを表す列挙型です
    /// </summary>
    public enum GameServiceUpdateTiming
    {
        /// <summary>
        /// メインループ最初のタイミング。
        /// ただし、Time.frameCountや入力情報の更新直後となります。
        /// </summary>
        MainLoopHead,

        /// <summary>
        /// メインループの最後のタイミング。
        /// 実際は EndOfFrame のタイミングですが EndOfFrame の処理が終わった後にスケジューリングされます。
        /// </summary>
        MainLoopTail,

        /// <summary>
        /// MonoBehaviour.FixedUpdate直前のタイミング
        /// </summary>
        PreFixedUpdate,

        /// <summary>
        /// MonoBehaviour.FixedUpdate直後のタイミング
        /// </summary>
        PostFixedUpdate,

        /// <summary>
        /// 物理シミュレーション直後のタイミング。
        /// ただし、シミュレーションによる物理イベントキューが全て処理された直後となります。
        /// </summary>
        PostPhysicsSimulation,

        /// <summary>
        /// WaitForFixedUpdate直後のタイミング。
        /// </summary>
        PostWaitForFixedUpdate,

        /// <summary>
        /// UnitySynchronizationContextにPostされた関数キューが処理される直前のタイミング
        /// </summary>
        PreProcessSynchronizationContext,

        /// <summary>
        /// UnitySynchronizationContextにPostされた関数キューが処理された直後のタイミング
        /// </summary>
        PostProcessSynchronizationContext,

        /// <summary>
        /// MonoBehaviour.Update直前のタイミング
        /// </summary>
        PreUpdate,

        /// <summary>
        /// MonoBehaviour.Update直後のタイミング
        /// </summary>
        PostUpdate,

        /// <summary>
        /// UnityのAnimator(UpdateMode=Normal)によるポージング処理される直前のタイミング
        /// </summary>
        PreAnimation,

        /// <summary>
        /// UnityのAnimator(UpdateMode=Normal)によるポージング処理された直後のタイミング
        /// </summary>
        PostAnimation,

        /// <summary>
        /// MonoBehaviour.LateUpdate直前のタイミング
        /// </summary>
        PreLateUpdate,

        /// <summary>
        /// MonoBehaviour.LateUpdate直後のタイミング
        /// </summary>
        PostLateUpdate,

        /// <summary>
        /// メインスレッドにおける描画デバイスのPresentする直前のタイミング
        /// </summary>
        PreDrawPresent,

        /// <summary>
        /// メインスレッドにおける描画デバイスのPresentされた直後のタイミング
        /// </summary>
        PostDrawPresent,

        /// <summary>
        /// Unityプレイヤーのフォーカスが得られたときのタイミング。
        /// OnApplicationFocus(true)。
        /// </summary>
        OnApplicationFocusIn,

        /// <summary>
        /// Unityプレイヤーのフォーカスが失われたときのタイミング。
        /// OnApplicationFocus(false)。
        /// </summary>
        OnApplicationFocusOut,

        /// <summary>
        /// Unityプレイヤーのメインループが一時停止したときのタイミング。
        /// OnApplicationPause(true)。
        /// </summary>
        OnApplicationSuspend,

        /// <summary>
        /// Unityプレイヤーのメインループが再開したときのタイミング。
        /// OnApplicationPause(false)。
        /// </summary>
        OnApplicationResume,

        /// <summary>
        /// あらゆるカメラのカリングが行われる直前のタイミング。
        /// ただし、カメラが存在する数分１フレームで複数回呼び出される可能性があります。
        /// さらに、スレッドはメインスレッド上におけるタイミングとなります。
        /// </summary>
        CameraPreCulling,

        /// <summary>
        /// あらゆるカメラのレンダリングが行われる直前のタイミング。
        /// ただし、カメラが存在する数分１フレームで複数回呼び出される可能性があります。
        /// さらに、スレッドはメインスレッド上におけるタイミングとなります。
        /// </summary>
        CameraPreRendering,

        /// <summary>
        /// あらゆるカメラのレンダリングが行われた直後のタイミング。
        /// ただし、カメラが存在する数分１フレームで複数回呼び出される可能性があります。
        /// さらに、スレッドはメインスレッド上におけるタイミングとなります。
        /// </summary>
        CameraPostRendering,

        /// <summary>
        /// UnityプレイヤーのWaitForEndOfFrameの継続するタイミング。
        /// {yield return endOfFrame; OnEndOfFrame;}
        /// </summary>
        OnEndOfFrame,
    }
}