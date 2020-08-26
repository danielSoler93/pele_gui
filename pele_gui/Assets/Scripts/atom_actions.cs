using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atom_actions : MonoBehaviour
{
    //Triggered when you click on the sphere
    void OnMouseDown()
    {

        if (general_manager.manager.pick_atom.pick_residue == true)
        {
            UpdateResnameAndChain(this);
        }

        if (general_manager.manager.pick_atom.pick_initial_position == true)
        {
            UpdateInitialPosition(this);
        }
        if (general_manager.manager.pick_atom.pick_final_position == true)
        {
            UpdateFinalPosition(this);
        }
    }


    private void UpdateResnameAndChain(atom_actions atom)
    {
        Debug.Log(general_manager.manager.helper);
        GameObject package = general_manager.manager.helper.SelectActivePackage();
        Debug.Log(package.transform.childCount);
        for (int i = 0; i < package.transform.childCount; i++)
        {
            if (package.transform.GetChild(i).transform.name == "resname_panel")
            {
                InputField inputField = package.transform.GetChild(i).transform.GetComponentInChildren<InputField>();
                inputField.text = atom.GetComponent<atom_properties>().residue;
            }
            if (package.transform.GetChild(i).transform.name == "chain_panel")
            {
                InputField inputField = package.transform.GetChild(i).transform.GetComponentInChildren<InputField>();
                inputField.text = atom.GetComponent<atom_properties>().chain;
            }

         }
    }

    private void UpdateInitialPosition(atom_actions atom)
    {
        foreach (GameObject package in GameObject.FindGameObjectsWithTag("package"))
        {
            if (package.activeSelf)
            {
                Debug.Log(package.transform.childCount);
                for (int i = 0; i < package.transform.childCount; i++)
                {
                    if (package.transform.GetChild(i).transform.name == "initial_panel")
                    {
                        InputField inputField = package.transform.GetChild(i).transform.GetComponentInChildren<InputField>();
                        inputField.text = atom.GetComponent<atom_properties>().chain +
                            ":" + atom.GetComponent<atom_properties>().residue +
                            ":" + atom.GetComponent<atom_properties>().atomname;
                    }
                }

            }
        }
    }

    private void UpdateFinalPosition(atom_actions atom)
    {
        foreach (GameObject package in GameObject.FindGameObjectsWithTag("package"))
        {
            if (package.activeSelf)
            {
                Debug.Log(package.transform.childCount);
                for (int i = 0; i < package.transform.childCount; i++)
                {
                    if (package.transform.GetChild(i).transform.name == "final_panel")
                    {
                        InputField inputField = package.transform.GetChild(i).transform.GetComponentInChildren<InputField>();
                        inputField.text = atom.GetComponent<atom_properties>().chain +
                            ":" + atom.GetComponent<atom_properties>().residue +
                            ":" + atom.GetComponent<atom_properties>().atomname;
                    }
                }

            }
        }
    }
}
