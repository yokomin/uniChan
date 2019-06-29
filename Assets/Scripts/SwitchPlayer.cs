using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] GameObject Unichan;
    [SerializeField] GameObject[] animal = new GameObject[1];

    int bottonCnt = -1;
    int playerState = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            bottonCnt++;
            if(bottonCnt > animal.Length)
            {
                bottonCnt = -1;
            }
        }

        switch(bottonCnt)
        {
            case -1:
                if(playerState != -1){
                    animal[0].SetActive(false);
                    Unichan.SetActive(true);
                    playerState = -1;
                }
                transform.position = Unichan.transform.position;
                Unichan.transform.localPosition = Vector3.zero;
                break;
            case 0:
                if(playerState != 0){
                    Unichan.SetActive(false);
                    animal[0].SetActive(true);
                    playerState = 0;
                }
                transform.position = animal[0].transform.position;
                animal[0].transform.localPosition = Vector3.zero;
                break;
        }
    }
}
