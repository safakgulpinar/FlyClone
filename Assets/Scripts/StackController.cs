using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackController : MonoBehaviour
{

    [SerializeField] private List<GameObject> stackList = new List<GameObject>();
    [SerializeField] private Transform startPos1;
    [SerializeField] private Transform startPos2;
    [SerializeField] private Vector3 posOffset;
    private Vector3 start1, start2;
    private int yCount1 = 1;
    private int yCount2 = 1;
    [SerializeField] private TextMeshPro countText;
    [SerializeField] private float deleteTime = 0.1f;
    [SerializeField]private float deleteTimeHolder = 0.1f;

        
    [SerializeField] private Ortiz _ortiz;
    [SerializeField] private InfoText _infoText;

    public void AddList(GameObject addObj)
    {
       if(stackList.Count < 81)
        {  
            if (!stackList.Contains(addObj))
            {
                stackList.Add(addObj);
            

            int mod = (stackList.Count - 1) % 2;
            switch(mod)
            {
             case 0:
                stackList[stackList.Count-1].transform.parent = startPos1;
                start1 = new Vector3(startPos1.position.x, startPos1.position.y + (posOffset.y * yCount1), startPos1.position.z);
                stackList[stackList.Count - 1].transform.position = start1;
                stackList[stackList.Count - 1].transform.rotation = transform.rotation;
                yCount1++;
                break;
           
             case 1:
                stackList[stackList.Count - 1].transform.parent = startPos2;
                start2 = new Vector3(startPos2.position.x, startPos2.position.y + (posOffset.y * yCount2), startPos2.position.z);
                stackList[stackList.Count - 1].transform.position = start2;
                stackList[stackList.Count - 1].transform.rotation = transform.rotation;
                yCount2++;
                break;
             }

            countText.SetText((stackList.Count - 1).ToString());

                
        }
    } 
}

    private void Update()
    {
        if (stackList.Count == 80)
        {
            Debug.Log("z");            
            _infoText.onInfoText();
            _ortiz.onOrtiz();
        }
    }

    private void RemoveObj(GameObject removeObj)
    {
        if (stackList.Contains(removeObj))
        {
            removeObj.GetComponent<Rigidbody>().isKinematic = false;
            stackList.Remove(removeObj);
            Destroy(removeObj, 1f);

            countText.SetText((stackList.Count - 1).ToString());
            if (stackList.Count - 1 <= 0)
                countText.SetText("0");

            else
                countText.SetText((stackList.Count - 1).ToString());
        }
                
    }

    public IEnumerator RemoveLastOne()
    {
        yield return new WaitForSeconds(deleteTime);
        deleteTime *= 1;
        RemoveObj(stackList[stackList.Count - 1]);
    }

    public void TimeReset()
    {
        deleteTime = deleteTimeHolder;
    }
}
