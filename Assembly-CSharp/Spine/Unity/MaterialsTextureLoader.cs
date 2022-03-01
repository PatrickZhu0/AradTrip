using System;
using System.IO;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E3 RID: 18915
	public class MaterialsTextureLoader : TextureLoader
	{
		// Token: 0x0601B49B RID: 111771 RVA: 0x0086644F File Offset: 0x0086484F
		public MaterialsTextureLoader(AtlasAsset atlasAsset)
		{
			this.atlasAsset = atlasAsset;
		}

		// Token: 0x0601B49C RID: 111772 RVA: 0x00866460 File Offset: 0x00864860
		public void Load(AtlasPage page, string path)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			Material material = null;
			foreach (Material material2 in this.atlasAsset.materials)
			{
				if (material2.mainTexture == null)
				{
					Debug.LogError("Material is missing texture: " + material2.name, material2);
					return;
				}
				if (material2.mainTexture.name == fileNameWithoutExtension)
				{
					material = material2;
					break;
				}
			}
			if (material == null)
			{
				Debug.LogError("Material with texture name \"" + fileNameWithoutExtension + "\" not found for atlas asset: " + this.atlasAsset.name, this.atlasAsset);
				return;
			}
			page.rendererObject = material;
			if (page.width == 0 || page.height == 0)
			{
				page.width = material.mainTexture.width;
				page.height = material.mainTexture.height;
			}
		}

		// Token: 0x0601B49D RID: 111773 RVA: 0x00866556 File Offset: 0x00864956
		public void Unload(object texture)
		{
		}

		// Token: 0x04013017 RID: 77847
		private AtlasAsset atlasAsset;
	}
}
