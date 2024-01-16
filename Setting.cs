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
      [Name("Enabled")]
      [Description("Disables or enables the bear. !This setting is not immediate go into a building and then leave it to apply it")]
      public bool bearEnabled = true;
      [Name("Enabled in Far Range Branch Line")]
      [Description("The Far Range Branch Line is a transition region and the bear is not supposed to spawn in transition regions but since you can not go there normally in the hunted challenge he will still spawn there")]
      public bool bearEnabledInFRBL = true;
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
