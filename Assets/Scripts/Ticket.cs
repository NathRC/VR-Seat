using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour
{

    public Canvas canvas;
    private GameObject siegeSelectionne;
    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                if (hit.collider != null){
                    Color redColor = new Color(1f,0f,0f,1f);
                    Color greenColor = new Color(0f,1f,0f,1f);
                    Color yourColor = new Color(1f,0.6f,0f,1f);

                    if (hit.collider.GetComponent<MeshRenderer>().material.color == redColor){
                        hit.collider.GetComponent<MeshRenderer>().material.color = redColor;
                    } else if (hit.collider.GetComponent<MeshRenderer>().material.color == greenColor){
                        GameObject parent = hit.collider.gameObject.transform.parent.gameObject;
                        foreach (Transform child in parent.transform){
                            child.gameObject.GetComponent<Renderer>().material.color = yourColor;
                        }
                        siegeSelectionne = parent;
                        activate(true);
                    } else if (hit.collider.GetComponent<MeshRenderer>().material.color == yourColor){
                        GameObject parent = hit.collider.gameObject.transform.parent.gameObject;
                        foreach (Transform child in parent.transform){
                            child.gameObject.GetComponent<Renderer>().material.color = greenColor;
                        }
                    }
                }
                Debug.Log(Physics.Raycast(ray, out hit));
            }
        }
    }

    public void activate(bool isActivated){
        canvas.GetComponent<Canvas>().enabled = isActivated;
    }

    public void DisactivateOk(){
        canvas.GetComponent<Canvas>().enabled = false;

        foreach (Transform child in siegeSelectionne.transform){
            child.gameObject.GetComponent<Renderer>().material.color = new Color(1f,0f,0f,1f);
        }
    }

    public void DisactivatePasOk(){
        canvas.GetComponent<Canvas>().enabled = false;

        foreach (Transform child in siegeSelectionne.transform){
            child.gameObject.GetComponent<Renderer>().material.color = new Color(0f,1f,0f,1f);
        }
    }

}
