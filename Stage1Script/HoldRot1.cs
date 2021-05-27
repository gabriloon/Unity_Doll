using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldRot1 : MonoBehaviour
{//RigidBody의 컴포넌트가 있는 들고 싶은 물체에다가 이 Script를 넣는다.

    public Transform theDest;//플레이어하위로 오브젝트 생성후(이름을 Destination) 에 위치를 플레이어 바로 앞으로 놔둔다. 
    private float Distance;
    public GameObject Player;
    public GameObject holdIcon;
    private void OnMouseOver()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (Distance < 3.5f)
        {
            holdIcon.SetActive(true);
        }
        else
        {
            holdIcon.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        holdIcon.SetActive(false);
    }

    void OnMouseDown()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (Distance < 3.5f)
        {
            GetComponent<BoxCollider>().enabled = false;//들고 있는 물체의 Collider를 없애고
            GetComponent<Rigidbody>().useGravity = false;//들고 있는동안 무중력상태.
            GetComponent<Rigidbody>().isKinematic = true;//들고 있는 물체가 Rigidbody 효과에 영향을 받는다.
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;//물체가 들고있는 동안에 다른 물체와 부딪쳤을시 회전 방지.
            this.transform.position = theDest.position;//물체를 눈앞으로 끌고 온다.
            this.transform.parent = GameObject.Find("Destination").transform;//자식으로 관계 변경
        }
    }
    void OnMouseUp()
    {
        this.transform.parent = null;//관계 플레이와의 관계에서 해제
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}

