using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Common;
public class RoleData
{
    public RoleType RoleType { get; set; }
    public GameObject RolePrefab { get;set; }

    public Vector3 SpawnPosition { get; set; }
    
    //Prefab/BluePlayer
    private const string PREFIX_PREFAB = "Prefab/";
    public RoleData(RoleType roleType, string rolePath,Vector3 SpawnPostion)
    {
        this.RoleType = roleType;
        this.RolePrefab = Resources.Load(PREFIX_PREFAB+rolePath) as GameObject;
        this.SpawnPosition = SpawnPostion;
    }
}
