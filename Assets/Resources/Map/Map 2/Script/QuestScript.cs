using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{
    public Quest MyQuest { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select()
    {
        GetComponent<Text>().color = Color.red;
        Questlog.MyInstance.ShowDescription(MyQuest);
    }
        public void DeSelect()
    {
        GetComponent<Text>().color = Color.white;
    }
    
}
