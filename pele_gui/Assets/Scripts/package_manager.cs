using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class package_manager : MonoBehaviour
{

    public Dropdown package_dropdown;
    public GameObject package_sidebar;

    // Start is called before the first frame update
    void Start()
    {
        package_dropdown.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Change_PackagePanel()
    {
        // Switch left panel
        string package_selected = package_dropdown.options[package_dropdown.value].text.ToLower();
        foreach (Transform package in package_sidebar.transform)
        {
            if (package.name == package_selected)
            {
                package.gameObject.SetActive(true);
            }
            else
            {
                package.gameObject.SetActive(false);

            }
        }
    }

    public void deselectToggles(Toggle excludeToggle)
    {
        GameObject activePackage = general_manager.manager.helper.SelectActivePackage();

        foreach (Toggle toggle in activePackage.GetComponentsInChildren<Toggle>())
        {
            if (toggle != excludeToggle)
            {
                toggle.isOn = false;
            }
        }
    }
}
