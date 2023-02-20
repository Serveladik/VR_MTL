using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject OrbitalMenu, TrainingMenu, WeeklyTraining, Scoring, Freemode, Activation, FatigueInduction, SpecialTraining;
    public Button WeeklyTrainingBtn, ScoringBtn, FreemodeBtn, ActivationBtn, FatigueInductionBtn, SpecialTrainingBtn;
    public TextMeshProUGUI[] TimeText;
    public TextMeshProUGUI Date;
    public Hand Left, Right;
    public GameObject VisualTestSpace;
    public VisualTestLayer VisualTestLayerScript;
    public GameObject ReminderAndCountDown;

    protected void Start() => Date.text = "" + System.DateTime.Now.Date;

    protected void Update()
    {
        foreach (TextMeshProUGUI t in TimeText)
        {
            if (t != null)
            {
                t.text = "" + System.DateTime.Now.Hour + " : " + System.DateTime.Now.Minute;

            }
        }

        if(Left.SecondaryButton || Right.SecondaryButton)
        {
            if (VisualTestSpace.activeInHierarchy)
            {
                VisualTestSpace.gameObject.SetActive(false);
                EnableWeeklyTrainingMenu();
                ReminderAndCountDown.gameObject.SetActive(false);
                VisualTestLayerScript.StopCouroutinesHere();
                Debug.Log("Not working");
                return;
            }
        }


    }

    public void EnableOrbitalMenu()
    {
        EnableMenu(true);
    }

    public void EnableWeeklyTrainingMenu()
    {
        EnableMenu(false, true);
    }
    public void EnableScoringMenu()
    {
        EnableMenu(false, false, true);
    }

    public void EnableFreemodeMenu()
    {
        EnableMenu(false, false, false, true);
    }

    public void EnableActivationMenu()
    {
        EnableMenu(false, false, false, false, true);
    }

    public void EnableFatigueInductionMenu() => EnableMenu(false, false, false, false, false, true);

    public void EnableSpecialTrainingMenu() => EnableMenu(false, false, false, false, false, false, true);

    public void EnableMenu(bool OrbitalMenuState, bool WeeklyTrainingState = false, bool ScoringState = false, bool freemodeState = false, bool activationState = false, bool fatigueInductionState = false, bool specialTrainingState = false, bool TrainingMenuState = false)
    {
        OrbitalMenu.SetActive(OrbitalMenuState);
        WeeklyTraining.SetActive(WeeklyTrainingState);
        Scoring.SetActive(ScoringState);
        Freemode.SetActive(freemodeState);
        Activation.SetActive(activationState);
        FatigueInduction.SetActive(fatigueInductionState);
        SpecialTraining.SetActive(specialTrainingState);
        TrainingMenu.SetActive(TrainingMenuState);
    }

    public void TrainingMenuBack() => EnableMenu(false, false, false, false, false, false, false, true);
}
