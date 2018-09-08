using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    //Component
    [SerializeField]
    private Camera m_CharacterCamera;
    private GameObject m_Character;

    //Hide Mouse
    private bool m_lockCursor = true;

    //Camera Movement Variable
    private Vector2 m_MouseLook;
    private Vector2 m_SmoothV;
    [SerializeField]
    private float sensitivity = 5.0f;
    [SerializeField]
    private float smoothing = 2.0f;

    //Camera Shake Variable
    [SerializeField]
    private float m_duration = 1f;
    [SerializeField]
    private float m_magnitude = 5f;

    //Player Movement 
    [SerializeField]
    private float m_CharacterSpeed = 10.0f;













    // Use this for initialization
    void Start() {

        if (m_CharacterCamera == null) {
            Debug.LogError("You have not attached a Camera reference to this GameObject");
        }

        m_Character = this.gameObject;




    }

    // Update is called once per frame
    void Update() {



        CharacterMovement();
        CameraMovement();

        if (Input.GetKey("escape")) {
            m_lockCursor = !m_lockCursor;
        }
        Cursor.lockState = m_lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !m_lockCursor;

        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Starting");
            StartCoroutine(CameraShake());
        }

    }


    void CharacterMovement(){
        float translation = Input.GetAxis("Vertical") * m_CharacterSpeed;
        float straffe = Input.GetAxis("Horizontal") * m_CharacterSpeed;
        //Keep Movement Smooth in Update()
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        m_Character.transform.Translate(straffe, 0, translation);

    }

    void CameraMovement() {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        m_SmoothV.x = Mathf.Lerp(m_SmoothV.x, md.x, 1f / smoothing);
        m_SmoothV.y = Mathf.Lerp(m_SmoothV.y, md.y, 1f / smoothing);
        m_MouseLook += m_SmoothV;

        m_CharacterCamera.transform.localRotation = Quaternion.AngleAxis(-m_MouseLook.y, Vector3.right);
        m_Character.transform.localRotation = Quaternion.AngleAxis(m_MouseLook.x, m_Character.transform.up);
    }

    public void setShake(float m_duration, float m_magnitude) {
        this.m_duration = m_duration;
        this.m_magnitude = m_magnitude;
    }


    IEnumerator CameraShake() {
        Vector3 cameraOriginalPos = m_CharacterCamera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < m_duration) {
            float x = Random.Range(-1f, 1f) * m_magnitude;
            float y = Random.Range(-1f, 1f) * m_magnitude;

            m_CharacterCamera.transform.localPosition = new Vector3(x,y, cameraOriginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        m_CharacterCamera.transform.localPosition = cameraOriginalPos;
        Debug.Log("Ending");
    }

}
