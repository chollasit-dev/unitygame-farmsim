using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StructureManager : MonoBehaviour
{
    [SerializeField] private bool isConstructing;
    [SerializeField] private bool isDemolishing;

    [SerializeField] private GameObject curBuildingPrefab;
    [SerializeField] private GameObject buildingParent;

    [SerializeField] private Vector3 curCursorPos;

    public GameObject buildingCursor;
    public GameObject demolishCursor;
    public GameObject gridPlane;

    private GameObject ghostBuilding;

    [SerializeField] private GameObject _curStructure; //Currently selected structure
    public GameObject CurStructure { get { return _curStructure; } set { _curStructure = value; } }

    [SerializeField] private GameObject[] structurePrefab;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            CancelStructureMode();

        curCursorPos = Formula.instance.GetCurTilePosition();

        if (isConstructing) //Mode Construct
        {
            buildingCursor.transform.position = curCursorPos;
            gridPlane.SetActive(true);
        }
        else if (isDemolishing) //Mode Demolish
        {
            demolishCursor.transform.position = curCursorPos;
            gridPlane.SetActive(true);
        }
        else //Mode Play
        {
            gridPlane.SetActive(false);
        }

        CheckLeftClick();
    }

    private bool CheckMoney(GameObject obj)
    {
        int cost = obj.GetComponent<Structure>().CostToBuild;

        if (cost <= Office.instance.Money)
            return true;
        else
            return false;
    }

    public void BeginNewBuildingPlacement(GameObject prefab)    //Button Mapping
    {
        if (!CheckMoney(prefab))
            return;
        isDemolishing = false;
        isConstructing = true;

        curBuildingPrefab = prefab;

        //Instantiage Ghost Building
        ghostBuilding = Instantiate(curBuildingPrefab, curCursorPos, Quaternion.identity);
        ghostBuilding.GetComponent<FindBuildingSite>().Plane.SetActive(true);

        buildingCursor = ghostBuilding;
        buildingCursor.SetActive(true);
    }

    private void DeductMoney(int cost)
    {
        Office.instance.Money -= cost;
        MainUI.instance.UpdateResourceUI();
    }

    private void PlaceBuilding()
    {
        if (buildingCursor.GetComponent<FindBuildingSite>().CanBuild == false)
            return;

        GameObject structureObj = Instantiate(curBuildingPrefab,
                                               curCursorPos,
                                               Quaternion.identity,
                                               buildingParent.transform);

        Structure s = structureObj.GetComponent<Structure>();

        //Add building in Office
        Office.instance.AddBuilding(s);
        //Deduct Money
        DeductMoney(s.CostToBuild);
        //Cancel if there is not enough money
        if (!CheckMoney(structureObj))
            CancelStructureMode();
    }

    private void CheckLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isConstructing)
                PlaceBuilding(); //Real Construction
            else if (isDemolishing)
                Demolish(); //Real Demolish
            else
                CheckOpenPanel();  //Normal Mode
        }
    }

    private void CancelStructureMode()
    {
        isConstructing = false;

        if (buildingCursor != null)
            buildingCursor.SetActive(false);
        if (ghostBuilding != null)
            Destroy(ghostBuilding);
    }

    private void OpenFarmPanel()
    {
        string name = CurStructure.GetComponent<Farm>().StructureName;

        MainUI.instance.FarmNameText.text = name;
        MainUI.instance.ToggleFarmPanel();
    }

    private void CheckOpenPanel()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //if we left click something
        if (Physics.Raycast(ray, out hit, 1000))
        {
            //Mouse over UI
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            CurStructure = hit.collider.gameObject;

            switch (hit.collider.tag)
            {
                case "Farm": // if we click Object with Farm tag 
                    OpenFarmPanel();
                    break;
            }
        }
    }

    public void CallStaff()
    {
        Office.instance.SendStaff(CurStructure);
        MainUI.instance.UpdateResourceUI();
    }

    private void Demolish()
    {
        Structure s = Office.instance.Structures.Find(x => x.transform.position == curCursorPos);

        if (s != null)
        {
            Office.instance.RemoveBuilding(s);
        }

        MainUI.instance.UpdateResourceUI();
    }


    public void ToggleDemolish() //Map with Demolish Btn
    {
        isConstructing = false;
        isDemolishing = !isDemolishing;

        gridPlane.SetActive(isDemolishing);
        demolishCursor.SetActive(isDemolishing);
    }


}
