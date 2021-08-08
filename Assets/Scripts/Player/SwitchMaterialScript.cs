using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMaterialScript : MonoBehaviour
{
    public GameObject BullSkin;
    public GameObject BullHornSkin;



    void Start()
    {
        BullSkin.GetComponent<SkinnedMeshRenderer>().material = BullSkin.GetComponent<SkinnedMeshRenderer>().materials[PlayerPrefs.GetInt("currentSkin", 0)]; //***
        BullHornSkin.GetComponent<MeshRenderer>().material = BullHornSkin.GetComponent<MeshRenderer>().materials[PlayerPrefs.GetInt("currentSkin", 0)];
    }

}