using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using LilinsAdditions.Main.Features;
using LilinsAdditions.Main.Handlers;
using ProjectMER.Features;
using UnityEngine;

namespace LilinsAdditions.Main.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class MysteryBoxSpawn : ICommand
{
    public string Command => "mbspawn";
    public string[] Aliases => new[] { "spawnbox" };
    public string Description => "Force spawns a Mystery Box in a random eligible room.";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var config = LilinsAdditions.Instance.Config;
        var spawnPoints = config.MysteryBoxSpawnPoints;

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            response = "No mystery box spawn points configured.";
            return false;
        }

        var randomEntry = spawnPoints.ElementAt(UnityEngine.Random.Range(0, spawnPoints.Count));
        var selectedType = randomEntry.Key;
        var data = randomEntry.Value;

        var rooms = Room.List
            .Where(r => r.Type == selectedType)
            .ToList();

        if (rooms.Count == 0)
        {
            response = $"Room '{selectedType}' not found on this map. Try again.";
            return false;
        }

        var room = rooms[UnityEngine.Random.Range(0, rooms.Count)];

        Vector3 globalPosition = room.transform.localToWorldMatrix *
                                 new Vector4(data.Position.x, data.Position.y, data.Position.z, 1);
        var globalRotation = room.transform.rotation * Quaternion.Euler(data.Rotation);

        if (!ObjectSpawner.TrySpawnSchematic("MysteryBox", globalPosition, globalRotation, out var schematic))
        {
            response = "Failed to spawn the Mystery Box schematic. Make sure the schematic files are installed.";
            return false;
        }

        PMERHandler.TrackedSchematics.Add(schematic);

        response = $"Mystery Box spawned in {room.Type}.";
        return true;
    }
}
