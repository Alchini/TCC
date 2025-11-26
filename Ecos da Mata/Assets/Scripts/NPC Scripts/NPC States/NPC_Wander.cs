using System.Collections;
using UnityEngine;

public class NPC_Wander : MonoBehaviour
{

    [Header("Wander Area")]
    public float WanderWidth = 5;
    public float WanderHeigh = 5;
    public Vector2 StartingPosition;

    public float pauseDuration = 1;
    public float speed = 2;
    public Vector2 target;


    private Rigidbody2D rb;
    private Animator anim;
    private bool isPaused;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {

        if (isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (Vector2.Distance(transform.position, target) < .1f)
            StartCoroutine(PauseAndPickNewDestination());

        Move();
    }


    private void Move()
    {

        Vector2 direction = (target - (Vector2)transform.position).normalized;
        if (direction.x > 0 && transform.localScale.x < 0 || direction.x < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        rb.linearVelocity = direction * speed;

    }

    private void OnEnable()
    {
        StartCoroutine(PauseAndPickNewDestination());

    }


    IEnumerator PauseAndPickNewDestination()
    {
        isPaused = true;
        anim.Play("Idle");
        yield return new WaitForSeconds(pauseDuration);

        target = GetRandomTarget();
        isPaused = false;
        anim.Play("Walk");


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PauseAndPickNewDestination());
    }



    private Vector2 GetRandomTarget()
    {
        float halfWidth = WanderWidth / 2;
        float halfHeight = WanderHeigh / 2;
        int edge = Random.Range(0, 4);

        return edge switch
        {
            0 => new Vector2(StartingPosition.x - halfWidth, Random.Range(StartingPosition.y - halfHeight, StartingPosition.y + halfHeight)),
            1 => new Vector2(StartingPosition.x + halfWidth, Random.Range(StartingPosition.y - halfHeight, StartingPosition.y + halfHeight)),
            2 => new Vector2(Random.Range(StartingPosition.x - halfWidth, StartingPosition.x + halfWidth), StartingPosition.y - halfHeight),
            _ => new Vector2(Random.Range(StartingPosition.x - halfWidth, StartingPosition.x + halfWidth), StartingPosition.y + halfHeight),

        };

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(StartingPosition, new Vector3(WanderWidth, WanderHeigh, 0));
    }

}
