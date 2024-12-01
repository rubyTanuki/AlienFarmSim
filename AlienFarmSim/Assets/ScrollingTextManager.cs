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

    void Awake()
    {
        textRectTransform = text.GetComponent<RectTransform>();

        /*
        cloneText = Instantiate(text) as TextMeshProUGUI;
        RectTransform cloneRectTransform = cloneText.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(textRectTransform);
        cloneRectTransform.anchorMin = new Vector2(1, 0.5f);
        cloneRectTransform.localScale = new Vector3(1,1,1);
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
    }
}
