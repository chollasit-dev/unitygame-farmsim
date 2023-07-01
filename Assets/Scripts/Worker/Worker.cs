using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    public enum UnitState
    {
        Idle,
        Walk,
        Plow,
        Sow,
        Water,
        Harvest
    }

    public enum Gender
    {
        male,
        female
    }

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

    [SerializeField] private UnitState state;
    public UnitState State { get { return state; } set { state = value; } }

    private NavMeshAgent navAgent;
    public NavMeshAgent NavAgent { get { return navAgent; } set { navAgent = value; } }

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }
}
