using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheZombie;
    public int StatusCheck;
    // Start is called before the first frame update
  

    void DamageZombie(int DamageAmount) {
        EnemyHealth -= DamageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth == 0 && StatusCheck == 0){
            StatusCheck = 2;
            this.GetComponent<Animator>().SetBool("isDie", true);
            //TheZombie.GetComponent<Animation>().Stop("Z_Walk_InPlace");
            //TheZombie.GetComponent<Animation>().Play("Z_FallingForward");
        }
        
    }
}
