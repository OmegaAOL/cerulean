# Cerulean for Bluesky

<img width="1402" height="792" alt="image" src="https://github.com/user-attachments/assets/bd13c309-8684-41c2-9606-6d63280ac2c4" />

*Screenshot of release 1.0 running on [Reunion7](https://www.reunion7.com)*

This is the repository for Cerulean, an open-source Bluesky client. It recently exited beta and is now quite usable. It is written in C# and .NET Framework 2.0, and uses WinForms (fully native). It runs on Windows 98 and up.

<img width="912" height="385" alt="cerulean-git-NEW" src="https://github.com/user-attachments/assets/6d494e83-05fe-4fa0-b967-ceac51333974" />

# OS compatibility

**Windows:** Official minimum is **Windows 98**, can run on **Windows 95** with MattKC's backport. **Windows 2000** or higher is recommended as it provides a much better experience.

**Mac OS and Linux:** Supported with **WINE**. No reported problems.

# What Cerulean can do (so far)

- **Accounts:** Logging in (2FA supported), resetting password,
saving credentials with DPAPI encryption, creation
- **Tabs:** tabbed feed browsing lets you have multiple different feeds in tabs 
- **Posts:** viewing, creating, liking, reposting/unreposting, quote posts, deleting posts, viewing embeds, viewing hashtags, sharing posts, permalinking to posts, opening posts/threads in browser, collapsing posts
- **Feeds:** timeline, discover, custom feed selection, tabbed feed browsing
- **Threads:** viewing in Reddit-style UI with custom depth markers
- **Profiles:** searching for profiles and viewing profile information, following and unfollowing
- **Notifications:** view notifications, including follows, likes and replies
- **Chat:** view a list of your current chats
- **PDSes:** Cerulean is fully compatible with custom PDSes and can also create an account in the PDS if implemented server-side. Both invite-only and public PDSes supported.
- **Themes:** There is experimental theme support starting from Release 1.3 beta 2. It is not fully complete and may look broken.

# What needs to be fixed

- Uploading images to posts
- Reporting users and posts, blocking users

# What needs to be added 

- Multiple account support
- Searching for posts
- Viewing all posts of a particular user
- Starter packs
- Actual functioning chat
- Lists

# Release nomenclature

**Current** 

Releases follow a decimalized numbering system. The syntax is [major version].[minor version] (for example 1.2).
Beta releases are not decimalized. For example, the second beta of release 1.3 would be release 1.3 beta 2, not release 1.3.1 or release 1.3b0.1.
The first release was **Release 1.0.**

_Beta_ here represents a pre-release and is not related to the historical Beta stage. 

**Historical**

- **Alpha** 0.0.1 - 0.0.4 followed iterative decimalization. The first Alpha release was **Alpha 0.0.1.**
- **Alpha** 0.10 - 0.20 dropped the second decimal and added release jumping (e.g. jump 5-10 places if important release).
- **Beta** releases added the second decimal back. The first Beta release was **Beta 0.1.0.** (this was a counting reset from Alpha)
- **Crimson** releases stopped release jumping, and incremented by 1 major version for every 10 minor. The first Crimson release was **Crimson 0.2.9c** and picked up from Beta.

# Building Cerulean

The project is **open-source**, but licensed under the **GPLv3** - any forks should credit **both me and the Cerulean project.**

This project is built using **Microsoft Visual Studio 2010** and **.NET Framework 2.0.** You can use VS2026/2022/etc, but I **recommend you use VS2010** due to how incredibly lightweight it is and the great improvements in performance you will notice. If you are encountering issues:

- Enable .NET Framework 2.0 in Windows Features, and check the compile bar & Project Settings to see if you're building for **x86** (not Any CPU or x64).
- If you've tried that and it still doesn't work, file an issue.

Please stick to the existing code style when submitting pull requests. This includes **not removing commented-out code.**

# Credits

Any libraries linked are .NET 2.0 versions. Some may be **severely out of date.** Find newer versions for new projects.

- [Jeffrey Phillips, LibCurl.NET](https://sourceforge.net/projects/libcurl-net/) - .NET Framework 2.x, there is an [updated and greatly enhanced fork](https://github.com/masroore/CurlSharp)
- [Legion of the Bouncy Castle, BouncyCastle.Cryptography](https://www.bouncycastle.org/download/bouncy-castle-c/#latest) - .NET Framework 2.x, there is a newer version for modern .NET
- [James Newton King, Newtonsoft.Json](https://www.newtonsoft.com/json) - all versions of .NET Framework/Standard/Core supported, but largely superseded by [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json) in Core
- [OpenSSL Library, OpenSSL](https://openssl-library.org/source/old/1.0.2/index.html) - Windows 98+ build [here](https://github.com/OmegaAOL/openssl-windows98)
- [cURL](https://curl.se/download/) - Windows 98+ build [here](https://github.com/OmegaAOL/curl-windows98)
- [Microsoft, Windows Vista Icons / Windows 98 Icons.](https://www.microsoft.com) These assets are licensed by Cerulean under the [doctrine of fair use.](https://en.wikipedia.org/wiki/Fair_use?useskin=modern)
- [NSIS-Dev, Nullsoft Scriptable Install System 2](https://github.com/NSIS-Dev). Formerly owned and developed by [Nullsoft, Inc.](https://en.wikipedia.org/wiki/Nullsoft?useskin=modern)


# Thank you!

If you made it this far, thank you. I do not have a donation option at the moment, but I will put one up eventually as the app becomes usable. Please consider donating if you can.
