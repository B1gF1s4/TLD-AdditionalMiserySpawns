using Il2CppTLD.Gameplay;
using Il2CppTLD.Scenes;
using MelonLoader;

namespace AdditionalMiserySpawns
{
	public class Mod : MelonMod
	{
		public static RegionSpecification? Region { get; set; }

		public static SceneSet? SceneSet { get; set; }

		public static void RollRandomSpawnLocation()
		{
			Region = SandboxBaseConfig.GetRandomRegionFromAllAvailable();
			SceneSet = SceneSetManager.FindSceneSetForSceneName(Region.name);
		}
	}
}
