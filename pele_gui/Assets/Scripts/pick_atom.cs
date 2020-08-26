using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pick_atom : MonoBehaviour
{
    public bool pick_residue;
    public bool pick_initial_position;
    public bool pick_final_position;

    public void Start()
    {
        pick_residue = false;
        pick_initial_position = false;
        pick_final_position = false;
    }


    public void Toggle_Changed_Residue(bool new_value)
    {
        general_manager.manager.pick_atom.pick_residue = new_value;
    }

    public void ToggleChangedInitialPosition(bool new_value)
    {
        general_manager.manager.pick_atom.pick_initial_position = new_value;
    }

    public void ToggleChangedFinalPosition(bool new_value)
    {
        general_manager.manager.pick_atom.pick_final_position = new_value;
    }
}
