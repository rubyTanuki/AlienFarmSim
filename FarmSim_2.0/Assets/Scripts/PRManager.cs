using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRManager : MonoBehaviour
{
    private RectTransform rectTransform;

    private Page page;

    public bool zoomed;

    public GameObject selectedRow;

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        page = GetComponent<Page>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PageManager.pageStack.Peek() == page) ZoomOut();

        if(zoomed){
            ZoomIn(selectedRow.GetComponent<RectTransform>());
        }
    }

    public void ZoomIn(RectTransform rowTransform){
        zoomed = true;
        selectedRow = rowTransform.gameObject;
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, new Vector3(1.3f,1.3f,1f), 8*Time.deltaTime);

        //move to the right position based on rowTransform
        Vector3 anchPos = rowTransform.anchoredPosition;
        Vector3 targetPosition = new Vector3((anchPos.x <250?130.5f:-120)*1.3f, (0-anchPos.y-143)*1.3f, 0);
        targetPosition.x -= 150;
        targetPosition.y -= 80;
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, targetPosition, 8*Time.deltaTime);
    }
    public void ZoomOut(){
        zoomed = false;
        selectedRow = null;
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, new Vector3(1f,1f,1f), 8*Time.deltaTime);
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, new Vector3(0,0,0), 8*Time.deltaTime);
    }
}
