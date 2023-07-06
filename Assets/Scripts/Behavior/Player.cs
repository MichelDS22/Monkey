using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    public float jumpForce = 3.5f;

    public Transform groundCheck; //para saber que está apoyado en el suelo
    public LayerMask groundLayer; //El tipo de caja de layer, seleccionar la layer que es el suelo, para checar la colisión
    public float groundCheckRadius; // para ver que tan grande es el piso


    private Rigidbody2D _rigibody;
    private Animator _animator;

    //Vectores de movimiento
    private Vector2 _movement;
    private bool _facingRigth = true;
    private bool _isGrounded; // estoy en el suelo si o no

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        //Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal"); //Raw para dar el valor final
        _movement = new Vector2(horizontalInput, 0f);
        //Flipping
        if (horizontalInput < 0f && _facingRigth == true)
        {
            Flip();
        }
        else if (horizontalInput > 0f && _facingRigth == false)
        {
            Flip();
        }

        //Checa el piso
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // el overlap sirve para checar con la layer, como el piso está en una layer y el jugador en otra, si se tocan, aquí se hará verdadero

        //Checa el salto
        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            _rigibody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigibody.velocity = new Vector2(horizontalVelocity, _rigibody.velocity.y);
    }
    private void LateUpdate()
    {
        //    _animator.SetBool("Idle", _movement == Vector2.zero);
        //    _animator.SetBool("IsGrounded", _isGrounded);
       // _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _facingRigth = !_facingRigth; // si es falso voltea el valor a verdadero y viceverza
        float localSclaeX = transform.localScale.x;
        localSclaeX = localSclaeX * -1f;
        transform.localScale = new Vector3(localSclaeX, transform.localScale.y, transform.localScale.z);
    }
}
