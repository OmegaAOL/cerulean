# Cerulean

<img width="1402" height="792" alt="image" src="https://github.com/user-attachments/assets/bd13c309-8684-41c2-9606-6d63280ac2c4" />

*Screenshot of Cerulean Release 1.0 on [Reunion7](https://www.reunion7.com)*

This is the repository for the open-source Cerulean Bluesky client, which recently exited the Beta stage and is now quite usable. It is written in C# and uses  WinForms (fully native) + .NET Framework 2.0. It runs on Windows 98 and up, but I am reasonably confident it can be backported to Windows 95.

<img width="912" height="385" alt="cerulean-git-NEW" src="https://github.com/user-attachments/assets/6d494e83-05fe-4fa0-b967-ceac51333974" />

# What Cerulean can do (so far)

- Logging in (2FA supported), resetting password, changing PDS host
- Encryption of handle and password (AES-256 on legacy Windows, DPAPI on Windows 2000 and up)
- Creating posts, reposts (also undoing reposts), quote posts
- Tabbed feed browsing
- Viewing threads
- Sharing posts, permalinking to posts, opening posts/threads in browser, collapsing posts
- Liking and unliking posts
- Viewing your timeline & your other feeds
- Searching for profiles and viewing profile information
- Following and unfollowing people
- Viewing images and avatars
- Deleting posts
- Viewing notifications

# What needs to be fixed

- Uploading images to posts
- Creating account
- Reporting users and posts, blocking users

# What needs to be added 

- Themes (logic exists partly in code)
- Viewing all posts of a particular user
- Starter packs
- Chat
- Lists

# Security

Cerulean stores your handle and password encrypted in the registry *(HKEY_CURRENT_USER\Software\Cerulean\LoginData)*. It is **encrypted**.

On Windows 2000 and up this uses DPAPI encryption. DPAPI is a Windows API that encrypts data for you based on a lot of user account information. It is widely considered best-in-class for passwordless encryption and programs like Chrome, Edge, KeePassXC and KeePass use it. It is more than fine for you to use your real password (if you don't trust me, check and build from source!)

On Windows 9x/ME/NT4 this uses AES-256, but the encryption key is partly hardcoded and partly derived from basic machine info (Windows did not have DPAPI back then). This is still great for most attackers, but a dedicated attacker combing through the Cerulean source code will be able to quite easily decrypt your key and info. There is literally nothing that can be done about this. Recommend using app passwords for these Windows versions.

Still apprehensive about DPAPI? To show you how confident I am in Cerulean's encryption, here is my encrypted handle and full password. Try what you will.

<img width="1239" height="281" alt="image" src="https://github.com/user-attachments/assets/87b46189-ae34-4fdb-898d-88b59c4ea557" />

# Release information

Cerulean is in the process of leaving the beta stage. Until the first stable release is published, *Crimson* releases will be uploaded. Consider Crimson the new beta branch now that we're out of beta. These Crimson releases are not production worthy. Do not use them as a daily driver. You have been warned.

<img width="555" height="147" alt="crimson" src="https://github.com/user-attachments/assets/d6580bfb-ec4c-4acf-a63d-39b5cc28a185" />

Releases get version bumps to the nearest 10 if they are notable. (for instance: alpha 0.0.4 -> 0.1.0, beta 0.1.0 -> 0.2.0)

# Future roadmap

I plan to develop Cerulean into a full client that has all the features of Bluesky, and even surpassing it in some cases (write your own scripts for different actions, local TOTP login, tabbed usage)

# Open-source details and how to compile

The project is open-source, but licensed under the GPL3 - any forks should credit both me and the Cerulean project.

This project is built using Microsoft Visual Studio 2010 and .NET Framework 2.0. This *should* work in VS2022, but VS2010 is recommended due to the sheer performance improvement (if you've only used VS2022, try 2010, you won't believe how much better it is)

- FIRST, enable .NET Framework 2.0 in Windows Features, download Visual Studio 2010 Express (free) or Professional (paid, or pirate it), and make sure NET Framework 2.0 is selected in VS2010 Cerulean Project Settings.
- SECOND, if and ONLY IF you've tried the above and it still doesn't work, file an issue.

cURL and libcurl are built using Microsoft Visual Studio 2005 (Microsoft VC++ 8)

The source code is meant to be readable and easily changable, not to be as small as possible. This also means there is a lot of commented-out (or *dead*) code that I may comment in/out at times. **Do not remove dead code!**

# Credits

Any libraries linked are .NET 2.0 versions. Some may be severely out of date. Find newer versions for new projects.

- [Jeffrey Phillips, LibCurl.NET](https://sourceforge.net/projects/libcurl-net/) - .NET 2.0 only, there is an [updated fork](https://github.com/masroore/CurlSharp)
- [Lorenz Cuno Klopfenstein, WindowsFormsAero](https://codeplexarchive.org/project/windowsformsaero) - .NET 2.0 and .NET 4.x, there is an [updated version by the same maintainer](https://github.com/LorenzCK/WindowsFormsAero)
- [James Newton King, Newtonsoft.Json](https://www.newtonsoft.com/json) - .NET 2.0 - .NET Core 9
- [OpenSSL Library, OpenSSL](https://openssl-library.org/source/old/1.0.2/index.html) - Windows 98+ build [here](https://github.com/OmegaAOL/openssl-windows98)
- [cURL](https://curl.se/download/) - Windows 98+ build [here](https://github.com/OmegaAOL/curl-windows98)
- [Microsoft, Windows Vista Icons / Windows 98 Icons](https://www.microsoft.com)


# Thank you!

If you made it this far, thank you. I do not have a donation option at the moment, but I will put one up eventually as the app becomes usable. Please consider donating if you can.
