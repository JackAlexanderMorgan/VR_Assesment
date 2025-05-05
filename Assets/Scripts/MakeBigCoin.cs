//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class CurrencyProcessor : MonoBehaviour
//{
//    public GetData getDataScript; // Reference to GetData script
//    public GameObject bigCoin; // Reference to big coin prefab
//    public GameObject smallCoin; // Reference to small coin prefab
//    public TMP_Dropdown currencyDropdown;
//    public Button generateCoinsButton;
//    public bool isCoinsGenerated = false;


//    void Start()
//    {
//        // Start coroutine to wait for data to be ready
//        StartCoroutine(WaitForDataAndProcess());
//        currencyDropdown.onValueChanged.AddListener(OnCurrencyDropdownValueChanged);
//        generateCoinsButton.onClick.AddListener(OnGenerateCoinsButtonPressed);
//    }

//    // Coroutine to wait until data is loaded
//    IEnumerator WaitForDataAndProcess()
//    {
//        // Wait until the isDataReady flag is true
//        while (!getDataScript.isDataReady)
//        {
//            yield return null; // Wait for the next frame
//        }

//        // Once the data is ready, process the currency values
//        ProcessCurrency(getDataScript.priceOfUSDValue, "USD");
//        ProcessCurrency(getDataScript.priceOfAUDValue, "AUD");
//        ProcessCurrency(getDataScript.priceOfJPYValue, "JPY");
//        ProcessCurrency(getDataScript.priceOfAEDValue, "AED");
//        ProcessCurrency(getDataScript.priceOfCHFValue, "CHF");
//    }

//    // Method to process and separate the currency into whole and decimal parts
//    void ProcessCurrency(float price, string currencyName)
//    {
//        int wholePart = (int)price; // Get the whole part (before the decimal)
//        float decimalPart = price - wholePart; // Get the decimal part (after the decimal)
//        decimalPart = Mathf.Round(decimalPart * 100); // Round decimal to 2 digits

//        // Convert to two-digit strings
//        string wholePartString = wholePart.ToString("00"); // Ensure two digits for whole part
//        string decimalPartString = decimalPart.ToString("00"); // Ensure two digits for decimal part

//        // Output the whole and decimal parts
//        Debug.Log($"{currencyName} - Whole Part: {wholePartString}, Decimal Part: {decimalPartString}");

//        // Here you could use the wholePartString and decimalPartString in further logic, such as generating coins


//    }

//    void OnCurrencyDropdownValueChanged(int index)
//    {
//        string selectedCurrency = currencyDropdown.options[index].text; // Get the selected currency

//        // You can choose to call the GenerateCoins method for the selected currency

//    }
//    void OnGenerateCoinsButtonPressed()
//    {
//        // Get the selected currency from the dropdown and generate coins
//        string selectedCurrency = currencyDropdown.options[currencyDropdown.value].text;
//        GenerateCoinsForSelectedCurrency(selectedCurrency);
//    }
//    public void GenerateCoinsForSelectedCurrency(string currency)
//    {
//        // Ensure coins are generated only once
//        if (!isCoinsGenerated)
//        {
//            switch (currency)
//            {
//                case "USD":
//                    GenerateCoins((int)getDataScript.priceOfUSDValue, bigCoin, "USD", "Big Coin");
//                    GenerateCoins((int)((getDataScript.priceOfUSDValue - (int)getDataScript.priceOfUSDValue) * 100), smallCoin, "USD", "Small Coin");
//                    break;
//                case "AUD":
//                    GenerateCoins((int)getDataScript.priceOfAUDValue, bigCoin, "AUD", "Big Coin");
//                    GenerateCoins((int)((getDataScript.priceOfAUDValue - (int)getDataScript.priceOfAUDValue) * 100), smallCoin, "AUD", "Small Coin");
//                    break;
//                case "JPY":
//                    GenerateCoins((int)getDataScript.priceOfJPYValue, bigCoin, "JPY", "Big Coin");
//                    GenerateCoins((int)((getDataScript.priceOfJPYValue - (int)getDataScript.priceOfJPYValue) * 100), smallCoin, "JPY", "Small Coin");
//                    break;
//                case "AED":
//                    GenerateCoins((int)getDataScript.priceOfAEDValue, bigCoin, "AED", "Big Coin");
//                    GenerateCoins((int)((getDataScript.priceOfAEDValue - (int)getDataScript.priceOfAEDValue) * 100), smallCoin, "AED", "Small Coin");
//                    break;
//                case "CHF":
//                    GenerateCoins((int)getDataScript.priceOfCHFValue, bigCoin, "CHF", "Big Coin");
//                    GenerateCoins((int)((getDataScript.priceOfCHFValue - (int)getDataScript.priceOfCHFValue) * 100), smallCoin, "CHF", "Small Coin");
//                    break;
//                default:
//                    Debug.Log("Invalid currency selection.");
//                    break;
//            }


//        }
//    }
//    void GenerateCoins(int quantity, GameObject coinPrefab, string currencyName, string coinType)
//    {
//        // Position to spawn coins (adjust as needed)
//        Vector3 position = new Vector3(0f, 1.5f, 4.2f); // Starting position

//        // Generate coins based on quantity
//        for (int i = 0; i < quantity; i++)
//        {
//            // Adjust the coin position (e.g., adding a slight offset each time to avoid overlap)
//            // Increment the x-position for each new coin (or use other logic for positioning)

//            // Instantiate the coin at the calculated position
//            Instantiate(coinPrefab, position, Quaternion.identity);

//            // Log to the console for visual feedback
//            Debug.Log($"Generated {coinType} for {currencyName}: {coinPrefab.name} at {position}");
//        }
//    }
//}