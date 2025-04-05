# Cerulean 

This is the repository for the open-source Cerulean Bluesky client, currently in the alpha stage and barely usable. It is written in C# and uses 
the .NET Framework 2. This enables the executable (without any dependencies) to run on Windows 98. To interface with the Bluesky
API it uses curl-OpenSSL, which I have gotten to [run on Windows 98 and above.](https://github.com/OmegaAOL/curl-windows98) 

![alt text](https://i.imgur.com/bzciwrw.png)

# What's present and what works

A few menus like the login screen (and its accompanying functions) and the About screen have been finished. The main window hasn't
been started yet, except for the menu bat, and can be accessed by (for now) pressing "Configure TOTP Authentication" on the 
login screen. The majority of time I spent on this project was troubleshooting compatibility, mostiy with Windows 98.

You cannot login. [LibCurl.NET](https://sourceforge.net/projects/libcurl-net/) and my Windows 98 build of libcurl are in the binaries, but they don't seem to be working with *any* version
of Windows at the moment. As soon as I get them to work, you will be able to login to your Bluesky account using Cerulean.

# Security

Like many, many other programs ([Chrome](https://www.askcybersecurity.com/where-are-my-saved-passwords-in-chrome/) and [Firefox](https://stackoverflow.com/questions/37685932/where-in-the-filesystem-does-firefox-store-saved-passwords)
being two of the most major), Cerulean stores your login data unencrypted. If you check "Remember Me" in the login window, your data is saved in *HKEY_CURRENT_USER\Software\Cerulean\LoginDetails* in two seperate entries. This is
neither abnormal nor a breach of protocol, and you can delete your login data either by logging in again but with "Remember Me" unchecked (which wipes your login data), or going to Account > Delete My Login Data in the Menu Bar.
Again, I would like to remind you that this is neither an uncommon nor proportionally more insecure way of storing login data, and it is much more rewarding (and easier) to steal your Google Chrome LoginData.db file than to fish through
the registry to steal the logins of one account.

This is why **I recommend you use an app password** - they can be easily managed and deleted if your account is compromised, and they are randomly-generated unique strings.

TL:DR; What Cerulean does with passwords is normal and commonplace in the industry. There is no need to worry, but if you are concerned you may use an app password (recommended) or uncheck "Remember Me" (not recommended).

# Usability

I plan to develop Cerulean into a full client that has all the features of Bluesky, and even surpassing it in some cases (write your own scripts for different actions, local TOTP login, tabbed usage)

# Open-source details and how to compile

The project is open-source, but licensed under the GPL3 - any forks will have to credit both me and the project as being the originator of theirs.

This project is built using Microsoft Visual Studio 2010 and .NET Framework 2.0. I am not sure if Microsoft still maintains compilation options for .NET 2, but AFAIK Visual Studio 2017 had the option.
I am unsure about later versions.

Curl and libcurl are built using Microsoft Visual Studio 2005 (Microsoft VC++ 8)

# Thank you!

If you made it this far, thank you. I do not have a donation option at the moment, but I will put one up eventually as the app becomes usable. Please consider donating if you can.
