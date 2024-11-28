using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerController Instance;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform weaponCollider;

    private PlayerControles playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    //animation
    private Animator MyAnimator;
    private SpriteRenderer mySpriteRender;
    //knockBack
    private Knockback knockback;

    //slash
    private bool facingLeft = false;


    private void Awake()
    {
        Instance = this;
        playerControls = new PlayerControles();
        rb = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    //goi playerInput
    private void Update()
    {
        PlayerInput();
        AdjustPlayerFacingDerection();

    }
    //goi move
    private void FixedUpdate()
    {
        AdjustPlayerFacingDerection();
        Move();
    }

    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    //khoi tao ham PlayerInput
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        MyAnimator.SetFloat("moveX", movement.x);
        MyAnimator.SetFloat("moveY", movement.y);

    }
    //khoi tao ham Move
    private void Move()
    {
        if (knockback.gettingKnockedBack) { return;  }

        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    //goi ham quay mat
    private void AdjustPlayerFacingDerection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
            facingLeft = true;
        }
        else
        {
            mySpriteRender.flipX = false;
        }
    }
}
