using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFrontOrBack : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject black;
    //[SerializeField] Text text;
    Vector3 coinPosition;
    public bool isDetermined = false;
    //bool isMove = true;
    float stopCounter = 0f;
    private void Start()
    {
        coinPosition = coin.transform.position;
    }
    private void Update()
    {
        if (!isDetermined)
        {
            if (coin.transform.position == coinPosition)
            {
                stopCounter += Time.deltaTime;
                if (stopCounter > 1.5f)
                {
                    isDetermined = true;
                    ResultCounter.sum++;
                    Debug.Log("BLACK : " + black.transform.position.y + " WHITE : " + coin.transform.position.y);
                    if (black.transform.position.y > coin.transform.position.y)
                    {
                        ResultCounter.black++;
                    }
                    //gameObject.SetActive(false);
                }
            }
            else
            {
                coinPosition = coin.transform.position;
                stopCounter = 0f;
            }
        }
    }
}
