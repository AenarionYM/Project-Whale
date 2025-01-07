using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Abstracts
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        public Dictionary<string, int> AnimationHashes { get; set; } = new();
        private void Start()
        {
            // Get attached animator
            _animator = GetComponent<Animator>();
            // Assign animations to the dictionary
            CacheAnimationHashes();
        }

        public void CacheAnimationHashes()
        {
            // Clear previously cached animations
            AnimationHashes.Clear();
            // Add all animations hashes to the dictionary
            foreach (var parameter in _animator.parameters)
            {
                var hash = Animator.StringToHash(parameter.name);
                AnimationHashes[parameter.name] = hash;
            }
        }

        public void TriggerAnimation(string animName, float speed = 1)
        {
            // Search for animation hash
            if (AnimationHashes.TryGetValue(animName, out var anim))
            {
                _animator.SetTrigger(anim);
            }
        }
    }
}