using UnityEngine;
using System.Collections;

public class LevelDetectorScript : MonoBehaviour {

    public LiftManagerScript LiftManager;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Level0"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_00;
        if (other.gameObject.CompareTag("Level1"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_01;
        if (other.gameObject.CompareTag("Level2"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_02;
        if (other.gameObject.CompareTag("Level3"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_03;
    }

}
