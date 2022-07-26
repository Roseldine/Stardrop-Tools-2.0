﻿
using UnityEngine;

namespace StardropTools.Tween
{
    public class TweenVector2 : Tween
    {
        public Vector2 start;
        public Vector2 end;
        public Vector2 lerped;

        protected override void SetEssentials()
        {
            tweenType = TweenType.Vector2;
        }

        public TweenVector2()
        {
            SetEssentials();
        }

        public TweenVector2 SetStart(Vector2 start)
        {
            this.start = start;
            return this;
        }

        public TweenVector2 SetEnd(Vector2 end)
        {
            this.end = end;
            return this;
        }

        public TweenVector2 SetStartEnd(Vector2 start, Vector2 end)
        {
            this.start = start;
            this.end = end;
            return this;
        }

        protected override void TweenUpdate(float percent)
        {
            lerped = Vector2.LerpUnclamped(start, end, Ease(percent));
        }

        protected override void Loop()
        {
            ResetRuntime();
            ChangeState(TweenState.running);
        }

        protected override void PingPong()
        {
            Vector2 temp = start;
            start = end;
            end = temp;

            ResetRuntime();
            ChangeState(TweenState.running);
        }
    }
}