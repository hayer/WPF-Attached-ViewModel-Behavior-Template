# ***Attached View Model Behavior*** templates for _dotnet new_

Simple package that simplifies the creation attached viewmodel behaviors.
Based on idea of Sacha Barber, based on template by [@espenrl](https://github.com/espenrl), forked from [here](https://github.com/espenrl/WPF-Attached-ViewModel-Behavior-Template).

Updated to use ***.NET Core 3.0***.

## How to use

 1. Create a _project_
```bash
dotnet new avmb-project -n MyAwesomeApp
```

 2. Create a _view_ and a _viewmodel_
```bash
dotnet new avmb-view --namespace MyAwesomeApp -n FirstView
```

> Use _`--only-viewmodel`_ or _`--only-view`_ to create only viewmodel or view.

 3. Create some _behaviors_ for the viewmodel
```bash
dotnet new avmb-behavior --namespace MyAwesomeApp --viewmodel FirstViewModel -n SaveBehavior
dotnet new avmb-behavior --namespace MyAwesomeApp --viewmodel FirstViewModel -n OpenBehavior
```

 4. Project will now contain a couple of errors, these are reminders to register the viewmodel and behaviors!


### Program not working? Create an issue.
### Template annoying? Think something is missing? Create an issue.
