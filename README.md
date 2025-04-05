# Cerulean 

This is the repository for the Cerulean Bluesky client, currently in the alpha stage and unusable. It is written in C# and uses 
the .NET Framework 2. This enables the executable (without any dependencies) to run on Windows 98. To interface with the Bluesky
API it uses curl-OpenSSL, which I have gotten to ![run on Windows 98 and above.](https://github.com/OmegaAOL/curl-windows98) 

![alt text](https://i.imgur.com/bzciwrw.png)

# What's present and what works

A few menus like the login screen (and its accompanying functions) and the About screen have been finished. The main window hasn't
been started yet, except for the menu bat, and can be accessed by (for now) pressing "Configure TOTP Authentication" on the 
login screen. The majority of time I spent on this project was troubleshooting compatibility, mostiy with Windows 98.

You cannot login. LibCurl.NET and my Windows 98 build of libcurl are in the binaries, but they don't seem to be working with *any* version
of Windows at the moment. As soon as I get them to work, you will be able to login to your Bluesky account
