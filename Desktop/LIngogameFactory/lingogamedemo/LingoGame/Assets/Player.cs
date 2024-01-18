using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;
    private Vector3 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 获取WASD键的输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);

        // 根据输入移动角色
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // 更新动画状态
        if (movement.magnitude > 0)
        {
            animator.SetBool("Walk", true);

            // 根据移动方向旋转角色
            Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
