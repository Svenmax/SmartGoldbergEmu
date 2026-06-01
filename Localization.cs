using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace SmartGoldbergEmu
{
    internal static class Localization
    {
        public const string English = "en";
        public const string SimplifiedChinese = "zh-Hans";

        private static readonly Dictionary<string, string> SimplifiedChineseStrings = new Dictionary<string, string>
        {
            ["&Save"] = "保存",
            ["Save"] = "保存",
            ["&Cancel"] = "取消",
            ["Cancel"] = "取消",
            ["OK"] = "确定",
            ["File"] = "文件",
            ["Add Game"] = "添加游戏",
            ["Edit Game"] = "编辑游戏",
            ["Delete Game"] = "删除游戏",
            ["Settings"] = "设置",
            ["Exit"] = "退出",
            ["About"] = "关于",
            ["Smart Goldberg Emu.\r\nMade by Nemirtingas\r\nEdited by Kola124\r\n\r\nThis application UI is inspired by SmartSteamEmu Launcher.\r\nYou can find original on gitlab:\r\n\r\nAnd edit on github: "] = "Smart Goldberg Emu.\r\n由 Nemirtingas 制作\r\n由 Kola124 修改\r\n\r\n本程序界面受 SmartSteamEmu Launcher 启发。\r\n原版可在 GitLab 找到：\r\n\r\nGitHub 修改版：",
            ["Generate Achievements"] = "生成成就",
            ["Generate Items"] = "生成物品",
            ["Create Shortcut"] = "创建快捷方式",
            ["Open Game Emu Folder"] = "打开游戏模拟器文件夹",
            ["Properties"] = "属性",
            ["SmartGoldbergEmu Launcher"] = "SmartGoldbergEmu 启动器",
            ["General"] = "常规",
            ["Change Avatar"] = "更换头像",
            ["Username:"] = "用户名:",
            ["SteamID:"] = "SteamID:",
            ["Language:"] = "Steam 语言:",
            ["UI Language:"] = "界面语言:",
            ["Port:"] = "端口:",
            ["WebAPI Key:"] = "WebAPI 密钥:",
            ["Appearance"] = "外观",
            ["Font Size"] = "字体大小",
            ["Image Size"] = "图片大小",
            ["Notification Colour"] = "通知颜色",
            ["Notification"] = "通知",
            ["Background Colour"] = "背景颜色",
            ["Background"] = "背景",
            ["Element Colour"] = "元素颜色",
            ["Element"] = "元素",
            ["Element Hover Colour"] = "元素悬停颜色",
            ["Element Hovered"] = "元素悬停",
            ["Element Active Colour"] = "元素激活颜色",
            ["Element Active"] = "元素激活",
            ["R,G,B,A"] = "R,G,B,A",
            ["Ach Position"] = "成就位置",
            ["Inv Position"] = "邀请位置",
            ["Chat Position"] = "聊天位置",
            ["Sound & Font"] = "声音和字体",
            ["Sound and Font"] = "声音和字体",
            ["Add Friend Sound"] = "添加好友声音",
            ["Delete Friend Sound"] = "删除好友声音",
            ["Add Achievement Sound"] = "添加成就声音",
            ["Delete Achievement Sound"] = "删除成就声音",
            ["Add Font"] = "添加字体",
            ["Change Font"] = "更换字体",
            ["Delete Font"] = "删除字体",
            ["Change Sound"] = "更换声音",
            ["Delete Sound"] = "删除声音",
            ["Font"] = "字体",
            ["Friend Notification"] = "好友通知",
            ["Achievement Notification"] = "成就通知",
            ["Font Spacing X"] = "字体间距 X",
            ["Font Spacing X:"] = "字体间距 X:",
            ["Font Spacing Y"] = "字体间距 Y",
            ["Font Spacing Y:"] = "字体间距 Y:",
            ["Notifications"] = "通知",
            ["Animation"] = "动画",
            ["Roundness"] = "圆角",
            ["Margin X"] = "边距 X",
            ["Margin Y"] = "边距 Y",
            ["Achievement Duration"] = "成就持续时间",
            ["Progress Duration"] = "进度持续时间",
            ["Invitation Duration"] = "邀请持续时间",
            ["Invite Duration"] = "邀请持续时间",
            ["Chat Duration"] = "聊天持续时间",
            ["Notification Animation"] = "通知动画",
            ["Notification Margin Y"] = "通知边距 Y",
            ["Notification Margin X"] = "通知边距 X",
            ["Notification Rounding"] = "通知圆角",
            ["Game Settings"] = "游戏设置",
            ["Other Settings"] = "其他设置",
            ["Disable Unknown Leaderboard"] = "禁用未知排行榜",
            ["Matchmake Actual Type"] = "匹配实际类型",
            ["Matchmake Source Querry"] = "匹配来源查询",
            ["Share Leaderboards Over Network"] = "通过网络共享排行榜",
            ["Disable Lobby Creation"] = "禁用大厅创建",
            ["Force Http Success"] = "强制 HTTP 成功",
            ["Disable Source Query"] = "禁用 Source 查询",
            ["Disable Avatar"] = "禁用头像",
            ["Disable Friend Notification"] = "禁用好友通知",
            ["Disable Achievement Notification"] = "禁用成就通知",
            ["Achievements Bypass"] = "绕过成就",
            ["Beta Branch:"] = "Beta 分支:",
            ["Force Steam Deck"] = "强制 Steam Deck",
            ["Force SteamID:"] = "强制 SteamID:",
            ["Force Listen Port:"] = "强制监听端口:",
            ["Force Language:"] = "强制语言:",
            ["Force Account Name:"] = "强制账户名:",
            ["Local Save Path:"] = "本地存档路径:",
            ["Paths, Groups,Depot"] = "路径、组、Depot",
            ["Instaled App IDs:"] = "已安装 App ID:",
            ["Custom Depots:"] = "自定义 Depot:",
            ["Custom Subscribed Groups list:"] = "自定义订阅组列表:",
            ["Custom App Paths list:"] = "自定义 App 路径列表:",
            ["Custom Icon:"] = "自定义图标:",
            ["Clan Tag:"] = "战队标签:",
            ["Enable HTTP (Disable lan only has to be on)"] = "启用 HTTP（需启用仅 LAN 禁用）",
            ["Offline"] = "离线",
            ["Disable Networking"] = "禁用网络",
            ["Disable LAN Only"] = "禁用仅 LAN",
            ["Disable Overlay"] = "禁用覆盖层",
            ["Use 64bits"] = "使用 64 位",
            ["Game AppID:"] = "游戏 AppID:",
            ["Game Folder:"] = "游戏文件夹:",
            ["Game Parameters:"] = "游戏参数:",
            ["Game Exe:"] = "游戏程序:",
            ["Game Name:"] = "游戏名称:",
            ["Server Browser"] = "服务器浏览器",
            ["History Tab:"] = "历史标签:",
            ["Favorites Tab:"] = "收藏标签:",
            ["Internet and Spectate Tabs:"] = "互联网和观战标签:",
            ["Force IP Country:"] = "强制 IP 国家:",
            ["Custom Broadcast:"] = "自定义广播:",
            ["Stats"] = "统计",
            ["Disable Stats Sharing"] = "禁用统计共享",
            ["Game Server Stats"] = "游戏服务器统计",
            ["Save Only Higher Stat Progress"] = "只保存更高统计进度",
            ["Allow Unknown Stats"] = "允许未知统计",
            ["Get Stats"] = "获取统计",
            ["Custom Stats:"] = "自定义统计:",
            ["Custom"] = "自定义",
            ["Get Mods From Folder"] = "从文件夹获取 Mod",
            ["Create DLL Folder"] = "创建 DLL 文件夹",
            ["Create Mods Folder"] = "创建 Mods 文件夹",
            ["Clear"] = "清空",
            ["Remove"] = "移除",
            ["Add"] = "添加",
            ["Custom Env var value"] = "自定义环境变量值",
            ["Custom Env var name"] = "自定义环境变量名",
            ["DLC"] = "DLC",
            ["Unlock All DLC"] = "解锁所有 DLC",
            ["Get DLC info from GitHub"] = "从 GitHub 获取 DLC 信息",
            ["Get DLC info from Steam"] = "从 Steam 获取 DLC 信息",
            ["Custom DLC list:"] = "自定义 DLC 列表:",
            ["Folder to goldberg's 32bits steamclient.dll"] = "goldberg 32 位 steamclient.dll 文件夹",
            ["Folder to goldberg's 64bits steamclient64.dll"] = "goldberg 64 位 steamclient64.dll 文件夹",
            ["Delete"] = "删除",
            ["Error"] = "错误",
            ["Invalid Env Var"] = "无效环境变量",
            ["Null env var value"] = "空环境变量值",
            ["No DLC"] = "无 DLC",
            ["Not valid Appid"] = "Appid 无效",
            ["Port invalid"] = "端口无效",
            ["Webapi Key invalid"] = "WebAPI 密钥无效",
            ["File Deleted"] = "文件已删除",
            ["File doesn't exist"] = "文件不存在",
            ["Restart Required"] = "需要重启",
            ["The UI language change will take effect after restarting the application."] = "界面语言变更将在重启应用后生效。",
            ["Are you sure you want to delete this appid?"] = "确定要删除这个 appid 吗？",
            ["The port must be a number >1024"] = "端口必须是大于 1024 的数字",
            ["The webapi key consists of 32 alphanum char in upper case.\n\nMore infos at https://steamcommunity.com/dev/apikey"] = "WebAPI 密钥由 32 个大写字母数字字符组成。\n\n更多信息见 https://steamcommunity.com/dev/apikey",
            ["File was successfully deleted"] = "文件已成功删除",
            ["An env var must have a name"] = "环境变量必须有名称",
            ["An empty env var value will clear it before starting the game, are you sure ?"] = "空环境变量值会在启动游戏前清空该变量，确定继续吗？",
            ["Invalid IP Address"] = "IP 地址无效",
            ["Appid has no DLC"] = "Appid 没有 DLC",
            ["Appid is not valid?"] = "Appid 无效？"
            ,
            ["Start folder "] = "起始文件夹 ",
            [" does not exist"] = " 不存在",
            ["Game exe "] = "游戏程序 ",
            ["Invalid app id"] = "无效 app id",
            ["Game Launch Error"] = "游戏启动错误",
            ["Unsupported"] = "不支持",
            ["This feature is only available on Windows for the moment"] = "该功能目前仅在 Windows 上可用",
            ["Cannot find SmartGoldbergEmu Launcher: "] = "找不到 SmartGoldbergEmu 启动器：",
            ["Cannot launch game: "] = "无法启动游戏：",
            ["Can't generate achievements definition file, webapi key is missing.\n\nSee https://steamcommunity.com/dev/apikey to get yours."] = "无法生成成就定义文件，缺少 webapi key。\n\n请访问 https://steamcommunity.com/dev/apikey 获取。",
            ["Failed to get achievements definition (wrong webapi key ?)"] = "获取成就定义失败（WebAPI 密钥错误？）",
            ["Achievements definition file created"] = "成就定义文件已创建",
            ["Error, is appid wrong ?"] = "错误，appid 有误？",
            ["Failed to get items definition"] = "获取物品定义失败",
            ["No items for this game"] = "该游戏没有物品",
            ["No items for this game: Invalid meta answer."] = "该游戏没有物品：元数据应答无效。",
            ["No items for this game: Invalid items answer."] = "该游戏没有物品：物品应答无效。",
            ["Items definition file created"] = "物品定义文件已创建",
            ["You need to set up game app id first. You can find your game app id on steam store url: http://store.steampowered.com/app/<AppId>"] = "请先设置游戏 AppID。可以从 Steam 商店地址中找到 AppID：http://store.steampowered.com/app/<AppId>",
            ["Cannot setup registry keys in HKEY_CURRENT_USER\\Software\\Valve\\Steam\\ActiveProcess"] = "无法在 HKEY_CURRENT_USER\\Software\\Valve\\Steam\\ActiveProcess 中设置注册表项",
            ["Folder: "] = "文件夹：",
            ["Ok!"] = "好的！",
            ["Folder"] = "文件夹",
            ["Game executables (*.exe)|*.exe;|All Files|*.*"] = "游戏可执行文件 (*.exe)|*.exe;|所有文件|*.*",
            ["Image Files|*.jpg; *.jpeg; *.png; *.ico|All Files|*.*"] = "图像文件|*.jpg; *.jpeg; *.png; *.ico|所有文件|*.*",
            ["PNG|*.png|JPG|*.jpg|All files|*.*"] = "PNG|*.png|JPG|*.jpg|所有文件|*.*",
            ["WAV|*.wav|All files|*.*"] = "WAV|*.wav|所有文件|*.*",
            ["TTF|*.ttf|All files|*.*"] = "TTF|*.ttf|所有文件|*.*",
            ["Webapi Key error"] = "WebAPI 密钥错误",
            ["game app id"] = "游戏 AppID"
        };

        public static string CurrentLanguage { get; private set; } = English;

        public static void InitializeFromSettings()
        {
            CurrentLanguage = LoadUiLanguage();
        }

        public static string LoadUiLanguage()
        {
            string configPath = GetConfigPath();
            if (string.IsNullOrEmpty(configPath) || !File.Exists(configPath))
                return English;

            XmlDocument document = new XmlDocument();
            document.Load(configPath);
            XmlNode node = document.SelectSingleNode("/configuration/appSettings/add[@key='UiLanguage']");
            return Normalize(node?.Attributes?["value"]?.Value);
        }

        public static void SaveUiLanguage(string language)
        {
            string configPath = GetConfigPath();
            if (string.IsNullOrEmpty(configPath))
                return;

            XmlDocument document = new XmlDocument();
            if (File.Exists(configPath))
                document.Load(configPath);
            else
                document.AppendChild(document.CreateElement("configuration"));

            XmlElement root = document.DocumentElement;
            if (root == null)
            {
                root = document.CreateElement("configuration");
                document.AppendChild(root);
            }

            XmlElement appSettings = root.SelectSingleNode("appSettings") as XmlElement;
            if (appSettings == null)
            {
                appSettings = document.CreateElement("appSettings");
                root.PrependChild(appSettings);
            }

            XmlElement setting = appSettings.SelectSingleNode("add[@key='UiLanguage']") as XmlElement;
            if (setting == null)
            {
                setting = document.CreateElement("add");
                setting.SetAttribute("key", "UiLanguage");
                appSettings.AppendChild(setting);
            }

            setting.SetAttribute("value", Normalize(language));
            document.Save(configPath);
        }

        private static string GetConfigPath()
        {
            return Path.Combine(AppContext.BaseDirectory, "SmartGoldbergEmu.dll.config");
        }

        public static string Normalize(string language)
        {
            return language == SimplifiedChinese ? SimplifiedChinese : English;
        }

        public static string GetLanguageDisplayName(string language)
        {
            return Normalize(language) == SimplifiedChinese ? "简体中文" : "English";
        }

        public static string GetLanguageCodeFromDisplayName(string displayName)
        {
            return displayName == "简体中文" ? SimplifiedChinese : English;
        }

        public static string T(string text)
        {
            if (CurrentLanguage == SimplifiedChinese && SimplifiedChineseStrings.TryGetValue(text, out string translated))
                return translated;

            return text;
        }

        public static void ApplyTo(Control root)
        {
            ApplyControl(root);
        }

        private static void ApplyControl(Control control)
        {
            if (!string.IsNullOrEmpty(control.Text))
                control.Text = T(control.Text);

            if (control is ToolStrip toolStrip)
                ApplyToolStripItems(toolStrip.Items);

            if (control.ContextMenuStrip != null)
                ApplyToolStripItems(control.ContextMenuStrip.Items);

            foreach (Control child in control.Controls)
                ApplyControl(child);
        }

        private static void ApplyToolStripItems(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (!string.IsNullOrEmpty(item.Text))
                    item.Text = T(item.Text);

                if (item is ToolStripDropDownItem dropDownItem)
                    ApplyToolStripItems(dropDownItem.DropDownItems);
            }
        }
    }
}
