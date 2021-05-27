using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{

    //RoomScene;
   public static bool phoneKey;//PhoneGet,FlashLightCtrl 영향,핸드폰 가지고 있는가?
    public static bool haveLighter;//DollInteraction, ClearRoom1 영향, 라이터 가지고 있는지 확인.
    public static bool haveDoll;//DollInteraction, ClearRoom1 영향
    public static bool haveKnife;//ObEvent1 에 영향
    public static bool isNightmare;//isNightStart 에 영향
 
    public static int startRoom = 0;//괴담 넘버 저장;
    public static Vector3 playerPos;//플레이어 위치값


    public static int Room1;//스테이지1
    public static int Room2;//스테이지2
    public static int Room3;//스테이지3
    public static int isInOut;
    public static int isFirstDoor;
    public static int isSecondDoor;
    //public static bool isClear;
    // Start is called before the first frame update
    // Update is called once per frame
}
