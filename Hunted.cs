using MelonLoader;
using System;
using Il2Cpp;
using HarmonyLib;
using Il2CppTLD;
using BearSettings;

namespace Always_Hunted;
internal sealed class Hunted : MelonMod
{
  public override void OnInitializeMelon()
  {
    Settings.OnLoad();
  }

  public override void OnUpdate()
  {
    string? sceneName = GameManager.m_ActiveScene;
    Action_SpawnHuntedChallengeBear spawnBear = new Action_SpawnHuntedChallengeBear();

    if(sceneName != null && GameManager.IsOutDoorsScene(sceneName) && GameManager.IsActiveScene(sceneName) && !spawnBear.ChallengeBearIsActive() && Settings.options.bearEnabled == true)
    {
      spawnBear.minSpawnDistance = Settings.options.minSpawn;
      spawnBear.maxSpawnDistance = Settings.options.maxSpawn;

      if((Settings.options.bearEnabledInFRBL && sceneName == "LongRailTransitionZone") && spawnBear.SpawnChallengeBearNearPlayer())
      {
        Console.WriteLine("Bear Spawned At " + DateTime.Now);
      }
    }
  }
}
