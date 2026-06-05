using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class EnemyIosh : MonoBehaviour
{
    public static Action<int> EnemigoMuerto;
    private int valPts = 2;
    private Money_System moneySystem;
    private bool muerto = false;
    private bool puedeHacerDano = true;

    private float moveSpeed = 1f;
    private float moveSpeed_rage = 2f;
    public int Edamage = 1;
    private int life = 2;

    private Animator animator;
    [SerializeField] private float viewRadius = 5f;
    [SerializeField] private LayerMask enemy_layer;


    public GameObject enemy;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneySystem = FindAnyObjectByType<Money_System>();
        target = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       if (muerto) return;

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
            animator.SetFloat("InputX", moveDirection.x); 
            animator.SetFloat("InputY", moveDirection.y);
            animator.SetBool("IsWalking", true);

            float distance = Vector2.Distance(target.position, transform.position);
            if (distance <= 7f)
            {
                moveSpeed = moveSpeed_rage;
            }
            else
            {
                moveSpeed = 1f;
            }

            Collider2D objecto_view = Physics2D.OverlapCircle(transform.position, viewRadius, enemy_layer);
        }

    }

    public void SetearEnemy(float a, float b, int c, int d)
    {
        moveSpeed = a;
        moveSpeed_rage = b;
        Edamage = c;
        life = d;
    }

    public void TakeDamage(int damage)
    {
        if (muerto) return;
        life -= damage;

        if (life <= 0)
        {
            muerto = true;
            moneySystem.SumarMoney(valPts);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsDeath", true);

            rb.simulated = false;
            Destroy(gameObject, 1f);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (muerto) return;
        if (collision.gameObject.TryGetComponent(out Player_vida vidaJugador) && puedeHacerDano)
        {
            puedeHacerDano = false;
            vidaJugador.RecibirDano(Edamage);
            StartCoroutine(CooldownDano());
        }
    }

    IEnumerator CooldownDano()
    {
        yield return new WaitForSeconds(1f);
        puedeHacerDano = true;
    }

    private void FixedUpdate()
    {
        if (muerto) return;
        if (target)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}
