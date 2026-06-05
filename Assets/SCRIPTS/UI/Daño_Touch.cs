using UnityEngine;

public class Daño_Touch : MonoBehaviour
{
    [SerializeField] private int daño;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player_vida vidaJugador))
        {
            vidaJugador.RecibirDano(daño);
        }
    }
}
