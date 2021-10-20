using Terraria.ModLoader;

namespace BiomeEssences
{
	public class BiomeEssences : Mod
	{
        internal static ModHotKey EssenceEffectKey;

        public override void Load()
        {
            EssenceEffectKey = RegisterHotKey("Essence Effect", "Y");
        }

        public override void Unload()
        {
            EssenceEffectKey = null;
        }
    }
}