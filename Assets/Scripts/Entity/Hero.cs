using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Hero : Entity
{
    [Header("Player Movement Settings")]
    private readonly float speed = 7f; //Movement speed
    private readonly float jumpForce = 17f; //Jump power
    private new Rigidbody2D rigidbody;

    [Header("Player Animation Settings")]
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject[] hearts;

    private float direction;
    private bool isGrounded;
    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    public void Start()
    {
        //GetComponents
        rigidbody = GetComponent<Rigidbody2D>();

        //Lives
        lives = GlobalVar.Get_lives();
        for(int i = 8; i > lives; i--)
        {
            hearts[i - 1].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
            transform.localScale = new Vector2 (-0.4f, 0.4f);
        else if (direction < 0)
            transform.localScale = new Vector2 (0.4f, 0.4f);
            
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        
        if (isGrounded) State = States.run;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        //sprite.flipX = direction.x < 0f;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }

    public override void Take_Damage(int lost_lives)
    {
        int remaining_lives = lives - lost_lives;
        animator.SetTrigger("damage");
        while(lives > remaining_lives)
        {
            hearts[lives - 1].SetActive(false);
            lives--;
            if (lives == 0)
            {
                FindObjectOfType<GameManager>().EndGame();
                break;
            }
        }
        GlobalVar.Set_lives(lives);
        Debug.Log(lives);
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}