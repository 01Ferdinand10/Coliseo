using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    float health, maxhealth = 3;
    public static Action<int> EnemigoMuerto;
    private int valPts = 2;
    private Money_System moneySystem;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneySystem = FindAnyObjectByType<Money_System>();
        health = maxhealth; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            moneySystem.SumarMoney(valPts);
            Destroy(gameObject);
        }
    }
}
