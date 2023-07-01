using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerController : MonoBehaviour
{
    private Animator anim;
    private Worker worker;

    void Start()
    {
        anim
    }

    void Update()
    {

    }

    private void CheckState()
    {
        DisableAll();
        switch (worker.State)
        {
            case UnitState.Idle:
                anim.SetBool("isIdle", true);
                break;
            case UnitState.Walk:
                anim.SetBool("isWalk", true);
                break;
            case UnitState.Plow:
                anim.SetBool("isPlow", true);
                break;
            case UnitState.Sow:
                anim.SetBool("isSow", true);
                break;
            case UnitState.Water:
                anim.SetBool("isWater", true);
                break;
            case UnitState.Harvest:
                anim.SetBool("isHarvest", true);
                break;
        }
    }

    private void DisableAll()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isPlow", false);
        anim.SetBool("isSow", false);
        anim.SetBool("isWater", false);
        anim.SetBool("isHarvest", false);
    }
}
