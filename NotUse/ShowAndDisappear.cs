using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndDisappear : MonoBehaviour
{
    public GameObject showA;
    // Start is called before the first frame update
    public GameObject telpPos;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShowDis());
    }

    private void Update()
    {
        showA.transform.LookAt(Player.transform.position);
        showA.transform.localRotation *= Quaternion.Euler(-90, 0, 0);
    }
    IEnumerator ShowDis()
    {
        Vector3 pos = telpPos.transform.position;
        showA.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        showA.SetActive(false);

        //showA.transform.position = pos;
        showA.transform.position = Player.transform.position - new Vector3(-0.2f, 0.8f, 0);//뒤에 벡터 뺴는건 값조절 잘해서 땅에 닿으면서 순간이동 되게 조절.
        showA.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        showA.SetActive(false);
        // showA.transform.position = ElePos.position;

    }
}