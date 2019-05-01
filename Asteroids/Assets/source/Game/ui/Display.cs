using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Text scoreDisplay;

    void Start()
    {
        // get the score display
        scoreDisplay = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        // update & display the score
        scoreDisplay.text = Utilities.Instance.PlayerScore.ToString();
    }
}
