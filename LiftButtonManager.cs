using UnityEngine;
using System.Collections;

public class LiftButtonManager : MonoBehaviour {

    private Camera MainCam;

    public LiftManagerScript LiftManager;

    public GameObject Button_Lvl00;
    public GameObject Button_Lvl01;
    public GameObject Button_Lvl02;
    public GameObject Button_Lvl03;

    private Animation ButtonLvl00Anim;
    private Animation ButtonLvl01Anim;
    private Animation ButtonLvl02Anim;
    private Animation ButtonLvl03Anim;

    void Start ()
    {
        MainCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        ButtonLvl00Anim = Button_Lvl00.GetComponent<Animation>();
        ButtonLvl01Anim = Button_Lvl01.GetComponent<Animation>();
        ButtonLvl02Anim = Button_Lvl02.GetComponent<Animation>();
        ButtonLvl03Anim = Button_Lvl03.GetComponent<Animation>();
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == Button_Lvl00.GetComponent<Collider>())
                {
                    print("hitLvl 00");
                    LiftManager.CurrentLiftSelection = LiftManagerScript.LevelSelection.Lvl00;
                    ButtonLvl00Anim.Play("ButtonLiftAnim");
                }
                if (hit.collider == Button_Lvl01.GetComponent<Collider>())
                {
                    print("hitLvl 01");
                    LiftManager.CurrentLiftSelection = LiftManagerScript.LevelSelection.Lvl01;
                    ButtonLvl01Anim.Play("ButtonLiftAnim");
                }
                if (hit.collider == Button_Lvl02.GetComponent<Collider>())
                {
                    print("hitLvl 02");
                    LiftManager.CurrentLiftSelection = LiftManagerScript.LevelSelection.Lvl02;
                    ButtonLvl02Anim.Play("ButtonLiftAnim");
                }
                if (hit.collider == Button_Lvl03.GetComponent<Collider>())
                {
                    print("hitLvl 03");
                    LiftManager.CurrentLiftSelection = LiftManagerScript.LevelSelection.Lvl03;
                    ButtonLvl03Anim.Play("ButtonLiftAnim");
                }

            }
        }
    }

}
