using MelonLoader;
using System;
using Il2Cpp;
using HarmonyLib;
using Il2CppTLD;
using System.Text.Json;

namespace Always_Hunted;

public class BearSettings
{
  public float MinimumSpawnDistance {get; set;}
  public float MaximumSpawnDistance {get; set;}
  public bool BearIsEnabled {get; set;}
  public bool BearEnabledInFRBL {get; set;}
}

internal sealed class Hunted : MelonMod
{
  const string fileName = "Mods/BearSettings.json";
  BearSettings bearSettings = new BearSettings
  {
    MinimumSpawnDistance = 75,
    MaximumSpawnDistance = 200,
    BearIsEnabled = true,
    BearEnabledInFRBL = true,
  };
  
  public override void OnInitializeMelon()
  {
    if(File.Exists(fileName))
    {
      string settingsText = File.ReadAllText(fileName);
      bearSettings = JsonSerializer.Deserialize<BearSettings>(settingsText)!;
    }
    else 
    {
      string writeText = JsonSerializer.Serialize(bearSettings);
      File.WriteAllText(fileName, writeText);
    }
  }

  public override void OnUpdate()
  {
    string? sceneName = GameManager.m_ActiveScene;
    Action_SpawnHuntedChallengeBear spawnBear = new Action_SpawnHuntedChallengeBear();

    if(InputManager.GetKeyDown(InputManager.m_CurrentContext, UnityEngine.KeyCode.F7) && !GameManager.IsMainMenuActive() && sceneName != null)
    {
      if(File.Exists(fileName))
      {
        string settingsText = File.ReadAllText(fileName);
        bearSettings = JsonSerializer.Deserialize<BearSettings>(settingsText)!;
      }
      else 
      {
        string writeText = JsonSerializer.Serialize(bearSettings);
        File.WriteAllText(fileName, writeText);
      }
      
      Console.WriteLine("Settings Reloaded");
    }

    if(sceneName != null && GameManager.IsOutDoorsScene(sceneName) && GameManager.IsActiveScene(sceneName) && !spawnBear.ChallengeBearIsActive() && bearSettings.BearIsEnabled == true)
    {
      spawnBear.minSpawnDistance = bearSettings.MinimumSpawnDistance;
      spawnBear.maxSpawnDistance = bearSettings.MaximumSpawnDistance;

      if(bearSettings.BearEnabledInFRBL == true)
      {
        if(spawnBear.SpawnChallengeBearNearPlayer())
        {
          Console.WriteLine("Bear Spawned At " + DateTime.Now);
        }
      }
      else if(bearSettings.BearEnabledInFRBL == false)
      {
        if(sceneName != "LongRailTransitionZone" && spawnBear.SpawnChallengeBearNearPlayer())
        {
          Console.WriteLine("Bear Spawned At " + DateTime.Now);
        }
      }
    }
  }
}
