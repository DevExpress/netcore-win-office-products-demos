## .Net Core 3 DevExpress WinForms Office Demos

This repository contains the following DevExpress Office demo applications that target .Net Core 3:

* Rich Text Editor
* Spreadsheet
* PDF Viewer

## System requirements

* Visual Studio 2019 with the .NET desktop development workload installed

* [.NET Core 3 SDK Preview 5 or more recent](https://dotnet.microsoft.com/download/dotnet-core/3.0)

## Run the demos

Open a solution in Visual Studio.

Before you build the solution, make sure that the 'Use previews of the .NET Core SDK' option is enabled (find this setting from the Visual Studio main menu: _Tools | Options | Project_ and _Solutions | .NET Core_).

If you downloaded the solution as a .zip file, you may encounter the following error when you build the project:

`MSB3821 Couldn't process file *.resx due to its being in the Internet or Restricted zone or having the mark of the web on the file. Remove the mark of the web if you want to process these files.`

Refer to the following article for information on how to resolve this issue: 

https://developercommunity.visualstudio.com/content/problem/291761/couldnt-process-file-abcresx-due-to-its-being-in-t.html

## Integrate DevExpress WinForms Office Controls into a .NET Core 3 application

Follow the steps below to add the DevExpress NuGet packages packages to your .Net Core 3 project:

1. [Register](https://docs.devexpress.com/GeneralInformation/116698/installation/install-devexpress-controls-using-nuget-packages/setup-visual-studio%27s-nuget-package-manager) the DevExpress Early Access feed in Visual Studio's NuGet Package Manager.

    'https://nuget.devexpress.com/early-access/api'

2. Install the **DevExpress.WindowsDesktop.Win** package (for .Net Core 3).

## Feedback

Use the DevExpress Support Center to provide feedback.

## See Also

[.NET Core 3.0 Windows Forms Samples](https://github.com/dotnet/samples/tree/master/windowsforms)
