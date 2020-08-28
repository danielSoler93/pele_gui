using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject SelectActivePackage()
    {
        foreach (GameObject package in GameObject.FindGameObjectsWithTag("package"))
        {
            if (package.activeSelf)
            {
                return package;
            }
        }
        return null;
    }

    public string SelectText(GameObject package, string panel)
    {
        for (int i = 0; i < package.transform.childCount; i++)
        {
            if (package.transform.GetChild(i).transform.name == panel)
            {
                InputField inputField = package.transform.GetChild(i).transform.GetComponentInChildren<InputField>();
                Debug.Log(inputField);
                return inputField.text;
            }
        }
        return null;
    }

    public string WriteLine(string key, string value, string fileContent)
    {
        if (value != null)
        {
            fileContent += key + ": " + value +  "\n";
        }
        return fileContent;
    }
}