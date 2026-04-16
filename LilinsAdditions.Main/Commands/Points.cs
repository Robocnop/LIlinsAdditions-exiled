using System;
using CommandSystem;
using Exiled.API.Features;
using LilinsAdditions.Main.Features;

namespace LilinsAdditions.Main.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Points : ICommand
{
    private const int MinimumArgumentCount = 2;
    private const int ArgumentCountWithAmount = 3;

    public string Command => "points";
    public string[] Aliases => new[] { "pts" };
    public string Description => "Manages points for a selected player (add/set/remove/get)";

    private static Translation T => LilinsAdditions.Instance.ActiveTranslation;

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count < MinimumArgumentCount)
        {
            response = T.PointsUsage;
            return false;
        }

        var action = arguments.At(0).ToLower();
        var playerName = arguments.At(1);

        if (!TryGetPlayer(playerName, out var player))
        {
            response = string.Format(T.PointsPlayerNotFound, playerName);
            return false;
        }

        return ExecuteAction(action, player, arguments, out response);
    }

    private static bool TryGetPlayer(string playerName, out Player player)
    {
        player = Player.Get(playerName);
        return player != null;
    }

    private static bool ExecuteAction(string action, Player player, ArraySegment<string> arguments, out string response)
    {
        switch (action)
        {
            case "get":
                return HandleGetPoints(player, out response);

            case "add":
            case "set":
            case "remove":
                return HandlePointsModification(action, player, arguments, out response);

            default:
                response = T.PointsInvalidAction;
                return false;
        }
    }

    private static bool HandleGetPoints(Player player, out string response)
    {
        var currentPoints = PointSystem.GetPoints(player);
        response = string.Format(T.PointsGet, player.Nickname, currentPoints);
        return true;
    }

    private static bool HandlePointsModification(string action, Player player, ArraySegment<string> arguments,
        out string response)
    {
        if (!TryParseAmount(arguments, out var amount))
        {
            response = T.PointsInvalidAmount;
            return false;
        }

        switch (action)
        {
            case "add":
                PointSystem.AddPoints(player, amount);
                response = string.Format(T.PointsAdded, amount, player.Nickname);
                break;

            case "set":
                PointSystem.SetPoints(player, amount);
                response = string.Format(T.PointsSet, player.Nickname, amount);
                break;

            case "remove":
                PointSystem.RemovePoints(player, amount);
                response = string.Format(T.PointsRemoved, amount, player.Nickname);
                break;

            default:
                response = T.PointsInvalidAction;
                return false;
        }

        return true;
    }

    private static bool TryParseAmount(ArraySegment<string> arguments, out int amount)
    {
        amount = 0;
        return arguments.Count >= ArgumentCountWithAmount && int.TryParse(arguments.At(2), out amount);
    }
}