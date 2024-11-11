using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField]
    private Quest[] quests;

    //Debugging
    [SerializeField]
    private Questlog tmpLog;

    private void Awake()
    {
        //here we need to accept a quest; // debug only
        tmpLog.AcceptQuest(quests[0]);
        tmpLog.AcceptQuest(quests[1]);
    }
}
