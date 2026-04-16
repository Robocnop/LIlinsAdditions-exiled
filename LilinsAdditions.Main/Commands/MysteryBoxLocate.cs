using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using LilinsAdditions.Main.Handlers;

namespace LilinsAdditions.Main.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class MysteryBoxLocate : ICommand
{
    public string Command => "mblocate";
    public string[] Aliases => new[] { "mbl", "boxlocate" };
    public string Description => "Lists the rooms where Mystery Boxes are currently active.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var tracked = PMERHandler.TrackedSchematics;

        if (tracked.Count == 0)
        {
            response = "No Mystery Boxes are currently active.";
            return true;
        }

        var sb = new StringBuilder();
        sb.AppendLine($"Mystery Boxes active: {tracked.Count}");

        var i = 1;
        foreach (var schematic in tracked)
        {
            var room = Room.FindParentRoom(schematic.gameObject);
            var roomName = room != null ? room.Type.ToString() : "Unknown";
            sb.AppendLine($"  {i}. {roomName}");
            i++;
        }

        response = sb.ToString().TrimEnd();
        return true;
    }
}
