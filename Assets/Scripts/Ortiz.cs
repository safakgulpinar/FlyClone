using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ortiz : MonoBehaviour
{
    [SerializeField] private Image photoImage;

    public void onOrtiz()
    {

        this.gameObject.GetComponent<Image>().enabled = true;
        Destroy(gameObject, 3.5f);

    }

}
