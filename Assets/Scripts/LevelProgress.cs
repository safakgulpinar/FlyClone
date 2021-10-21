using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private Image uiFillImage;
    [SerializeField] private TextMeshProUGUI uiStartText;
    [SerializeField] private TextMeshProUGUI uiEndText;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;

    private Vector3 endLinePosition;
    
    private float fullDistance;

    private void Start()
    {
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }

    public void SetLevelTexts(int level)
    {
        uiStartText.text = level.ToString();
        uiEndText.text = (level+1).ToString();
    }

    private float GetDistance ()
    {
        return Vector3.Distance(playerTransform.position, endLinePosition);
    }

    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
        
    }

    private void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance, 0f,  newDistance);

        UpdateProgressFill(progressValue);
        
    }




}
