using UnityEngine;
using UnityEngine.UI;

public class ImgController : MonoBehaviour
{
    public Image[] images;  

    void Start()
    {
        string selectedObjectNamesString = PlayerPrefs.GetString("SelectedObjectNames", "");
        string[] selectedObjectNames = selectedObjectNamesString.Split(',');

        foreach (Image img in images)
        {
            if (ArrayContains(selectedObjectNames, img.gameObject.name))
            {
                img.gameObject.SetActive(true);
            }
        }
    }

    bool ArrayContains(string[] array, string value)
    {
        foreach (string item in array)
        {
            if (item == value)
                return true;
        }
        return false;
    }
}
