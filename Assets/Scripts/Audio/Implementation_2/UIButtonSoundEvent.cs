 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;
 using System.Collections;
 

 public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {    
 
    [SerializeField] string soundName;
    
    public void OnPointerEnter( PointerEventData ped ) {
        SoundManager.PlaySound(soundName);
    }
 
    public void OnPointerDown( PointerEventData ped ) {
        // SoundManager.PlaySound("MenuButton_hover");
    }    
 }