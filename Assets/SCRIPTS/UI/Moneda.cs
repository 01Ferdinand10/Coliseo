using UnityEngine;
using System;

public class Moneda : MonoBehaviour
{
    public static Action<int> EnemigoMuerto;
    [SerializeField] private int valPts;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Recolectar();
        }
    }

    private void Recolectar()
    {
        EnemigoMuerto?.Invoke(valPts);
        Destroy(gameObject);
    }
}
