using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point pos);

    [SerializeField] Transform spawnPoint;
    public static Vector2 MousePosition;

    Camera m_mainCamera;
    Rigidbody2D m_rigidbody;
    public static SpriteRenderer m_spriteRenderer;
    [SerializeField] Sprite IdleSprite;
    [SerializeField] Sprite StrongSprite;

    public static bool IsHolding;

    Vector2 m_cursorSetPoint;

    [SerializeField] ParticleSystem CursorParticle;
    float m_cursorParticleTimer = 0;

    List<PressurePlate> m_pressurePlates = new List<PressurePlate>();

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

        m_rigidbody = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        IsHolding = false;
        if(spawnPoint)
            transform.position = spawnPoint.position;

        m_mainCamera = Camera.main;
        
        m_cursorSetPoint = new Vector2(Screen.currentResolution.width/2f,Screen.currentResolution.height/2f);
        SetCursorPos((int)m_cursorSetPoint.x,(int)m_cursorSetPoint.y);
    }

    void Update() {
#if UNITY_EDITOR
        m_rigidbody.MovePosition(Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 5));
#else
        Point cursorPos = new Point();
        GetCursorPos(out cursorPos);

        Vector3 mouseMovementVector = m_mainCamera.ScreenToWorldPoint(new Vector2(cursorPos.X,cursorPos.Y))-m_mainCamera.ScreenToWorldPoint(m_cursorSetPoint);
        mouseMovementVector *= new Vector2(1,-1);
        m_rigidbody.MovePosition(transform.position + mouseMovementVector);
        SetCursorPos((int)m_cursorSetPoint.x,(int)m_cursorSetPoint.y);
#endif
        MousePosition = transform.position;

        if(m_cursorParticleTimer > 0)
            m_cursorParticleTimer -= Time.deltaTime;

        if(!IsHolding && Input.GetMouseButtonDown(1)){
            gameObject.tag = "Interactable";
            gameObject.layer = 0;
            m_spriteRenderer.sprite = StrongSprite;
            foreach(var pressurePlate in m_pressurePlates){
                pressurePlate.AddMouseTrigger();
            }
        } else if(!IsHolding && Input.GetMouseButtonUp(1)){
            if(gameObject.layer == 0){
                gameObject.tag = "Untagged";
                gameObject.layer = 8;
                m_spriteRenderer.sprite = IdleSprite;
                foreach(var pressurePlate in m_pressurePlates){
                    pressurePlate.RemoveMouseTrigger();
                }
            }
        }
        
    }
    void OnDisable() {
        Cursor.visible = true;
        m_spriteRenderer.enabled = false;
        m_spriteRenderer.enabled = false;
    }

    void OnEnable() {
        Cursor.visible = false;
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_spriteRenderer.enabled = true;
    }

    void OnCollisionStay2D(Collision2D other) {
        if(other.relativeVelocity.magnitude > 2){
            if(m_cursorParticleTimer <= 0){
                Instantiate(CursorParticle,other.contacts[0].point,Quaternion.identity);
                m_cursorParticleTimer = .2f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        var script = other.GetComponent<PressurePlate>();
        if(script){
            m_pressurePlates.Add(script);  
            Debug.Log("Added " + other.name);
        }  
    }
    void OnTriggerExit2D(Collider2D other) {
        var script = other.GetComponent<PressurePlate>();
        if(script){
            m_pressurePlates.Remove(script);
            Debug.Log("Removed " + other.name);
        }    
    }
}
