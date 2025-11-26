/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public float attackRange = 2;
    public float attackCollDown = 2;
    public float playerDetectDistance = 5;
    public bool enemyOn = false;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private float attackCollDownTimer;
    private int facingDirection = 1;
    private EnemyState enemyState;


    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }


    void Update()
    {
        if (!enemyOn) return;

        checkForPlayer();
        if (attackCollDownTimer > 0)
            attackCollDownTimer -= Time.deltaTime;

        if (enemyState == EnemyState.Chasing)
            Chase();
        else if (enemyState == EnemyState.Attacking)
            rb.linearVelocity = Vector2.zero;
    }


    void Chase()
    {

        if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }



    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    private void checkForPlayer()
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectDistance, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCollDownTimer <= 0)
            {
                attackCollDownTimer = attackCollDown;
                ChangeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                Debug.Log("ta perseguindo!");
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
            anim.SetBool("IsIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("IsChasing", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("IsAttacking", false);

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
            anim.SetBool("IsIdle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("IsChasing", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("IsAttacking", true);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectDistance);
    }

    public bool iaAtiva = false;

    public void ActivateEnemy()
    {
        enemyOn = true;
        ChangeState(EnemyState.Idle);
    }


}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking

}

*/