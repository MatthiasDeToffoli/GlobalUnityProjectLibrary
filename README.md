# GlobalUnityProjectLibrary
Library for global C# project link to unity, it's some stuff I create all the time when I work in new unity projects I made a library for use this more easily 

## Classes
### Editor
#### SwitchMenuButtonEditor

This script is link to the ***SwitchMenuButtonListener*** it show a checkbox ScreenToCloseIsParent if this checkbox is checked then so the screen to close is the object parent of the script, if not we need to set the object to close, so the property is showed in the Unity editor.

## Managers
### AMainManager

This abstract class manage all the managers you will create. For used it you have to create a child of it and use the type of the child as parameter.

```C#
public class MyMainManager : AMainManager<MyMainManager>
```

It's a singleton it will get the manager you want and initialise it. It has a property managers which is it list of managers. This list is created at the awake of the MainManager. It's the managers wich will told to it to add them in it list in their start (so the list doesn't have a reference to the other managers before it).

In the function after start (***see AMonobehavior***) the MainManager will call init of all managers sort by there Init Order (***see AManagedManager***).

This class has a method GetFirstManager wich will get the first manager it has and GetFirstManager<TManaged> where TManaged is a child of AManagedManager, 
  
```C#
MyManagedManager lManager = MyMainManager.instance.GetFirstManager<MyManagedManager>();
```
  
This last will get the first manager of this class, it's the only way to access to your managers.
  
*The main goal of this class is to avoid to much singleton*

### ManagedManager
#### AManagedManager

This abstract class represent all the managers which will be managed by the MainManager. It has a property InitOrder this one will say the order of call the Init between two ManagedManagers, if you have MyManagedManagerA which have an InitOrder set to 1 and MyManagedManagerB with an InitOrder set to 2, then the Init of the MyManagedManagerA will be call before the one of MyManagedManagerB.
In its start, the ManagedManager call a function for add itself in the MainManager.

#### AManagerWithList

It's a ***AManagedManager*** containing a list typed T called objects. For create a AManagerWithList you have to specify T

```C#
public class MyManagerWithListOfCarrot : AManagerWithList<Carrot>
```

#### AMenuManager

***AManagerWithList*** managing all the ***AMenuScreen***. In its Awake, it will active all AMenuScreen it has in it list for call their awake and Start. And in the Init of the Manager it will active false all it screen. You will have to set the screens in the list using the editor of Unity.
