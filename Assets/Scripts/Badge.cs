using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Badge : MonoBehaviour
{

    public Canvas badge;
    public Canvas UIbadge;
    // Start is called before the first frame update
    void Start()
    {
        badge.GetComponent<Canvas>().enabled = true;
        UIbadge.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisactivateBadge(){
        badge.GetComponent<Canvas>().enabled = false;
        UIbadge.GetComponent<Canvas>().enabled = true;
    }

    public void DisactivateUIBadge(){
        UIbadge.GetComponent<Canvas>().enabled = false;
    }

}
