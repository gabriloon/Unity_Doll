using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveAgent : MonoBehaviour
{
    private readonly float patrolSpeed = 1.5f;//순찰 속도
    private readonly float traceSpeed = 5.0f;//플레이어 발견, 쫒는 속도

    public List<Transform> wayPoints;//List에 순찰 위치값 들을 저장후에 그에 따라 순찰
    public int nextIdx;//다음 이동한 순찰 포인트
    private float damping;//회전속도

    public GameObject group;
    private NavMeshAgent agent;
    private Transform enemyTr;

    private bool _patrolling;

    public bool patrolling
    {//순찰시 보고
        get { return _patrolling; }
        set {//외부에 value 받고 설정 
            //foundS.Stop(); 
            _patrolling = value;
            if (_patrolling) {
                agent.speed = patrolSpeed;
                damping = 1.0f;
                MoveWayPoint();//set 으로 호출시 MoveWayPoint 함수를 실행.
            }
        }
    }

    private Vector3 _traceTarget;

    public Vector3 traceTarget
    {
        get { return _traceTarget; }
        set
        {
            //foundS.Play();
               _traceTarget = value;
                agent.speed = traceSpeed;
            damping = 7.0f;//Enemy 돌아보는 속도에 영향
                TraceTarget(_traceTarget);//set 으로 호출시 MoveWayPoint 함수를 실행.
       }
        
    }

    public float speed {
        get { return agent.velocity.magnitude; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();//Navmesh 컴포넌트
        agent.autoBraking = false;//목표가 가까워졌을때에도 느려지지않게
        agent.updateRotation = false;
    agent.speed = patrolSpeed;
        enemyTr = GetComponent<Transform>();

        //var group = GameObject.Find("WayPointGroup");
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
            nextIdx = Random.Range(0, wayPoints.Count);//순찰할 위치 랜덤으로 결정
        }

        //MoveWayPoint();
        this.patrolling = true;
    }

    void MoveWayPoint()
    {
        //Debug.Log(agent.isPathStale);
        if (agent.isPathStale) return;

        agent.destination = wayPoints[nextIdx].position;//이걸 nextidx를 랜덤으로 하면 랜덤으로 이동한다.
        agent.isStopped = false;
    }


void TraceTarget(Vector3 pos) {
        if (agent.isPathStale) return;

        agent.destination = pos;
        agent.isStopped = false;
}

    public void Stop() {//필요없
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        _patrolling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isStopped == false) {
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
        }

        if (!_patrolling) return;
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {//움직이며 순찰지점에 거의 도달했을경우
            nextIdx = Random.Range(0, wayPoints.Count);//랜덤으로 이동
            MoveWayPoint();
        }
    }
}
