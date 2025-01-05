using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    
        
    
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movement;
        private Animator _animator;
        private AudioSource _audioSource;
        private Vector2 dashDirection;
        private TrailRenderer _trailRenderer;
        private BoxCollider2D _playerCollider;
        
        private bool _freezeRotation;
        private bool isDashing = false;
        private float dashTime;
        private float lastDashTime;
        
        [Header("=========================")]
        public float speed = 5f;
        public float dashSpeed = 20f; // How fast the character dashes
        public float attackDashSpeed = 20f; // How fast the character dashes
        public float dashDuration = 0.2f; // How long the dash lasts
        public float heavyAttackDashDuration = 0.1f; // How long the dash lasts
        public float lightAttackDashDuration = 0.05f;
        public float dashCooldown = 1f;
        public float dashCost = 25f;
        public float dashShakeMagnitude = 0.15f;
        public int heavyAttackDamage = 50;
        public float heavyAttackCost = 35f;
        public int lightAttackDamage = 25;
        public float lightAttackCost = 15f;
        
        
        [Header("=========================")]
        public bool isFacingRight = true;
        public AudioClip slashSound;
        public GameObject sword;
        public UIController uiController;
        
        
        
        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _trailRenderer = GetComponent<TrailRenderer>();
            _playerCollider = GetComponent<BoxCollider2D>();
        }
    
        void Update()
        {
            if (_movement.x != 0 || _movement.y != 0)
            {
                _animator.SetBool("isMoving", true);
            }
            else
            {
                _animator.SetBool("isMoving", false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && uiController.currentStamina >= lightAttackCost)
            {
                _animator.SetTrigger("Light");
            }
            
            if (Input.GetKeyDown(KeyCode.Mouse1) && uiController.currentStamina >= heavyAttackCost)
            {
                _animator.SetTrigger("Heavy");
            }
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown && !isDashing && uiController.currentStamina >= dashCost)
            {
                StartDash();
            }
            // Stop dashing when time is up
            if (isDashing && Time.time >= dashTime)
            {
                StopDash();
            }
        }
        
        void FixedUpdate()
        {
            Movement();

            if (!_freezeRotation)
            {
                FaceMousePosition();
            }
            if (isDashing)
            {
                _rigidbody2D.linearVelocity = dashDirection * dashSpeed; // Apply dash speed in the direction
            }
        }
        
        private void Movement()
        {
            _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _rigidbody2D.linearVelocity = new Vector2(_movement.x * speed, _movement.y * speed);
        }

        private void FaceMousePosition()
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Determine if the mouse is to the left or right of the player
            float rotationValue = (mousePosition.x > transform.position.x) ? 0f : -180f;

            if (rotationValue != 0f) isFacingRight = true;
            else isFacingRight = false;
            // Apply rotation based on the snapped value
            transform.rotation = Quaternion.Euler(0f, rotationValue, 0f);
        }

        
        
        public void HeavyActivation()
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            _freezeRotation = true;
            _audioSource.PlayOneShot(slashSound);
            sword.SetActive(true);
            sword.GetComponent<AttackController>().damage = heavyAttackDamage;
            uiController.UpdateStamina(-heavyAttackCost);
        }

        public void LightActivation()
        {
            _freezeRotation = true;
            _audioSource.PlayOneShot(slashSound);
            sword.SetActive(true);
            sword.GetComponent<AttackController>().damage = lightAttackDamage;
            uiController.UpdateStamina(-lightAttackCost);
        }

        public void HeavyDeactivation()
        {
            sword.SetActive(false);
            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
            _rigidbody2D.freezeRotation = false;
            _freezeRotation = false;
        }

        public void LightDeactivation()
        {
            sword.SetActive(false);
            _rigidbody2D.freezeRotation = false;
            _freezeRotation = false;
        }
        
        private void StartDash()
        {
            // Record the direction for the dash (based on movement input)
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            
            //Disable Collider
            _playerCollider.enabled = false;

            // If no direction is pressed, dash in the last known direction or stop
            if (dashDirection == Vector2.zero)
            {
                return; // Default to dashing right if no direction input
            }

            isDashing = true;
            uiController.UpdateStamina(-dashCost); // Reduce stamina for dash
            dashTime = Time.time + dashDuration; // Calculate when the dash ends
            lastDashTime = Time.time; // Record the last dash time

            if (_trailRenderer != null)
            {
                _trailRenderer.emitting = true;
            }
            
            // Trigger screen shake when dash starts
            if (ScreenShake.instance != null)
            {
                ScreenShake.instance.TriggerShake(dashDuration, dashShakeMagnitude);
            }
        }

        public void HeavyAttackDash()
        {
            // Record the direction for the dash
            if (isFacingRight)
            {
                dashDirection = Vector2.left; // Default to dashing right if no direction input
            }
            else
            {
                dashDirection = Vector2.right;
            }
            isDashing = true;
            dashTime = Time.time + heavyAttackDashDuration; // Calculate when the dash ends
            lastDashTime = Time.time;
            
            _rigidbody2D.linearVelocity = dashDirection * attackDashSpeed;
            
            if (isDashing && Time.time >= dashTime)
            {
                
                StopDash();
                
            }
        }
        
        public void LightAttackDash()
        {
            
            if (isFacingRight)
            {
                dashDirection = Vector2.left;
            }
            else
            {
                dashDirection = Vector2.right;
            }

            isDashing = true;
            dashTime = Time.time + lightAttackDashDuration; // Calculate when the dash ends
            lastDashTime = Time.time;
            
            _rigidbody2D.linearVelocity = dashDirection * attackDashSpeed;
            
            if (isDashing && Time.time >= dashTime)
            {
                StopDash();
            }
        }

        private void StopDash()
        {
            isDashing = false;
            _rigidbody2D.linearVelocity = Vector2.zero; // Stop the character when the dash ends
            
            if (_trailRenderer != null)
            {
                _trailRenderer.emitting = false;
            }
            
            _playerCollider.enabled = true;
        }
}
