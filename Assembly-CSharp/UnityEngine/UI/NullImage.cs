using System;

namespace UnityEngine.UI
{
	// Token: 0x020001FB RID: 507
	[AddComponentMenu("UI/NullImage", 12)]
	public class NullImage : MaskableGraphic
	{
		// Token: 0x06001034 RID: 4148 RVA: 0x00054B07 File Offset: 0x00052F07
		protected NullImage()
		{
			base.useLegacyMeshGeneration = false;
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x00054B16 File Offset: 0x00052F16
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			toFill.Clear();
		}
	}
}
