using Main.AgentsController;
using Main.AgentsController.Observable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableHandler 
{
    BaseController _observable;
    IObserver _observer;
    IObserver[] _observerArray = new IObserver[5];
    public ObservableHandler(BaseController observable, IObserver observer) 
    {
        _observable = observable;
        AddObservers(observer);
        
    }
    public ObservableHandler(BaseController observable, IObserver[] observer) 
    {
        _observable = observable;
        AddObservers(observer);
        Debug.Log($"Added {observer} in {observable.name}");
    }
    private void AddObservers(IObserver observer)
    {
        this._observer = observer;
        this._observable.AddObserver(_observer);
        Debug.Log($"Added {observer} in {_observable}");
    }
    private void AddObservers(IObserver[] observer)
    {
        this._observerArray = observer;
        this._observable.AddObserver(this._observerArray);
    }
}
