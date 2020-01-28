using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCounter : MonoBehaviour
{
    public static int sum = 0;
    public static int black = 0;
    private int sumBuffer = 0;
    private int blackBuffer = 0;
    [SerializeField] Text text;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int coinToCoinInterval;
    [SerializeField] int numberOfCoins;

    private void Start()
    {
        for(int i = 0; i < numberOfCoins; i++)
        {
            coinPrefab.transform.Rotate(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            coinPrefab.transform.position = new Vector3(
                ((i%Mathf.Sqrt(numberOfCoins))-(Mathf.Sqrt(numberOfCoins)/2)) * coinToCoinInterval,
                6f,
                ((int)(i/ Mathf.Sqrt(numberOfCoins)) - coinToCoinInterval) * (Mathf.Sqrt(numberOfCoins)/2)
                );
            Instantiate(coinPrefab);
        }
        text.text = "BLACK : " + black.ToString() + "\nWHITE : " + (sum - black).ToString();
    }
    void Update()
    {
        if(sumBuffer != sum)
        {
            text.text = "BLACK : " + black.ToString() + "\nWHITE : " + (sum - black).ToString();
        }
        sumBuffer = sum;
        blackBuffer = black;
    }
}
