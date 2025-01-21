using DanhengPlugin.Lol.Commands;
using EggLink.DanhengServer.Command.Command;
using EggLink.DanhengServer.GameServer.Plugin.Constructor;
using EggLink.DanhengServer.Internationalization;
using EggLink.DanhengServer.Util;

namespace DanhengPlugin.Lol;

[PluginInfo("Lol", "what can i say << lol", "1.0")]
public class Lol : IPlugin
{
    private readonly Logger _logger = new("Lol");

    public void OnLoad()
    {
        CommandManager.Instance?.RegisterCommand(typeof(CommandBuild));
        _logger.Info(I18NManager.Translate("Lol.LoadedLol"));
    }

    public void OnUnload()
    {
        _logger.Info(I18NManager.Translate("Lol.UnloadedLol"));
    }
}
