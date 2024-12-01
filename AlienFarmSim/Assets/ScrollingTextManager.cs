using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollingTextManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float scrollSpeed = 5;

    private TextMeshProUGUI cloneText;

    private RectTransform textRectTransform;
    private string sourceText;
    private string tempText;

    private Vector3 startPosition;

    void Awake()
    {
<<<<<<< Updated upstream
        textRectTransform = text.GetComponent<RectTransform>();

        /*
=======
        
        textRectTransform = text.GetComponent<RectTransform>();
        sourceText = text.text;
        createClone();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        sourceText = text.text;
        infoWidth = GetComponent<RectTransform>().rect.width + 10;
        textRectTransform.localPosition = new Vector3(7, 15, 0);
        StartCoroutine(Scroll());
    }

    public void startScroll(){
        StartCoroutine(Scroll());
    }
    public IEnumerator Scroll(){
        float width = text.preferredWidth + 5;
        if(width<infoWidth && cloneText != null) GameObject.Destroy(cloneText.gameObject);
        startPosition = textRectTransform.localPosition;
        float scrollPosition = 0;

        while(true){
            width = text.preferredWidth + 5;
            

            //recompute width if text has changed
            if(text.text != sourceText){
                sourceText = text.text;
                
                if(cloneText != null){
                    GameObject.Destroy(cloneText.gameObject);
                    if(width>infoWidth)
                        createClone();
                } 
            }


            //scroll by moving rect transform
            textRectTransform.localPosition = new Vector3((-scrollPosition%width) + startPosition.x, startPosition.y, startPosition.z);
            if(scrollPosition%width < scrollSpeed * 20 * Time.deltaTime) yield return new WaitForSeconds(1.5f);
            if(scrollPosition>width) scrollPosition = 0;
            
            if(width>infoWidth){
                scrollPosition += scrollSpeed * 20 * Time.deltaTime;
            }
            yield return null;
        }
    }

    private void createClone(){
>>>>>>> Stashed changes
        cloneText = Instantiate(text) as TextMeshProUGUI;
        cloneText.SetText(text.text);
        RectTransform cloneRectTransform = cloneText.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(textRectTransform);
        cloneRectTransform.anchorMin = new Vector2(1, 0.5f);
        cloneRectTransform.localScale = new Vector3(1,1,1);
<<<<<<< Updated upstream
        */
    }

    // Start is called before the first frame update
    IEnumerator  Start()
    {
        float width = text.preferredWidth;
        Vector3 startPosition = new Vector3(10, 13, 0);
        Debug.Log(textRectTransform.position);

        float scrollPosition = 0;

        while(true){
            //recompute width if text has changed
            /*
            if(text.hasChanged){
                width = text.preferredWidth;
                cloneText.text = text.text;
            }
            */

            //scroll by moving rect transform
            //textRectTransform.position = new Vector3(-scrollPosition % width, startPosition.y, startPosition.z);
            textRectTransform.position = new Vector3(10, 13, 0);
            scrollPosition += scrollSpeed * 20 * Time.deltaTime;

            yield return null;
        }
=======
        cloneRectTransform.anchoredPosition = new Vector3(5, 0, 0);
        Canvas.ForceUpdateCanvases();
>>>>>>> Stashed changes
    }
}
