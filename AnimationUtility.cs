using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace trickyclown
{
    public static class AnimationUtility
    {
        /// <summary>
        /// Based on an animation name, returns a BoE animation hash if available or a vanilla animation.
        /// </summary>
        public static int GetAnimationByName(string name)
        {
            if (BunchOfEmotesSupport.Installed)
            {
                if (BunchOfEmotesSupport.TryGetGameAnimationForCustomAnimation(name, out var animation))
                    return animation;
            }
            return Animator.StringToHash(name);
        }
    }
}
