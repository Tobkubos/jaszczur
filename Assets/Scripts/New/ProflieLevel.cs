using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProflieLevel : MonoBehaviour
{
    public Storage Storage;
	void Update()
    {
		Storage.ProfileLevelSlider.value = (float)(Storage.val_experience / Storage.val_ProfileExperienceToNextLvl);
        if(Storage.val_experience >= Storage.val_ProfileExperienceToNextLvl)
        {
            Storage.val_experience = 0;
            Storage.val_ProfileExperienceToNextLvl *= 1.2f;
            Storage.val_ProfileLevel += 1;
        }
	}
}
