using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselArrows : MonoBehaviour
{
    public static int currentPage = 0;
    public static int maxPage;
    public void BackPage()
    {
        if(currentPage == 0)
        {
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage = maxPage;
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage--;
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
    }
    public void NextPage()
    {
        if(currentPage == maxPage)
        {
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage = 0;
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage++;
            this.gameObject.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        maxPage = this.gameObject.transform.childCount - 1; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError(currentPage);
    }
}
