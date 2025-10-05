# Cerulean for Bluesky

<img width="1402" height="792" alt="image" src="https://github.com/user-attachments/assets/bd13c309-8684-41c2-9606-6d63280ac2c4" />

*Screenshot of Cerulean Release 1.0 on [Reunion7](https://www.reunion7.com)*

This is the repository for the open-source Cerulean Bluesky client, which recently exited the Beta stage and is now quite usable. It is written in C# and uses  WinForms (fully native) + .NET Framework 2.0. It runs on Windows 98 and up, but I am reasonably confident it can be backported to Windows 95.

<img width="912" height="385" alt="cerulean-git-NEW" src="https://github.com/user-attachments/assets/6d494e83-05fe-4fa0-b967-ceac51333974" />

# What Cerulean can do (so far)

- Accounts: Logging in (2FA supported), resetting password,
saving credentials with DPAPI encryption, creation
- Tabs: tabbed feed browsing lets you have multiple different feeds in tabs 
- Posts: viewing, creating, liking, reposting/unreposting, quote posts, deleting posts, viewing embeds, viewing hashtags, sharing posts, permalinking to posts, opening posts/threads in browser, collapsing posts
- Feeds: timeline, discover, custom feed selection, tabbed feed browsing
- Threads: viewing in Reddit-style UI with custom depth markers
- Profiles: searching for profiles and viewing profile information, following and unfollowing
- Notifications: view notifications, including follows, likes and replies
- Chat: view a list of your current chats
- PDSes: Cerulean is fully compatible with custom PDSes and can also create an account in the PDS if implemented server-side. Both invite-only and public PDSes supported.

# What needs to be fixed

- Uploading images to posts
- Reporting users and posts, blocking users

# What needs to be added 

- Themes (logic exists partly in code)
- Multiple account support
- Viewing all posts of a particular user
- Starter packs
- Actual functioning chat
- Lists

# Security

Cerulean stores your handle and password encrypted in the registry *(HKEY_CURRENT_USER\Software\Cerulean\LoginData)*. They are **encrypted**. If you are running a version older than Beta 0.2.5, upgrade now because older versions of Cerulean used to store credentials unencrypted. Upgrading will automatically encrypt any stored credentials.

On Windows 2000 and up this uses DPAPI encryption. DPAPI is a Windows API that encrypts data for you based on a lot of user account information. It is widely considered best-in-class for passwordless encryption and programs like Chrome, Edge, KeePassXC and KeePass use it. It is more than fine for you to use your real password (if you don't trust me, check and build from source!)

On Windows 9x/ME/Nt4 this uses AES-256 but the encryption key is basically hardcoded. This is still a great defense against most attackers, but a dedicated attacker combing through source code or using a decompiler will be able to quite easily decrypt your key and info. There is literally nothing that can be done about this. I recommend using app passwords for these Windows versions.

Still apprehensive about DPAPI? To show you how confident I am in Cerulean's encryption, here is my encrypted handle and full password. Try what you will.

<img width="1239" height="281" alt="image" src="https://github.com/user-attachments/assets/87b46189-ae34-4fdb-898d-88b59c4ea557" />

# Building Cerulean

The project is open-source, but licensed under the GPLv3 - any forks should credit both me and the Cerulean project.

This project is built using Microsoft Visual Studio 2010 and .NET Framework 2.0. You can use VS2026/2022/etc, but I recommend you use VS2010 due to how incredibly lightweight it is and the great improvements in performance you will notice. If you are encountering issues:

- Enable .NET Framework 2.0 in Windows Features, and check the compile bar & Project Settings to see if you're building for x86 (not Any CPU or x64).
- If you've tried that and it still doesn't work, file an issue.

Please stick to the existing code style when submitting pull requests. This includes not removing commented-out code.

# Credits

Any libraries linked are .NET 2.0 versions. Some may be severely out of date. Find newer versions for new projects.

- [Jeffrey Phillips, LibCurl.NET](https://sourceforge.net/projects/libcurl-net/) - .NET Framework 2.x, there is an [updated and greatly enhanced fork](https://github.com/masroore/CurlSharp)
- [Lorenz Cuno Klopfenstein, WindowsFormsAero](https://codeplexarchive.org/project/windowsformsaero) - .NET Framework 2.x and 4.0, there is an [updated version by the same maintainer](https://github.com/LorenzCK/WindowsFormsAero)
- [James Newton King, Newtonsoft.Json](https://www.newtonsoft.com/json) - all versions of .NET Framework/Standard/Core supported, but largely superseded by [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json) in Core
- [OpenSSL Library, OpenSSL](https://openssl-library.org/source/old/1.0.2/index.html) - Windows 98+ build [here](https://github.com/OmegaAOL/openssl-windows98)
- [cURL](https://curl.se/download/) - Windows 98+ build [here](https://github.com/OmegaAOL/curl-windows98)
- [Microsoft, Windows Vista Icons / Windows 98 Icons.](https://www.microsoft.com) These assets are licensed by Cerulean under the [doctrine of fair use.](https://en.wikipedia.org/wiki/Fair_use?useskin=modern)
- [NSIS-Dev, Nullsoft Scriptable Install System 2](https://github.com/NSIS-Dev). Formerly owned and developed by [Nullsoft, Inc.](https://en.wikipedia.org/wiki/Nullsoft?useskin=modern)


# Thank you!

If you made it this far, thank you. I do not have a donation option at the moment, but I will put one up eventually as the app becomes usable. Please consider donating if you can.
