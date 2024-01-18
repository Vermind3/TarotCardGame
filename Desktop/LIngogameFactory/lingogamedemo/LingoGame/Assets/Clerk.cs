using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clerk : MonoBehaviour
{
   // public Transform player;
    public Button dialogueButton;
    public Camera camera;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        dialogueButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsTargetVisible(camera, this.transform.position))
        {
            Debug.Log("目标在屏幕外");
            UpdateArrowPosition(arrow, camera, this.transform.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保触发器与玩家标签匹配
        {
            dialogueButton.gameObject.SetActive(true);
        }
    }

    // 当玩家离开触发器区域
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueButton.gameObject.SetActive(false);
        }
    }

    bool IsTargetVisible(Camera camera, Vector3 targetPosition)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(targetPosition);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    void UpdateArrowPosition(GameObject arrow, Camera camera, Vector3 targetPosition)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(targetPosition);
        bool isOffScreen = screenPoint.z < 0 || screenPoint.x <= 0 || screenPoint.x >= 1 || screenPoint.y <= 0 || screenPoint.y >= 1;

        arrow.SetActive(isOffScreen);

        if (isOffScreen)
        {
            screenPoint.x = Mathf.Clamp(screenPoint.x, 0.05f, 0.95f); // 保持箭头在屏幕边缘
            screenPoint.y = Mathf.Clamp(screenPoint.y, 0.05f, 0.95f);
            screenPoint.z = 0;

            Vector3 arrowPosition = camera.ViewportToScreenPoint(screenPoint);
            arrow.transform.position = arrowPosition;
            arrow.transform.up = (targetPosition - camera.transform.position).normalized;
        }
    }

}
