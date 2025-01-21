using EggLink.DanhengServer.Command;
using EggLink.DanhengServer.Command.Command;
using EggLink.DanhengServer.Internationalization;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;

namespace DanhengPlugin.Lol.Commands;

[CommandInfo(
    "lol",
    "what can i say",
    "Usage: /lol move x y z    /lol fly    /lol team Id1 Id2 Id3 Id4"
)]
public class CommandBuild : ICommand
{
    [CommandMethod("move")]
    public async ValueTask MovePosX(CommandArg arg)
    {
        var player = arg.Target?.Player;
        if (player == null)
        {
            await arg.SendMsg(I18NManager.Translate("Game.Command.Notice.PlayerNotFound"));
            return;
        }
        Position playerPos = player.Data.Pos!;
        Position playerRot = player.Data.Rot!;
        var inputX = playerPos.X + arg.GetInt(0);
        var inputY = playerPos.Y + arg.GetInt(1);
        var inputZ = playerPos.Z + arg.GetInt(2);
        Position position = new Position(inputX, inputY, inputZ);
        await player.MoveTo(position, playerRot);
        await arg.SendMsg("动起来~");
    }

    [CommandMethod("fly")]
    public async ValueTask MovePosY(CommandArg arg)
    {
        var player = arg.Target?.Player;
        if (player == null)
        {
            await arg.SendMsg(I18NManager.Translate("Game.Command.Notice.PlayerNotFound"));
            return;
        }
        Position playerPos = player.Data.Pos!;
        Position playerRot = player.Data.Rot!;
        Position position = new Position(playerPos.X, playerPos.Y + 3600, playerPos.Z);
        await player.MoveTo(position, playerRot);
        await arg.SendMsg("我焯起飞~");
    }

    [CommandMethod("team")]
    public async ValueTask ChangeTeam(CommandArg arg)
    {
        var player = arg.Target?.Player;
        if (player == null)
        {
            await arg.SendMsg(I18NManager.Translate("Game.Command.Notice.PlayerNotFound"));
            return;
        }
        var curLineupIndex = player.LineupManager!.LineupData.GetCurLineupIndex();
        var replaceLineup = new List<int>
        {
            arg.GetInt(0),
            arg.GetInt(1),
            arg.GetInt(2),
            arg.GetInt(3),
        };
        await player.LineupManager.ReplaceLineup(curLineupIndex, replaceLineup);
    }

    // [CommandMethod("raid")]
    // public async ValueTask StartRaid(CommandArg arg)
    // {
    //     var player = arg.Target?.Player;
    //     if (player == null)
    //     {
    //         await arg.SendMsg(I18NManager.Translate("Game.Command.Notice.PlayerNotFound"));
    //         return;
    //     }
    //     var curLineup = player.LineupManager!.GetCurLineup();
    //     var avatarList = curLineup?.BaseAvatars;
    //     var avatarIdList = new List<int>();
    //     foreach (var avatar in avatarList!)
    //     {
    //         avatarIdList.Add(avatar.BaseAvatarId);
    //     }
    //     await player.RaidManager!.EnterRaid(arg.GetInt(0), arg.GetInt(1), avatarIdList);
    // }
}
