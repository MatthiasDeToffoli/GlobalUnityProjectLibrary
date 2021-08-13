# GlobalUnityProjectLibrary
Library for global C# project link to unity, it's some stuff I create all the time when I work in new unity projects I made a library for use this more easily 

## Classes
### Attributes
#### CustomLabelAttribute
Attribute used for change the label text of a property in the unity inspector

*This attribute don't work on arrays, lists or their elements*

#### CustomElementLabelAttribute
Attribute used for change the label text of arrays or lists elements.

It can replace the element label by one word keeping the index of the element. 
It can also replace some elements by words without the index (the words are set in a array of nullable string), in this case if the elements index not match it will write element + the index or a word you chosed + the index.

*This attribute don't work only on arrays or lists elements*

#### RangeWithStepAttribute
Attribute which work like the Unity's attribute Range with a step

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

### Levels
#### ALevelBehavior
Behavior for the levels

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

##### ALevelManager
Abstract parent of all ***AManagerWithList*** which will managed the ***ALevelBehavior*** objects

##### MenuManager

***AManagerWithList*** managing all the ***AMenuScreen***. In its Awake, it will active all AMenuScreen it has in it list for call their awake and Start. And in the Init of the Manager it will active false all it screen. You will have to set the screens in the list using the editor of Unity.

### Menu

#### Screens
##### AMenuScreen

This will represent UI screens (like MainMenu, OptionsMenu...) it has two functions, open and close, wich will SetActive true or false on its gameobject.

##### AValidationScreen

A screen will be used for validate an action it has two buttons, one for validate, the other for invalidate

#### ButtonListeners
##### AButtonListener

This class need the UnityEngine.UI.Button component on it object for work. It will listen the events of the button and do actions with it. It will be used for more control and do actions in the C# script and not in the unity Editor, better for encapsulation and control our code. When we click on the button the function OnButtonClicked will be called.

##### BooleanButtonListeners
###### ABooleanButtonListener.
Button Listener which send a boolean state when we click on it.

###### BooleanButtonListenerConfigurable
***ABooleanButtonListener*** which has a state configurable in the inspector

###### ValidateButtonListener.

***ABooleanButtonListener*** which always send true

###### InvalidateButtonListener.

***ABooleanButtonListener*** which always send false

##### CloseScreenButtonListener
It's a AButtonListener which will close a screen when the button will be clicked. The screen to close can be the parent GameObject or a screen set in the Unity editor.

##### ExitAppButtonListener

It's a AButtonListener which will exit the application when the button will be clicked

##### SwitchScreenButtonListener
It's a Close Screen Button Listener which will open a screen when the button will be clicked, in more than close another one. The screen to open will be set in the Unity editor.

### Pooling
#### GameObjectPoolElement
Pool element which will create game objects

#### PoolInitializerContainer
Pool initializer which contain a list of ***GameObjectElement*** (this last can be updated in unity inspector)

*Overide this class for add more list editables, and overide the property elements for used all your list*

#### APoolManager
Manager which manage all the pools and their container. It wait a typeparam for it Initializer container which is a ***PoolInitializerContainer***.

### VisualFeebacks

#### AVisualFeedBack
Abstract class used for show a visual feedback with code

#### AShortLivedVisualFeedback
***AVisualFeedBack*** which will desapear after a time

#### AVisualFeedBacksManager
Manager used for manage all visual feedbacks

### Editor

#### CustomEditors
##### CloseScreenButtonListenerEditor

This script is linked to the ***CloseScreenButtonListener*** class, it show a checkbox ScreenToCloseIsParent if this checkbox is checked then so the screen to close is the object parent of the script, if not we need to set the object to close, so the property is showed in the Unity editor.

##### SwitchScreenButtonEditor

This script is linked to the ***SwitchScreenButtonListener*** class, it is a child of ***CloseScreenButtonListenerEditor***, so it work like it but add the possibility to set a screen to open.

#### Drawers
#### CustomLabelDrawers

Linked to the ***CustomLabel*** attribute, it change the property's label

#### CustomElementLabelDrawer

Linked to the ***CustomElementLabel*** attribute, it change the Element's label

##### RangeWithStepDrawer

Linked to the ***RangeWithStep*** attribute, it apply the step on the slider in the unity inspector GUI

#### GUIStyles

Static class for implement default GUI styles used in editor

### Utils
#### Enums
##### GameState
Enum used for know the game state (in menu, in game, loading, pause) it has an instance in the MainManager
##### CoroutineTypeOfWait
Enum used for know if we want to wait the end of frames, seconds or fixed updated

#### Constants

Constants global to all the project

##### Manager
All global static events used in the managers

___

*<sub>Made with Unity 2020.1.0f1 and .Net Standard 2.1</sub>*
