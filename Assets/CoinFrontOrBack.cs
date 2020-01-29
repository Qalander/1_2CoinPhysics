using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFrontOrBack : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject black;
    Vector3 coinPosition;
    public bool isDetermined = false;
    float stopCounter = 0f;
    float resetCount = 0f;
    private void Start()
    {
        coinPosition = coin.transform.position;
    }
    private void Update()
    {
        Debug.Log(Time.deltaTime.ToString());
        if (!isDetermined)
        {
            resetCount += Time.deltaTime;
            if (coin.transform.position == coinPosition)
            {
                stopCounter += Time.deltaTime;
                if (stopCounter > 1.5f)
                {
                    isDetermined = true;
                    ResultCounter.sum++;
                    //Debug.Log("BLACK : " + black.transform.position.y + " WHITE : " + coin.transform.position.y);
                    if (black.transform.position.y > coin.transform.position.y)
                    {
                        ResultCounter.black++;
                    }
                    Destroy(gameObject);
                }
            }
            else
            {
                coinPosition = coin.transform.position;
                stopCounter = 0f;
            }
            if(resetCount > 4f)
            {
                resetCount = 0f;
                gameObject.transform.position = new Vector3(
                    gameObject.transform.position.x,
                    4f,
                    gameObject.transform.position.z);
            }
        }
    }
}
