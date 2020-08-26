using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_yaml : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteInput()
    {
        helpers helpers = general_manager.manager.helper;
        string FileContent = "";
        GameObject activePackage = helpers.SelectActivePackage();
        string resname = helpers.SelectText(activePackage, "resname_panel");
        string chain = helpers.SelectText(activePackage, "chain_panel");
        string initialPosition = helpers.SelectText(activePackage, "initial_panel");
        string finalPosition = helpers.SelectText(activePackage, "final_panel");
        FileContent = helpers.WriteLine("resname", resname, FileContent);
        FileContent = helpers.WriteLine("chain", chain, FileContent);
        Debug.Log(initialPosition);
        FileContent = helpers.WriteLine("initial_position", initialPosition, FileContent);
        FileContent = helpers.WriteLine("final_position", finalPosition, FileContent);
        Debug.Log(FileContent);
    }
}
