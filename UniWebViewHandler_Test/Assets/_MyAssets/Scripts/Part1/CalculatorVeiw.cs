using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorVeiw : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI calculatorScreen;


    Calculator calculator;

    // Start is called before the first frame update
    void Start()
    {
        calculator = GetComponent<Calculator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTabbed(GameObject buttenTMP)
    {
        string newTXT = buttenTMP.GetComponent<TextMeshProUGUI>().text;

        if (newTXT == "=")
        {
            calculatorScreen.text = calculator.Calculat(calculatorScreen.text);
        }
        else if (newTXT == "C")
        {
            calculatorScreen.text = "0";
        }
        else
        {
            if (calculatorScreen.text == "0")
            {
                calculatorScreen.text = newTXT;
            }
            else
            {
                calculatorScreen.text += newTXT;
            }
        }

    }

}
