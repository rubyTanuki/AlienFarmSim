using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class util_slideIn : MonoBehaviour
{
    [Tooltip("1 = up | 2 = down | 3 = right | 4 = left")]
    [Range(1, 4)]
    public int direction;

    [SerializeField] private int DISTANCE = 400;
    [SerializeField] private float SPEED = 10f;

    private Vector3 targetPosition;
    private Vector3 outPosition;

    private RectTransform rectTransform;

    private bool init = false;

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        targetPosition = rectTransform.anchoredPosition;
        switch(direction){
            case 1:
                outPosition = new Vector3(targetPosition.x, targetPosition.y+DISTANCE, targetPosition.z);
                break;
            case 2:
                outPosition = new Vector3(targetPosition.x, targetPosition.y-DISTANCE, targetPosition.z);
                break;
            case 3:
                outPosition = new Vector3(targetPosition.x+DISTANCE, targetPosition.y, targetPosition.z);
                break;
            case 4:
            outPosition = new Vector3(targetPosition.x-DISTANCE, targetPosition.y, targetPosition.z);
                break;
            default:
                outPosition = new Vector3(targetPosition.x, targetPosition.y+DISTANCE, targetPosition.z);
                break;
        }
        rectTransform.anchoredPosition = outPosition;
        init = true;
    }
    void OnEnable(){
        if(init)
            rectTransform.anchoredPosition = outPosition;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime*SPEED);
    }
}
