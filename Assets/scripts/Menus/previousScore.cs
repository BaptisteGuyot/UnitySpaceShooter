using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class previousScore : MonoBehaviour
{

       
    // Start is called before the first frame update
    void Start()
    {

        GameObject dataContainer = GameObject.Find("dataContainer");
        if(dataContainer != null)
        {
            bool previousState = dataContainer.GetComponent<dataContainerScript>().getWon();
            int previousScore = dataContainer.GetComponent<dataContainerScript>().getPreviousScore();
            GameObject.Find("previousScoreText").GetComponent<TextMeshProUGUI>().SetText((previousState ? "Victory !" : "Defeat...")+"\n Previous score : {0}", previousScore);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
