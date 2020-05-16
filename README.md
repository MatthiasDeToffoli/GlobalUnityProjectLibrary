# GlobalUnityProjectLibrary
Library for global C# project link to unity, it's some stuff I create all the time when I work in new unity projects I made a library for use this more easily 

## Classes
### MonoBehaviours
#### AMonoBehaviour
this abstract class is a child of Monobehaviour, it add a mathod ListenToEvent call on the Start (used for listening all event the MonoBehavior will have to listen), another method UnlistenToEvent called on the OnDestroy (used for unlistening all events the MonoBehavior listen) and the method AfterStart called after all Start of the project. 

*This function as created because for me the Awake is for initialise own properties of the class, on the Start we can link to other Monobehaviors. So for have interaction and initialisation with all Monobehavior initialized I use the AfterStart because that mean all monobehaviors are initialized.*

#### AMonoBehaviourSingleton
It's an abstract class representing an ***AMonobehaviour*** which is a singleton. For used it you have to create a child of it and use the type of the child as parameter.

```C#
public class MyMonoBehaviourSingleton : AMonoBehaviourSingleton<MyMonoBehaviourSingleton>
```
So you will can have only one object with this component, if you put two you can select the behavior, it will destroy the old version and keep the new or keep the old and destroy the new but it will never keep several versions. You have another option in the editor for keep the object when you will change scene. So the object will never be destroyed and keep its values.

### Managers
#### AMainManager

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

It has a Method clear for clear all the managers et its list
  
*The main goal of this class is to avoid to much singleton*

#### ManagedManager
##### AManagedManager

This abstract class represent all the managers which will be managed by the MainManager. It has a property InitOrder this one will say the order of call the Init between two ManagedManagers, if you have MyManagedManagerA which have an InitOrder set to 1 and MyManagedManagerB with an InitOrder set to 2, then the Init of the MyManagedManagerA will be call before the one of MyManagedManagerB.
In its start, the ManagedManager call a function for add itself in the MainManager.

##### AManagerWithList

It's a ***AManagedManager*** containing a list typed T called objects. For create a AManagerWithList you have to specify T

```C#
public class MyManagerWithListOfCarrot : AManagerWithList<Carrot>
```

##### AMenuManager

***AManagerWithList*** managing all the ***AMenuScreen***. In its Awake, it will active all AMenuScreen it has in it list for call their awake and Start. And in the Init of the Manager it will active false all it screen. You will have to set the screens in the list using the editor of Unity.

### Menu

#### AMenuScreen

This will represent UI screens (like MainMenu, OptionsMenu...) it has two functions, open and close, wich will SetActive true or false on its gameobject.

#### ButtonListeners
##### AButtonListener

This class need the UnityEngine.UI.Button component on it object for work. It will listen the events of the button and do actions with it. It will be used for more control and do actions in the C# script and not in the unity Editor, better for encapsulation and control our code. When we click on the button the function OnButtonClicked will be called.

##### ExitAppButtonListener

It's a AButtonListener which will exit the application when the button will be clicked

##### SwitchMenuButtonListener
It's a AButtonListener which will close a screen and open another  when the button will be clicked. The screen to close can be the parent GameObject or a screen set in the Unity editor. The screen to open will be set in the Unity editor.

### Editor
### GuiStyles

Static class for implement default GUI styles used in editor

#### SwitchMenuButtonEditor

This script is link to the ***SwitchMenuButtonListener*** it show a checkbox ScreenToCloseIsParent if this checkbox is checked then so the screen to close is the object parent of the script, if not we need to set the object to close, so the property is showed in the Unity editor.

### Utils
#### Enums
##### GameState
Enum used for know the game state (in menu, in game, loading, pause) it has an instance in the MainManager

#### Constants

Constants global to all the project

#### GlobalEventHandler
Static class keeping all global static events wich can be called in the project
##### Manager
All global static events used in the managers

___

*<sub>Made with Unity 2019.3.13f1 and .Net Standard 2.1</sub>*
