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

    private Vector2 lastPosition;
    private float stuckTimer;
    public float stuckCheckInterval = 1f;
    public float stuckDistanceThreshold = 0.05f;



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
        {
            StartCoroutine(PauseAndPickNewDestination());
            return; // evita chamar Move no mesmo frame
        }

        Move();

        // --- DETECÇÃO DE TRAVAMENTO ---
        stuckTimer += Time.deltaTime;

        if (stuckTimer >= stuckCheckInterval)
        {
            float movedDistance = Vector2.Distance(transform.position, lastPosition);

            // Se quase não saiu do lugar no intervalo, considera travado
            if (movedDistance < stuckDistanceThreshold)
            {
                StartCoroutine(PauseAndPickNewDestination());
            }

            lastPosition = transform.position;
            stuckTimer = 0f;
        }
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
        if (isPaused) return;

        // empurra um pouquinho pro lado oposto ao ponto de contato
        var contact = collision.GetContact(0);
        Vector2 away = ((Vector2)transform.position - contact.point).normalized;
        transform.position += (Vector3)(away * 0.05f); // ajuste esse valor se necessário

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
