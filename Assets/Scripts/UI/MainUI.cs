using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text staffText;
    [SerializeField] private TMP_Text wheatText;
    [SerializeField] private TMP_Text melonText;
    [SerializeField] private TMP_Text cornText;
    [SerializeField] private TMP_Text milkText;
    [SerializeField] private TMP_Text appleText;

    [SerializeField] private TMP_Text dayText;

    public static MainUI instance;

    public GameObject laborMarketPanel;

    public GameObject farmPanel;
    [SerializeField] private TMP_Text farmNameText;
    public TMP_Text FarmNameText
    { get { return farmNameText; } set { farmNameText = value; } }

    public GameObject warehousePanel;
    [SerializeField] private TMP_Text warehouseNameText;
    public TMP_Text WarehouseNameText
    { get { return warehouseNameText; } set { warehouseNameText = value; } }

    void Start()
    {
        instance = this;
        UpdateResourceUI();
    }

    public void UpdateResourceUI()
    {
        moneyText.text = Office.instance.Money.ToString();
        staffText.text = Office.instance.Workers.Count.ToString();
        wheatText.text = Office.instance.Wheat.ToString();
        melonText.text = Office.instance.Melon.ToString();
        cornText.text = Office.instance.Corn.ToString();
        milkText.text = Office.instance.Milk.ToString();
        appleText.text = Office.instance.Apple.ToString();
    }

    public void ToggleLaborPanel()
    {
        if (!laborMarketPanel.activeInHierarchy)
            laborMarketPanel.SetActive(true);
        else
            laborMarketPanel.SetActive(false);
    }

    public void ToggleFarmPanel()
    {
        if (!farmPanel.activeInHierarchy)
            farmPanel.SetActive(true);
        else
            farmPanel.SetActive(false);
    }

    public void ToggleWarehousePanel()
    {
        if (!warehousePanel.activeInHierarchy)
            warehousePanel.SetActive(true);
        else
            warehousePanel.SetActive(false);
    }
}
