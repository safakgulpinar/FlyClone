using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsStack : MonoBehaviour
{
    [SerializeField] private List<GameObject> botStackList = new List<GameObject>();
    [SerializeField] private Transform botStartPos1;
    [SerializeField] private Transform botStartPos2;
    [SerializeField] private Vector3 botPosOffset;
    private Vector3 botStart1, botStart2;
    private int yCount1 = 1;
    private int yCount2 = 1;

    public void AddList(GameObject addObj)
    {
        if (botStackList.Count < 81)
        {
            if (!botStackList.Contains(addObj))
            {
                botStackList.Add(addObj);


                int mod = (botStackList.Count - 1) % 2;
                switch (mod)
                {
                    case 0:
                        botStackList[botStackList.Count - 1].transform.parent = botStartPos1;
                        botStart1 = new Vector3(botStartPos1.position.x, botStartPos1.position.y + (botPosOffset.y * yCount1), botStartPos1.position.z);
                        botStackList[botStackList.Count - 1].transform.position = botStart1;
                        botStackList[botStackList.Count - 1].transform.rotation = transform.rotation;
                        yCount1++;
                        break;

                    case 1:
                        botStackList[botStackList.Count - 1].transform.parent = botStartPos2;
                        botStart2 = new Vector3(botStartPos2.position.x, botStartPos2.position.y + (botPosOffset.y * yCount2), botStartPos2.position.z);
                        botStackList[botStackList.Count - 1].transform.position = botStart2;
                        botStackList[botStackList.Count - 1].transform.rotation = transform.rotation;
                        yCount2++;
                        break;
                }

            }
        }

    }    
}