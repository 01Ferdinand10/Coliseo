using UnityEngine;
using System;

public class ContenedorHeart : MonoBehaviour
{
    [SerializeField] private CorazonUI[] corazones;
    [SerializeField] private Player_vida vida_player;

    private void Start()
    {
        vida_player = FindAnyObjectByType<Player_vida>();

        vida_player.PlayerRecibirDano += ActivarCorazones;
        vida_player.PlayerCurar += ActivarCorazones;

        ActivarCorazones(vida_player.GetVidaActual());
    }

    void OnDisable()
    {
        vida_player.PlayerRecibirDano -= ActivarCorazones;
        vida_player.PlayerCurar -= ActivarCorazones;
    }

    private void ActivarCorazones(int vidaActual)
    {
        for (int i = 0;i<corazones.Length;i++)
        {
            if (i < vidaActual)
            {
                if (corazones[i].EstaActivo()) { continue; }

                corazones[i].ActivarCorazon();
            } else
            {
                if (!corazones[i].EstaActivo()) { continue; }
                corazones[i].DesactivarCorazon();
            }

        }
    }
}

