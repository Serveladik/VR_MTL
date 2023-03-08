using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionGame : MonoBehaviour
{
    [SerializeField] int widthCells = 8;
    [SerializeField] int heightCells = 6;
    public GameObject row;
    public GameObject cells;

    [SerializeField] int fillRow = 1;
    [SerializeField] int fillCell = 1;
    [SerializeField] Sprite spriteFill;

    void Start()
    {
        CreateCells(widthCells,heightCells);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            FillCell(fillRow, fillCell);
        }
    }
    

    void CreateCells(int width, int height)
    {
        for(int i = 0; i < width; i++)
        {
            GameObject rowParent = Instantiate(row, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            rowParent.AddComponent<RectTransform>();
            rowParent.GetComponent<RectTransform>().sizeDelta = new Vector2 (widthCells * 100, 100);

            rowParent.AddComponent<HorizontalLayoutGroup>();
            rowParent.name = "Row " + i;

            for(int j = 0; j < width; j++)
            {
                GameObject cell = Instantiate(cells, this.gameObject.transform.position, this.gameObject.transform.rotation, rowParent.transform);
                cell.AddComponent<RectTransform>();
                cell.AddComponent<Image>();
                cell.name = "Cell " + j;
            }
        }
    }

    void FillCell(int row, int cell)
    {
        GameObject rowCount = this.gameObject.transform.GetChild(row).gameObject;
        GameObject cellCount = rowCount.gameObject.transform.GetChild(cell).gameObject;
        cellCount.GetComponent<Image>().sprite = spriteFill;
        cellCount.GetComponent<Image>().enabled = true;
    }
}
