namespace LilinsAdditions.Translations;

internal static class En
{
    internal static readonly global::LilinsAdditions.Translation Instance = new()
    {
        BorrowedTimeActivated = "Borrowed Time activated! Damage stored for 10s.",
        BorrowedTimeExplosion = "The borrowed time has run out... explosively!",
        BorrowedTimeEnded = "Borrowed Time ended! Taking {0} damage.",

        CardiacOverdriveAlreadyActive = "<color=red>Cardiac Overdrive is already active!</color>",
        CardiacOverdriveActivated = "<color=red>Cardiac Overdrive activated for {0}s!</color>",
        CardiacOverdriveStatus = "<color=red>💔 Using life force! HP: {0} | {1}s left</color>",
        CardiacOverdriveHeartOut = "<color=red>Your heart gave out! Effect ended.</color>",
        CardiacOverdriveEnded = "<color=yellow>Cardiac Overdrive effect ended.</color>",

        GogglesRemoved = "You remove the {0}",
        GogglesEquipped = "You put on the {0}",
        GogglesAlreadyWearing = "You are already wearing something!",

        SpeedRouletteBoost = "⚡ SPEED BOOST! (+{0}% speed)",
        SpeedRouletteSlow = "🐌 SLOWED DOWN! (-{0}% speed)",

        PointsUsage = "Usage: points (get|add|set|remove) <player> [amount]",
        PointsInvalidAction = "Not a valid action. Use: get, add, set, remove",
        PointsInvalidAmount = "Please enter a valid amount.",
        PointsPlayerNotFound = "Player '{0}' not found.",
        PointsGet = "Player {0} has {1} points.",
        PointsAdded = "Added {0} points to {1}.",
        PointsSet = "Set {0}'s points to {1}.",
        PointsRemoved = "Removed {0} points from {1}.",
    };
}
