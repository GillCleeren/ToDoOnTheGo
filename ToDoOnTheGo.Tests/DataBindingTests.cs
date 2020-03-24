using System;
using System.IO;
using System.Reflection;
using ToDoOnTheGo.Tests.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace ToDoOnTheGo.Tests
{
    public class DataBindingTests
    {
        [Fact(DisplayName = "Extend the ToDoItem Class")]
        public void CreatingToDoItemClass()
        {
            var filePath = TestHelpers.GetRootString() + "ToDoOnTheGo\\ToDoOnTheGo" + Path.DirectorySeparatorChar + "ToDoItem.cs";

            Assert.True(File.Exists(filePath), "`ToDoItem.cs` should exist in the ToDoOnTheGo project.");

            var toDoItemModel = TestHelpers.GetClassType("ToDoOnTheGo.ToDoItem");

            Assert.True(toDoItemModel != null, "`ToDoItem` class was not found, ensure `ToDoItem.cs` contains a `public` class `ToDoItem`.");

            var idProperty = toDoItemModel.GetProperty("Id");
            Assert.True(idProperty != null && idProperty.PropertyType == typeof(int), "`ToDoItem` class did not contain a `public` `int` property `Id`.");

            var descriptionProperty = toDoItemModel.GetProperty("Description");
            Assert.True(descriptionProperty != null && descriptionProperty.PropertyType == typeof(string), "`ToDoItem` class did not contain a `public` `string` property `Description`.");

            var completedProperty = toDoItemModel.GetProperty("Completed");
            Assert.True(completedProperty != null && completedProperty.PropertyType == typeof(bool), "`ToDoItem` class did not contain a `public` `bool` property `Completed`.");
        }

        [Fact(DisplayName = "Initialize the NewToDoItem property in the constructor")]
        public void InitializeNewToDoItemInConstructor()
        {
            MockForms.Init();

            var mainPage = new MainPage();

            var newToDoItem = mainPage.NewToDoItem;

            Assert.True(newToDoItem != null, "The `public` `ToDoItem` property `NewToDoItem` must be initialized in the constructor.");
        }

        [Fact(DisplayName = "Set the Binding Context for the view in the constructor")]
        public void SetBindingContextInConstructor()
        {
            MockForms.Init();

            var mainPage = new MainPage();

            var bindingContext = mainPage.BindingContext;

            Assert.True(bindingContext != null, "The BindingContext must be set.");

            var bindingContextType = bindingContext.GetType();
            Assert.True(bindingContextType == typeof(ToDoItem), "The BindingContext must be set to an instance of the ToDoItem type.");
        }

        [Fact(DisplayName = "Add First Label in StackLayout in MainPage")]
        public void AddFirstLabelInsideStackLayout()
        {
            MockForms.Init();

            var mainPage = new MainPage();
            var rootStackLayout = mainPage.Content as StackLayout;

            Assert.True(rootStackLayout != null, "The root item of MainPage should be a StackLayout.");

            var children = rootStackLayout.Children;
            Assert.True(children != null, "The Label needs to be added inside the StackLayout.");

            var descriptionLabel = rootStackLayout.Children[0] as Label;
            Assert.True(descriptionLabel != null, "The first child of the StackLayout needs to be a Label.");
        }

        [Fact(DisplayName = "Set the Text Property of the Label to Description")]
        public void SetTextOfDescriptionLabel()
        {
            MockForms.Init();

            var mainPage = new MainPage();
            var rootStackLayout = mainPage.Content as StackLayout;
            var descriptionLabel = rootStackLayout.Children[0] as Label;
            Assert.True(descriptionLabel.Text == "Description", "The Label Text property needs to be set to Description.");
        }

        [Fact(DisplayName = "Add Entry in StackLayout in MainPage after Label")]
        public void AddFirstEntryAfterLabel()
        {
            MockForms.Init();

            var mainPage = new MainPage();
            var rootStackLayout = mainPage.Content as StackLayout;
            var descriptionEntry = rootStackLayout.Children[1] as Entry;
            Assert.True(descriptionEntry != null, "The second child of the StackLayout needs to be an Entry.");
        }

        [Fact(DisplayName = "Set the Data Binding Statement on the Entry")]
        public void SetDataBindingStatement()
        {
            MockForms.Init();

            var mainPage = new MainPage();
            var rootStackLayout = mainPage.Content as StackLayout;
            var descriptionEntry = rootStackLayout.Children[1] as Entry;
            var databinding = descriptionEntry.GetBinding(Entry.TextProperty);
            Assert.True(databinding != null, "The data binding statement is missing from the Entry.");

            Assert.True(databinding.Path == "Description", "The Binding needs to be set to the Description property of the NewToDoItem.");
        }
    }
}
