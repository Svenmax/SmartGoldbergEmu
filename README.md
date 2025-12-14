SmartGoldbergEmu Launcher Rev 2.2c (softkmo) - 02/16/2025
*************************************************
*    ATTENTION: THIS IS A THIRD-PARTY RELEASE   *
*************************************************

Official releases from Kola124 can be found at:
Forum 	- "https://cs.rin.ru/forum/viewtopic.php?f=29&t=115235"
GitHub 	- "https://github.com/Kola124/SmartGoldbergEmu"
Rev2.2c - "https://cs.rin.ru/forum/viewtopic.php?p=3221424#p3221424"

- All credits to Kola124 and Nemirtingas where due.
  Keep up the good work!

SGEL Change notes: v2.2e
- New
 - 
 
- Quality of Life Improvements:
 - Batch files (.bat) can be added as game executables.
 - Selecting custom icon from exe file will extract the icon into the game folder.



SGEL Change notes: v2.2d
- New:
  - Now SGEL will autoinstall Datanup Goldberg emulator when diles missin or not installed.
- Quality of Life Improvements:
  - Improvement to catch and exclude some non-ingame content Dlc´s.
  

SGEL Change notes: v2.2c
 
- New:
  - Adding a game will now automatically set the "Use 64-bit" option based on whether `steam_api.dll` or `steam_api64.dll` is found in the game folder.
    This ensures GSEL loads the game with the correct client version every time. **GAME MUST BE RE-ADDED IF THEY DON'T WORK PROPERLY.**
  - On game launch, if `GameOverlayRenderer64.dll` or `GameOverlayRenderer.dll` are found in `win64` or `win32` folders, they will be copied along with the Steam client file.
  - On game exit, the following files will be removed from the configuration folder (`games/<any_appid>/Dll´s`) to prevent unnecessary duplicates and free up space:
    - `GameOverlayRenderer64.dll`
    - `GameOverlayRenderer.dll`
    - `steamclient.dll`
    - `steamclient64.dll`
 
- Quality of Life Improvements:
  - **Improved:** The DLC list generation now disables and categorizes non-ingame relevant content IDs.


SGEL Change notes: Rev 2.2a

- Quality of Life Improvements:
  - On launch, SGEL will check for `steam_apikey.txt` and load the stored Steam API key.
  - On first launch, random values for `account_id` and `listening_port` will be generated in the settings menu.
  - Added a **"Get API Key"** button to the settings menu.
  - When adding a game, SGEL will check for `steam_appid.txt` in the .exe folder and set the game ID automatically.

- DLC List Generator Update:
  - Unified into a single button for convenience.
  - Now fetches DLC IDs from multiple sources for better accuracy:
    - `store.steampowered.com/api`
    - `api.steampowered.com`
    - `raw.githubusercontent.com/Nemirtingas/games-infos-datas/main/steam`

- Bug Fixes & UI Adjustments:
  - Fixed incorrect path generation.
  - Fixed missing images when generating achievement data (regenerate achievements to apply the fix).
  - Minor UI adjustments in some menus.
  - Improved error handling to prevent crashes when no settings files are present.
