using System;
using System.Collections.Generic;
using GamePool;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AEA RID: 19178
	[AddComponentMenu("UI/Effects/Extensions/BestFit Outline")]
	public class BestFitOutline : Shadow
	{
		// Token: 0x0601BE6A RID: 114282 RVA: 0x0088957D File Offset: 0x0088797D
		protected BestFitOutline()
		{
		}

		// Token: 0x0601BE6B RID: 114283 RVA: 0x00889588 File Offset: 0x00887988
		public override void ModifyMesh(Mesh mesh)
		{
			if (!this.IsActive())
			{
				return;
			}
			List<UIVertex> list = ListPool<UIVertex>.Get();
			using (VertexHelper vertexHelper = new VertexHelper(mesh))
			{
				vertexHelper.GetUIVertexStream(list);
			}
			Text component = base.GetComponent<Text>();
			float num = 1f;
			if (component && component.resizeTextForBestFit)
			{
				num = (float)component.cachedTextGenerator.fontSizeUsedForBestFit / (float)(component.resizeTextMaxSize - 1);
			}
			int num2 = 0;
			int count = list.Count;
			base.ApplyShadowZeroAlloc(list, base.effectColor, num2, list.Count, base.effectDistance.x * num, base.effectDistance.y * num);
			num2 = count;
			count = list.Count;
			base.ApplyShadowZeroAlloc(list, base.effectColor, num2, list.Count, base.effectDistance.x * num, -base.effectDistance.y * num);
			num2 = count;
			count = list.Count;
			base.ApplyShadowZeroAlloc(list, base.effectColor, num2, list.Count, -base.effectDistance.x * num, base.effectDistance.y * num);
			num2 = count;
			count = list.Count;
			base.ApplyShadowZeroAlloc(list, base.effectColor, num2, list.Count, -base.effectDistance.x * num, -base.effectDistance.y * num);
			using (VertexHelper vertexHelper2 = new VertexHelper())
			{
				vertexHelper2.AddUIVertexTriangleStream(list);
				vertexHelper2.FillMesh(mesh);
			}
			ListPool<UIVertex>.Release(list);
		}
	}
}
