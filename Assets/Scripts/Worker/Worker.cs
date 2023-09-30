using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Gender
{
    male,
    female
}

public class Worker : Unit
{
    private int id;
    public int ID { get { return id; } set { id = value; } }
    [SerializeField] private int charSkinID;
    public int CharSkinID { get { return charSkinID; } set { charSkinID = value; } }
    public GameObject[] charSkin;

    [SerializeField] private int charFaceID;
    public int CharFaceID { get { return charFaceID; } set { charFaceID = value; } }
    public Sprite[] charFacePic;

    [SerializeField] private string staffName;
    public string StaffName { get { return staffName; } set { staffName = value; } }

    [SerializeField] private int dailyWage;
    public int DailyWage { get { return dailyWage; } set { dailyWage = value; } }

    [SerializeField] private Gender staffGender = Gender.male;
    public Gender StaffGender { get { return staffGender; } set { staffGender = value; } }

    [SerializeField] private bool hired = false;
    public bool Hired { get { return hired; } set { hired = value; } }

    //Mining
    [SerializeField] private GameObject targetMine;
    public GameObject TargetMine { get { return targetMine; } set { targetMine = value; } }

    private int maxAmount = 30;

    [SerializeField] private int curAmount;
    public int CurAmount { get { return curAmount; } set { curAmount = value; } }

    //Miner State Timer
    [SerializeField] private float miningTimer = 0f;
    [SerializeField] private float miningTimeWait = 1f;

    //Miner Dig Timer
    [SerializeField] private float timeLastDig;
    [SerializeField] private float digRate = 3f;

    public void InitiateCharID(int i)
    {
        charSkinID = i;
        charFaceID = i;
    }

    public void SetGender()
    {
        if (charSkinID == 1 || charSkinID == 4)
        {
            staffGender = Gender.female;
        }
    }

    public void ChangeCharSkin()
    {
        for (int i = 0; i < charSkin.Length; i++)
        {
            if (i == charSkinID)
            {
                charSkin[i].SetActive(true);
            }
            else
            {
                charSkin[i].SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != targetStructure)
        {
            return;
        }

        Farm farm = other.gameObject.GetComponent<Farm>();

        if ((farm != null) && (farm.HP < 100))
        {
            switch (farm.Stage)
            {
                case FarmStage.plowing:
                    state = UnitState.Plow;
                    EquipTool(0); //Hoe
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.sowing:
                    state = UnitState.Sow;
                    EquipTool(1); //Sack
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.maintaining:
                    state = UnitState.Water;
                    EquipTool(2); //Watering Can
                    farm.CheckTimeForWork();
                    break;
                case FarmStage.harvesting:
                    state = UnitState.Harvest;
                    farm.CheckTimeForWork();
                    break;
            }
        }
    }

    public void HideCharSkin()
    {
        foreach (GameObject obj in charSkin)
        {
            obj.SetActive(false);
        }
    }

    public void DisableAllTools()
    {
        for (int i = 0; i < tools.Length; i++)
            tools[i].SetActive(false);
    }

    private void EquipTool(int i)
    {
        DisableAllTools();
        tools[i].SetActive(true);
    }

    #region Resource

    #endregion
}
