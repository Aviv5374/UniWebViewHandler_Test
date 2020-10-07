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

    public void OnTabbed(GameObject buttonTMP)
    {
        string buttonTXT = buttonTMP.GetComponent<TextMeshProUGUI>().text;

        if (buttonTXT == "=")
        {
            calculatorScreen.text = calculator.Calculat(calculatorScreen.text);
        }
        else if (buttonTXT == "C")
        {
            calculatorScreen.text = "0";
        }
        else
        {
            if (calculatorScreen.text == "0")
            {
                calculatorScreen.text = buttonTXT;
            }
            else
            {
                calculatorScreen.text += buttonTXT;
            }
        }

    }

}
