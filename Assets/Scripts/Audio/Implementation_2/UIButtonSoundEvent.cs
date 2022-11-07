 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;
 using System.Collections;
 

 public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {    
 
    [SerializeField] string soundName;
    private Button button;

    private void Awake() {
        this.button = this.gameObject.GetComponent<Button>();
    }

    private void SetButtonSound()
    {
        this.button.onClick.AddListener(delegate {SoundManager.PlaySound("MenuButton");});
    }

    public void OnPointerEnter( PointerEventData ped ) {
        SoundManager.PlaySound(soundName);
    }
 
    public void OnPointerDown( PointerEventData ped ) {
        // SoundManager.PlaySound("MenuButton_hover");
    }    
 }