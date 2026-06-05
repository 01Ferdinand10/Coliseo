using UnityEngine;

public class CorazonUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private bool estado_activo;

    public void ActivarCorazon()
    {
        animator.SetTrigger("Restore");
        estado_activo = true;
    }

    public void DesactivarCorazon()
    {
        animator.SetTrigger("Golpe");
        estado_activo = false;
    }

    public bool EstaActivo() => estado_activo;
}
