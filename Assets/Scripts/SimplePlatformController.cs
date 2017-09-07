using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector] public bool facingLeft = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    private bool hasCollided;
    public Health health;
    public AudioClip EnemyKilled1, PlayerHurt;

    private bool grounded = false;
    private Animator anim;
    public Rigidbody2D rb2d;

    private Vector3 playerPos, enemyPos;
    public GameObject parent, enemyChild;

	// Use this for initialization
	void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        if(!grounded)
        {
            anim.SetBool("grounded", false);
        }
        if (grounded)
            anim.SetBool("grounded", true);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if(grounded)
            anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && facingLeft)
            Flip();
        else if (h < 0 && !facingLeft)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Has collided beginning:" + hasCollided);
        if (collision.gameObject.CompareTag("Enemy") && hasCollided == false)
        {
            Debug.Log("HEHEHE");
            GameObject other = collision.gameObject;
            var enemyPos = other.transform.position;
            var playerPos = gameObject.transform.position;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (enemyPos.x > playerPos.x)
            {
                hasCollided = true;
                rb2d.AddForce(new Vector2(-4000f, 600f));
                Debug.Log("AddForce does it make sound");
                health.ChangeHealth(-1);
                StartCoroutine(Wait());
                Debug.Log("Waited");
                SoundManager.instance.RandomizeSfx(PlayerHurt);
            }
            if (enemyPos.x < playerPos.x)
            {
                hasCollided = true;
                rb2d.AddForce(new Vector2(4000f, 600f));
                Debug.Log("AddForce");
                health.ChangeHealth(-1);
                StartCoroutine(Wait());
                SoundManager.instance.RandomizeSfx(PlayerHurt);
            }
        }
        if (gameObject.transform.name == "hero" && hasCollided == false)
        {
            if (collision.gameObject.CompareTag("EnemyChild"))
            {
                Debug.Log("Toched top nemy!!!!!!!");
                rb2d.AddForce(new Vector2(0f, 500f));
                GameObject other = collision.gameObject;
                GameObject otherParent = other.transform.parent.gameObject;
                Destroy(otherParent);
                Destroy(other);
                SoundManager.instance.RandomizeSfx(EnemyKilled1);
            }
        }
        if (gameObject.transform.name != "hero" && hasCollided == false)
        {
            if (collision.gameObject.CompareTag("EnemyChild"))
            {
                hasCollided = true;
                Debug.Log("Toched top nemy");
                rb2d.AddForce(new Vector2(0f, 500f));
                GameObject other = collision.gameObject;
                GameObject otherParent = other.transform.parent.gameObject;
                health.ChangeHealth(-1);
                StartCoroutine(Wait());
                SoundManager.instance.RandomizeSfx(PlayerHurt);
            }
        }
    }
    //Waiting for 3 seconds
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("Waited for 5 Seconds???");
        hasCollided = false;
    }

void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
