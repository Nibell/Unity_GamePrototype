//////////////////////////////////////////////////////////////
// BenchmarkCSharp_Control.cs
//
// BenchmarkCSharp_Control creates a 2D control scheme where the back
// button is used to exit the application.
//////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class BenchmarkCSharp_Control : MonoBehaviour
{
    void Start()
    {
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("AppMeny");
        }
    }
}
