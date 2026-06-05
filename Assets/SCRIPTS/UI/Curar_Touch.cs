using UnityEngine;

public class Curar_Touch : MonoBehaviour
{
    [SerializeField] private int vida;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player_vida vidaJugador))
        {
            vidaJugador.Curar(vida);
        }
    }
}
