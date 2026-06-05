using UnityEngine;
using System;

public class Player_vida : MonoBehaviour
{
    public Action<int> PlayerRecibirDano;
    public Action<int> PlayerCurar;

    [SerializeField] private int vidaMax;
    [SerializeField] private int vidaActual;
    [SerializeField] playerMovement player;

    private void Awake()
    {
        vidaActual = vidaMax;
    }

    public void RecibirDano(int dano)
    {
        int temporal = vidaActual - dano;

        temporal = Mathf.Clamp(temporal, 0, vidaMax);
        vidaActual = temporal;

        PlayerRecibirDano?.Invoke(vidaActual);

        if (vidaActual <= 0)
        {
            player.Morir();
        }
    }

    public void Curar(int pocion)
    {
        int temporal = pocion + vidaActual;
        temporal = Mathf.Clamp(temporal, 0, vidaMax);
        vidaActual = temporal;

        PlayerCurar?.Invoke(vidaActual);
    }

    public int GetVidaMax() => vidaMax;
    public int GetVidaActual() => vidaActual;
}
