using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;


public class Button_a : MonoBehaviour {

    void Awake()
    {
        IObservable<int> clickCountStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ => 1)
            .Scan((acc, current) => acc + current);

        clickCountStream.Subscribe(clickCount => Debug.Log(clickCount));
    } 

	// Use this for initialization
	void Start () {

        //string text = GameObject.Find("Text_dummy").GetComponent<Text>().text;
        //Debug.Log(text);

        //this.gameObject.
        //LoginButton.onClick.AsObservable().Subscribe(_ => _sceneManager.TryLogin(InputFieldID.text, InputFieldPassword.text));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
