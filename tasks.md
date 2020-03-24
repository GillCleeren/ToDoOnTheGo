# Using data binding in Xamarin.Forms

## Purpose of the project
This project will show you how to build a simple data bound interface in Xamarin.Forms using XAML.

## Task 1: Clone the starter project

Once you have cloned the project to your local machine, follow the steps below to open the project in Visual Studio:

- Open the folder where you cloned the project from GitHub. Make sure to use the `start` branch.
- In that folder, look for the `ToDoOnTheGo.sln` file and double-click it. Visual Studio will open and load the starter project.
- To ensure that all is working fine on your machine, right-click on the solution in the Solution Explorer and select Build Solution. Once the solution has successfully compiled, you are good to go.

### Running the tests

Still in the Solution Explorer, look for the ToDoOnTheGo.Tests project. This project contains all the tests that we&#39;ll use to test your progress. Right-click the project and select Run Tests. The Test Explorer will open and will run all tests. The tests will fail at this point but that's entirely normal.

## Task 2: Extend the ToDoItem class

In the root of the ToDoOnTheGo project, you'll find the `ToDoItem` class. Inside this class, add the following properties and make sure all properties are public:

- `Id` of type `int`
- `Description` of type `string`
- `Completed` of type `bool`


## Task 3: Initialize the property from the constructor

In the constructor of MainPage.xaml.cs, instantiate the NewToDoItem property to be a new ToDoItem using `NewToDoItem = new ToDoItem();`. Make sure to put this code after the already present `InitializeComponent()` call.

## Task 4: Set the BindingContext

Through the BindingContext property, we can specify which object the UI (XAML) will be data binding to. That will in our case be the NewToDoItem. Set the `this.BindingContext` property to be equal to the NewToDoItem to do so. Make sure to do this still in the constructor.

## Task 5: Build up the UI

Open the `MainPage.xaml` now. You&#39;ll see in there already a `StackLayout`. Add within this `StackLayout` a new `Label` using XAML.

```
<StackLayout>

     <Label></Label>
        
</StackLayout>
```
Note that in XAML, spacing and line breaks between elements have no influence on the final UI.

## Task 6: Set the text for the Label

This `Label` will be used to point the user to what data he or she should be entering in the text entry we will add soon. Therefore, set the `Text` property of the `Label` to `Description`.
```
<Label Text="Description"></Label>
```

## Task 7: Add an entry

Below the `Label` but still within the `StackLayout`, now create an `Entry`. An `Entry` in Xamarin.Forms will be rendered as a textbox.
```
<Entry></Entry>
```

## Task 8: Data bind the Entry

We&#39;ll want the `Entry` to be data bound to the `Description` property on the `NewToDoItem`, which we have already set as the `BindingContext`. 

To create the data binding, set the value of the `Text` property to `{Binding Description}`. Make sure to surround this expression with double quotes.

```
<Entry Text="{Binding Description}"></Entry>
```

At this point, you have created your first data-bound interface in Xamarin.Forms using XAML. 