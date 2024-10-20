using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WriteAnimation : MonoBehaviour
{
    string originalTexte;
    Text uiTexte;
    public float delai =1.0f; 

    // Update is called once per frame
  
    void Awake() 
    {
        uiTexte = GetComponent<Text>();
        originalTexte = uiTexte.text;
        uiTexte.text = null;
        StartCoroutine(ShowLetterByLetter());
    }

    IEnumerator ShowLetterByLetter()
    {
        for(int i = 0; i<= originalTexte.Length; i++)
        {
            uiTexte.text = originalTexte.Substring(0,i);
            yield return new WaitForSeconds(delai);
           
        }
    }
}
