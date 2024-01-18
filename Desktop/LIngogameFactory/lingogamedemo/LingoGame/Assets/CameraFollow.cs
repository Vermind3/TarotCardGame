using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 目标角色的Transform
    public Vector3 offset; // 摄像机相对于角色的偏移量

    void LateUpdate()
    {
        // 更新摄像机的位置为目标位置加上偏移量
        transform.position = target.position + offset;

        // （可选）如果你还想让摄像机始终面向角色，可以取消注释下面这行代码
        // transform.LookAt(target);
    }
}
