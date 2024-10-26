using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserContoller : MonoBehaviour
{
    public float maxDistance = 100f;
    public int MaxReflectTimes = 5;
    private LineRenderer lineRenderer;   
    private Vector3 WorldMousePos;
    private Vector2 direction;
    private Vector2 startFirePos;
    private GameObject player;
    private void Start()
    {    
        lineRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindWithTag("Player");        
    }

    private void Update()
    {
        //玩家位置作为发射位置
        startFirePos = player.transform.position;
        //获得鼠标位置并转化到世界坐标当中
        WorldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //获得鼠标与人物之间的方向向量
        direction = GetDirection(startFirePos, WorldMousePos);
        // 按住鼠标左键时发射激光
        if(Input.GetMouseButton(0))
        {
            StartFireLase(startFirePos, direction, MaxReflectTimes, 0);
        }
    }

    public Vector3 GetDirection(Vector3 origin,Vector3 target)
    {
        // 设置 z 轴为 0（适用于2D游戏）
        origin.z = 0;
        // 计算方向向量
        Vector3 direction = (target - origin).normalized;
        // 输出方向向量，用于调试
        //Debug.Log("Direction: " + direction);
        return direction;
    }

    private void StartFireLase(Vector2 origin, Vector2 direction,int maxReflectTimes,int currentReflectTimes)
    {
        //Debug.Log("INFO:StartFireLaser");
        lineRenderer.positionCount = 2;
        FireLaser(origin, direction, maxReflectTimes, currentReflectTimes);
    }

    void FireLaser(Vector2 origin, Vector2 direction,int maxReflectTimes,int currentReflectTimes)
    {       

        
        // 发送射线检测
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);
        // 设置LineRenderer的起点       
        lineRenderer.SetPosition(currentReflectTimes, origin);
        // 如果射线碰到物体
        if (hit.collider != null)
        {
            //射线的碰撞检测
            if (hit.collider.CompareTag("button"))
            {
                Debug.Log("INFO:检测到button");
                hit.collider.GetComponent<IButton>().Click();
            }
            // 判断是否需要反射
            if (hit.collider.CompareTag("Reflective"))
            {
                if (currentReflectTimes > maxReflectTimes)  //递归中止条件
                {
                    //Debug.Log("INFO:到达反射数量上限");
                    return;
                }

                lineRenderer.positionCount++;

                currentReflectTimes++;
                
                Vector2 reflectDirection = Vector2.Reflect(direction, hit.normal); //计算反射方向

                Vector2 OFFSET = new Vector2(-0.01f, -0.01f);
                
                Vector2 offsetedPos = hit.point + direction * OFFSET;   //需要将碰撞点朝着射线来的方向进行一点偏移，不然会在原点发射碰撞
                
                FireLaser(offsetedPos, reflectDirection,maxReflectTimes,currentReflectTimes);
                //Debug.Log("INFO:触发反射");
            }
            else
            {
                // 设置射线终点
                lineRenderer.SetPosition(currentReflectTimes + 1, hit.point);
            }
           
        }
        else
        {
            // 设置射线终点
            // 没有碰到任何物体的情况下
            lineRenderer.SetPosition(currentReflectTimes+1,origin+direction*maxDistance);
        }
        
    }
}
