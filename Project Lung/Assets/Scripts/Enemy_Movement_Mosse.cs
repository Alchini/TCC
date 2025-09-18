using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase2D : MonoBehaviour
{
    [Header("Alvos")]
    public Transform player;
    public string playerTag = "Player";

    [Header("Movimento")]
    public float speed = 3f;
    public float chaseRange = 8f;
    public float stopDistance = 1.2f;   // distância de “parada” para não grudar

    [Header("Ataque")]
    public float attackRange = 1.1f;    // quando entrar aqui, tenta atacar
    public float attackCooldown = 1.0f; // segundos entre ataques
    public int attackDamage = 10;      
    public LayerMask targetLayers;     

    [Header("Visão (opcional)")]
    public bool useLineOfSight = false;
    public LayerMask losObstacles;

    [Header("Animação / Visual")]
    public bool flipSpriteByX = true;
    public Animator animator;           
    public string moveBoolParam = "isMoving";
    public string attackTriggerParam = "attack";

    private Rigidbody2D rb;
    private float nextAttackTime = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag(playerTag);
            if (p) player = p.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            StopMoving();
            return;
        }

        Vector2 pos = rb.position;
        Vector2 targetPos = player.position;
        Vector2 toPlayer = targetPos - pos;
        float dist = toPlayer.magnitude;

        // fora do raio de perseguição
        if (dist > chaseRange)
        {
            StopMoving();
            return;
        }

        // dar uma olhada nisso dps
        if (useLineOfSight)
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, toPlayer.normalized, dist, losObstacles);
            if (hit.collider != null)
            {
                StopMoving();
                return;
            }
        }

        // caso q não vai acontecer
        if (dist <= stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            SetMoving(false);
        }
        else
        {
            // perseguindo (WALK)
            Vector2 dir = toPlayer / dist; 
            rb.linearVelocity = dir * speed;
            SetMoving(true);

            if (flipSpriteByX && Mathf.Abs(rb.linearVelocity.x) > 0.01f)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Sign(rb.linearVelocity.x) * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }

        // checa ataque (distância + cooldown)
        TryAttack(dist, pos, targetPos);
    }

    void TryAttack(float dist, Vector2 pos, Vector2 targetPos)
    {
        if (Time.time < nextAttackTime) return;

        if (dist <= attackRange)
        {

            if (flipSpriteByX && Mathf.Abs(targetPos.x - pos.x) > 0.01f)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Sign(targetPos.x - pos.x) * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            // dispara animação de ATTACK
            if (animator != null && !string.IsNullOrEmpty(attackTriggerParam))
                animator.SetTrigger(attackTriggerParam);

            nextAttackTime = Time.time + attackCooldown;


        }
    }

    void StopMoving()
    {
        rb.linearVelocity = Vector2.zero;
        SetMoving(false);
    }

    void SetMoving(bool moving)
    {
        if (animator != null && !string.IsNullOrEmpty(moveBoolParam))
            animator.SetBool(moveBoolParam, moving);
    }

    public void OnAttackHit()
    {
        Vector2 center = (Vector2)transform.position;
        Collider2D hit = Physics2D.OverlapCircle(center, attackRange, targetLayers);
        if (hit)
        {
            // pra adicionar dps mecancia de dano
        }
    }

    // Gizmos
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow; Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.cyan;   Gizmos.DrawWireSphere(transform.position, stopDistance);
        Gizmos.color = Color.red;    Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
