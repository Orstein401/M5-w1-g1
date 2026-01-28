
using UnityEngine;


public class Orbit : MonoBehaviour
{
    [SerializeField] Transform core;

    [Header("orbita")]
    [SerializeField] Vector3 offSet;
    [SerializeField] Vector3 angleDir;
    Vector3 orbit = Vector3.zero;

    [Header("parametri")]
    [SerializeField] float speed;

    [Header("disegno")]
    [SerializeField] float sides;


    private void Update()
    {
        //transform.position = new Vector3(core.transform.position.x+Mathf.Cos(angle)*offSet.x, core.transform.position.y,core.transform.position.z+ Mathf.Sin(angle)*offSet.z);
        //transform.position = CalculateOrbit();
        //transform.position=CalculateAngleOrbit(CalculateOrbit());

        CalculateOrbit();
        CalculateAngleOrbit();
    }

    private Vector3 CalculateOrbit()
    {
        float angle = Time.time * speed;


        orbit.x = core.position.x + Mathf.Cos(angle) * offSet.x;
        orbit.y = core.position.y;
        orbit.z = core.position.z + Mathf.Sin(angle) * offSet.z;

        return orbit;

        //orbit.y = core.transform.position.y + Mathf.Sin(Time.time) * offSet.y;
    }

    private void CalculateAngleOrbit()
    {

        Quaternion rotation = Quaternion.Euler(angleDir.y, angleDir.x, angleDir.z);
        orbit = rotation * orbit;
        transform.position = orbit;


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 startCorner = new Vector3 (core.position.x+offSet.x, 0, 0);
        Vector3 previusCorner = startCorner;
        for (int i = 0; i < sides; i++)
        {
            float cornerAngle = 2f * Mathf.PI / (float)sides * i;
            Vector3 currentCorner = new Vector3(Mathf.Cos(cornerAngle) * offSet.x, 0f, Mathf.Sin(cornerAngle) * offSet.z);

            Quaternion rotation = Quaternion.Euler(angleDir.y, angleDir.x, angleDir.z);
            currentCorner = rotation * currentCorner;
            currentCorner += core.transform.position;
            Gizmos.DrawLine(currentCorner, previusCorner);
            previusCorner = currentCorner;
        }
        Gizmos.DrawLine(previusCorner, startCorner);

        //Gizmos.color = Color.red;

        //Quaternion rotation = Quaternion.Euler(angleDir.y, angleDir.x, angleDir.z);

        //Vector3 prevPoint = Vector3.zero;
        //bool firstPoint = true;

        //for (int i = 0; i <= sides; i++)
        //{
        //    float angle = 2f * Mathf.PI / sides * i;

        //    Vector3 point = new Vector3(Mathf.Cos(angle) * offSet.x,0f,Mathf.Sin(angle) * offSet.z);

        //    // INCLINAZIONE DEL PIANO
        //    point = rotation * point;

        //    // TRASLAZIONE SUL CORE
        //    point += core.position;

        //    if (!firstPoint)
        //    {
        //        Gizmos.DrawLine(prevPoint, point);
        //    }
        //    else
        //    {
        //        firstPoint = false;
        //    }

        //    prevPoint = point;
        //}


    }

    //Quaternion rotation;
    //Vector3 desirePos;
    //float a = 1f;
    //float b = 0f;

    //a+= speed*Time.deltaTime;
    //rotation = Quaternion.Euler(a,b,0f);
    //desirePos = core.transform.position + rotation * offSet;
    //transform.SetPositionAndRotation(desirePos, rotation);

    //CalculateAngleOrbit()
    //Quaternion newInclination = Quaternion.AngleAxis(angleGrade, angleDir);
    //orbit = newInclination* orbit;
    //transform.position = core.transform.position +orbit;
}
