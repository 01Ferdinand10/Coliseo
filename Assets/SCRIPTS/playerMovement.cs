using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private Vector2 lookDir = Vector2.down;
    [SerializeField] Vector2 upPos;
    [SerializeField] Vector2 downPos;
    [SerializeField] Vector2 leftPos;
    [SerializeField] Vector2 rightPos;
    [SerializeField] Vector3 upRot;
    [SerializeField] Vector3 downRot;
    [SerializeField] Vector3 leftRot;
    [SerializeField] Vector3 rightRot;
    public Transform Aim;

    [SerializeField] PlayMusic PlayMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic.playBgMusic();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isDeath"))
        {
            return;
        }

        if (PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        if (animator.GetBool("isAttacking"))
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("isWalking", rb.linearVelocity.magnitude > 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
        }

        moveInput = context.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                lookDir = new Vector2(Mathf.Sign(moveInput.x), 0);
            }
            else
            {
                lookDir = new Vector2(0, Mathf.Sign(moveInput.y));
            }

            animator.SetFloat("LastInputX", lookDir.x);
            animator.SetFloat("LastInputY", lookDir.y);
        }

        if (lookDir == Vector2.up)
        {
            Aim.localPosition = upPos;
            Aim.localEulerAngles = upRot;
        }
        else if (lookDir == Vector2.down)
        {
            Aim.localPosition = downPos;
            Aim.localEulerAngles = downRot;
        }
        else if (lookDir == Vector2.left)
        {
            Aim.localPosition = leftPos;
            Aim.localEulerAngles = leftRot;
        }
        else if (lookDir == Vector2.right)
        {
            Aim.localPosition = rightPos;
            Aim.localEulerAngles = rightRot;
        }

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    public void Morir()
    {
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isDeath", true);

        StartCoroutine(LoadDefeatScene());
    }

    IEnumerator LoadDefeatScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DefeatScene");
    }
}
