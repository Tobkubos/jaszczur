using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : MonoBehaviour
{
    public Storage Storage;
    public GameObject AchievementsList;
    public TextMeshProUGUI achievementsToCollect;
    public GameObject bgToCollect;
    public int num = 0;
    void Start()
    {
        
    }
    
    public void ShowAchievements()
    {
        AchievementsList.SetActive(true);
    }
    public void CloseAchievements()
    {
        AchievementsList.SetActive(false);
    }

    void Update()
    {
        num = 0;
        for (int i = 0; i < Storage.Achievements.Length; i++)
        {
            if (Storage.Achievements[i].transform.Find("ButtonToCollect").GetComponent<Button>().interactable == true)
            {
                bgToCollect.SetActive(true);
                num++;
            }
        }

        if(num == 0)
        {
            bgToCollect.SetActive(false);
        }

        achievementsToCollect.text = num.ToString();
    }
}
