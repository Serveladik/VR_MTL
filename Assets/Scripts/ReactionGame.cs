using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionGame : MonoBehaviour
{
    public int panelNumber = 0;
    [SerializeField] GameObject[] gamePanels;
    public int widthCells = 8;
    public int heightCells = 6;
    public GameObject row;
    public GameObject cells;

    public int fillRow = 1;
    public int fillCell = 1;
    public Sprite spriteFill;

    void Start()
    {
        CreateCells(gamePanels.Length, widthCells, heightCells);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            FillCell(panelNumber, fillRow, fillCell);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            EmptyCell(panelNumber, fillRow, fillCell);
        }
    }
    

    void CreateCells(int panelsCount, int width, int height)
    {
        for(int panelNumber = 0; panelNumber < gamePanels.Length; panelNumber++)
        {
            for(int i = 0; i < width; i++)
            {
                GameObject rowParent = Instantiate(row, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gamePanels[panelNumber].transform);
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
    }
    
    public Image showedImage;
    public void FillCell(int panelNumber, int row, int cell)
    {
        GameObject panel = this.gameObject.transform.GetChild(panelNumber).gameObject;
        GameObject rowCount = panel.transform.GetChild(row).gameObject;
        GameObject cellCount = rowCount.gameObject.transform.GetChild(cell).gameObject;

        showedImage = cellCount.GetComponent<Image>();
        showedImage.sprite = spriteFill;
        showedImage.enabled = true;
    }

    void EmptyCell(int panelNumber, int row, int cell)
    {
        GameObject panel = this.gameObject.transform.GetChild(panelNumber).gameObject;
        GameObject rowCount = panel.transform.GetChild(row).gameObject;
        GameObject cellCount = rowCount.gameObject.transform.GetChild(cell).gameObject;

        showedImage = cellCount.GetComponent<Image>();
        showedImage.sprite = null;
        showedImage.enabled = false;
    }
}
