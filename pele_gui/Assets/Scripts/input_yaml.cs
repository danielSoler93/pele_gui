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
        string input_yml = "input.yml";
        helpers helpers = general_manager.manager.helper;
        string FileContent = "";
        GameObject activePackage = helpers.SelectActivePackage();
        string system = general_manager.manager.system;
        string resname = helpers.SelectText(activePackage, "resname_panel");
        string chain = helpers.SelectText(activePackage, "chain_panel");
        string initialPosition = helpers.SelectText(activePackage, "initial_panel");
        string finalPosition = helpers.SelectText(activePackage, "final_panel");
        FileContent = helpers.WriteLine("system", system, FileContent);
        FileContent = helpers.WriteLine("resname", resname, FileContent);
        FileContent = helpers.WriteLine("chain", chain, FileContent);
        FileContent = helpers.WriteLine("initial_position", initialPosition, FileContent);
        FileContent = helpers.WriteLine("final_position", finalPosition, FileContent);
        FileContent = _WritePackageLine(activePackage, FileContent);
 
        System.IO.File.WriteAllText(input_yml, FileContent);
    }

    public string _WritePackageLine(GameObject activePackage, string FileContent)
    {
        helpers helpers = general_manager.manager.helper;
        if (activePackage.name == "gpcr")
        {
            FileContent = helpers.WriteLine("gpcr_orth", "true", FileContent);
        }
        else if (activePackage.name == "allosteric")
        {
            FileContent = helpers.WriteLine("allosteric", "true", FileContent);
        }
        else if (activePackage.name == "ppi")
        {
            FileContent = helpers.WriteLine("ppi", "true", FileContent);
        }
        else if (activePackage.name == "docking")
        {
            FileContent = helpers.WriteLine("induced_fit_fast", "true", FileContent);
        }
        else if (activePackage.name == "binding")
        {
            FileContent = helpers.WriteLine("out_in", "true", FileContent);
        }
        return FileContent;
    }
}
