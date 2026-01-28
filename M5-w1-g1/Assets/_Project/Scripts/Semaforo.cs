using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    [SerializeField] private bool on;
    [SerializeField] private Color color;

    [SerializeField] private MeshRenderer green;
    [SerializeField] private MeshRenderer yellow;
    [SerializeField] private MeshRenderer red;


    private void OnEnable()
    {
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        while (on)
        {
            red.material.color = Color.gray;
            green.material.color = Color.green;
            Debug.Log("verde");

            yield return new WaitForSeconds(3f);

            green.material.color = Color.gray;
            yellow.material.color = Color.yellow;
            Debug.Log("yellow");

            yield return new WaitForSeconds(3f);

            yellow.material.color = Color.gray;
            red.material.color = Color.red;
            Debug.Log("red");

            yield return new WaitForSeconds(3f);

        }

    }
}
