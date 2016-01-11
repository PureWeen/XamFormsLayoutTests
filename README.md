Changing Text in Version 2.0 now fires a
```
OnTextPropertyChanged event
```

Which seems to invalidate the measure and cause the Parent of the LayoutHost to layout the children

Changing Visibility in Version 2.0 fires an

```
 OnIsVisibleChanged(Boolean oldValue, Boolean newValue)
 ```
 
 
 These seem to fire a new method
 
 ```
  this.InvalidateMeasure(InvalidationTrigger.Undefined);
  ```
  
  That you can't short circuit by using your own Layout..
  
  
  The included projects have the same code except one version is Forms 1.3 and the other is Forms 2.0.
  
  1.3 looks to short circuit successfully where as 2.0 does not.