using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownButton : MonoBehaviour
{
    private TMP_Dropdown drop;
    private TextMeshProUGUI txt;
    TMP_Dropdown.OptionData optData1, optData2, optData3, optData4, optData5, optData6;
    List<TMP_Dropdown.OptionData> messages = new List<TMP_Dropdown.OptionData>();
    int msgIndex;
    private SceneController SceneCtrl;

    void Start() {
        SceneCtrl = GameObject.Find("SceneController").GetComponent<SceneController>();
        txt = GameObject.Find("Label").GetComponent<TextMeshProUGUI>();
        drop = GetComponent<TMP_Dropdown>();
        drop.ClearOptions();

        optData1 = new TMP_Dropdown.OptionData();
        optData1.text = "2 x 4";
        messages.Add(optData1);

        optData2 = new TMP_Dropdown.OptionData();
        optData2.text = "2 x 3";
        messages.Add(optData2);

        optData3 = new TMP_Dropdown.OptionData();
        optData3.text = "2 x 5";
        messages.Add(optData3);

        optData4 = new TMP_Dropdown.OptionData();
        optData4.text = "3 x 4";
        messages.Add(optData4);

        optData5 = new TMP_Dropdown.OptionData();
        optData5.text = "4 x 4";
        messages.Add(optData5);

        optData6 = new TMP_Dropdown.OptionData();
        optData6.text = "4 x 5";
        messages.Add(optData6);

        foreach (TMP_Dropdown.OptionData message in messages) {
            drop.options.Add(message);
            msgIndex = messages.Count - 1;
        }

        drop.onValueChanged.AddListener(delegate { ValueChanged(drop); });
        drop.value = PlayerPrefs.GetInt("dropdown_value", 0);
        drop.RefreshShownValue();
        txt.text = "Option" + drop.value + ": " + drop.options[drop.value].text;
    }

    void Update() {

    }

    void ValueChanged(TMP_Dropdown change) {
        txt.text = "Option" + change.value + ": " + change.options[change.value].text;
        switch (change.value) {
            case 0: //2 x 4
                SceneCtrl.SetSize(2, 4);
                PlayerPrefs.SetInt("rows", 2);
                PlayerPrefs.SetInt("columns", 4);
                PlayerPrefs.SetInt("dropdown_value", 0);
                break;
            case 1: //2 x 3
                SceneCtrl.SetSize(2, 3);
                PlayerPrefs.SetInt("rows", 2);
                PlayerPrefs.SetInt("columns", 3);
                PlayerPrefs.SetInt("dropdown_value", 1);
                break;
            case 2: //2 x 5
                SceneCtrl.SetSize(2, 5);
                PlayerPrefs.SetInt("rows", 2);
                PlayerPrefs.SetInt("columns", 5);
                PlayerPrefs.SetInt("dropdown_value", 2);
                break;  
            case 3: //3 x 4
                SceneCtrl.SetSize(3, 4);
                PlayerPrefs.SetInt("rows", 3);
                PlayerPrefs.SetInt("columns", 4);
                PlayerPrefs.SetInt("dropdown_value", 3);
                break;  
            case 4: //4 x 4
                SceneCtrl.SetSize(4, 4);
                PlayerPrefs.SetInt("rows", 4);
                PlayerPrefs.SetInt("columns", 4);
                PlayerPrefs.SetInt("dropdown_value", 4);
                break;  
            case 5: //4 x 5
                SceneCtrl.SetSize(4, 5);
                PlayerPrefs.SetInt("rows", 4);
                PlayerPrefs.SetInt("columns", 5);
                PlayerPrefs.SetInt("dropdown_value", 5);
                break;          
        }
        PlayerPrefs.Save();
    }

}
