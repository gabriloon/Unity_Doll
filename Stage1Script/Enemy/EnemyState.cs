using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        PATROL,
        TRACE,
        ATTACK,
        Clear
    }
    public State state = State.PATROL;
    public GameObject player;
    public GameObject playerFirst;
    public GameObject EnemyCamera;
    public AudioSource ShadowLaugh;
    public GameObject FadeSc;

    public bool isClear = false;//이걸 Awake 내에서 false 로 만들지 고민.
    private Transform playerTr;
    private Transform enemyTr;

    private Animator animator;
    public float attackDist = 5.0f;
    public float traceDist = 10.0f;
    private WaitForSeconds ws;
    private MoveAgent moveAgent;//추가
    private readonly int hashMove = Animator.StringToHash("isMove");
    private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashOffset = Animator.StringToHash("Offset");
    private readonly int hashWalkSpeed = Animator.StringToHash("WalkSpeed");
    private readonly int hashKillPlayer = Animator.StringToHash("isKill");
    private float angle;
    private float dist;
    private Animation tempAnim;


    private EnemyFov enemyFov;

    public AudioSource foundS;

    //public static bool isPlayer;

    void Awake()
    {

        tempAnim = FadeSc.GetComponent<Animation>();
        playerTr = player.GetComponent<Transform>();//플레이어 위치
        enemyTr = GetComponent<Transform>();//Enemy 위치
        animator = GetComponent<Animator>();
        moveAgent = GetComponent<MoveAgent>();//추가
        ws = new WaitForSeconds(0.3f);
        animator.SetFloat(hashOffset, Random.Range(1.0f, 1.1f));//회전속도
        animator.SetFloat(hashWalkSpeed, Random.Range(1.0f, 1.1f));//걸음속도
        enemyFov = GetComponent<EnemyFov>();
        Debug.Log("EnemyState:Awake");
    }

    void OnEnable()
    {
        StartCoroutine(CheckState());//플레이어와 Enemy등의 거리등 확인해서 State 변경
        StartCoroutine(Action());//State 변경된것에 따라 Animator Set 설정과 속도등 변경
        Debug.Log("EnemyState:OnEnable");
    }

    IEnumerator CheckState()
    {
        yield return new WaitForSeconds(1.0f);

        while (!isClear)
        {//isClear 즉 플레이어가 잡히거나 게임을 끝내기전까지 계속
            if (state == State.Clear)
            {
                yield break;//종료
            }
            dist = Vector3.Distance(playerTr.position, enemyTr.position);

            if (dist <= attackDist)//플레이어와 거리값이 2 이하일때
            {
                if (enemyFov.isViewPlayer())
                    state = State.ATTACK;//공격
                else
                    state = State.TRACE;//플레이어 추적
            }
            else if (enemyFov.isTracePlayer())//플레이어와 거리값이 10 이하일때 거리 안에 있는게 플레이어인지, 각도등 고려해서 확인
            {
                Debug.Log("EnemyState:CheckState추적");
                state = State.TRACE;//플레이어 추적
            }
            else
            {
                Debug.Log("EnemyState:CheckState복귀");
                state = State.PATROL; //일반적인 상태 -> 순찰
            }
            yield return ws;
        }
    }
    IEnumerator Action()
    {

        while (!isClear)
        {
            yield return ws;

            switch (state)
            {
                case State.PATROL:
                    moveAgent.patrolling = true;//Moveaget 순찰 시작
                    animator.SetBool(hashKillPlayer, false);//애니메이터로 동작변경
                    animator.SetBool(hashMove, true);

                    break;
                case State.TRACE:
                    moveAgent.traceTarget = playerTr.position;//Moveagent 호출(속도,목적지 변경을 위해)
                    animator.SetBool(hashKillPlayer, false);//애니메이터로 동작변경
                    animator.SetBool(hashMove, true);
                    if (!foundS.isPlaying)//울부짖는 소리가 재생중이 아니라면
                    {
                        foundS.Play();
                    }


                    break;
                case State.ATTACK:
                    moveAgent.Stop();
                    animator.SetBool(hashMove, false);
                    animator.SetBool(hashKillPlayer, true);
                    GetComponent<AudioSource>().Stop();
                    ShadowLaugh.Play();
                    player.GetComponent<FirstPersonController>().enabled = false;
                    // player.transform.rotation = Quaternion.LookRotation(this.transform.position);
                    playerFirst.SetActive(false);
                    EnemyCamera.SetActive(true);
                    //yield return new WaitForSeconds(1.0f);
                    tempAnim.Play("FadeScAnim2");//화면 검정 
                    yield return new WaitForSeconds(4.0f);

                    KeyCheck.isNightmare = false;//종료 후 값 초기화
                    KeyCheck.phoneKey = false;
                    KeyCheck.haveDoll = false;
                    KeyCheck.haveKnife = false;
                    KeyCheck.haveLighter = false;

                    SceneManager.LoadScene(0);//로비 씬으로 이동
                    StopAllCoroutines();
                    break;
                case State.Clear:
                    moveAgent.Stop();//필요없
                    break;


            }
        }
    }
    void Update()
    {
        animator.SetFloat(hashSpeed, moveAgent.speed);    //Animator 에서 speed 파라미터에 이동속도값을 전송

    }
}
