using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class RotateMenu : MonoBehaviour
{
    public Quaternion[] rot;
    public float speed;
    int i = 0, newI;
    public Hand LeftHand, RightHand;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        if (LeftHand.GripButtonDown || Input.GetKeyDown(KeyCode.F))
        {
            i++;
            if(i>rot.Length-1)
            {
                i = 0;
            }
            StopAllCoroutines();
            StartCoroutine(StartRotation());
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed*Time.deltaTime);

        }
        if (RightHand.GripButtonDown || Input.GetKeyDown(KeyCode.G))
        {
            i--;
            if(i<0)
            {
                i=rot.Length-1;
            }
               StopAllCoroutines();
             StartCoroutine(StartRotation());
            ///transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(rot.x, -rot.y, rot.z, rot.w), speed*Time.deltaTime);

        }

    }

    IEnumerator StartRotation()
    {
        yield return null;
        while (transform.rotation != rot[i])
        {
            yield return null;
            transform.rotation = Quaternion.Slerp(transform.rotation, rot[i], speed * Time.deltaTime);
        }

    }

    IEnumerator StartRotationNegative()
    {
        yield return null;
        while (transform.rotation != rot[i])
        {
              yield return null;
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(rot[i].x, rot[i].y, rot[i].z, rot[i].w), speed * Time.deltaTime);
        }

    }
}
