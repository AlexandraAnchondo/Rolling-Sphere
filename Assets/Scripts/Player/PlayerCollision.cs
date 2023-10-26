using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    AudioManager audioManager;

    void Start(){
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Obstacle")){
            FindObjectOfType<AudioManager>().Play("gameOver");
            PlayerManager.gameOver = true; 
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Mora")){
            FindObjectOfType<AudioManager>().Play("Mora");
            PlayerManager.moras+=5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Stardust")){
            FindObjectOfType<AudioManager>().Play("Mora");
            PlayerManager.stardust+=1;
            Destroy(other.gameObject);
        }
    }
}
