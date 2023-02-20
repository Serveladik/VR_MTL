using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using UnityEngine.Video;
public class VisualTestLayer : MonoBehaviour
{
    public List<Panels> panels = new List<Panels>();
        float transitionTime = 1f;

    [Serializable]
    public class Panels
    {
        public string id;
        public RawImage PeripheralZone;
        public RawImage CentralZone;
        public GameObject SurfaceLayerObj;
        public List<SurFaceLayerSquare> SurfaceLayer = new List<SurFaceLayerSquare>();


        [Serializable]
        public class SurFaceLayerSquare
        {
            public string squareId;
            public RawImage Images;

            public SurFaceLayerSquare(string id, RawImage img)
            {
                squareId = id;
                Images = img;
            }
        }
    }

private IEnumerator coroutine;
    public GameObject SurfaceLaterGameObject;

    private void Start()
    {
        StartInitalize(0);
        StartInitalize(1);
        StartInitalize(2);
        StartInitalize(3);
        StartInitalize(4);
        StartInitalize(5);
    }

    private void StartInitalize(int index)
    {
        foreach (Transform g in panels[index].SurfaceLayerObj.GetComponentsInChildren<Transform>())
        {
            panels[index].SurfaceLayer.Add(new Panels.SurFaceLayerSquare(g.name, g.GetComponent<RawImage>()));
        }
    }

    public void ResetTestLayers()
    {
        // foreach()
    }

    public void TestDemo1()
    {
        panels[0].CentralZone.color = Color.black;
        panels[0].PeripheralZone.color = Color.yellow;
        panels[0].SurfaceLayer[3].Images.color = new Color(panels[0].SurfaceLayer[3].Images.color.r, panels[0].SurfaceLayer[3].Images.color.g, panels[0].SurfaceLayer[3].Images.color.b, 1f);
        panels[0].SurfaceLayer[3].Images.color = Color.green;

        panels[1].CentralZone.color = Color.grey;
        panels[1].PeripheralZone.color = Color.magenta;
        panels[1].SurfaceLayer[9].Images.color = new Color(panels[1].SurfaceLayer[9].Images.color.r, panels[1].SurfaceLayer[9].Images.color.g, panels[1].SurfaceLayer[9].Images.color.b, 1f);
        panels[1].SurfaceLayer[9].Images.color = Color.cyan;

        panels[2].CentralZone.color = Color.green;
        panels[2].PeripheralZone.color = Color.blue;
        panels[2].SurfaceLayer[27].Images.color = new Color(panels[2].SurfaceLayer[27].Images.color.r, panels[2].SurfaceLayer[27].Images.color.g, panels[2].SurfaceLayer[27].Images.color.b, 1f);
        panels[2].SurfaceLayer[27].Images.color = Color.black;

        panels[3].CentralZone.color = Color.white;
        panels[3].PeripheralZone.color = Color.blue;
        panels[3].SurfaceLayer[17].Images.color = new Color(panels[3].SurfaceLayer[17].Images.color.r, panels[3].SurfaceLayer[17].Images.color.g, panels[3].SurfaceLayer[17].Images.color.b, 1f);
        panels[3].SurfaceLayer[17].Images.color = Color.cyan;

        panels[4].CentralZone.color = Color.cyan;
        panels[4].PeripheralZone.color = Color.magenta;
        panels[4].SurfaceLayer[7].Images.color = new Color(panels[4].SurfaceLayer[7].Images.color.r, panels[4].SurfaceLayer[7].Images.color.g, panels[4].SurfaceLayer[7].Images.color.b, 1f);
        panels[4].SurfaceLayer[7].Images.color = Color.yellow;

        panels[5].CentralZone.color = Color.red;
        panels[5].PeripheralZone.color = Color.magenta;
        panels[5].SurfaceLayer[35].Images.color = new Color(panels[5].SurfaceLayer[35].Images.color.r, panels[5].SurfaceLayer[35].Images.color.g, panels[5].SurfaceLayer[35].Images.color.b, 1f);
        panels[5].SurfaceLayer[35].Images.color = Color.green;
    }

