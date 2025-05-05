using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyProcessor : MonoBehaviour
{
    public GetData getDataScript;
    public GameObject bigCoin;
    public GameObject smallCoin;
    public TMP_Dropdown currencyDropdown;
    public Button generateCoinsButton;
    public Button clearCoinsButton;

    private List<GameObject> generatedBigCoins = new List<GameObject>();
    private List<GameObject> generatedSmallCoins = new List<GameObject>();

    void Start()
    {
        StartCoroutine(WaitForDataAndProcess());
        currencyDropdown.onValueChanged.AddListener(OnCurrencyDropdownValueChanged);
        generateCoinsButton.onClick.AddListener(OnGenerateCoinsButtonPressed);
        clearCoinsButton.onClick.AddListener(OnClearCoinsButtonPressed);
    }

    IEnumerator WaitForDataAndProcess()
    {
        while (!getDataScript.isDataReady)
        {
            yield return null;
        }

        ProcessCurrency(getDataScript.priceOfUSDValue, "USD");
        ProcessCurrency(getDataScript.priceOfAUDValue, "AUD");
        ProcessCurrency(getDataScript.priceOfJPYValue, "JPY");
        ProcessCurrency(getDataScript.priceOfAEDValue, "AED");
        ProcessCurrency(getDataScript.priceOfCHFValue, "CHF");
    }

    void ProcessCurrency(float price, string currencyName)
    {
        int wholePart = (int)price;
        float decimalPart = price - wholePart;
        decimalPart = Mathf.Round(decimalPart * 100);

        string wholePartString = wholePart.ToString("000");
        string decimalPartString = decimalPart.ToString("00");

        Debug.Log(currencyName + " - Whole Part: " + wholePartString + ", Decimal Part: " + decimalPartString);
    }

    void OnCurrencyDropdownValueChanged(int index)
    {
        string selectedCurrency = currencyDropdown.options[index].text;
    }

    void OnGenerateCoinsButtonPressed()
    {
        string selectedCurrency = currencyDropdown.options[currencyDropdown.value].text;
        GenerateCoinsForSelectedCurrency(selectedCurrency);
    }

    void OnClearCoinsButtonPressed()
    {
        DestroyPreviousCoins();
    }

    public void GenerateCoinsForSelectedCurrency(string currency)
    {
        

        if (currency == "USD")
        {
            GenerateCoins((int)getDataScript.priceOfUSDValue, bigCoin, "USD", "Big Coin", generatedBigCoins);
            GenerateCoins((int)((getDataScript.priceOfUSDValue - (int)getDataScript.priceOfUSDValue) * 100), smallCoin, "USD", "Small Coin", generatedSmallCoins);
        }
        else if (currency == "AUD")
        {
            GenerateCoins((int)getDataScript.priceOfAUDValue, bigCoin, "AUD", "Big Coin", generatedBigCoins);
            GenerateCoins((int)((getDataScript.priceOfAUDValue - (int)getDataScript.priceOfAUDValue) * 100), smallCoin, "AUD", "Small Coin", generatedSmallCoins);
        }
        else if (currency == "JPY")
        {
            GenerateCoins((int)getDataScript.priceOfJPYValue, bigCoin, "JPY", "Big Coin", generatedBigCoins);
            GenerateCoins((int)((getDataScript.priceOfJPYValue - (int)getDataScript.priceOfJPYValue) * 100), smallCoin, "JPY", "Small Coin", generatedSmallCoins);
        }
        else if (currency == "AED")
        {
            GenerateCoins((int)getDataScript.priceOfAEDValue, bigCoin, "AED", "Big Coin", generatedBigCoins);
            GenerateCoins((int)((getDataScript.priceOfAEDValue - (int)getDataScript.priceOfAEDValue) * 100), smallCoin, "AED", "Small Coin", generatedSmallCoins);
        }
        else if (currency == "CHF")
        {
            GenerateCoins((int)getDataScript.priceOfCHFValue, bigCoin, "CHF", "Big Coin", generatedBigCoins);
            GenerateCoins((int)((getDataScript.priceOfCHFValue  - (int)getDataScript.priceOfCHFValue) * 100), smallCoin, "CHF", "Small Coin", generatedSmallCoins);
        }
        else
        {
            Debug.Log("Invalid currency selection.");
        }
    }

    void GenerateCoins(int quantity, GameObject coinPrefab, string currencyName, string coinType, List<GameObject> generatedCoins)
    {
        Vector3 position = new Vector3(0f, 1.5f, 4.2f);

        for (int i = 0; i < quantity; i++)
        {
            GameObject coin = Instantiate(coinPrefab, position, Quaternion.identity);
            generatedCoins.Add(coin);
            Debug.Log("Generated " + coinType + " for " + currencyName + ": " + coinPrefab.name + " at position: " + position);
        }
    }
    void DestroyPreviousCoins()
    {
        // Destroy all big coins
        foreach (GameObject coin in generatedBigCoins)
        {
            Destroy(coin);
        }
        generatedBigCoins.Clear(); // Clear the list after destroying coins

        // Destroy all small coins
        foreach (GameObject coin in generatedSmallCoins)
        {
            Destroy(coin);
        }
        generatedSmallCoins.Clear(); // Clear the list after destroying coins
    }
}


