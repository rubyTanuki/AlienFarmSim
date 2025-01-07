using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlipNumberScript : MonoBehaviour
{
    private List<FlipDigitScript> digits = new List<FlipDigitScript>();

    private int MAX_VALUE;

    public int startNum;

    public int currentNum;

    // Start is called before the first frame update
    void Awake()
    {
        digits.Clear();
        for(int i= (gameObject.transform.childCount-1);i>=0;i--){
            digits.Add(gameObject.transform.GetChild(i).gameObject.GetComponent<FlipDigitScript>());
        }

        

        // foreach(Transform child in gameObject.transform){
        //     digits.Add(child.GetComponent<FlipDigitScript>());
        // }
        int dig = digits.Count;
        string max = "";
        for(int i=0;i<dig;i++) max += "9";
        MAX_VALUE = Int32.Parse(max);
    }

    void Start(){
        SetNum(startNum);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SetNum(currentNum + 1);
        }
        if(Input.GetMouseButtonDown(1)){
            SetNum(currentNum + 5);
        }
        if(Input.GetMouseButtonDown(2)){
            SetNum(UnityEngine.Random.Range(0, MAX_VALUE));
        }
    }

    public void SetNum(int num){
        int n = num;
        currentNum = n;
        if(n>MAX_VALUE) n = MAX_VALUE;
        foreach(FlipDigitScript digit in digits){
            digit.SetNum(n%10);
            n = n/10;
        }
    }
}
