# Cerulean

<img width="1412" height="817" alt="image" src="https://github.com/user-attachments/assets/7ff743a7-adcb-4ab4-86b9-5bfd800565fb" />

*Screenshot of Cerulean Beta 0.2.0 on [Reunion7](https://www.reunion7.com)*

This is the repository for the open-source Cerulean Bluesky client, currently in the beta stage and pretty usable. It is written in C# and uses 
.NET Framework 2.0. It runs on Windows 98(FE) and up, but I am reasonably confident it can be backported to Windows 95.

<img width="912" height="385" alt="cerulean-git-NEW" src="https://github.com/user-attachments/assets/6d494e83-05fe-4fa0-b967-ceac51333974" />

# What works (so far)

- Logging in, resetting password, changing PDS host
- Encryption of handle and password (AES-256 on legacy Windows, DPAPI on Windows 2000 and up)
- Creating posts, reposts (also undoing reposts), quote posts
- Sharing posts, permalinking to posts, opening posts/threads in browser, collapsing posts
- Liking and unliking posts
- Viewing your timeline & your other feeds
- Searching for profiles and viewing profile information
- Viewing images and avatars
- Deleting posts

# What needs to be fixed

- Spawning new anonymous threads. Basically: Don't click buttons too fast/spam-click
- Uploading images to posts
- Creating account
- Reporting users and posts, blocking users
- Viewing notifications

# What needs to be added 

- Viewing all posts of a particular user
- Viewing threads (use more -> open in browser for this rn)
- Starter packs
- Chat
- Lists

# Security

Cerulean stores your handle and password in the registry using AES-256-CBC. This is more than safe enough for the forseeable future.

# Future roadmap

I plan to develop Cerulean into a full client that has all the features of Bluesky, and even surpassing it in some cases (write your own scripts for different actions, local TOTP login, tabbed usage)

# Open-source details and how to compile

The project is open-source, but licensed under the GPL3 - any forks should credit both me and the Cerulean project.

This project is built using Microsoft Visual Studio 2010 and .NET Framework 2.0. This *should* work in VS2022, but VS2010 is recommended due to the sheer
performance improvement (if you've only used VS2022, try 2010, you won't believe how much better it is)

- FIRST, enable .NET Framework 2.0 in Windows Features, download Visual Studio 2010 Express (free)
or Professional (paid, or pirate it), and make sure NET Framework 2.0 is selected in VS2010
Cerulean Project Settings.
- SECOND, if and ONLY IF you've tried the above and it still doesn't work, file an issue.
cURL and libcurl are built using Microsoft Visual Studio 2005 (Microsoft VC++ 8)

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
