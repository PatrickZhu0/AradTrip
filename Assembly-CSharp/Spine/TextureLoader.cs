using System;

namespace Spine
{
	// Token: 0x020049AD RID: 18861
	public interface TextureLoader
	{
		// Token: 0x0601B1A6 RID: 111014
		void Load(AtlasPage page, string path);

		// Token: 0x0601B1A7 RID: 111015
		void Unload(object texture);
	}
}
