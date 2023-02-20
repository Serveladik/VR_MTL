using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ReminderAndCountDown : MonoBehaviour
{
   public TextMeshProUGUI Reminder;
   public TextMeshProUGUI CountDown;
   public GameObject ReminderAndCountDownGameObject;

   public static ReminderAndCountDown Instance = null;

   protected void Awake() => Instance = this;

    public  void ShowReminderAndCountDown(string Reminder, int countDown, UnityAction callback)
    {
        ReminderAndCountDownGameObject.SetActive(true);
        StartCoroutine(Countdown(Reminder, countDown, callback));
    }

    IEnumerator Countdown (string reminder, int seconds, UnityAction callback) {
        Reminder.text = reminder;
     int counter = seconds;
     while (counter >= 0) {
        CountDown.text = "" + counter;
         yield return new WaitForSeconds (1);
         counter--;
     }
     callback.Invoke();
 }

}
