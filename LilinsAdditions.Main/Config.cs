using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using LilinsAdditions.Main.Helper;
using LilinsAdditions.Main.Items.GobbleGums;
using LilinsAdditions.Main.Items.SCPs;
using LilinsAdditions.Main.Items.Weapons.LMGs;
using LilinsAdditions.Main.Items.Weapons.Pistols;
using LilinsAdditions.Main.Items.Weapons.Rifles;
using LilinsAdditions.Main.Items.Weapons.Shotguns;
using LilinsAdditions.Main.Items.Weapons.SMGs;
using UnityEngine;
using static LilinsAdditions.Main.Features.SchematicSpawner;

namespace LilinsAdditions;

public class Config : IConfig
{
    [Description("Whether this plugin is enabled.")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether debug messages should be shown in the console.")]
    public bool Debug { get; set; } = false;

    [Description("Language used for in-game messages. Bundled options: en, fr. Contributors can add more.")]
    public string Language { get; set; } = "en";

    // --- Feature Toggles ---

    [Description("Whether the Fortuna Fizz vending machine feature is enabled.")]
    public bool EnableFortunaFizz { get; set; } = true;

    [Description("Whether the Mystery Box feature is enabled.")]
    public bool EnableMysteryBox { get; set; } = true;

    [Description("Whether hidden coins spawn on the map.")]
    public bool EnableHiddenCoins { get; set; } = false;

    [Description("Whether facility guards spawn in random rooms at round start.")]
    public bool EnableRandomGuardSpawn { get; set; } = false;

    [Description("Whether players are teleported to a random LCZ room when entering SCP-914 on Rough setting.")]
    public bool Enable914Teleport { get; set; } = false;

    [Description("Whether a credit card containing the victim's points drops on death.")]
    public bool EnableCreditCardDrop { get; set; } = false;

    [Description("Whether SCPs are teleported to a safe HCZ room instead of dying to the void.")]
    public bool EnableAntiSCPSuicide { get; set; } = false;

    // --- Audio ---

    [Description("Absolute path to the audio clip played by the Fortuna Fizz vending machine.")]
    public string VendingMachineMusicPath { get; set; } = string.Empty;

    [Description("Absolute path to the audio clip played by the Mystery Box.")]
    public string MysteryBoxMusicPath { get; set; } = string.Empty;

    [Description("Absolute path to the audio clip played on burst fire.")]
    public string BurstSoundPath { get; set; } = string.Empty;

    [Description("Absolute path to the audio clip played when tracking activates.")]
    public string TrackingSoundPath { get; set; } = string.Empty;

    [Description("Volume of the Fortuna Fizz vending machine music.")]
    public float VendingMachineMusicVolume { get; set; } = 2f;

    [Description("Volume of the Mystery Box music.")]
    public float MysteryBoxMusicVolume { get; set; } = 1.5f;

    // --- Point System ---

    [Description("Points each eligible player starts with at round begin.")]
    public int StartingPoints { get; set; } = 400;

    [Description("Points awarded for killing an enemy.")]
    public int PointsForKillingEnemy { get; set; } = 200;

    [Description("Points passively gained every PointsOverTimeDelay seconds.")]
    public int PointsOverTime { get; set; } = 100;

    [Description("Interval in seconds between passive point gains.")]
    public int PointsOverTimeDelay { get; set; } = 120;

    [Description("Points required to use the Mystery Box.")]
    public int PointsForMysteryBox { get; set; } = 800;

    [Description("Points required to use the Fortuna Fizz vending machine.")]
    public int PointsForVendingMachine { get; set; } = 200;

    [Description("Points rewarded for picking up a hidden coin.")]
    public int PointsForCoin { get; set; } = 1500;

    [Description("Hint shown to the player when they lack points to use the Mystery Box.")]
    public string MysteryBoxMissingPointsText { get; set; } = "<color=red>You need 800 Points to open the box!</color>";

    [Description("Hint shown to the player when they lack points to use the vending machine.")]
    public string VendingMachineMissingPointsText { get; set; } = "<color=red>You need 200 points!</color>";

    // --- Spawn Limits ---

    [Description("Maximum number of times a single vending machine can be used per round.")]
    public int VendingMachineUsageLimit { get; set; } = 10;

    [Description("Maximum number of Mystery Boxes that can spawn per round.")]
    public int MaxMysteryBoxCount { get; set; } = 8;

    [Description("Maximum number of Fortuna Fizz vending machines that can spawn per round.")]
    public int MaxVendingMachineCount { get; set; } = 5;

    [Description("Maximum number of hidden coins that can spawn per round.")]
    public int MaxCoinCount { get; set; } = 2;

    // --- Mystery Box Pool ---

    [Description("Weighted item pool used by the Mystery Box. Higher weight = more likely to appear.")]
    public List<MysteryBoxPoolConfig> MysteryBoxItemPool { get; set; } = new()
    {
        new MysteryBoxPoolConfig { Name = "Grenade Launcher", Weight = 2 },
        new MysteryBoxPoolConfig { Name = "Behemoth 50.cal", Weight = 3 },
        new MysteryBoxPoolConfig { Name = "Nullifier", Weight = 10 },
        new MysteryBoxPoolConfig { Name = "Entity Swapper", Weight = 10 },
        new MysteryBoxPoolConfig { Name = "Russian Roulette", Weight = 10 },
        new MysteryBoxPoolConfig { Name = "HumeBreaker v2.1", Weight = 2 },
        new MysteryBoxPoolConfig { Name = "RangeTec - .308 Lapua", Weight = 3 },
        new MysteryBoxPoolConfig { Name = "Kerberos-12", Weight = 10 },
        new MysteryBoxPoolConfig { Name = "MS9K - MedShot 9000", Weight = 6 }
    };

    // --- Spawn Points ---

    [Description("Room-based spawn points for the Mystery Box schematic.")]
    public Dictionary<RoomType, SpawnData> MysteryBoxSpawnPoints { get; set; } = new()
    {
        { RoomType.Lcz330, new SpawnData(new Vector3(-5.84f, 0.13f, 3.014f), new Vector3(0, -90, 0)) },
        { RoomType.LczGlassBox, new SpawnData(new Vector3(4.503f, 0.13f, 4.947f), new Vector3(0, -90, 0)) },
        { RoomType.LczAirlock, new SpawnData(new Vector3(0f, 0.13f, 1f), new Vector3(0, -90, 0)) },
        { RoomType.LczCafe, new SpawnData(new Vector3(-5.878f, 0.13f, 4.542f), new Vector3(0, -90, 0)) },
        { RoomType.LczClassDSpawn, new SpawnData(new Vector3(-24.711f, 0.13f, 0f), new Vector3(0, -180f, 0)) },
        { RoomType.LczCrossing, new SpawnData(new Vector3(2.343f, 0.13f, -2.31f), new Vector3(0, 45, 0)) },
        { RoomType.LczPlants, new SpawnData(new Vector3(0f, 0.13f, 1.474f), new Vector3(0, -90f, 0)) },
        { RoomType.LczStraight, new SpawnData(new Vector3(0f, 0.13f, -1.144f), new Vector3(0, 90f, 0)) },
        { RoomType.LczTCross, new SpawnData(new Vector3(1.158f, 0.13f, 0f), new Vector3(0, 0f, 0)) },
        { RoomType.Hcz127, new SpawnData(new Vector3(-3.769f, 0.13f, -5.085f), new Vector3(0, 135f, 0)) },
        { RoomType.HczIntersectionJunk, new SpawnData(new Vector3(-1.614f, 0.13f, 0f), new Vector3(0, -180f, 0)) },
        { RoomType.HczHid, new SpawnData(new Vector3(2.247f, 0.13f, -1.868f), new Vector3(0, 90f, 0)) },
        { RoomType.HczStraightPipeRoom, new SpawnData(new Vector3(-6.326f, 5.204f, 5.375f), new Vector3(0, 180f, 0)) },
        { RoomType.HczArmory, new SpawnData(new Vector3(2.065f, 0.13f, 5.214f), new Vector3(0, 0f, 0)) }
    };

    [Description("Room-based spawn points for the Fortuna Fizz vending machine schematic.")]
    public Dictionary<RoomType, SpawnData> VendingMachineSpawnPoints { get; set; } = new()
    {
        { RoomType.LczGlassBox, new SpawnData(new Vector3(8.842f, 0.332f, -2.923f), new Vector3(0, 0, 0)) },
        { RoomType.LczCafe, new SpawnData(new Vector3(-4.339f, 0.332f, -4.614f), new Vector3(0, 90, 0)) },
        { RoomType.Lcz914, new SpawnData(new Vector3(0f, 0.332f, 6.879f), new Vector3(0, -90, 0)) },
        { RoomType.HczHid, new SpawnData(new Vector3(1.037f, 0.332f, 4.992f), new Vector3(0, -90f, 0)) },
        { RoomType.HczArmory, new SpawnData(new Vector3(2.11f, 0.332f, -5.15f), new Vector3(0, 0f, 0)) }
    };

    [Description("Room-based spawn points for hidden coins.")]
    public Dictionary<RoomType, SpawnData> CoinSpawnPoints { get; set; } = new()
    {
        { RoomType.LczAirlock, new SpawnData(new Vector3(2.855f, 0.0178f, -4.25f), new Vector3(0, 0, 0)) },
        { RoomType.Lcz173, new SpawnData(new Vector3(12.099f, 11.479f, 3.962f), new Vector3(0, 0, 0)) },
        { RoomType.LczArmory, new SpawnData(new Vector3(0.2342f, 0.524f, 2.0502f), new Vector3(0, 0, 0)) },
        { RoomType.HczHid, new SpawnData(new Vector3(-6.05f, 4.4983f, -4.744f), new Vector3(0, 0, 0)) },
        { RoomType.HczNuke, new SpawnData(new Vector3(1.288f, -72.417f, -0.423f), new Vector3(0, 0, 0)) }
    };

    // --- Custom Items ---

    [Description("Configuration for the Gas Mask custom item.")]
    public List<Gasmask> Gasmask { get; set; } = new() { new Gasmask() };

    [Description("Configuration for the Explosive LMG custom weapon.")]
    public List<ExplosiveLMG> ExplosiveLMG { get; set; } = new() { new ExplosiveLMG() };

    [Description("Configuration for the Grenade Launcher custom weapon.")]
    public List<GrenadeLauncher> GrenadeLauncher { get; set; } = new() { new GrenadeLauncher() };

    [Description("Configuration for the Behemoth .50 Cal custom weapon.")]
    public List<Behemoth> Behemoth { get; set; } = new() { new Behemoth() };

    [Description("Configuration for the Nullifier (HackGun) custom weapon.")]
    public List<HackGun> HackGun { get; set; } = new() { new HackGun() };

    [Description("Configuration for the Entity Swapper (PlaceSwap) custom weapon.")]
    public List<PlaceSwap> PlaceSwap { get; set; } = new() { new PlaceSwap() };

    [Description("Configuration for the Russian Roulette custom weapon.")]
    public List<RussianRoulette> RussianRoulette { get; set; } = new() { new RussianRoulette() };

    [Description("Configuration for the HumeBreaker custom weapon.")]
    public List<HumeBreaker> HumeBreaker { get; set; } = new() { new HumeBreaker() };

    [Description("Configuration for the Sniper custom weapon.")]
    public List<Sniper> Sniper { get; set; } = new() { new Sniper() };

    [Description("Configuration for the Breach Shotgun custom weapon.")]
    public List<BreachShotgun> BreachShotgun { get; set; } = new() { new BreachShotgun() };

    [Description("Configuration for the Medic Gun custom weapon.")]
    public List<MedicGun> MedicGun { get; set; } = new() { new MedicGun() };

    // --- GobbleGums ---

    [Description("Configuration for the Anywhere But Here GobbleGum.")]
    public List<AnywhereButHere> AnywhereButHere { get; set; } = new() { new AnywhereButHere() };

    [Description("Configuration for the Chemical Cocktail GobbleGum.")]
    public List<ChemicalCocktail> ChemicalCocktail { get; set; } = new() { new ChemicalCocktail() };

    [Description("Configuration for the Better Be Small GobbleGum.")]
    public List<BetterBeSmall> BetterBeSmall { get; set; } = new() { new BetterBeSmall() };

    [Description("Configuration for the Death Cheat GobbleGum.")]
    public List<DeathCheat> DeathCheat { get; set; } = new() { new DeathCheat() };

    [Description("Configuration for the I Don't Want To Be Here GobbleGum.")]
    public List<IDontWantToBeHere> IDontWantToBeHere { get; set; } = new() { new IDontWantToBeHere() };

    [Description("Configuration for the In Plain Sight GobbleGum.")]
    public List<InPlainSight> InPlainSight { get; set; } = new() { new InPlainSight() };

    [Description("Configuration for the Juggernaut GobbleGum.")]
    public List<Juggernaut> Juggernaut { get; set; } = new() { new Juggernaut() };

    [Description("Configuration for the Light Headed GobbleGum.")]
    public List<LightHeaded> LightHeaded { get; set; } = new() { new LightHeaded() };

    [Description("Configuration for the Never Seen GobbleGum.")]
    public List<NeverSeen> NeverSeen { get; set; } = new() { new NeverSeen() };

    [Description("Configuration for the Now You See Me GobbleGum.")]
    public List<NowYouSeeMe> NowYouSeeMe { get; set; } = new() { new NowYouSeeMe() };

    [Description("Configuration for the Peel And Run GobbleGum.")]
    public List<PeelAndRun> PeelAndRun { get; set; } = new() { new PeelAndRun() };

    [Description("Configuration for the Random Effect GobbleGum.")]
    public List<RandomEffect> RandomEffect { get; set; } = new() { new RandomEffect() };

    [Description("Configuration for the Shadow Step GobbleGum.")]
    public List<ShadowStep> ShadowStep { get; set; } = new() { new ShadowStep() };

    [Description("Configuration for the Shrink And Run GobbleGum.")]
    public List<ShrinkAndRun> ShrinkAndRun { get; set; } = new() { new ShrinkAndRun() };

    [Description("Configuration for the Silent Step GobbleGum.")]
    public List<SilentStep> SilentStep { get; set; } = new() { new SilentStep() };

    [Description("Configuration for the Switcheroo GobbleGum.")]
    public List<Switcheroo> Switcheroo { get; set; } = new() { new Switcheroo() };

    [Description("Configuration for the Where Is Waldo GobbleGum.")]
    public List<WhereIsWaldo> WhereIsWaldo { get; set; } = new() { new WhereIsWaldo() };

    [Description("Configuration for the Inventory Swap GobbleGum.")]
    public List<InventorySwap> InventorySwap { get; set; } = new() { new InventorySwap() };

    [Description("Configuration for the Life Leech GobbleGum.")]
    public List<LifeLeech> LifeLeech { get; set; } = new() { new LifeLeech() };

    [Description("Configuration for the Cardiac Overdrive GobbleGum.")]
    public List<CardiacOverdrive> CardiacOverdrive { get; set; } = new() { new CardiacOverdrive() };

    [Description("Configuration for the Speed Roulette GobbleGum.")]
    public List<SpeedRoulette> SpeedRoulette { get; set; } = new() { new SpeedRoulette() };

    [Description("Configuration for the Borrowed Time GobbleGum.")]
    public List<BorrowedTime> BorrowedTime { get; set; } = new() { new BorrowedTime() };
}