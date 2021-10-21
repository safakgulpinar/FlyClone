using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;

    public void onInfoText()
    {

        this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        Destroy(gameObject, 3.5f);

    }
}
