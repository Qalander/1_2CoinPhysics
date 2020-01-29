using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    [SerializeField] InputField numOfCoins;
    [SerializeField] InputField c2CInterval;
    ResultCounter couter;
    private void Start()
    {
        couter = GameObject.FindGameObjectWithTag("Player").GetComponent<ResultCounter>();
    }
    public void OnClick()
    {
        var objects = GameObject.FindGameObjectsWithTag("Coin");
        foreach (var obj in objects) Destroy(obj);

        if (int.TryParse(numOfCoins.text, out int i))
            Settings.numberOfCoins = i;
        if (float.TryParse(c2CInterval.text, out float j))
            Settings.coinToCoinInterval = j;
        couter.Create();
            
    }
}
