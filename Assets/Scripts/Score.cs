using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text _score;
    private int _scoreValue;
    private readonly string _scoreTextCore = "Score: ";
    
    // Start is called before the first frame update
    void Start()
    {
        _score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        _score.text = _scoreTextCore + (++_scoreValue);
    }
}
