using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //public Dictionary<GameObject, string> ItemDictionary = new Dictionary<GameObject, string>(); 
    public Dictionary<string, int> Inventory = new Dictionary<string, int>(); //tracks how many of each building you have

    public void GenerateRewards()
    {

    }

    public void UpdateRewardDisplay()
    {
        //GameManager.Instance.UIManager.UpdateRewardsUI();
    }
}
