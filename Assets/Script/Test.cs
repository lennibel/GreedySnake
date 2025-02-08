using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Gizmo Settings")]
    public float arrowLength = 1.0f;
    public Color forwardColor = Color.blue;
    public Color upColor = Color.green;
    public Color rightColor = Color.red;

    void OnDrawGizmos()
    {
        // 获取物体位置和方向
        Vector3 pos = transform.position;
        
        // 绘制前向（Z轴）
        Gizmos.color = forwardColor;
        Gizmos.DrawRay(pos, transform.forward * arrowLength);
        
        // 绘制上方（Y轴）
        Gizmos.color = upColor;
        Gizmos.DrawRay(pos, transform.up * arrowLength * 0.5f);
        
        // 绘制右方（X轴）
        Gizmos.color = rightColor;
        Gizmos.DrawRay(pos, transform.right * arrowLength * 0.5f);
    }
    void Update()
    {
        // print(transform.up);
    }
}
