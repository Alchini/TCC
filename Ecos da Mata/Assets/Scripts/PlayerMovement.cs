using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public Rigidbody2D rb;
    public Animator anim;
    public int facingDirection = 1;

    private bool isKnockedBack;

    [Header("Footstep")]
    [SerializeField] private float footstepInterval = 0.3f;
    [SerializeField] private float minMoveMagnitude = 0.1f;

    private float footstepTimer;
    private bool isMoving;

    void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            Vector2 velocity = new Vector2(horizontal, vertical) * speed;
            rb.linearVelocity = velocity;

            // >>> NOVO: está se movendo?
            isMoving = velocity.magnitude > minMoveMagnitude;
            // <<<
        }
    }

    private void Update()
    {
        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        if (!isMoving || isKnockedBack)
            return;

        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0f)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayFootstep();
            }
            footstepTimer = footstepInterval;
        }
    }


    void Flip()
    {

        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);


    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockBackCounter(stunTime));
    }

    IEnumerator KnockBackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }

}

