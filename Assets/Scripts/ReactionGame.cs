using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionGame : MonoBehaviour
{
    [SerializeField] int widthCells = 8;
    [SerializeField] int heightCells = 6;

    void Start()
    {
        CreateCells(widthCells,heightCells);
    }

    
    void Update()
    {
        
    }


    void CreateCells(int width, int height)
    {
        GameObject rowParent;
        GameObject cell;
        for(int i = 0; i < width; i++)
        {
            rowParent = Instantiate(new GameObject(), this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            rowParent.AddComponent<RectTransform>();
            rowParent.GetComponent<RectTransform>().sizeDelta = new Vector2 (widthCells * 100, 100);

            rowParent.AddComponent<HorizontalLayoutGroup>();
            rowParent.name = "Row " + i;

            for(int j = 0; j < width; j++)
            {
                cell = Instantiate(new GameObject(), this.gameObject.transform.position, this.gameObject.transform.rotation, rowParent.transform);
                cell.AddComponent<RectTransform>();
                cell.AddComponent<Image>();
                cell.name = "Cell " + j;
            }
        }
    }
}
