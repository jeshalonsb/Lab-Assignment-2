using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [Header("Cubes")]
    public GameObject[] cubes = new GameObject[5];
    public float cubeSize = 1f;
                                                                        //cube - sphere array
    [Header("Spheres")]
    public GameObject[] sphere = new GameObject[5];
    public float sphereRadius = 1f;

    private void OnValidate()
    {
         foreach (GameObject cube in cubes)
        {
            if (cube != null)
            {
                cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);                  //set cube size 
            }
        }

         foreach (GameObject sphere in sphere)
        {
            if (sphere != null)                          
            {
                float diameter = sphereRadius * 2;

                sphere.transform.localScale = new Vector3(diameter, diameter, diameter);                //set sphere size
            }
        }
    }

}
