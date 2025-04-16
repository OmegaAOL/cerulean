# Cerulean 

Check out the new website! https://ceruleanweb.neocities.org/

This is the repository for the open-source Cerulean Bluesky client, currently in the alpha stage and barely usable. It is written in C# and uses 
the .NET Framework 2. This enables the executable (without any dependencies) to run on Windows 98. To interface with the Bluesky
API it uses curl-OpenSSL, which I have gotten to [run on Windows 98 and above.](https://github.com/OmegaAOL/curl-windows98) 

![alt text](https://i.imgur.com/bzciwrw.png)

# What's present and what works

You can login and send a (text) post to Bluesky using either File -> New Post (Ctrl+T) or by using the Quick Post bar.
You can set a digital signature for your posts in Tools -> Options.
You can search for other posts on Bluesky, but you will receive a pure JSON result - difficult to parse.
You can get your main "Following" feed, and get custom feeds with the Feed Selector, but - like Search - the result is pure JSON for now.

# A note on security

Like many, many other programs ([Chrome](https://www.askcybersecurity.com/where-are-my-saved-passwords-in-chrome/) and [Firefox](https://stackoverflow.com/questions/37685932/where-in-the-filesystem-does-firefox-store-saved-passwords)
being two of the most major), Cerulean stores your login data unencrypted. If you check "Remember Me" in the login window, your data is saved in *HKEY_CURRENT_USER\Software\Cerulean\LoginDetails* in two seperate entries. This is
neither abnormal nor a breach of protocol, and you can delete your login data by clicking 
"Log Out" in the program. 

I would like to remind you that this is neither an uncommon nor proportionally more insecure way of storing login data, and it is much more rewarding (and easier) to steal your Google Chrome LoginData.db file than to fish through
the registry to steal the logins of one account.

- This is why **I recommend you use an app password** - they can be easily managed and deleted if your account is compromised, and they are randomly-generated unique strings.
- *A password database that's encrypted with random data in your Windows install is planned, but definitely not a priority atm.*

TL:DR; What Cerulean does with passwords is normal and commonplace in the industry. There is no need to worry, but if you are concerned you may use an app password (recommended) or uncheck "Remember Me" (not recommended).

# Future roadmap

I plan to develop Cerulean into a full client that has all the features of Bluesky, and even surpassing it in some cases (write your own scripts for different actions, local TOTP login, tabbed usage)

# Open-source details and how to compile

The project is open-source, but licensed under the GPL3 - any forks will have to credit both me and the project as being the originator of theirs.

This project is built using Microsoft Visual Studio 2010 and .NET Framework 2.0. If you have installed the development kit for NET Framework 2.0/3.5 along with Visual Studio,
it should theoretically still work as of Visual Studio 2022. If you are unable to build Cerulean:

- FIRST, redownload the source code (get rid of messed up options from newer Visual Studios reading the solution), enable .NET Framework 2.0 in Windows Features,
  download Visual Studio 2010 Express (free) or Professional (paid, or sail the sea), and make sure NET Framework 2.0 is selected in VS2010 Cerulean Project Settings.
- SECOND, if and ONLY IF you've tried the above and it still doesn't work, file an issue.

Curl and libcurl are built using Microsoft Visual Studio 2005 (Microsoft VC++ 8)

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
