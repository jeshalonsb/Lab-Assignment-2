using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectManager))]
public class ObjectsManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectManager manager = (ObjectManager)target;

        DrawDefaultInspector();                                //draw normal inspector 

        EditorGUILayout.Space(10);

        if (manager.cubeSize > 2f)
        {
            EditorGUILayout.HelpBox("Size cant be more than 2", MessageType.Warning);                          //warning messages
        }
        else if (manager.cubeSize <= 0)
        {
            EditorGUILayout.HelpBox("Size cant be less than 0", MessageType.Warning);
        }

        if (manager.sphereRadius > 2)
        {
            EditorGUILayout.HelpBox("Radius cant be more than 2", MessageType.Warning);
        }
        else if (manager.sphereRadius < 1)
        {
            EditorGUILayout.HelpBox("Radius cant be less than 1", MessageType.Warning);
        }

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Cube Controls", EditorStyles.boldLabel);                             //cube setup

        if (GUILayout.Button("Select All Cubes"))
        {
            Selection.objects = manager.cubes;
        }

        if (GUILayout.Button ("Clear Selection"))
        {
            Selection.objects = new Object[0];
        }

        EditorGUILayout.EndHorizontal();

        bool cubesEnabled = ObjectsEnabled(manager.cubes);                            //check if cubes are enabled 

        if (cubesEnabled)
        {
            GUI.backgroundColor = Color.green;
        }
        else
        {
            GUI.backgroundColor = Color.red; 
        }

        if (GUILayout.Button("Disable / Enable All Cubes"))
        {
            ToggleObjects(manager.cubes);
        }

        GUI.backgroundColor = Color.white;

        EditorGUILayout.Space(10);

        EditorGUILayout.LabelField("Sphere Controls", EditorStyles.boldLabel);                   //sphere setup

        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("Select All Spheres"))
        {
            Selection.objects = manager.sphere;
        }
        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = new Object[0];
        }

        EditorGUILayout.EndHorizontal();

        bool spheresEnabled = ObjectsEnabled(manager.sphere);

        if (spheresEnabled)
        {
            GUI.backgroundColor = Color.green;
        }
        else
        {
            GUI.backgroundColor = Color.red;
        }

        if (GUILayout.Button ("Disable / Enable All Spheres"))
        {
            ToggleObjects(manager.sphere);
        }

        GUI.backgroundColor= Color.white;

    }
    private bool ObjectsEnabled(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null && !obj.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private void ToggleObjects (GameObject[] objects)
    {
        bool currentlyEnabled = ObjectsEnabled(objects);

        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                Undo.RecordObject(obj, "Toggle Object");

                obj.SetActive(!currentlyEnabled);

                EditorUtility.SetDirty(obj);
            }
        }
    }
}
