using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using Il2CppTLD.Scenes;

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

			var sets = InitSceneSets();
			var sceneSet = sets[rand.Next(0, sets.Count - 1)];

			if (sceneSet == null)
				return true;

			__instance.m_ForceSceneLoad = sceneSet;

			return true;
		}

		private static List<SceneSet> InitSceneSets()
		{
			var sets = new List<SceneSet>();

			AddSceneSetToSets("RiverValleyRegion", ref sets);
			AddSceneSetToSets("RuralRegion", ref sets);
			AddSceneSetToSets("AshCanyonRegion", ref sets);
			AddSceneSetToSets("CanneryRegion", ref sets);
			AddSceneSetToSets("CoastalRegion", ref sets);
			AddSceneSetToSets("CrashMountainRegion", ref sets);
			AddSceneSetToSets("LakeRegion", ref sets);
			AddSceneSetToSets("MarshRegion", ref sets);
			AddSceneSetToSets("MountainTownRegion", ref sets);
			AddSceneSetToSets("TracksRegion", ref sets);

			return sets;
		}

		private static void AddSceneSetToSets(string sceneName, ref List<SceneSet> sets)
		{
			var set = SceneSetManager.FindSceneSetForSceneName(sceneName);
			if (set != null)
				sets.Add(set);
		}
	}
}
