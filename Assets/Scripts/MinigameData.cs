using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
public class MinigameData : MonoBehaviour
{
    public ReactionGame Game;
    public static string URL = "https://dev.l47.io/api/vr";
    [Header("PANELS")]
    public int idx;
    public int numRows;
    public int numCols;
    [Header("SELECTED PANEL")]
    public int fillRow;
    public int fillCol;
    public string imgUrl;

    
    void Start()
    {
        StartCoroutine(GetGameData(URL));
    }

    IEnumerator GetGameData(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();

            switch (www.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    JSONNode root = JSONNode.Parse(www.downloadHandler.text);
				    JSONNode nodes = root["test"];
                    JSONArray loops = nodes["loops"].AsArray;
                    //JSONArray panels = loops["panels"].AsArray;

                    //Debug.LogError(loops[0]["panels"]);
                    for(int i = 0; i < loops.Count; i++)
                    {
                        JSONArray panels = loops[i]["panels"].AsArray;
                        JSONArray coords = panels[i]["customCoords"].AsArray;
                        foreach(JSONNode panel in panels)
                        {
                            idx = panel["idx"];
                            numRows = panel["numRows"];
                            numCols = panel["numCols"];

                            Game.panelNumber = idx;
                            Game.heightCells = numRows;
                            Game.widthCells = numCols;
                            Debug.LogError(coords);

                            foreach(JSONNode fillCoord in coords)
                            {
                                fillRow = fillCoord["row"];
                                fillCol = fillCoord["col"];
                                imgUrl = "https://dev.l47.io" + fillCoord["img"];

                                Game.fillRow = fillRow;
                                Game.fillCell = fillCol;
                            }
                        }
                    }
                    StartCoroutine(DownloadImage(imgUrl));
                    //foreach (JSONNode node in loops)
				    //{
				    //	Debug.LogError(node["id"]);
				    //}
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    IEnumerator DownloadImage(string img)
    {   
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(img);
        yield return www.SendWebRequest();
            Debug.LogError(www.result);
        switch (www.result)
        {

                case UnityWebRequest.Result.ConnectionError:
                Debug.LogError("Connection problem");
                break;

                case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("Data problem");
                break;

                case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("Request problem");
                break;

                case UnityWebRequest.Result.Success:
                Debug.LogError("Success");

                Texture2D texture = ((DownloadHandlerTexture) www.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));
                Game.spriteFill = sprite;
                Game.FillCell(Game.panelNumber, Game.fillRow, Game.fillCell);
                
                break;
        } 
    }
}
