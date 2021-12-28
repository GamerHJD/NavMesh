/****************************************************
    文件：NavTest.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour 
{
    private NavMeshAgent navMeshAgent;
    public Transform Node1;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        Debug.Log(Mathf.Cos(90));
    }

    /// <summary>
    /// 
    /// </summary>
    public void TestNavMove()
    {
        Vector3 curPos = transform.position;
        Vector3 dstPos = Node1.position;
        Vector3 proPos;
        bool checkDisable = false;
        if (dstPos.y > curPos.y)
        {
            proPos = new Vector3(dstPos.x,curPos.y,curPos.z);
        }
        else
        {
            proPos = new Vector3(curPos.x, curPos.y, dstPos.z);
        }

        navMeshAgent.SetDestination(proPos);


        StartCoroutine(LoopDetection(checkDisable, () => {
            if (Vector3.Distance(transform.position, proPos) <= 0.15f)
            {
                checkDisable = true;
                navMeshAgent.SetDestination(dstPos);
            }
        }));
             
    }

    IEnumerator LoopDetection(bool disable,Action action)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            action();
            if (disable) break;
        }
    }
}