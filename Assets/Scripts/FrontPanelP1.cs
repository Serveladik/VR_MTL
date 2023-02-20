using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class FrontPanelP1 : MonoBehaviour
{
    public RawImage[] ArrayPanels;
    public Zone[] PeripheralZone, CentralZone;

    public string PeripheralZoneString;
    public string CentralZoneString;
        int peripheralCount = 0;
        int centralCount = 0;

    public void Start()
    {
     //// PerpareCentralZone();
     // PerparePeripheralZone();
    }
     public void PerpareCentralZone()
    {
          var ceri = CentralZoneString.Split(';');
        foreach(string s in ceri)
        {
            centralCount++;
        }
        CentralZone = new Zone[centralCount];
        for(int i=0; i<centralCount; i++)
        {
            CentralZone[i] = new Zone();
            CentralZone[i].zoneId = ceri[i];

            foreach(RawImage r in ArrayPanels)
            {
                if(r.name == ceri[i])
                {
                    CentralZone[i].zoneRawImage = r;
                }
            }
        }
    }


    public void PerparePeripheralZone()
    {
          var peri = PeripheralZoneString.Split(';');
        foreach(string s in peri)
        {
            peripheralCount++;
        }
        PeripheralZone = new Zone[peripheralCount];
        for(int i=0; i<peripheralCount; i++)
        {
            PeripheralZone[i] = new Zone();
            PeripheralZone[i].zoneId = peri[i];

            foreach(RawImage r in ArrayPanels)
            {
                if(r.name == peri[i])
                {
                    PeripheralZone[i].zoneRawImage = r;
                }
            }
            Debug.Log(peri[i]);
        }
    }

    public  string RemoveSpecialCharacters( string str) {
   StringBuilder sb = new StringBuilder();
   foreach (char c in str) {
      if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
         sb.Append(c);
      }
   }
   return sb.ToString();
}

    [System.Serializable]
    public class Zone{
        public string zoneId;
        public RawImage zoneRawImage;
    }
}
