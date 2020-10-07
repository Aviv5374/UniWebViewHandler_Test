using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Calculat(string lol)
    {
        string entcalcResult = "Calculat"; //string.Empty;
        int expressionLength = lol.Length;
        List<float> expressionEntries = new List<float>();
        List<char> expressionOperators = new List<char>();

        /*
        Well, the general idea is this: I get a string and break it down into an array of chars.
        I go through the array and from it, I separate the operations and numbers into different lists. 
        The operations remain as chars, and the numbers in the first place become integers, and later I have to see how I deal with floats.
        When there are decimal numbers and bigger I will take the previous number I found multiply it by 10 and add to it the last number I found, 
        and I will repeat this process until the next value in the array is an operation or I have reached the end of the array. 
        I assume that makes the list count of operations smaller than the list count of numbers. 
        When this is not the case I calculate the first operation with zero.
        That is, if the original string is: -1 + 1, the actual calculation will be 0 - 1 + 1.
        After I have the two lists I send them to a method which operation needs to be done on the numbers, 
        i.e.expressionEntries[INDEX] expressionOperators[INDEX] expressionEntries[INDEX + 1].
        In the first step do the calculations from right to left without considering the right order of the operations. 
        In the second stage, I send the two lists to a method that arranges them so that the order of the operations will be in the correct order, with the priority that the arrangement will allow the correct execution from right to left.
        Finally, the string version of the result (entcalcResult) will be sent back to CalculatorVeiw which updates the screen.
        */

        return entcalcResult;
    }
}
