using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public static Stack<Page> pageStack = new Stack<Page>();

    

    private static bool initialized;

    void Awake(){
        //pageStack.Clear();
    }

    void Start(){
        closeAll();
    }

    public static void ClosePage(){
        if(pageStack.Count>0){
            pageStack.Pop().Close();
        }
    }

    public static void closeAll(){
        for(int i=0;i<pageStack.Count;i++){
            ClosePage();
        }
    }


    public static void AddOpenPage(Page page){
        pageStack.Push(page);
    }
}