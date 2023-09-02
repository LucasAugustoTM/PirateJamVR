using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUIScript : MonoBehaviour
{
    [SerializeField]
    GameObject winCanvas;
    [SerializeField]
    GameObject loseCanvas;
    [SerializeField]
    GameObject Mesh;
    [SerializeField]
    GameObject barco;

    private void OnDisable()
    {
        PlayerController.onEndLevel -= CheckWin;
    }

    private void OnEnable()
    {
        PlayerController.onEndLevel += CheckWin;
    }
 
    private void CheckWin(bool win)
    {
        if (win) {
            winCanvas.SetActive(true); 
            Mesh.SetActive(true);
            barco.GetComponent<MovementController>().windSpeed = 0;
            }
        else {
            loseCanvas.SetActive(true);
            Mesh.SetActive(true);
            barco.GetComponent<MovementController>().windSpeed = 0;
        }
    }
}
