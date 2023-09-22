using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Click : MonoBehaviour
{
    private List<string> selectedObjectNames = new List<string>(); 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                CapsuleCollider capsuleCollider = hit.collider.GetComponent<CapsuleCollider>();
                if (capsuleCollider != null)
                {
                    selectedObjectNames.Add(capsuleCollider.gameObject.name);

                    Debug.Log("Clicked Object Name: " + capsuleCollider.gameObject.name);
                }
                else
                {
                    Debug.Log("The clicked object does not have a CapsuleCollider.");
                }
            }
        }
    }

    public void OnSonucButtonClicked()
    {
        string selectedObjectNamesString = string.Join(",", selectedObjectNames.ToArray());
        PlayerPrefs.SetString("SelectedObjectNames", selectedObjectNamesString);

        SceneManager.LoadScene(1);
    }
}
