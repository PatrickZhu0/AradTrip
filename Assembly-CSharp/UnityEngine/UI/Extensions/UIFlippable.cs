using System;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AF1 RID: 19185
	[RequireComponent(typeof(RectTransform), typeof(Graphic))]
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/Effects/Extensions/Flippable")]
	public class UIFlippable : MonoBehaviour, IMeshModifier
	{
		// Token: 0x170025EA RID: 9706
		// (get) Token: 0x0601BE8A RID: 114314 RVA: 0x0088B515 File Offset: 0x00889915
		// (set) Token: 0x0601BE8B RID: 114315 RVA: 0x0088B51D File Offset: 0x0088991D
		public bool horizontal
		{
			get
			{
				return this.m_Horizontal;
			}
			set
			{
				this.m_Horizontal = value;
			}
		}

		// Token: 0x170025EB RID: 9707
		// (get) Token: 0x0601BE8C RID: 114316 RVA: 0x0088B526 File Offset: 0x00889926
		// (set) Token: 0x0601BE8D RID: 114317 RVA: 0x0088B52E File Offset: 0x0088992E
		public bool vertical
		{
			get
			{
				return this.m_Veritical;
			}
			set
			{
				this.m_Veritical = value;
			}
		}

		// Token: 0x0601BE8E RID: 114318 RVA: 0x0088B537 File Offset: 0x00889937
		protected void OnValidate()
		{
			base.GetComponent<Graphic>().SetVerticesDirty();
		}

		// Token: 0x0601BE8F RID: 114319 RVA: 0x0088B544 File Offset: 0x00889944
		public void ModifyMesh(VertexHelper verts)
		{
			RectTransform rectTransform = base.transform as RectTransform;
			for (int i = 0; i < verts.currentVertCount; i++)
			{
				UIVertex uivertex = default(UIVertex);
				verts.PopulateUIVertex(ref uivertex, i);
				uivertex.position = new Vector3((!this.m_Horizontal) ? uivertex.position.x : (uivertex.position.x + (rectTransform.rect.center.x - uivertex.position.x) * 2f), (!this.m_Veritical) ? uivertex.position.y : (uivertex.position.y + (rectTransform.rect.center.y - uivertex.position.y) * 2f), uivertex.position.z);
				verts.SetUIVertex(uivertex, i);
			}
		}

		// Token: 0x0601BE90 RID: 114320 RVA: 0x0088B64C File Offset: 0x00889A4C
		public void ModifyMesh(Mesh mesh)
		{
		}

		// Token: 0x0401375D RID: 79709
		[SerializeField]
		private bool m_Horizontal;

		// Token: 0x0401375E RID: 79710
		[SerializeField]
		private bool m_Veritical;
	}
}
