using UnityEngine;
using System.Collections;

public class LiftManagerScript : MonoBehaviour {

	public enum LiftLevel
    {
        Level_00,
        Level_01,
        Level_02,
        Level_03
    }

    public LiftLevel CurrentLevel;

    public enum LiftState
    {
        movingUp,
        movingDown,
        notMoving
    }

    public LiftState CurrentLiftState;

    public enum LevelSelection
    {
        Lvl00,
        Lvl01,
        Lvl02,
        Lvl03,
        LvlUnselected
    }

    public LevelSelection CurrentLiftSelection;

    public GameObject Lift;
    public GameObject MainChar;
    public GameObject IndicatorG;
    public GameObject Indicator1;
    public GameObject Indicator2;
    public GameObject Indicator3;

    private Animation LiftAnim;

    void Start ()
    {
        CurrentLevel = LiftLevel.Level_00;
        CurrentLiftState = LiftState.notMoving;
        CurrentLiftSelection = LevelSelection.LvlUnselected;

        LiftAnim = Lift.GetComponent<Animation>();
    }   

    void Update ()
    {
        switch (CurrentLevel)
        {
            case LiftLevel.Level_00:
                IndicatorG.SetActive(true);
                Indicator1.SetActive(false);
                Indicator2.SetActive(false);
                Indicator3.SetActive(false);
                break;
            case LiftLevel.Level_01:
                IndicatorG.SetActive(false);
                Indicator1.SetActive(true);
                Indicator2.SetActive(false);
                Indicator3.SetActive(false);
                break;
            case LiftLevel.Level_02:
                IndicatorG.SetActive(false);
                Indicator1.SetActive(false);
                Indicator2.SetActive(true);
                Indicator3.SetActive(false);
                break;
            case LiftLevel.Level_03:
                IndicatorG.SetActive(false);
                Indicator1.SetActive(false);
                Indicator2.SetActive(false);
                Indicator3.SetActive(true);
                break;
        }

        float currentY = 0.0f;
        float newY = 3.0f;

        switch (CurrentLiftState)
        {
            case LiftState.movingUp:
                Lift.transform.position = new Vector3(7.5f, Lift.transform.position.y + Mathf.Lerp(currentY, newY, Time.smoothDeltaTime), 0);
                MainChar.transform.parent = Lift.transform;
                break;
            case LiftState.movingDown:
                Lift.transform.position = new Vector3(7.5f, Lift.transform.position.y - Mathf.Lerp(currentY, newY, Time.smoothDeltaTime), 0);
                MainChar.transform.parent = Lift.transform;
                break;
            case LiftState.notMoving:
                Lift.transform.position = new Vector3(7.5f, Lift.transform.position.y, 0);
                MainChar.transform.parent = null;
                break;
        }

        switch (CurrentLiftSelection)
        {
            case LevelSelection.Lvl00:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl01:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl02:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl03:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.LvlUnselected:
                StartCoroutine(GoToLevel());
                break;
        }
    }

   IEnumerator GoToLevel ()
    {
        // if pressed the same level 
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_00))     
        {
            print("already at level G");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl01) && (CurrentLevel == LiftLevel.Level_01))
        {
            print("already at level 1");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_02))
        {
            print("already at level 2");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_03))
        {
            print("already at level 3");
        }

        //if At Level G 
        if ((CurrentLiftSelection == LevelSelection.Lvl01) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_01)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_01;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 1");
            }            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_02;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 2");
            }            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 3");
            }            
        }

        //if At Level 1
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_01))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level G");
            }
            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_01))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_02;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 2");
            }
            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_01))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 3");
            }
            
        }


        //if At Level 2
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level G");
            }
            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl01) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_01)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_01;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 1");
            }
            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 3");
            }
            
        }


        //if At Level 3
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                // CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level G");
            }
            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl01) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_01)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_01;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 1");
            }
            
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.Play("LiftDoorClose");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_02;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.Play("LiftDoorOpen");
                print("reached Level 2");
            }
            
        }

    }
}
