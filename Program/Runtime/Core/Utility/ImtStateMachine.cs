﻿// zlib/libpng License
//
// Copyright (c) 2018 Sinoa
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the authors be held liable for any damages arising from the use of this software.
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it freely,
// subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software.
//    If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.

using System;
using System.Collections.Generic;

namespace IceMilkTea.Core
{
    /// <summary>
    /// コンテキストを持つことのできるステートマシンクラスです
    /// </summary>
    /// <typeparam name="ContextT">このステートマシンが持つコンテキストのクラス型</typeparam>
    public class ImtStateMachine<ContextT> where ContextT : class
    {
        /// <summary>
        /// ステートマシンが処理する状態を表現するステートクラスです。
        /// </summary>
        public abstract class State
        {
            // メンバ変数定義
            internal Dictionary<int, State> stateTable;
            internal ImtStateMachine<ContextT> stateMachine;



            /// <summary>
            /// このステートが所属するステートマシン
            /// </summary>
            protected ImtStateMachine<ContextT> StateMachine => stateMachine;


            /// <summary>
            /// このステートが所属するステートマシンが持っているコンテキスト
            /// </summary>
            protected ContextT Context => stateMachine.context;



            /// <summary>
            /// ステートに突入したときの処理を行います
            /// </summary>
            protected internal virtual void Enter()
            {
            }


            /// <summary>
            /// ステートを更新するときの処理を行います
            /// </summary>
            protected internal virtual void Update()
            {
            }


            /// <summary>
            /// ステートから脱出したときの処理を行います
            /// </summary>
            protected internal virtual void Exit()
            {
            }


            /// <summary>
            /// ステートマシンが遷移をするとき、このステートがその遷移をガードします。
            /// </summary>
            /// <param name="eventId">遷移する理由になったイベントID</param>
            /// <param name="eventArg">イベントの引数オブジェクト</param>
            /// <returns>遷移をガードする場合は true を、ガードせず遷移を許す場合は false を返します</returns>
            protected internal virtual bool GuardTransition(int eventId, object eventArg)
            {
                // 通常はガードしない
                return false;
            }
        }



        /// <summary>
        /// ステートマシンで "任意" を表現する特別なステートクラスです
        /// </summary>
        private sealed class AnyState : State { }



        // メンバ変数定義
        private ContextT context;
        private List<State> stateList;
        private State currentState;
        private State nextState;
        private State prevState;
        private int lastEventId;
        private object lastEventArg;



        /// <summary>
        /// ImtStateMachine のインスタンスを初期化します
        /// </summary>
        /// <param name="context">このステートマシンが持つコンテキスト</param>
        /// <exception cref="ArgumentNullException">context が null です</exception>
        public ImtStateMachine(ContextT context)
        {
            // 渡されたコンテキストがnullなら
            if (context == null)
            {
                // nullは許されない
                throw new ArgumentNullException(nameof(context));
            }


            // コンテキストを覚えてステートリストのインスタンスを生成する
            this.context = context;
            stateList = new List<State>();


            // この時点で任意ステートのインスタンスを作ってしまう
            GetOrCreateState<AnyState>();
        }


        #region ステートテーブル操作系
        /// <summary>
        /// ステートの任意遷移構造を追加します。
        /// </summary>
        /// <typeparam name="T">任意状態から遷移する先になるステートの型</typeparam>
        /// <param name="eventId">遷移する条件となるイベントID</param>
        public void AddAnyTransition<T>(int eventId) where T : State, new()
        {
        }


        /// <summary>
        /// ステートの遷移構造を追加します。
        /// </summary>
        /// <typeparam name="T">遷移する元になるステートの型</typeparam>
        /// <typeparam name="U">遷移する先になるステートの型</typeparam>
        /// <param name="eventId">遷移する条件となるイベントID</param>
        public void AddTransition<T, U>(int eventId) where T : State, new() where U : State, new()
        {
        }
        #endregion


        #region ステートマシン制御系
        /// <summary>
        /// ステートマシンが起動する時に、最初に開始するステートを設定します。
        /// ステートマシンが起動する前であれば何度でも再設定が可能ですが、一度起動してしまった場合は二度と再設定が出来ません。
        /// </summary>
        /// <typeparam name="T">ステートマシンが起動時に開始するステートの型</typeparam>
        public void SetStartState<T>() where T : State, new()
        {
            // 現在処理中のステートが無いのなら
            if (currentState == null)
            {
                // 次に処理するステートの設定をする
                nextState = GetOrCreateState<T>();
            }
        }


        /// <summary>
        /// ステートマシンの内部更新を行います。
        /// ステートそのものが実行されたり、ステートの遷移などもこのタイミングで行われます。
        /// </summary>
        public void Update()
        {
        }
        #endregion


        #region 共通ロジック系
        /// <summary>
        /// 指定されたステートの型のインスタンスを取得しますが、存在しない場合は生成してから取得します。
        /// 生成されたインスタンスは、次回から取得されるようになります。
        /// </summary>
        /// <typeparam name="T">取得、または生成するステートの型</typeparam>
        /// <returns>取得、または生成されたステートのインスタンスを返します</returns>
        private T GetOrCreateState<T>() where T : State, new()
        {
            // 要求ステートの型を取得
            var requestStateType = typeof(T);


            // ステートの数分回る
            foreach (var state in stateList)
            {
                // もし該当のステートの型と一致するインスタンスなら
                if (state.GetType() == requestStateType)
                {
                    // そのインスタンスを返す
                    return (T)state;
                }
            }


            // ループから抜けたのなら、型一致するインスタンスが無いという事なのでインスタンスを生成してキャッシュする
            var newState = new T();
            stateList.Add(newState);


            // 新しいステートに、自身の参照とステートテーブルのインスタンスの初期化も行って返す
            newState.stateMachine = this;
            newState.stateTable = new Dictionary<int, State>();
            return newState;
        }
        #endregion
    }
}