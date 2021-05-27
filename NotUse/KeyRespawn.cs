using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRespawn : MonoBehaviour
{
    public GameObject keyPrefab;
    public GameObject[] positions1 = new GameObject[10];
   
    public bool isSpawn = false;//아직은 노쓸모 나중에 Trigger,새로운 이벤트발생등 처리할때 쓸거. 
    private int[] saveNum = new int[5] { 11, 11, 11, 11, 11 };//11이 안되면 0으로 바꿔보자.
 private bool isSame=false;

    void SpawnKey()
    {

        for (int a = 0; a < 5; a++)
        {

            while (true)
            {

                saveNum[a] = Random.Range(0, 11);
                isSame = false;

                for (int b = 0; b < a; b++)
                {
                    if (saveNum[a] == saveNum[b])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;

            }
        }
    }

    private void Start()
    {
        SpawnKey();

        for (int i = 0; i < 5; i++)
        {
            Instantiate(keyPrefab, positions1[saveNum[i]].transform.position, Quaternion.identity);
        }
    }





}
