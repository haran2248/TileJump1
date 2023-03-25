using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestVideoCreation : MonoBehaviour
{
    // Start is called before the first frame update
     RawImage RI;
    void Start()
    {
       RI = GetComponent<RawImage>();
        StartCoroutine(LateCall());
    }
    // Update is called once per frame'
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(20);
        RI.enabled = false;
    }
    void Update()
    {
     
    }
}
