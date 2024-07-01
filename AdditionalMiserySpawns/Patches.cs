using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using Il2CppTLD.Scenes;
using ModTemplate;

namespace AdditionalMiserySpawns
{
	[HarmonyPatch(typeof(SandboxBaseConfig), "ValidateStartingRegion")]
	internal class SandboxConfigValidateStartingRegionPatch
	{
		private static Random rand = new Random();

		internal static bool Prefix(SandboxBaseConfig __instance, ref RegionSpecification requestedRegion)
		{
			if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Misery)
				return true;

			RandomSpawnManager.RollRandomSpawnLocation();

			if (RandomSpawnManager.Region == null)
				return true;

			if (RandomSpawnManager.SceneSet == null)
				return true;

			__instance.m_ForceSceneLoad = RandomSpawnManager.SceneSet;
			requestedRegion = RandomSpawnManager.Region;
			return true;
		}
	}

	[HarmonyPatch(typeof(GameManager), "LaunchSandbox")]
	internal class GameManagerLaunchSandboxPatch
	{
		internal static void Postfix(GameManager __instance)
		{
			if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Misery)
				return;

			if (RandomSpawnManager.Region == null)
				return;

			if (RandomSpawnManager.SceneSet == null)
				return;

			GameManager.m_StartRegion = RandomSpawnManager.Region;
		}
	}
}
