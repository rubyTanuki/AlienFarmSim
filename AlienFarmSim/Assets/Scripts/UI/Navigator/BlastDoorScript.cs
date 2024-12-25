using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlastDoorScript : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    [Header(" ")]

    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject doorRight;

    private RectTransform leftTransform;
    private RectTransform rightTransform;

    private BoxCollider2D boxCollider;
    
    private Vector3 blastDoorOpenPos = new Vector3(450, 0, 0);
    private Vector3 blastDoorClosedPos = new Vector3(-5, 0, 0);

    Camera m_MainCamera;

    public bool isOpen;
    public bool isClosed;
    public bool hovering;

    private readonly float LERP_SPEED = 10f;

    private bool open = true;

    void Awake(){
        //this.gameObject.SetActive(true);
        boxCollider = GetComponent<BoxCollider2D>();
        m_MainCamera = Camera.main;
        rightTransform = doorRight.GetComponent<RectTransform>();
        leftTransform = doorLeft.GetComponent<RectTransform>();
        Close();
    }
    void OnEnable(){
        gm.setCameraTarget(this.gameObject.transform.position.x);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(open){
            openBlastDoors();
        }else{
            closeBlastDoors();
        }
        
        isOpen = rightTransform.anchoredPosition.x>425 && open;
        isClosed = rightTransform.anchoredPosition.x<0 && !open;

        boxCollider.enabled = isClosed;
        // if(Input.GetKeyDown(KeyCode.P)){
        //     open = !open;
        // }

        if(hovering && Input.GetKeyDown(KeyCode.F)){
            Open();
        }
        hovering = false;
        
    }

    public void Open() { open = true; GameManager.addToCloses(Close);}
    public void Close(){ open = false;}

    // public void forceOpen(){
    //     forced = true;
    //     rightTransform.anchoredPosition = blastDoorOpenPos;
    //     leftTransform.anchoredPosition = -blastDoorOpenPos;
    // }
    // public void forceClosed(){
    //     forced = true;
    //     rightTransform.anchoredPosition = blastDoorClosedPos;
    //     leftTransform.anchoredPosition = -blastDoorClosedPos;
    // }

    public void openBlastDoors(){
        // if(rightTransform.anchoredPosition.x>300){
        //     var size = m_MainCamera.orthographicSize;
        //     if(size>6) m_MainCamera.orthographicSize = size- (14*Time.deltaTime);
        // }
        gm.setCameraSizeTarget(6);
        rightTransform.anchoredPosition = Vector3.Lerp(rightTransform.anchoredPosition, blastDoorOpenPos, LERP_SPEED*Time.deltaTime);
        leftTransform.anchoredPosition = Vector3.Lerp(leftTransform.anchoredPosition, -blastDoorOpenPos, LERP_SPEED*Time.deltaTime); 
    }
    public void closeBlastDoors(){
        gm.setCameraSizeTarget(9.5f);
        //m_MainCamera.orthographicSize = Mathf.Lerp(Math.Min(m_MainCamera.orthographicSize, 9.5f), 10, 5*Time.deltaTime);
        rightTransform.anchoredPosition = Vector3.Lerp(rightTransform.anchoredPosition, blastDoorClosedPos, LERP_SPEED*Time.deltaTime);
        leftTransform.anchoredPosition = Vector3.Lerp(leftTransform.anchoredPosition, -blastDoorClosedPos, LERP_SPEED*Time.deltaTime); 
    }
}
