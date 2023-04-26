# FinalProjectSVGEditor
## Overview
This software is Final Project for course CS321, a simple editor in SVG file format. It can draw a total of 5 different patterns (ellipse, circle, rectangle, square and line). The code corresponding to the SVG file can be seen in real-time while the pattern is being generated. The editor supports exporting to four different formats, including SVG files, PNG files, PDF files and JEPG files, and supports re-importing existing SVG files. In addition to these, the editor also supports saving the current job state and reloading the job state to the editor when the user needs it. File save detection is also implemented in the editor, when the user closes or accidentally closes the window, the editor will detect whether the user has saved or not and alert the user, allowing the user to decide whether to continue to close the editor.

## Installtion
This software provides free installation, users only need to download the zip package and unzip it to any place on the computer to double-click the EXE program to start using this editor.

## Features/Functions
When the user uses the software for the first time, a folder named SAVEDATA will be automatically generated in the folder where the exe file is located. This folder will be used as a folder for the software to detect the save status and store the user's current work status, so please do not change the default folder when Saving (the default folder has been set to SAVEDATA). When the software runs, the software will generate a svg format file named SVGTempOutput.svg in the directory where the exe file is located. This file will be used as a temporary svg file for the editing state of the software. This file will be cleaned up automatically when the program is closed. After double-clicking the exe file to enter the editor, the editor will automatically detect if there is a saved working state in the SAVEDATA folder, if there is a saved working state, then the editor will automatically ask the user whether to choose to load a particular working state. After the user chooses to load or not to load, the editor will enter the main interface. On the right side of the interface is a visual display of the code in SVG file format. By default it is open, user can click menu bar-View-SVG Code View to close to make the SVG code display window disappear. The window displaying SVG code will always follow the position of the main window. The editor provides three different positions for the SVG Code View window, and the user can set the SVG View window to the left and right of the main window and to the free state (not affected by the position of the main window). Users only need to click Menu bar-View-SVG Code View Location to set the SVG window position. The left window is the main window of the editor. The window is divided into two parts, the upper part is the drawing box, where the user can use the mouse to draw specific graphics. The lower part is the log box, where some important user actions will be recorded. The bottom right corner of the log box has a button to clear the current log. The bottom left corner of the main window has coordinates relative to the frame, which makes it easier for the user to locate the pattern. The Type next to it shows the currently selected graphic category. The upper center of the main window shows the name of the file you are currently working on. In the top left corner of the form, there is a button called PenStyle. When the user presses the button, various options will appear with the brush, including color, graphic shape, line thickness, etc. The user can customize different options to draw different pictures in the drawing board.In the menu bar, the software has four main options, File, Edit, View and Tools. in the File menu, there are six sub options, namely NewWork, OpenSVGFile, Savework, loadwork, Export and Exit.

### NewWork
When user clicks NewWork, the editor will automatically identify whether user saves current work or not, if not, the editor will remind user to save. However, the user can also ignore the reminder and start a new work directly.
### OpenSVGFile
When the user clicks OpenSVGFile, the editor will pop up a file selection box for the user to choose the SVG file they want to open. After the user selects the file, the editor will automatically load the SVG to the editor page, thus displaying the screen of the currently selected SVG in the editor screen window and loading the code of the current SVG file to the SVG code display window on the right side of the screen. The user will be able to continue to modify the current svg file in the screen window in the form of drawing. The user will be able to use the mouse to draw directly in the screen window to visually modify the SVG file, and will also be able to delete the last pattern with the right mouse button.
### SaveWork
The editor allows the user to save the current work. By clicking the SaveWork button, the user can customize the name of the work save file. However, the user is asked to save the work file strictly in the default save location, because the editor's save decision is based on the file recognition of the default save location.
### LoadWork
The editor also provides the user with the ability to load previously saved work. When users click Loadwork and select the work they want to load, the editor will automatically load the image and code into the image window and code window respectively. This allows users to continue to complete their work.
### Export
The Export button provides four different formats for exporting, namely SVG, PNG, PDF and JPEG.
### Exit
When the user presses the EXIT button, the editor will automatically determine whether to save or not, if not, a reminder box will pop up. The functionality is roughly similar to closing the program window directly in the upper right corner.

The second main menu is Edit, which contains three sub-menus, Undo, Delete Last and ClearALL

### Undo
Undo will be activated when the user deletes a pattern with the right mouse button. This allows the user to use the Undo
button to restore the deleted pattern and code. Undo will not be activated if the pattern is not deleted.
### Delete Last
This button has the same function as the right mouse button to delete the last pattern directly.
### ClearAll
Allows the user to delete all data from the screen and SVG code boxes directly but without a save reminder.

The third main menu is View, which contains two sub-menus, SVG Code View and SVG Code View Location.
### SVG Code View
The switch controls the display and hiding of the SVG code window on the right side.
### SVG Code View Location
The menu that can be set to the right, left or free window of the main window.
The fourth main menu is Tools, under which various tools are available. At the moment only one tool is available - the viewer
### View In Browser
The editor has a built-in Webview2 control that allows you to quickly view SVG files in the browser even if you don't have a browser installed, improving your productivity.
## Library Use
Thanks for the Magick.NET.Core, Magick.NET-Q16-AnyCPU, Microsoft.Web.WebView2, SkiaSharp, SkiaSharp.Svg, Spire.PDF and Svg to provide a lots of methods to help this editor complete. Those libraries make the convert easily and quickly. And also the C# library like XmlWriter makes SVG file more easily to use. Thank you.
## ScreenShots
![1](https://user-images.githubusercontent.com/96554893/234685395-e3ddf51a-423c-4441-ba9f-952e6e2b56f6.png)
![2](https://user-images.githubusercontent.com/96554893/234685412-ab904fb6-a01b-465d-a3fd-80b5afa9930a.png)
![3](https://user-images.githubusercontent.com/96554893/234685421-d2d10553-0019-4cc9-98f2-2f64ffce1577.png)
## Bugs
When the SVG file is opened and loaded, if the beginning declaration of the SVG file is different from the beginning declaration written by the program using XMLWriter, the editor will load the SVG onto the drawing board with an error, but the SVG code will be displayed normally.

When using the scroll wheel in the drawing window, although the drawing window scales with the scroll wheel, the scaling is now only at the top left corner and the scaling does not expand the drawing area of the canvas, but only visually zooms in and out.
## TO DO
Desired additional features

Ability to display 2D floor plans in 3D

Fix existing bugs

Extend the canvas of SVG infinitely with zoom

Can use more different and complex graphics to draw

Continue...
