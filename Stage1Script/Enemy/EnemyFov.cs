using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{
    public float viewRange = 11.0f;
    public float viewAngle = 120.0f;

    public GameObject player;
    private Transform enemyTr;
    private Transform playerTr;
    private int playerLayer;
    private int obstacleLayer;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        enemyTr = GetComponent<Transform>();
        playerTr = player.transform;
        playerLayer = LayerMask.NameToLayer("PLAYER");//Player Layer
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");//Object
        layerMask = 1 << playerLayer | 1 << obstacleLayer;

    }

    /*
    public Vector3 CirclePoint(float angle) {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),0,Mathf.Cos(angle*Mathf.Deg2Rad));
    }
    */

    public bool isTracePlayer()
    {//순찰 중 플레이어 발견
        bool isTrace = false;
        Collider[] colls = Physics.OverlapSphere(enemyTr.position, viewRange, 1 << playerLayer);//11.0f,60도,Layer 체크 

        if (colls.Length == 1)//플레이어 발견되어 배열안에 값 저장
        {
            Vector3 dir = (playerTr.position - enemyTr.position).normalized;//백터 정규화 시켜서 거리 값 저장


            if (Vector3.Angle(enemyTr.forward, dir) < viewAngle * 0.5f)//Enemy의 시야각 안에 있으면 EnemyState 변경을 위해 true 반환
            {
                Debug.Log("EnemyFov:추적");
                isTrace = true;
            }
        }
        return isTrace;

    }

    public bool isViewPlayer()
    {//isTracePlayer 함수와 달리, Raycast 통해 각도,Layer,거리등 검사를 통해 플레이어 감지하고 true,false 반환
        bool isView = false;
        Debug.Log("EnemyFov:isView");
        RaycastHit hit;
        Vector3 dir = (playerTr.position - enemyTr.position).normalized;//정규화
        if (Physics.Raycast(enemyTr.position, dir, out hit, viewRange, layerMask))
        {//viewRange,dir 등 검사 통해 Raycast hit 감지
            isView = (hit.collider.CompareTag("Player"));//마지막으로 Raycast 의 hit 된 object 가 tag를 통해 Player인지 확인

        }
        return isView;
    }

}
