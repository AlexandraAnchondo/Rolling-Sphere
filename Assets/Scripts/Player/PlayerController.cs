using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour{
    public float speed; 
    float rotationSpeed = 0.8f; 
    private int limit = 5;

    void Update(){
        if(!PlayerManager.levelStarted)
            return;
        transform.Translate(0,0,speed*Time.deltaTime);
        if(Touchscreen.current != null){
            Vector2 delta = Touchscreen.current.primaryTouch.delta.ReadValue();
            transform.Rotate(0,0, delta.x * rotationSpeed);
        }
        if(PlayerManager.score > limit && speed < 45){
            limit+=5;
            speed+=2;
        }
    }
}
