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

    private float infoWidth;

    private Vector3 startPosition;

    [SerializeField] private float scrollPos;

    void Awake()
    {
        textRectTransform = text.GetComponent<RectTransform>();
        sourceText = text.text;
        //createClone();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        sourceText = text.text;
        infoWidth = GetComponent<RectTransform>().rect.width + 10;
        textRectTransform.anchoredPosition = new Vector3(0, textRectTransform.anchoredPosition.y, 0);
        StartCoroutine(Scroll());
    }
    void Start(){
        infoWidth = GetComponent<RectTransform>().rect.width + 10;
    }

    public void startScroll(){
        StartCoroutine(Scroll());
    }
    public IEnumerator Scroll(){
        float width = text.preferredWidth+5;
        //if(width<infoWidth && cloneText != null) GameObject.Destroy(cloneText.gameObject);
        startPosition = textRectTransform.anchoredPosition;
        float scrollPosition = 0;

        while(true){
            width = text.preferredWidth+5;
            //Debug.Log(this.gameObject.name + " " + infoWidth + " " + width);

            //recompute width if text has changed
            if(text.text != sourceText){
                sourceText = text.text;
                
                if(cloneText != null){
                    GameObject.Destroy(cloneText.gameObject);
                    if(width>=infoWidth)
                        createClone();
                } 
                if(cloneText == null && width>=infoWidth){
                    createClone();
                }
            }


            //scroll by moving rect transform
            textRectTransform.anchoredPosition = new Vector3((-scrollPosition%width), startPosition.y, startPosition.z);
            textRectTransform.anchoredPosition = new Vector3(textRectTransform.anchoredPosition.x + startPosition.x, startPosition.y, startPosition.z);
            if(scrollPosition%width < scrollSpeed * 20 * Time.deltaTime) yield return new WaitForSeconds(1f);
            if(scrollPosition>width) scrollPosition = 0;
            scrollPos = scrollPosition%width;
            
            if(width>infoWidth){
                scrollPosition += scrollSpeed * 20 * Time.deltaTime;
            }else{
                textRectTransform.anchoredPosition = new Vector3(0, textRectTransform.anchoredPosition.y, 0);
            }
            yield return null;
        }
    }

    private void createClone(){
        cloneText = Instantiate(text) as TextMeshProUGUI;
        cloneText.SetText(text.text);
        RectTransform cloneRectTransform = cloneText.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(textRectTransform);
        cloneRectTransform.anchorMin = new Vector2(1, 0.5f);
        cloneRectTransform.localScale = new Vector3(1,1,1);
        cloneRectTransform.anchoredPosition = new Vector3(5, 0, 0);
        Canvas.ForceUpdateCanvases();
    }
}
