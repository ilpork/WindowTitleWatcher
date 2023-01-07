# WindowTitleWatcher
This tiny system tray utility helps to get notified when title of an application window changes. 

`WindowTitleWatcher` makes the application window to flash in taskbar when a window with specified text in its title is encountered. 

## Development
.NET 4.8

## Supported platforms
Windows 10/11 

## Usage
Download the binary from [Releases](https://github.com/ilpork/WindowTitleWatcher/releases) and execute the application. 

The application can also be started with command line argument (e.g. `WindowTitleWatcher "Some text"`). If command line argument is given, the watcher is started automatically when starting the application. If no command line argument is given, configuration window is shown first.

`WindowTitleWatcher` makes the window to flash in taskbar when the given text is found from title of it. The watcher is stopped after that.

![Configuration window](img/configure_window.png)
![System tray menu](img/tray_menu.png)
![Tooltip](img/tooltip.png)

## Licence 
Copyright (c) 2023 by ilpork. All rights reserved.

Licensed under the MIT license.