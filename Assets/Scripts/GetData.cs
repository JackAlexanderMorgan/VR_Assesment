using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using TMPro;

public class GetData : MonoBehaviour
{

    public string DataURL;
    public GameObject priceText;
    //public GameObject[] priceInstances;
    private int counter;

    public float priceOfUSDValue;
    public float priceOfAEDValue;
    public float priceOfAUDValue;
    public float priceOfJPYValue;
    public float priceOfCHFValue;
    public bool isDataReady = false;

    void Start()
    {
        StartCoroutine(getData());
        
    }

    IEnumerator getData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(DataURL)) 
        { 

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }

            else
            {
                string json = request.downloadHandler.text;
                
                isDataReady = true;
                Debug.Log(json);
                ReadJSON(json);
                
            }

        }
    }

    void ReadJSON(string jsonString)
    {
        JSONNode node = JSON.Parse(jsonString);
        JSONObject obj = node.AsObject;

        string priceOfAED = obj["conversion_rates"]["AED"].Value;
        string priceOfUSD = obj["conversion_rates"]["USD"].Value;
        string priceOfJPY = obj["conversion_rates"]["JPY"].Value;
        string priceOfAUD = obj["conversion_rates"]["AUD"].Value;
        string priceOfCHF = obj["conversion_rates"]["CHF"].Value;

        priceOfUSDValue = float.Parse(priceOfUSD);
        priceOfAUDValue = float.Parse(priceOfAUD);
        priceOfJPYValue = float.Parse(priceOfJPY);
        priceOfAEDValue = float.Parse(priceOfAED);
        priceOfCHFValue = float.Parse(priceOfCHF);

        var x = 1.6025f;
        float y = 1.578f;
        var z = 3.938f;

        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(x, y, z);
            Instantiate(priceText, position, Quaternion.identity);
            TextMeshPro textComponent = priceText.GetComponent<TextMeshPro>();

            if (i == 0)
            {
                textComponent.text = priceOfAED;
            }
            else if (i == 1)
            {
                textComponent.text = priceOfUSD;
            }
            else if (i == 2)
            {
                textComponent.text = priceOfJPY;
            }
            else if (i == 3)
            {
                textComponent.text = priceOfAUD;
            }
            else if (i == 4)
            {
                textComponent.text = priceOfCHF;
                Debug.Log("priceWritten");
            }

            y -= 0.1715f;
        }
    }
}



