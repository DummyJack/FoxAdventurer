using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Camera camera;

    public float moveSpeed = 10;
    public float turnSmooth;
    public float turnTime = 0.1f;

    private float inputH;
    private float inputV;
    private Vector3 direction;

    public float gravity = -20f;
    public float jumpHeight = 1.0f;
    private Vector3 velocity;
    private bool isGround = true;

    private CharacterController controller;
    private Animator animator;

    private int attackNum = 0;
    private bool isAttacking;
    private bool canAttack = true;
    private bool canMove = true;
    public int attackDelayTime = 750;
    public int clearComboTime = 500;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        Jump();
    }

    public void Move()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        direction = new Vector3(inputH, 0, inputV);

        if (direction.magnitude >= 0.1f && !isAttacking && canMove)
        {
            animator.SetBool("isRunning", true);
            animator.SetFloat("speed", direction.magnitude);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmooth, turnTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            controller.Move(moveSpeed * Time.deltaTime * moveDirection);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetFloat("speed", 0f);
        }

        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            isAttacking = true;
            canMove = false;
            animator.SetBool("canMove", false);

            CancelInvoke(nameof(ClearCombo));
            Invoke(nameof(ClearCombo), (float)(clearComboTime + attackDelayTime) / 1000);

            switch (attackNum % 2)
            {
                case 0:
                    animator.CrossFade("Attack_01", 0.1f);
                    break;
                case 1:
                    animator.CrossFade("Attack_02", 0.2f);
                    break;
            }
            attackNum++;
            Invoke(nameof(SetCanAttack), (float)attackDelayTime / 1000);
        }

    }

    public void SetCanAttack()
    {
        canAttack = true;
    }

    public void ClearCombo()
    {
        attackNum = 0;
    }


    public void OnAttackEnd(AnimationEvent animationEvent)
    {
        canMove = true;
        animator.SetBool("canMove", true);
        isAttacking = false;

    }

    public void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            isGround = false;
            canAttack = false;
            animator.SetBool("isGround", false);
            if (direction.magnitude != 0)
            {
                animator.CrossFade("JumpMove", 0f);
            }
            else
            {
                animator.CrossFade("Jump", 0f);
            }
            controller.Move(new Vector3(0, 0.1f, 0));
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isGround && hit.normal.y > 0.5f)
        {
            isGround = true;
            canAttack = true;
            animator.SetBool("isGround", true);
            velocity.y = 0f;
        }
    }
}
