namespace LilinsAdditions.Translations;

internal static class Fr
{
    internal static readonly global::LilinsAdditions.Translation Instance = new()
    {
        BorrowedTimeActivated = "Temps Emprunté activé ! Dégâts stockés pendant 10s.",
        BorrowedTimeExplosion = "Le temps emprunté est écoulé... de manière explosive !",
        BorrowedTimeEnded = "Temps Emprunté terminé ! Vous prenez {0} dégâts.",

        CardiacOverdriveAlreadyActive = "<color=red>La Surcharge Cardiaque est déjà active !</color>",
        CardiacOverdriveActivated = "<color=red>Surcharge Cardiaque activée pour {0}s !</color>",
        CardiacOverdriveStatus = "<color=red>💔 Force vitale utilisée ! PV : {0} | {1}s restantes</color>",
        CardiacOverdriveHeartOut = "<color=red>Votre cœur a lâché ! Effet terminé.</color>",
        CardiacOverdriveEnded = "<color=yellow>Effet Surcharge Cardiaque terminé.</color>",

        GogglesRemoved = "Vous retirez {0}",
        GogglesEquipped = "Vous enfilez {0}",
        GogglesAlreadyWearing = "Vous portez déjà quelque chose !",

        SpeedRouletteBoost = "⚡ BOOST DE VITESSE ! (+{0}% de vitesse)",
        SpeedRouletteSlow = "🐌 RALENTI ! (-{0}% de vitesse)",

        PointsUsage = "Utilisation : points (get|add|set|remove) <joueur> [montant]",
        PointsInvalidAction = "Action invalide. Utilisez : get, add, set, remove",
        PointsInvalidAmount = "Veuillez entrer un montant valide.",
        PointsPlayerNotFound = "Joueur '{0}' introuvable.",
        PointsGet = "Le joueur {0} possède {1} points.",
        PointsAdded = "{0} points ajoutés à {1}.",
        PointsSet = "Points de {0} définis à {1}.",
        PointsRemoved = "{0} points retirés à {1}.",
    };
}
