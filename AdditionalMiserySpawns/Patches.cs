using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using Il2CppTLD.Scenes;

namespace AdditionalMiserySpawns
{
	[HarmonyPatch(typeof(SandboxBaseConfig), "ValidateStartingRegion")]
	internal class SandboxConfigValidateStartingRegionPatch
	{
		internal static bool Prefix(SandboxBaseConfig __instance, ref RegionSpecification requestedRegion)
		{
			if (ExperienceModeManager.GetCurrentExperienceModeType() !=
				ExperienceModeType.Misery)
				return true;

			Mod.RollRandomSpawnLocation();

			if (Mod.Region == null)
				return true;

			if (Mod.SceneSet == null)
				return true;

			__instance.m_ForceSceneLoad = Mod.SceneSet;
			requestedRegion = Mod.Region;
			return true;
		}
	}

	[HarmonyPatch(typeof(GameManager), "LaunchSandbox")]
	internal class GameManagerLaunchSandboxPatch
	{
		internal static void Postfix(GameManager __instance)
		{
			if (ExperienceModeManager.GetCurrentExperienceModeType() !=
				ExperienceModeType.Misery)
				return;

			if (Mod.Region == null)
				return;

			if (Mod.SceneSet == null)
				return;

			GameManager.m_StartRegion = Mod.Region;
		}
	}
}
