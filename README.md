Controlling visibility by removing the children looks like it works without causing everything to re-layout. 

Using IsVisible or changing the Text on a Label Invalidates the Children on XF2.0 whereas on XF1.3 it did not

I haven't found a way to change the text of a Label yet in XF2.0 that won't invalidate the measures on the parent.


Changing Text in Version 2.0 now fires
```
OnTextPropertyChanged event
```

Which seems to invalidate the measure and cause the Parent of the LayoutHost to layout the children

Changing Visibility in Version 2.0 fires

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
  
  MainPage.cs contains
  ```
          protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            Debug.WriteLine("Layout Changed");
        }
```

So you can watch when LayoutChildren is called on the parent content page.