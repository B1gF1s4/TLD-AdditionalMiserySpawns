using Il2CppTLD.Gameplay;
using Il2CppTLD.Scenes;

namespace ModTemplate
{
	public static class RandomSpawnManager
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
