using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollingTextManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float scrollSpeed = 10;

    public TextMeshProUGUI cloneText;

    private RectTransform textRectTransform;
    private string sourceText;
    private float infoWidth;

    void Awake()
    {
        Canvas.ForceUpdateCanvases();
        textRectTransform = text.GetComponent<RectTransform>();
        //createClone();
    }

    // Start is called before the first frame update
    void Start()
    {
        sourceText = text.text;
        infoWidth = GetComponent<RectTransform>().rect.width + 10;
        Debug.Log(infoWidth);
        StartCoroutine(Scroll());
    }
    void OnEnable()
    {
        sourceText = text.text;
        infoWidth = GetComponent<RectTransform>().rect.width + 10;
        StartCoroutine(Scroll());
    }


    IEnumerator Scroll(){
        float width = text.preferredWidth + 5;
        if(cloneText == null && width>infoWidth) createClone();
        if(cloneText != null && width<infoWidth) GameObject.Destroy(cloneText);
        Vector3 startPosition = textRectTransform.localPosition;

        float scrollPosition = 0;

        while(true){
            if(cloneText != null){
                cloneText.GetComponent<RectTransform>().localPosition = new Vector3(5, 0, 0);
            }

            //recompute width if text has changed
            if(text.text != sourceText){
                sourceText = text.text;
                width = text.preferredWidth + 5;
                if(cloneText == null && width>infoWidth) createClone();
                if(cloneText != null && width<infoWidth) GameObject.Destroy(cloneText);
            }

            //scroll by moving rect transform
            textRectTransform.localPosition = new Vector3((-scrollPosition % width), startPosition.y, startPosition.z);
            textRectTransform.localPosition = new Vector3(textRectTransform.localPosition.x + startPosition.x, startPosition.y, startPosition.z);
            if(scrollPosition%width < scrollSpeed * 20 * Time.deltaTime) yield return new WaitForSeconds(1.5f);
            
            if(width>infoWidth){
                scrollPosition += scrollSpeed * 20 * Time.deltaTime;
            }
            yield return null;
        }
    }

    private void createClone(){
        cloneText = Instantiate(text) as TextMeshProUGUI;
        RectTransform cloneRectTransform = cloneText.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(textRectTransform);
        cloneRectTransform.anchorMin = new Vector2(1, 0.5f);
        cloneRectTransform.localPosition = new Vector3(5, 0, 0);
        cloneRectTransform.localScale = new Vector3(1,1,1);
        cloneText.text = text.text;
        
        Debug.Log("Local: " +cloneRectTransform.localPosition);
        Debug.Log("World: " +cloneRectTransform.position);
    }
}