    public Texture[] TestImages;
    public VideoClip[] testClips;
    public void TestDemo2()
    {
        VideoPlayer player = panels[0].CentralZone.gameObject.AddComponent<VideoPlayer>() as VideoPlayer;
        RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        rt.Create();
        panels[0].CentralZone.texture = rt;
        player.targetTexture = rt;
        player.isLooping = true;
        player.clip = testClips[1];
        panels[0].PeripheralZone.texture = TestImages[3];
        panels[0].SurfaceLayer[3].Images.color = new Color(panels[0].SurfaceLayer[3].Images.color.r, panels[0].SurfaceLayer[3].Images.color.g, panels[0].SurfaceLayer[3].Images.color.b, 1f);
        panels[0].SurfaceLayer[3].Images.color = Color.green;


        panels[1].CentralZone.color = Color.grey;
        panels[1].PeripheralZone.texture = TestImages[1];
        panels[1].SurfaceLayer[9].Images.color = new Color(panels[1].SurfaceLayer[9].Images.color.r, panels[1].SurfaceLayer[9].Images.color.g, panels[1].SurfaceLayer[9].Images.color.b, 1f);
        panels[1].SurfaceLayer[9].Images.color = Color.cyan;

        panels[2].CentralZone.color = Color.green;
        panels[2].PeripheralZone.color = Color.blue;
        panels[2].SurfaceLayer[27].Images.color = new Color(panels[2].SurfaceLayer[27].Images.color.r, panels[2].SurfaceLayer[27].Images.color.g, panels[2].SurfaceLayer[27].Images.color.b, 1f);
        panels[2].SurfaceLayer[27].Images.texture = TestImages[2];

        panels[3].CentralZone.texture = TestImages[3];
        panels[3].PeripheralZone.texture = TestImages[2];
        panels[3].SurfaceLayer[17].Images.color = new Color(panels[3].SurfaceLayer[17].Images.color.r, panels[3].SurfaceLayer[17].Images.color.g, panels[3].SurfaceLayer[17].Images.color.b, 1f);
        panels[3].SurfaceLayer[17].Images.texture = TestImages[0];

        panels[4].CentralZone.texture = TestImages[4];
        panels[4].PeripheralZone.texture = TestImages[0];
        panels[4].SurfaceLayer[7].Images.color = new Color(panels[4].SurfaceLayer[7].Images.color.r, panels[4].SurfaceLayer[7].Images.color.g, panels[4].SurfaceLayer[7].Images.color.b, 1f);
        panels[4].SurfaceLayer[7].Images.color = Color.yellow;

        panels[5].CentralZone.color = Color.red;
        panels[5].PeripheralZone.color = Color.magenta;
        panels[5].SurfaceLayer[35].Images.color = new Color(panels[5].SurfaceLayer[35].Images.color.r, panels[5].SurfaceLayer[35].Images.color.g, panels[5].SurfaceLayer[35].Images.color.b, 1f);
        panels[5].SurfaceLayer[35].Images.texture = TestImages[4];
    }

