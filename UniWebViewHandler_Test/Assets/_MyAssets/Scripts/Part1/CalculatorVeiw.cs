using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorVeiw : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI calculatorScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTabb(GameObject buttenTMP)
    {
        string newTXT = buttenTMP.GetComponent<TextMeshProUGUI>().text;
        calculatorScreen.text += newTXT;
    }

}
