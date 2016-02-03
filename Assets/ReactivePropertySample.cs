using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using System;

// Reactive Notification Model
[Serializable]
public class Enemy// : ReactiveProperty<long>
{
    public ReactiveProperty<long> hp { get; private set; }

    public ReactiveProperty<bool> IsDead { get; private set; }

    public Enemy(int initialHp)
    {
        // Declarative Property
        hp = new ReactiveProperty<long>(initialHp);
        IsDead = hp.Select(x => x <= 0).ToReactiveProperty();
    }
}

public class ReactivePropertySample : MonoBehaviour
{
    public Enemy ememy_ = null;
    public FruitReactiveProperty fp_;

    public Button fire_gun;
    public Text ememy_hp;

	// Use this for initialization
	void Start () {
        ememy_ = new Enemy(100);

        fire_gun.onClick.AsObservable().Subscribe(_ => ememy_hp.color = Color.red);
        fire_gun.OnClickAsObservable().Subscribe(_ => ememy_.hp.Value -= 9);

        //fire_gun.onClick.AsObservable().Subscribe(x => Debug.Log(ememy_.Value));
        
        

        ememy_.hp.SubscribeToText(ememy_hp);
        ememy_.IsDead.Select(isDead => !isDead).SubscribeToInteractable(fire_gun);
        //ememy_.IsDead
        //    .Where(isDead => isDead == true)
        //    .Subscribe(_ =>
        //    {
        //        fire_gun.interactable = false;
        //    });
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum Fruit
{
    Apple, Grape
}

[Serializable]
public class FruitReactiveProperty : ReactiveProperty<Fruit>
{
    public FruitReactiveProperty()
    {
    }

    public FruitReactiveProperty(Fruit initialValue)
        : base(initialValue)
    {
    }
}