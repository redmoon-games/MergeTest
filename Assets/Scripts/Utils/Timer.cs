using System;
using Random = UnityEngine.Random;

namespace Utils
{
    public class Timer
    {
        public bool AutoReset = false;
        public Action onTimerFinished = () => {};
        public bool IsTimerFinished { get; private set; }
        public float TimerFillAmount => 1f - _timer / _timerInitValue;
        
        private float _timerInitValue = -1f;
        private FloatRange _timerInitRange = null;
        private float _timer;
        private bool _useRange = false;
        private float _previousFillAmount = 0f;

        public bool IsReady()
        {
            if (_useRange)
            {
                return _timerInitRange != null;
            }
            else
            {
                return _timerInitValue > float.Epsilon;
            }
        }
        
        public void Init(float initTime)
        {
            _timerInitValue = initTime;
            _useRange = false;
            Reset();
            IsTimerFinished = false;
        }
        
        public void Init(FloatRange initTimeRange)
        {
            _timerInitRange = initTimeRange;
            _useRange = true;
            ResetRange();
            IsTimerFinished = false;
        }

        public void DeInit()
        {
            _timerInitValue = -1f;
            onTimerFinished = () => {};
            _timerInitRange = null;
        }

        public void Reset(float newInitTime = -1f)
        {
            if (newInitTime > float.Epsilon)
            {
                Init(newInitTime);
            }
            else
            {
                _timer = _timerInitValue;
                IsTimerFinished = false;
            }
        }
        
        public void ResetRange()
        {
            if (_timerInitRange != null)
            {
                _timerInitValue = Random.Range(_timerInitRange.min, _timerInitRange.max);
                _timer = _timerInitValue;
            }

            IsTimerFinished = false;
        }
        
        public void ResetRange(FloatRange newRange)
        {
            Init(newRange);
        }

        public void SetFinished()
        {
            _timer = -1f;
        }

        public void Update(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer <= 0 && !IsTimerFinished)
            {
                IsTimerFinished = true;
                _timer = 0;
                onTimerFinished.Invoke();
                if (AutoReset)
                {
                    if (_useRange)
                    {
                        ResetRange();
                    }
                    else
                    {
                        Reset();
                    }
                }
            }
        }
        
        public float TimerFillAmountDelta()
        {
            var amount = TimerFillAmount;
            var res = amount - _previousFillAmount;
            _previousFillAmount = amount;
            return  res;
        }
    }
}
