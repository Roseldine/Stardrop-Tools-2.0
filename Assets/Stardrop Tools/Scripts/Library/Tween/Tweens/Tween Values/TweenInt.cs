﻿
using UnityEngine;

namespace StardropTools.Tween
{
    public class TweenInt : Tween
    {
        public int start;
        public int end;
        public int lerped;

        protected override void SetEssentials()
        {
            tweenType = TweenType.Int;
        }

        public TweenInt()
        {
            SetEssentials();
        }

        public TweenInt SetStart(int start)
        {
            this.start = start;
            return this;
        }

        public TweenInt SetEnd(int end)
        {
            this.end = end;
            return this;
        }

        public TweenInt SetStartEnd(int start, int end)
        {
            this.start = start;
            this.end = end;
            return this;
        }

        protected override void TweenUpdate(float percent)
        {
            lerped = (int)Mathf.LerpUnclamped(start, end, Ease(percent));
        }

        protected override void Loop()
        {
            ResetRuntime();
            ChangeState(TweenState.running);
        }

        protected override void PingPong()
        {
            int temp = start;
            start = end;
            end = temp;

            ResetRuntime();
            ChangeState(TweenState.running);
        }
    }
}