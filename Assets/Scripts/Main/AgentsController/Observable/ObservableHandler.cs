using Main.AgentsController;
using Main.AgentsController.Observable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableHandler 
{
    BaseController observable;
    IObserver observer;
    IObserver[] _observerArray = new IObserver[5];
    public ObservableHandler(BaseController observable, IObserver observer) 
    {
        this.observable = observable;
        AddObservers(observer);
        
    }
    public ObservableHandler(BaseController observable, IObserver[] observer) 
    {
        this.observable = observable;
        AddObservers(observer);
        Debug.Log($"Added {observer} in {observable.name}");
    }
    public void AddObservers(IObserver observer)
    {
        this.observer = observer;
        this.observable.AddObserver(this.observer);
        Debug.Log($"Added {observer} in {observable}");
    }
    public void AddObservers(IObserver[] observer)
    {
        this._observerArray = observer;
        this.observable.AddObserver(this._observerArray);
    }
}
