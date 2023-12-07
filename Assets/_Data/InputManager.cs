using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mouseWorldPos;

    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;

    public float OnFiring { get => onFiring; }

    protected Vector4 direction;

    public Vector4 Direction => direction;

    private void Awake() {
        if(InputManager.instance != null)   Debug.LogError("Only 1 Inputmanager is allowed to exist!");
        InputManager.instance = this;
    }

    void Update()
    {
        this.GetMouseDown();
        GetDirectionByKeyDown();
    }

    void FixedUpdate() {
        this.GetMousePos();
    }

    protected virtual void GetMouseDown() {
        this.onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos() {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetDirectionByKeyDown()
    {
        direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;

        if(direction.x == 0) direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;

        if(direction.y == 0) direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;
        
        direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;

        if(direction.z == 0) direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        
        direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;

        if(direction.w == 0) direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;

        // if(direction.x == 1) Debug.Log("Left");
        // if(direction.y == 1) Debug.Log("Right");
        // if(direction.z == 1) Debug.Log("Up");
        // if(direction.w == 1) Debug.Log("Down");
    }
}
