using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A37 RID: 18999
	public class SpineAtlasRegion : PropertyAttribute
	{
		// Token: 0x0601B6FB RID: 112379 RVA: 0x008766B8 File Offset: 0x00874AB8
		public SpineAtlasRegion(string atlasAssetField = "")
		{
			this.atlasAssetField = atlasAssetField;
		}

		// Token: 0x040131A2 RID: 78242
		public string atlasAssetField;
	}
}
