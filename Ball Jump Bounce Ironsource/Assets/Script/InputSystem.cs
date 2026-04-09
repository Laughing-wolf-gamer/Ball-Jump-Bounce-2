using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputSystem : MonoBehaviour{
    [SerializeField] private bool Onpc;
    [SerializeField] private bool isTouch;
    public Action<float> onTouch;
    public bool touchBegan;
    private float lastMousePosX;
    private bool lastMousePosValid;
    private void Update() {
        // Mobile / touch input
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                touchBegan = true;
            }
            if(touch.phase == TouchPhase.Moved){
                if(isTouch && onTouch != null){
                    onTouch(touch.deltaPosition.x);
                }
            }
            return;
        }

        // PC / WebGL mouse input
        // Enabled when Onpc is true or when running as WebGL build
        if (Onpc || Application.platform == RuntimePlatform.WebGLPlayer){
            if (Input.GetMouseButtonDown(0)){
                touchBegan = true;
                lastMousePosX = Input.mousePosition.x;
                lastMousePosValid = true;
            }

            if (Input.GetMouseButton(0)){
                if (!lastMousePosValid){
                    lastMousePosX = Input.mousePosition.x;
                    lastMousePosValid = true;
                }

                float currentX = Input.mousePosition.x;
                float deltaX = currentX - lastMousePosX;
                lastMousePosX = currentX;

                if (isTouch && onTouch != null){
                    onTouch(deltaX);
                }
            }
            else{
                lastMousePosValid = false;
            }
        }
    }

    public void setTouch(bool value){
        isTouch = value;
    }
    public bool GetTouch(){
        return isTouch;
    }
    


    
}
