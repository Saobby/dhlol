using EggLink.DanhengServer.Enums.Language;
using EggLink.DanhengServer.Internationalization;

namespace DanhengPlugin.Lol.Language;

[PluginLanguage(ProgramLanguageTypeEnum.CHS)]
public class LanguageCHS
{
    public PluginLanguage Lol => new();
}

public class PluginLanguage
{
    public string LoadedLol => "已加载lol插件by冲天大棒";
    public string UnloadedLol => "lol插件已卸载！";
}
