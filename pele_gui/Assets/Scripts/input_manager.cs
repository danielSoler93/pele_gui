using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Globalization;




public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    //public List<GameObject> inputs;
    public string path;



    public void Load_viewer(GameObject panel)
    {

        //string texto = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        string ext = Path.GetExtension(this.path);
        general_manager.manager.system = path;
        if (ext == ".pdb")
        {
            load(path);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Load_viewer(general_manager.manager.viewer);
        else if (eventData.button == PointerEventData.InputButton.Middle)
            Debug.Log("Middle click");
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            /*
            Encontra nombre???
            //GameObject go = GameObject.Find(eventData.button.name); 
            //if (go != null)
            //{
                go.SetActive(false);
            //}
            */
        }



    }


    public void load(string pdb)
    {
        UnityEngine.Object prefab_template = Resources.Load("Sphere");
        string fileName = pdb;
        IEnumerable<string> lines = File.ReadLines(fileName);
        List<Vector3> positions = new List<Vector3>();
        List<string> residues = new List<string>();
        bool first = true;
        Vector3 translation = new Vector3(0, 0, 0);

        foreach (string line in lines)
        {
            if (line.Length > 6)
            {
                string start = line.Substring(0, 6);
                if (start == "ATOM  " | start == "HETATM")
                {

                    string x_cord = line.Substring(31, 8);
                    string y_cord = line.Substring(39, 8);
                    string z_cord = line.Substring(47, 8);
                    float x_cord_f = float.Parse(x_cord, CultureInfo.InvariantCulture.NumberFormat);
                    float y_cord_f = float.Parse(y_cord, CultureInfo.InvariantCulture.NumberFormat);
                    float z_cord_f = float.Parse(z_cord, CultureInfo.InvariantCulture.NumberFormat);
                    string residue = line.Substring(17, 3).Trim();
                    string resnum = line.Substring(23, 3).Trim();
                    string chain = line.Substring(21, 1).Trim();
                    string atomname = line.Substring(11, 5).Trim();

                    if (first == true)
                    {
                        translation = new Vector3(x_cord_f, y_cord_f, z_cord_f) - general_manager.manager.viewer.transform.position;
                        first = false;
                    }
                    Vector3 initial_position = new Vector3(x_cord_f, y_cord_f, z_cord_f);
                    Vector3 translated_position = initial_position - translation;
                    GameObject atom = (GameObject)GameObject.Instantiate(prefab_template);
                    atom.transform.SetParent(general_manager.manager.viewer.transform);
                    atom.transform.position = translated_position;
                    atom_properties properties = atom.AddComponent<atom_properties>();
                    properties.residue = residue;
                    properties.chain = chain;
                    properties.atomname = atomname;
                    properties.position = atom.transform.position;
                    properties.resnum = resnum;


                }
            }

        }

    }

}




