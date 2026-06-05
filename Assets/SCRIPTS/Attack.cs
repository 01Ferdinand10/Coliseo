using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public GameObject Melee;
    private Animator animator;

    public bool isAttacking = false;
    float atkDur = 0.3f;
    float atkTimer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetBool("isDeath"))
        {
            Melee.SetActive(false);
            isAttacking = false;
            return;
        }

        CheckMeleeTimer();

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            OnAttack();
        }
    }

    void OnAttack()
    {
        if (!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
            animator.SetBool("isAttacking", true);
        }
    }

    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDur)
            {
                atkTimer = 0f;
                isAttacking=false;
                animator.SetBool("isAttacking", false);
                Melee.SetActive(false);
            }
        }
    }
}
