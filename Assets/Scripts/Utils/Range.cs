using System;

namespace Utils
{
    [Serializable]
    public class FloatRange : Range<float>
    {
        public FloatRange(float min, float max) : base(min, max)
        {
        }
        
        public override bool Contains(float value)
        {
            return value >= min && value < max;
        }
    }
    
    [Serializable]
    public class IntRange : Range<int>
    {
        public IntRange(int min, int max) : base(min, max)
        {
        }
        
        public override bool Contains(int value)
        {
            return value >= min && value < max;
        }
    }
    
    public abstract class Range<T>
    {
        public T min;
        public T max;

        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }
        public abstract bool Contains(T value);
    }
}