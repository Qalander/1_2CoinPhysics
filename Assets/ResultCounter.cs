using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCounter : MonoBehaviour
{
    public static int sum = 0;
    public static int black = 0;
    private int sumBuffer = 0;
    private int sumAll = 0;
    private int blackAll = 0;
    private bool isDetermined = false;
    [SerializeField] Text text;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int coinToCoinInterval;
    [SerializeField] int numberOfCoins;

    private void Start()
    {
        Settings.numberOfCoins = numberOfCoins;
        Settings.coinToCoinInterval = coinToCoinInterval;
        //Create();
    }
    void Update()
    {
        if (sum == Settings.numberOfCoins && !isDetermined)
        {
            isDetermined = true;
            sumAll += sum;
            blackAll += black;
        }
        if (sumBuffer != sum)
        {
            text.text = Settings.resetCount.ToString() + "回目"
                + "\nBLACK : " + black.ToString()
                + "\nWHITE : " + (sum - black).ToString()
                + "\n\n合計"
                + "\nBLACK : " + blackAll.ToString()
                + "\nWHITE : " + (sumAll - blackAll).ToString();
        }
        sumBuffer = sum;
        
    }
    public void Create()
    {
        isDetermined = false;
        Settings.resetCount++;
        black = sum = 0;
        for (int i = 0; i < Settings.numberOfCoins; i++)
        {
            coinPrefab.transform.Rotate(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            coinPrefab.transform.position = new Vector3(
                ((i % Mathf.Sqrt(Settings.numberOfCoins)) - (Mathf.Sqrt(Settings.numberOfCoins) / 2)) * Settings.coinToCoinInterval,
                6f,
                (int)(i / Mathf.Sqrt(Settings.numberOfCoins)) * Settings.coinToCoinInterval
                );
            Instantiate(coinPrefab);
        }
        text.text = Settings.resetCount.ToString() + "回目"
             + "\nBLACK : " + black.ToString()
             + "\nWHITE : " + (sum - black).ToString()
             + "\n\n合計"
             + "\nBLACK : " + blackAll.ToString()
             + "\nWHITE : " + (sumAll - blackAll).ToString();
    }
}
