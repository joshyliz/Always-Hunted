using ModSettings;
using UnityEngine;
using Il2Cpp;

namespace BearSettings
{
	internal class BearSpawning : JsonModSettings
	{
      [Name("Bear spawn minimum distance")]
      [Description("The minimum distance the bear will spawn from the player. (Defualt = 75)")]
      [Slider(1, 1000, 1000, NumberFormat = "{0:F2}")]
      public float minSpawn = new Action_SpawnHuntedChallengeBear().minSpawnDistance.value;
      [Name("Bear spawn maximum distance")]
      [Description("The maximum distance the bear will spawn from the player. (Defualt = 200)")]
      [Slider(1, 2000, 2000, NumberFormat = "{0:F2}")]
      public float maxSpawn = new Action_SpawnHuntedChallengeBear().maxSpawnDistance.value;
	}

	internal static class Settings
	{
      internal static BearSpawning options;

      public static void OnLoad()
      {
        options = new BearSpawning();
        options.AddToModSettings("Bear Settings");
      }
	}
}
