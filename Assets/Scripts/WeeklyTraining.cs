using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeklyTraining : MonoBehaviour
{
    public GameObject VirtualTestSpace;
    public GameObject WeeklyTrainingUI;
    public AudioSource source;
    public VisualTestLayer visualTestLayer;

 public void StartTraining() 
 {
    ReminderAndCountDown.Instance.ShowReminderAndCountDown("WeeklyTraining",3, ShowPanels);
    WeeklyTrainingUI.gameObject.SetActive(false);
 }

 public void ShowPanels()
 {
   StartCoroutine(DisplayP1Panel());

   IEnumerator DisplayP1Panel()
   {
    VirtualTestSpace.gameObject.SetActive(true);
    source.Play();
    yield return new WaitForSeconds(0.5f);
    VirtualTestSpace.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        VirtualTestSpace.gameObject.SetActive(true);
        source.Play();
   }
 }
}
