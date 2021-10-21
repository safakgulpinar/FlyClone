using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    [SerializeField] private Image photoImage;    

    public void onPhoto()
    {
        
        this.gameObject.GetComponent<Image>().enabled = true;
        Destroy(gameObject, 2f);
        
    }
    
}
