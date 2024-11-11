using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField]
    private string title;

    [SerializeField]
    private string description;

    [SerializeField]
    private CollectObjective[] collectObjectives;
    public QuestScript MyQuestScript { get; set; }
    public string MyTitle
    {
        get
        {
            return title;

        }
        set
        {
            title = value;
        }
    }
    public string MyDescription
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }

    public CollectObjective[] MyCollectObjectives { get => collectObjectives;  }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public abstract class Objective
{
    [SerializeField]
    private int amount;

    private int currentAmount;

    [SerializeField]
    private string type;

    public int MyAmount 
    { 
        get => amount; 
       
    }
    public int MyCurrentAmount 
    { get => currentAmount; 
        set => currentAmount = value; 
    }
    public string MyType 
    { 
        get => type;
      
    }
}



[System.Serializable]
public class CollectObjective : Objective
{

}
 