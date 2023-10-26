using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaimonSelector : MonoBehaviour
{
    public GameObject[] paimonSkins; 
    public Paimon[] paimons; 
    public Button[] buttons;

    public Button unlockButtonMora;
    public Button unlockButtonStardust; 

    int selectedPaimon; 

    void Awake(){
        int counter = 0; 
        foreach(Paimon p in paimons){
            p.index = counter;
            if(counter == 0){
                p.isLocked = false;
            } else {
                if(PlayerPrefs.GetInt(p.index.ToString(), 1) == 1)
                    p.isLocked = true;
                else 
                    p.isLocked = false;
                buttons[p.index].interactable = !p.isLocked;
            }
            counter++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedPaimon = PlayerPrefs.GetInt("selectedPaimon", 0);
        foreach(GameObject skin in paimonSkins){
            skin.SetActive(false);
        }
        paimonSkins[selectedPaimon].SetActive(true);
    }

    void Update(){
        if(PlayerPrefs.GetInt("TotalMoras", 0) < 20){
            unlockButtonMora.interactable = false;
        } else{
            unlockButtonMora.interactable = true;
        }
        if(PlayerPrefs.GetInt("TotalStardust", 0) < 10){
            unlockButtonStardust.interactable = false;
        } else{
            unlockButtonStardust.interactable = true;
        }
    }

    public void ChangeSkin(int index){
        paimonSkins[selectedPaimon].SetActive(false);
        selectedPaimon = index;
        paimonSkins[selectedPaimon].SetActive(true);
        PlayerPrefs.SetInt("selectedPaimon", index);
    }

    public void Unlock(){
        List<Paimon> lockedPaimons = new List<Paimon>();
        
        //List all the lock items
        foreach(Paimon p in paimons){
            if(p.isLocked){
                lockedPaimons.Add(p);
            }
        }
        if(lockedPaimons.Count == 0)
            return;

        //Select random Paimon
        int randomPaimon = Random.Range(0,lockedPaimons.Count);

        //Unlock Paimon
        int paimonIndex = lockedPaimons[randomPaimon].index;
        paimons[paimonIndex].isLocked = false;
        buttons[paimonIndex].interactable = true;
        PlayerPrefs.SetInt(paimonIndex.ToString(), 0);
        if(lockedPaimons.Count != 0 && PlayerPrefs.GetInt("TotalStardust", 0) > 9){
            unlockButtonStardust.onClick.AddListener(OnStardustPressed);
        }
        if(lockedPaimons.Count != 0 && PlayerPrefs.GetInt("TotalMoras", 0) > 19){
            unlockButtonMora.onClick.AddListener(OnMorasPressed);
        }

        //Select Paimon
        buttons[paimonIndex].onClick.Invoke();
    }

    public void OnMorasPressed(){
        PlayerPrefs.SetInt("TotalMoras", PlayerPrefs.GetInt("TotalMoras") - 20);
    }

    public void OnStardustPressed(){
        PlayerPrefs.SetInt("TotalStardust", PlayerPrefs.GetInt("TotalStardust") - 10);
    }
}
