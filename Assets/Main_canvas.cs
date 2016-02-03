using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;


public class Main_canvas : MonoBehaviour {

	// Use this for initialization
    public Text text_dummy;
    public Button button_a;
    public Button button_b;

    void Start () {


        button_a.onClick.AsObservable().Subscribe(_ => text_dummy.text = "a button clicked");
        button_a.onClick.AsObservable().Subscribe(_ => text_dummy.color = Color.green);


        //button_a.OnClickAsObservable().Buffer(3).SubscribeToText(text_dummy, _ => "a button clicked");


        button_b.onClick.AsObservable().Subscribe(_ => text_dummy.text = "b button clicked");
        button_b.onClick.AsObservable().Subscribe(_ => text_dummy.color = Color.red);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
