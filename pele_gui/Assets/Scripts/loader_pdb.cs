using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;


public class loader_pdb: MonoBehaviour
    {
        //public GameObject prefab_template;
        public UnityEngine.Object prefab_template = Resources.Load("Sphere");

        public void load(string pdb)
        {
            UnityEngine.Object prefab_template = Resources.Load("Sphere");
            string fileName = pdb;
            Debug.Log("Hola");
            Debug.Log(prefab_template);
            IEnumerable<string> lines = File.ReadLines(fileName);
            List<Vector3> positions = new List<Vector3>();
            bool first = true;
            Vector3 translation = new Vector3(0, 0, 0);
            foreach (string line in lines)
            {
                string start = line.Substring(0, 6);
                if (start == "ATOM  " | start == "HETATM")
                {
                    string x_cord = line.Substring(31, 8);
                    string y_cord = line.Substring(39, 8);
                    string z_cord = line.Substring(47, 8);
                    Debug.Log(x_cord);
                    Debug.Log(y_cord);
                    Debug.Log(z_cord);
                    float x_cord_f = float.Parse(x_cord, CultureInfo.InvariantCulture.NumberFormat);
                    float y_cord_f = float.Parse(y_cord, CultureInfo.InvariantCulture.NumberFormat);
                    float z_cord_f = float.Parse(z_cord, CultureInfo.InvariantCulture.NumberFormat);
                    if (first == true)
                    {
                        translation = new Vector3(x_cord_f, y_cord_f, z_cord_f+10) - general_manager.manager.viewer.transform.position;
                        first = false;
                    }
                    Vector3 initial_position = new Vector3(x_cord_f, y_cord_f, z_cord_f);
                    Debug.Log("Initial" + initial_position);
                    Debug.Log("Translation" + translation);
                    Vector3 translated_position = initial_position  - translation;
                    GameObject atom = (GameObject) GameObject.Instantiate(prefab_template);
                    Debug.Log("Final" + translated_position);
                    atom.transform.position = translated_position;

                }
                
            }

        }

    }

