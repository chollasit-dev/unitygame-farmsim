using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StructureType
{
    road,
    building,
    wheat,
    melon,
    corn,
    milk,
    apple
}

public abstract class Structure : MonoBehaviour
{
    [SerializeField] protected StructureType structureType;
    public StructureType StructureType { get { return structureType; } set { structureType = value; } }

    [SerializeField] protected bool functional;

    [SerializeField] protected string structureName;
    public string StructureName { get { return structureName; } }

    [SerializeField] protected int hp;
    public int HP { get { return hp; } set { hp = value; } }

    [SerializeField] protected int costToBuild;
    public int CostToBuild { get { return costToBuild; } }

    [SerializeField] protected int id;
    public int ID { get { return id; } set { id = value; } }
    void Start()
    {
        functional = false;
        hp = 1;
    }

    void Update()
    {

    }
}
