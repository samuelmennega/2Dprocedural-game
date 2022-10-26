using UnityEngine;
using Random = UnityEngine.Random;

namespace TarodevController
{
    /// <summary>
    /// This is a pretty filthy script. I was just arbitrarily adding to it as I went.
    /// You won't find any programming prowess here.
    /// This is a supplementary script to help with effects and animation. Basically a juice factory.
    /// </summary>
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private LayerMask _groundMask;

        private IPlayerController _player;
        public bool _playerGrounded;
        private ParticleSystem.MinMaxGradient _currentGradient;
        private Vector2 _movement;

        void Awake() => _player = GetComponentInParent<IPlayerController>();

        void Update()
        {
            _anim.SetBool("Grounded", _playerGrounded);
            if (_player == null) return;

            // Flip the sprite
            //if (_player.Input.X != 0) transform.localScale = new Vector3(_player.Input.X > 0 ? 1 : -1, 1, 1);


            // Play landing effects and begin ground movement effects
            if (!_playerGrounded && _player.Grounded)
            {
                _playerGrounded = true;

            }
            else if (_playerGrounded && !_player.Grounded)
            {
                _playerGrounded = false;

                _movement = _player.RawMovement; // Previous frame movement is more valuable
            }

        }

    }

}