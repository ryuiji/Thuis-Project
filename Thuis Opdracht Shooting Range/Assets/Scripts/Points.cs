using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    public int points;
    private int hitPoints = 10;
    public Text pointText;

	void Start () {
        points = 0;
	}
	
	public void AddPoints () {
        points += hitPoints;
        PointText();
	}
    public void PointText() {
        pointText.text = "Points: " + points.ToString();
    }
}
