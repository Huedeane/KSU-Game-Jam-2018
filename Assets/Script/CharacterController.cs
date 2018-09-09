using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {


    //Component
    [SerializeField]
    private Camera m_CharacterCamera;
    private GameObject m_Character;

    //Hide Mouse
    private bool m_LockCursor = true;

    //Camera Movement Variable
    private Vector2 m_MouseLook;
    private Vector2 m_SmoothV;
    [SerializeField]
    private float m_Sensitivity = 5.0f;
    [SerializeField]
    private float m_Smoothing = 2.0f;

    //Camera Shake Variable
    [SerializeField]
    private float m_Duration = 1f;
    [SerializeField]
    private float m_Magnitude = 5f;

    //Player Movement 
    [SerializeField]
    private float m_CharacterSpeed = 10.0f;

    //Object Pickup Variable
    [SerializeField]
    private bool m_ObjectFocus = false;
    private string m_InteractText = "";
    private bool m_ObjectInHand = false;


    // Use this for initialization
    void Start() {

        if (CharacterCamera == null) {
            Debug.LogError("You have not attached a Camera reference to this GameObject");
        }

        Character = this.gameObject;
        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void Update() {



        CharacterMovement();
        CameraMovement();
        PickupObject();

        if (Input.GetKeyDown("escape")) {
            Debug.Log(Time.timeScale);

            if (Time.timeScale == 1)
            {
                Debug.Log("Test");
                Time.timeScale = 0;
            }
            else {
                Time.timeScale = 1;
            }
            
            
        }

        if (Input.GetKey("space")) {
            Debug.Log("Starting");
            //StartCoroutine(CameraShake());
        }

    }


    void CharacterMovement(){
        float translation = Input.GetAxis("Vertical") * CharacterSpeed;
        float straffe = Input.GetAxis("Horizontal") * CharacterSpeed;
        //Keep Movement Smooth in Update()
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        Character.transform.Translate(straffe, 0, translation);

    }

    void CameraMovement() {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));



        md = Vector2.Scale(md, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
        SmoothV = new Vector2(Mathf.Lerp(SmoothV.x, md.x, 1f / Smoothing), Mathf.Lerp(SmoothV.y, md.y, 1f / Smoothing));
        MouseLook += SmoothV;

        CharacterCamera.transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        Character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, Character.transform.up);
    }

    public void setShake(float m_duration, float m_magnitude) {
        this.Duration = m_duration;
        this.Magnitude = m_magnitude;
    }

    /*
    IEnumerator CameraShake() {
        Vector3 cameraOriginalPos = CharacterCamera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < Duration) {
            float x = Random.Range(-1f, 1f) * Magnitude;
            float y = Random.Range(-1f, 1f) * Magnitude;

            CharacterCamera.transform.localPosition = new Vector3(x,y, cameraOriginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        CharacterCamera.transform.localPosition = cameraOriginalPos;
        Debug.Log("Ending");
    }*/

    void PickupObject() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 2.5f))
        {

            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.tag == "PickupAble" && hitObject != null && m_ObjectInHand == false)
            {
                ObjectFocus = true;
                InteractText = "Press E to pickup " + hitObject.name;
                if (Input.GetKey("e"))
                {
                    m_ObjectInHand = true;
                    Object.Destroy(hitObject);
                }
            }

        }
        else
        {
            ObjectFocus = false;
            InteractText = "";
        }
    }


    public Camera CharacterCamera
    {
        get
        {
            return m_CharacterCamera;
        }

        set
        {
            m_CharacterCamera = value;
        }
    }

    public GameObject Character
    {
        get
        {
            return m_Character;
        }

        set
        {
            m_Character = value;
        }
    }

    public bool LockCursor
    {
        get
        {
            return m_LockCursor;
        }

        set
        {
            m_LockCursor = value;
        }
    }

    public Vector2 MouseLook
    {
        get
        {
            return m_MouseLook;
        }

        set
        {
            m_MouseLook = value;
        }
    }

    public Vector2 SmoothV
    {
        get
        {
            return m_SmoothV;
        }

        set
        {
            m_SmoothV = value;
        }
    }

    public float Sensitivity
    {
        get
        {
            return m_Sensitivity;
        }

        set
        {
            m_Sensitivity = value;
        }
    }

    public float Smoothing
    {
        get
        {
            return m_Smoothing;
        }

        set
        {
            m_Smoothing = value;
        }
    }

    public float Duration
    {
        get
        {
            return m_Duration;
        }

        set
        {
            m_Duration = value;
        }
    }

    public float Magnitude
    {
        get
        {
            return m_Magnitude;
        }

        set
        {
            m_Magnitude = value;
        }
    }

    public float CharacterSpeed
    {
        get
        {
            return m_CharacterSpeed;
        }

        set
        {
            m_CharacterSpeed = value;
        }
    }

    public bool ObjectFocus
    {
        get
        {
            return m_ObjectFocus;
        }

        set
        {
            m_ObjectFocus = value;
        }
    }

    public string InteractText
    {
        get
        {
            return m_InteractText;
        }

        set
        {
            m_InteractText = value;
        }
    }



}
