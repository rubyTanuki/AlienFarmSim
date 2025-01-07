using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipDigitScript : MonoBehaviour
{
    [SerializeField] private GameObject img;
    Animator ani;

    


    // Start is called before the first frame update
    void Awake()
    {
        ani = img.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNum(int num){
        if(num>9) num = 9;
        ani.SetInteger("Num", num);
    }
}