    public void TestDemo3()
    {
        panels[0].CentralZone.color = Color.black;
        panels[0].PeripheralZone.color = new Color(panels[0].PeripheralZone.color.r, panels[0].PeripheralZone.color.g, panels[0].PeripheralZone.color.b, 0f);

        panels[0].SurfaceLayer[3].Images.color = new Color(panels[0].SurfaceLayer[3].Images.color.r, panels[0].SurfaceLayer[3].Images.color.g, panels[0].SurfaceLayer[3].Images.color.b, 1f);
        panels[0].SurfaceLayer[3].Images.color = Color.green;

        panels[1].CentralZone.color = Color.grey;
        panels[1].PeripheralZone.color = Color.magenta;
        panels[1].SurfaceLayer[9].Images.color = new Color(panels[1].SurfaceLayer[9].Images.color.r, panels[1].SurfaceLayer[9].Images.color.g, panels[1].SurfaceLayer[9].Images.color.b, 1f);
        panels[1].SurfaceLayer[9].Images.color = Color.cyan;

        panels[2].CentralZone.color = Color.green;
        panels[2].PeripheralZone.color = Color.blue;
        panels[2].SurfaceLayer[27].Images.color = new Color(panels[2].SurfaceLayer[27].Images.color.r, panels[2].SurfaceLayer[27].Images.color.g, panels[2].SurfaceLayer[27].Images.color.b, 1f);
        panels[2].SurfaceLayer[27].Images.color = Color.black;

        panels[3].CentralZone.color = Color.white;
        panels[3].PeripheralZone.color = Color.blue;
        panels[3].SurfaceLayer[17].Images.color = new Color(panels[3].SurfaceLayer[17].Images.color.r, panels[3].SurfaceLayer[17].Images.color.g, panels[3].SurfaceLayer[17].Images.color.b, 1f);
        panels[3].SurfaceLayer[17].Images.color = Color.cyan;

        panels[4].CentralZone.color = Color.cyan;
        panels[4].PeripheralZone.color = Color.magenta;
        panels[4].SurfaceLayer[7].Images.color = new Color(panels[4].SurfaceLayer[7].Images.color.r, panels[4].SurfaceLayer[7].Images.color.g, panels[4].SurfaceLayer[7].Images.color.b, 1f);
        panels[4].SurfaceLayer[7].Images.color = Color.yellow;

        panels[5].CentralZone.color = Color.red;
        panels[5].PeripheralZone.color = Color.magenta;
        panels[5].SurfaceLayer[35].Images.color = new Color(panels[5].SurfaceLayer[35].Images.color.r, panels[5].SurfaceLayer[35].Images.color.g, panels[5].SurfaceLayer[35].Images.color.b, 1f);
        panels[5].SurfaceLayer[35].Images.color = Color.green;
    }
    public AudioClip beepSound;
    public AudioSource source;
    public void TestDemo4()
    {
        source.clip = beepSound;
        panels[0].CentralZone.enabled = false;
        panels[0].PeripheralZone.enabled = false;
        panels[1].CentralZone.enabled = false;
        panels[1].PeripheralZone.enabled = false;
        panels[2].CentralZone.enabled = false;
        panels[2].PeripheralZone.enabled = false;
        Debug.Log("Hello");
        panels[3].CentralZone.enabled = false;
        panels[3].PeripheralZone.enabled = false;
        panels[4].CentralZone.enabled = false;
        panels[4].PeripheralZone.enabled = false;
        panels[5].CentralZone.enabled = false;
        panels[5].PeripheralZone.enabled = false;
        Debug.Log("Hello");
        StartCoroutine(LightUpBulbs());

        IEnumerator LightUpBulbs()
        {
            Debug.Log("hi");
            yield return null;
            yield return new WaitForSeconds(4);
            for (int i = 0; i < panels[0].SurfaceLayer.Count - 1; i++)
            {
                yield return new WaitForSeconds(transitionTime);
                Debug.Log("hi");
                Debug.Log(i);
                if (i == 48)
                {
                    StartCoroutine(LightUpBulbs1());

                    break;
                }
                else
                {
                    panels[0].SurfaceLayer[i].Images.color = new Color(panels[0].SurfaceLayer[i].Images.color.r, panels[0].SurfaceLayer[i].Images.color.g, panels[0].SurfaceLayer[i].Images.color.b, 1f);
                    if (i % 2 == 0)
                    {
                        panels[0].SurfaceLayer[i].Images.color = Color.red;
                    }
                    else
                    {
                        panels[0].SurfaceLayer[i].Images.color = Color.green;
                    }
                    source.Play();
                }

            }
        }

        IEnumerator LightUpBulbs1()
        {
            Debug.Log("hi");
            yield return null;
            for (int i = 0; i < panels[1].SurfaceLayer.Count - 1; i++)
            {
                yield return new WaitForSeconds(transitionTime);
                Debug.Log("hi");
                Debug.Log(i);
                if (i == 36)
                {
                    StartCoroutine(LightUpBulbs2());

                    break;
                }
                else
                {
                    panels[1].SurfaceLayer[i].Images.color = new Color(panels[1].SurfaceLayer[i].Images.color.r, panels[1].SurfaceLayer[i].Images.color.g, panels[1].SurfaceLayer[i].Images.color.b, 1f);
                    if (i % 2 == 0)
                    {
                        panels[1].SurfaceLayer[i].Images.color = Color.red;
                    }
                    else
                    {
                        panels[1].SurfaceLayer[i].Images.color = Color.green;
                    }
                    source.Play();
                }
            }
        }


        IEnumerator LightUpBulbs2()
        {
            Debug.Log("hi");
            yield return null;
            for (int i = 0; i < panels[2].SurfaceLayer.Count - 1; i++)
            {
                yield return new WaitForSeconds(transitionTime);
                Debug.Log("hi");
                Debug.Log(i);
                if (i == 36)
                {
                    StartCoroutine(LightUpBulbs3());

                    break;
                }
                else
                {
                    panels[2].SurfaceLayer[i].Images.color = new Color(panels[2].SurfaceLayer[i].Images.color.r, panels[2].SurfaceLayer[i].Images.color.g, panels[2].SurfaceLayer[i].Images.color.b, 1f);
                    if (i % 2 == 0)
                    {
                        panels[2].SurfaceLayer[i].Images.color = Color.red;
                    }
                    else
                    {
                        panels[2].SurfaceLayer[i].Images.color = Color.green;
                    }
                    source.Play();
                }
            }
        }

        IEnumerator LightUpBulbs3()
        {
            Debug.Log("hi");
            yield return null;
            for (int i = 0; i < panels[3].SurfaceLayer.Count - 1; i++)
            {
                yield return new WaitForSeconds(transitionTime);
                Debug.Log("hi");
                Debug.Log(i);
                if (i == 48)
                {
                    StartCoroutine(LightUpBulbs4());
                    break;
                }
                else
                {
                    panels[3].SurfaceLayer[i].Images.color = new Color(panels[3].SurfaceLayer[i].Images.color.r, panels[3].SurfaceLayer[i].Images.color.g, panels[3].SurfaceLayer[i].Images.color.b, 1f);
                    if (i % 2 == 0)
                    {
                        panels[3].SurfaceLayer[i].Images.color = Color.red;
                    }
                    else
                    {
                        panels[3].SurfaceLayer[i].Images.color = Color.green;
                    }
                    source.Play();
                }
            }
        }

        IEnumerator LightUpBulbs4()
        {
            Debug.Log("hi");
            yield return null;
            for (int i = 0; i < panels[4].SurfaceLayer.Count - 1; i++)
            {
                yield return new WaitForSeconds(transitionTime);
                Debug.Log("hi");
                Debug.Log(i);
                if (i == 36)
                {
                    StartCoroutine(LightUpBulbs5());

                    break;
                }
                else
                {
                    panels[4].SurfaceLayer[i].Images.color = new Color(panels[4].SurfaceLayer[i].Images.color.r, panels[4].SurfaceLayer[i].Images.color.g, panels[4].SurfaceLayer[i].Images.color.b, 1f);
                    if (i % 2 == 0)
                    {
                        panels[4].SurfaceLayer[i].Images.color = Color.red;
                    }
                    else
                    {
                        panels[4].SurfaceLayer[i].Images.color = Color.green;
                    }
                    source.Play();
                }
            }
        }

        IEnumerator LightUpBulbs5()
        {
            Debug.Log("hi");
            yield return null;
            for (int i = 0; i < panels[4].SurfaceLayer.Count - 1; i++)
            {
                yield return new WaitForSeconds(transitionTime);
                Debug.Log("hi");
                Debug.Log(i);
                if (i == 36)
                {

                    break;
                }
                else
                {
                    panels[5].SurfaceLayer[i].Images.color = new Color(panels[5].SurfaceLayer[i].Images.color.r, panels[5].SurfaceLayer[i].Images.color.g, panels[5].SurfaceLayer[i].Images.color.b, 1f);
                    if (i % 2 == 0)
                    {
                        panels[5].SurfaceLayer[i].Images.color = Color.red;
                    }
                    else
                    {
                        panels[5].SurfaceLayer[i].Images.color = Color.green;
                    }
                    source.Play();
                }
            }
        }
    }

    public void StopCouroutinesHere() => StopAllCoroutines();
}
