using System.Collections;
using System.IO;
using System;
using SimpleFileBrowser;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SimpleFileBrowser.FileBrowser;
using System.Collections.Generic;


    public class general_manager : MonoBehaviour
    {
        public static general_manager manager;
        public Dropdown package_dropdown;
        public GameObject package_sidebar;
        public GameObject viewer;
        public GameObject prefab_template;
        Vector3 last_position = new Vector3(0, 0, 0);
        public List<GameObject> inputs = new List<GameObject>();
        public pick_atom pick_atom;
        public pick_atom pick_initial_position;
        public helpers helper;

    //public GameObject go = new GameObject();
    //public loader_pdb loader = go.AddComponent<loader_pdb>();

    void Start()
        // Classe singleton --> Only one manager in the whole project
        //Only one class can do this job
        {
            if (!manager)
        {
            manager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
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
            Debug.Log(package_selected);
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



        public GameObject input_panel;
        public void Load_file()
        {
            SimpleFileBrowser.FileBrowser.ShowLoadDialog((path) => { load_input(path); }, null,
            false, null, "Select File", "Select");

        }

        public static char GetLetter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            System.Random rand = new System.Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num];
        }


        public void load_input(string path)
        {
            string text_input = Path.GetFileName(path);
            //If no input just create and append
            if (inputs.Count == 0)
            {
                GameObject input = create_prefab(text_input, path);
                inputs.Add(input);
                Debug.Log(inputs.Count);
            }
            //If already generated inputs
            else
            {
                bool all_active = true;
                foreach (GameObject Input in inputs)
                {
                    //Check if there are not enabled ones and set them active
                    if (Input.activeSelf == false)
                    {
                        Input.SetActive(true);
                        Input.GetComponentInChildren<Text>().text = text_input;
                        Input.GetComponent<ClickableObject>().path = path;
                        all_active = false;
                    }

                    //If all active create a new one at the end
                    if (all_active == true)
                    {
                        GameObject input = create_prefab(text_input, path);
                        GameObject last_input = inputs[inputs.Count - 1];
                        input.transform.position =
                            last_input.transform.position +
                            new Vector3(0, -last_input.GetComponent<RectTransform>().rect.height + (float) 3, 0);
                        inputs.Add(input);
                        Debug.Log(inputs.Count);


                    }
                }


            }
           

          
        }

        private GameObject create_prefab(string text_input, string path)
        {
            GameObject parent = input_panel;

            GameObject go = Instantiate(prefab_template);
            go.transform.SetParent(parent.transform, false);
            go.GetComponentInChildren<Text>().text = text_input;
            char letter = GetLetter();
            go.name = text_input + letter;
            //create callback on click Loadviewer()
            //go.GetComponent<Button>().onClick.AddListener(input_actions);
            go.AddComponent<ClickableObject>();
            go.GetComponent<ClickableObject>().path = path;
            return go;

        }

        public void Load_viewer(GameObject panel)
        {

            string texto = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
            Debug.Log(texto);
            Debug.Log(panel.name);
        }

        private void input_actions()
        {
            if (Input.GetMouseButtonDown(0)){
                Load_viewer(viewer);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                EventSystem.current.currentSelectedGameObject.SetActive(false);
            }
        }

    }






 //general mager object
 //report
 //ventanas
 //cargar 3D
 //Button (salir) genericos ventan
