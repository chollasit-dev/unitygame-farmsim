using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum FarmStage
{
    plowing,
    sowing,
    maintaining,
    harvesting
}

public class Farm : Structure
{
    [SerializeField] private FarmStage stage = FarmStage.plowing;
    public FarmStage Stage { get { return stage; } }

    [SerializeField] private int maxStaffNum = 3;
    public int MaxStaffNum { get { return maxStaffNum; } set { maxStaffNum = value; } }

    [SerializeField] private int dayRequired; //Day until harvest

    [SerializeField] private int dayPassed; //Day passed since last harvest

    [SerializeField] private float produceTimer = 0f;
    private int secondsPerDay = 10;

    private float WorkTimer = 0f;
    private float WorkTimeWait = 1f;

    [SerializeField] private GameObject FarmUI;

    [SerializeField] private List<Worker> currentWorkers;
    public List<Worker> CurrentWorkers { get { return currentWorkers; } set { currentWorkers = value; } }
    void Update()
    {
        CheckPlowing();
        CheckSowing();
        CheckMaintaining();
        CheckHarvesting();
    }

    public void CheckPlowing()
    {
        if ((hp >= 100) && (stage == FarmStage.plowing))
        {
            stage = FarmStage.sowing;
            hp = 1;
        }
    }

    public void CheckSowing()
    {
        if ((hp >= 100) && (stage == FarmStage.sowing))
        {
            functional = true; //Plant will auto grow
            stage = FarmStage.maintaining;
            hp = 1;
        }
    }

    public void CheckMaintaining()
    {
        if ((hp >= 100) && (stage == FarmStage.maintaining))
        {
            produceTimer += Time.deltaTime;
            dayPassed = Mathf.CeilToInt(produceTimer / secondsPerDay);
        }

        if ((functional == true) && (dayPassed >= dayRequired))
        {
            produceTimer = 0;
            stage = FarmStage.harvesting;
            hp = 1;
        }
    }
    public void CheckHarvesting()
    {
        if ((hp >= 100) && (stage == FarmStage.harvesting))
        {
            //harvest
            Debug.Log("Harvest +1000");

            hp = 1;
            stage = FarmStage.sowing;
        }
    }

    public void AddStaffToFarm(Worker w)
    {
        currentWorkers.Add(w);
    }

    private void Working()
    {
        hp += 3;
    }

    public void CheckTimeForWork()
    {
        WorkTimer += Time.deltaTime;

        if (WorkTimer >= WorkTimeWait)
        {
            WorkTimer = 0;
            Working();
        }
    }

}