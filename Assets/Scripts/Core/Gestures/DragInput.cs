using UnityEngine;

namespace Core.Gestures
{
    /// <summary>
    /// Simple object to contain information for a swipe input.
    /// </summary>
    public struct DragInput
    {
        /// <summary>
        /// ID of input that performed this swipe.
        /// </summary>
        public readonly int InputId;

        /// <summary>
        /// Position that the swipe began.
        /// </summary>
        public readonly Vector2 StartPosition;

        /// <summary>
        /// Last position that this swipe was at.
        /// </summary>
        public readonly Vector2 PreviousPosition;

        /// <summary>
        /// End position of the swipe.
        /// </summary>
        public readonly Vector2 EndPosition;

        /// <summary>
        /// Average normalized direction of the swipe. This is equivalent to
        /// <c>(EndPosition - StartPosition).normalized</c>.
        /// </summary>
        public readonly Vector2 DragDirection;

        /// <summary>
        /// Average velocity of the swipe in screen units per second.
        /// </summary>
        public readonly float DragVelocity;

        /// <summary>
        /// How much the swipe travelled in screen units. Will always be at least the difference between
        /// <see cref="StartPosition"/> and <see cref="EndPosition"/>, but will be longer for non-straight lines.
        /// </summary>
        public readonly float TravelDistance;

        /// <summary>
        /// Duration of the swipe in seconds.
        /// </summary>
        public readonly double DragDuration;

        /// <summary>
        /// A normalized measure of how consistent this swipe was in direction.
        /// </summary>
        public readonly float DragSameness;

        /// <summary>
        /// Construct a new swipe input from a given gesture.
        /// </summary>
        internal DragInput(ActiveGesture gesture) : this()
        {
            InputId = gesture.InputId;
            StartPosition = gesture.StartPosition;
            PreviousPosition = gesture.PreviousPosition;
            EndPosition = gesture.EndPosition;
            DragDirection = (EndPosition - StartPosition).normalized;
            DragDuration = gesture.EndTime - gesture.StartTime;
            TravelDistance = gesture.TravelDistance;
            DragSameness = gesture.SwipeDirectionSameness;
        }
    }
}
