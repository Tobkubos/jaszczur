
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    public double    val_TotalCash;
    public double    val_CashPerClick;
    public double    val_CashPerSec;
    public double    val_Diamonds;
    public double    val_DiamondsChance;

    public double    val_MaxMultiplier;
    public float     val_MultiplierCooldown;
    public double    val_DynamicMultiplier;

    public int       val_ProfileLevel;
    public double    val_ProfileExperienceToNextLvl;
	public double    val_experience;


    public double    val_ach_experiencePerClick;
    public double    val_ach_StartMultiplier;
    public double    val_ach_MultiplierPerClick;

	public float Fsize;

    public GameObject Canva;

    public GameObject   UpgradesMenu;
    public GameObject[] ClickUpgrades;
    public GameObject[] IdleUpgrades;
    public GameObject[] MultiplierUpgrades;
    public GameObject[] Achievements;
    public GameObject   LIST_ClickUpgrades;
    public GameObject   LIST_IdleUpgrades;
    public GameObject   LIST_MultiplierUpgrades;
    public GameObject   LIST_OtherUpgrades;
    public GameObject   Cash_Icon;
    public GameObject   Bonus_Popup;

    public GameObject OfflineIncomeBox;

    public GameObject   ClickObject;
    public Slider       Slider;
	public Slider       ProfileLevelSlider;

	public TextMeshProUGUI TEXT_TotalCash;
    public TextMeshProUGUI TEXT_CashPerClick;
    public TextMeshProUGUI TEXT_CashPerSec;
    public TextMeshProUGUI TEXT_Diamonds;
    public TextMeshProUGUI TEXT_ProfileLevel;
	public TextMeshProUGUI TEXT_ProfileExperienceToNextLvl;
    public TextMeshProUGUI TEXT_Multiplier;

    public TextMeshProUGUI TEXT_OfflineIncome;
	public TextMeshProUGUI TEXT_OfflineTime;

	public NumberConverter NumberConverter;

    public ParticleSystem ParticleClick;
	public ParticleSystem ParticleLevelUp;

	public double SECONDS;

    void Start()
    {
        Fsize = TEXT_TotalCash.fontSize;
    }
    void Update()
    {
        TEXT_TotalCash.text                   = NumberConverter.FormatNumber(val_TotalCash);
        TEXT_CashPerClick.text                = NumberConverter.FormatNumber(val_CashPerClick) + " per click";
        TEXT_CashPerSec.text                  = NumberConverter.FormatNumber(val_CashPerSec)+ " /s";
        TEXT_Diamonds.text                    = NumberConverter.FormatNumber(val_Diamonds);
        TEXT_ProfileLevel.text                = NumberConverter.FormatNumber(val_ProfileLevel);
		TEXT_ProfileExperienceToNextLvl.text  = NumberConverter.FormatNumber(val_experience) + " / " + NumberConverter.FormatNumber(val_ProfileExperienceToNextLvl);
	}
}
