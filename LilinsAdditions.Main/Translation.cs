using System.ComponentModel;
using Exiled.API.Interfaces;

namespace LilinsAdditions;

public class Translation : ITranslation
{
    // --- Borrowed Time ---

    [Description("Shown when Borrowed Time activates. Damage storage duration is hardcoded in the item config.")]
    public string BorrowedTimeActivated { get; set; } = "Borrowed Time activated! Damage stored for 10s.";

    [Description("Shown when stored damage exceeds the explosion threshold.")]
    public string BorrowedTimeExplosion { get; set; } = "The borrowed time has run out... explosively!";

    [Description("Shown when Borrowed Time ends normally. {0} = final damage dealt.")]
    public string BorrowedTimeEnded { get; set; } = "Borrowed Time ended! Taking {0} damage.";

    // --- Cardiac Overdrive ---

    [Description("Shown when the player tries to activate Cardiac Overdrive while it is already active.")]
    public string CardiacOverdriveAlreadyActive { get; set; } = "<color=red>Cardiac Overdrive is already active!</color>";

    [Description("Shown when Cardiac Overdrive activates. {0} = effect duration in seconds.")]
    public string CardiacOverdriveActivated { get; set; } = "<color=red>Cardiac Overdrive activated for {0}s!</color>";

    [Description("Shown periodically while the effect drains HP. {0} = current HP, {1} = seconds remaining.")]
    public string CardiacOverdriveStatus { get; set; } = "<color=red>💔 Using life force! HP: {0} | {1}s left</color>";

    [Description("Shown when the player's HP drops too low to continue the effect.")]
    public string CardiacOverdriveHeartOut { get; set; } = "<color=red>Your heart gave out! Effect ended.</color>";

    [Description("Shown when Cardiac Overdrive expires normally.")]
    public string CardiacOverdriveEnded { get; set; } = "<color=yellow>Cardiac Overdrive effect ended.</color>";

    // --- Goggles ---

    [Description("Shown when the player removes their goggles. {0} = item name.")]
    public string GogglesRemoved { get; set; } = "You remove the {0}";

    [Description("Shown when the player equips their goggles. {0} = item name.")]
    public string GogglesEquipped { get; set; } = "You put on the {0}";

    [Description("Shown when the player tries to equip goggles while already wearing something.")]
    public string GogglesAlreadyWearing { get; set; } = "You are already wearing something!";

    // --- Speed Roulette ---

    [Description("Shown on a positive speed roll. {0} = boost percentage.")]
    public string SpeedRouletteBoost { get; set; } = "⚡ SPEED BOOST! (+{0}% speed)";

    [Description("Shown on a negative speed roll. {0} = slowness percentage.")]
    public string SpeedRouletteSlow { get; set; } = "🐌 SLOWED DOWN! (-{0}% speed)";

    // --- Points Command (Remote Admin) ---

    [Description("Shown when the points command is used with wrong syntax.")]
    public string PointsUsage { get; set; } = "Usage: points (get|add|set|remove) <player> [amount]";

    [Description("Shown when an unknown action is passed to the points command.")]
    public string PointsInvalidAction { get; set; } = "Not a valid action. Use: get, add, set, remove";

    [Description("Shown when the amount argument is missing or not a number.")]
    public string PointsInvalidAmount { get; set; } = "Please enter a valid amount.";

    [Description("Shown when the target player is not found. {0} = player name entered.")]
    public string PointsPlayerNotFound { get; set; } = "Player '{0}' not found.";

    [Description("Shown when getting a player's points. {0} = player name, {1} = points.")]
    public string PointsGet { get; set; } = "Player {0} has {1} points.";

    [Description("Shown after adding points. {0} = amount added, {1} = player name.")]
    public string PointsAdded { get; set; } = "Added {0} points to {1}.";

    [Description("Shown after setting points. {0} = player name, {1} = new amount.")]
    public string PointsSet { get; set; } = "Set {0}'s points to {1}.";

    [Description("Shown after removing points. {0} = amount removed, {1} = player name.")]
    public string PointsRemoved { get; set; } = "Removed {0} points from {1}.";
}
