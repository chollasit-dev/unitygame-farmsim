using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStateBubble : MonoBehaviour
{
    public Image stateBubbleImg;

    public Sprite attackState;
    public Sprite miningState;
    public Sprite plowState;
    public Sprite sowState;
    public Sprite waterState;
    public Sprite harvestState;


    public void OnStateChange(UnitState state)
    {
        stateBubbleImg.enabled = true;
        CheckState(state);
    }
    private void CheckState(UnitState state)
    {
        switch (state)
        {
            case UnitState.Mining:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = miningState;
                break;
            case UnitState.AttackUnit:
            case UnitState.AttackBuilding:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = attackState;
                break;
            case UnitState.Plow:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = plowState;
                break;
            case UnitState.Sow:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = sowState;
                break;
            case UnitState.Water:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = plowState;
                break;
            case UnitState.Harvest:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.sprite = harvestState;
                break;
            default:
                stateBubbleImg.color = Color.white;
                stateBubbleImg.enabled = false;
                break;
        }
    }
}
