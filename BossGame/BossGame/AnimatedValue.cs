using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BossGame
{
    enum AnimationType
    {
        Direct,
        Smooth
    }

    class AnimatedValue
    {
        /// <summary>
        /// Type of animation
        /// </summary>
        AnimationType animationType = AnimationType.Direct;

        /// <summary>
        /// Value at the start of the animation
        /// </summary>
        float startValue = 0f;

        /// <summary>
        /// Value at the end of the animation
        /// </summary>
        float endValue = 0f;

        /// <summary>
        /// Timestamp of the start of the animation, in seconds
        /// </summary>
        float startTime = 0f;

        /// <summary>
        /// Length of animation, in seconds
        /// </summary>
        float animationTime = 0f;

        /// <summary>
        /// Time passed since start of animation, in seconds
        /// </summary>
        float timeElapsed
        {
            get
            {
                return TimeManager.CurrentTime - startTime;
            }
        }

        /// <summary>
        /// Progress of animation(0->1)
        /// </summary>
        float progress
        {
            get
            {
                return (timeElapsed / animationTime);
            }
        }

        /// <summary>
        /// Difference between starting value and ending value
        /// </summary>
        float valueChange
        {
            get
            {
                return endValue - startValue;
            }
        }

        /// <summary>
        /// Timestamp of the end of the animation, in seconds
        /// </summary>
        float endTime
        {
            get
            {
                return startTime + animationTime;
            }
        }

        /// <summary>
        /// If animation is in progress
        /// </summary>
        public bool IsAnimating
        {
            get
            {
                if (TimeManager.CurrentTime > endTime || TimeManager.CurrentTime < startTime)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// If animation has started
        /// </summary>
        public bool StartedAnimation
        {
            get
            {
                if (TimeManager.CurrentTime < startTime)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// If animation has finished
        /// </summary>
        public bool FinishedAnimation
        {
            get
            {
                if (TimeManager.CurrentTime > endTime)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Get: Current value in animation
        /// Set: Set the ending value of animation
        /// </summary>
        public float Value
        {
            get
            {
                if (FinishedAnimation == true)
                    return endValue;
                else if (StartedAnimation == false)
                    return startValue;

                switch (animationType)
                {
                    default:
                    case AnimationType.Direct:
                        if (startValue > endValue)
                            return MathHelper.Clamp(startValue + valueChange * progress, endValue, startValue);
                        return MathHelper.Clamp(startValue + valueChange * progress, startValue, endValue);

                    case AnimationType.Smooth:
                        return startValue + valueChange * ((float)Math.Sin(((1.0 - progress) * Math.PI) + Math.PI / 2) / 2 + 0.5f);
                }

            }
            set
            {
                startValue = Value;
                endValue = value;
                startTime = TimeManager.CurrentTime;
            }
        }

        public AnimatedValue(float animationTime, float startValue)
        {
            this.startValue = startValue;
            this.animationTime = animationTime;
            endValue = startValue;
            startTime = TimeManager.CurrentTime;
        }

        public AnimatedValue(float animationTime, float startValue, AnimationType animationType)
            : this(animationTime, startValue)
        {
            this.animationType = animationType;
        }
    }
}
