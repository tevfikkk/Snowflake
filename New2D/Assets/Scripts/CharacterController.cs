using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private float jumpForce = 10f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool grounded; // We need to know if the player is grounded or not
    private bool started; // We need to know if the game has started or not
    private bool jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>() as Rigidbody2D; // caching the rigidbody2D component
        _animator = GetComponent<Animator>() as Animator; // caching the animator component
        // started = true;
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                started = true;
            }
        }

        _animator.SetBool("Grounded", grounded);

    }

    private void FixedUpdate()
    {
        if (started)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }

        if (jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }


}
