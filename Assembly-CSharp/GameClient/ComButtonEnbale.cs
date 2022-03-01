using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E77 RID: 3703
	[AddComponentMenu("UI/Effects/ButtonEnable")]
	public class ComButtonEnbale : MonoBehaviour
	{
		// Token: 0x060092E1 RID: 37601 RVA: 0x001B48C4 File Offset: 0x001B2CC4
		private void OnValidate()
		{
			this._UpdateEnable();
		}

		// Token: 0x060092E2 RID: 37602 RVA: 0x001B48CC File Offset: 0x001B2CCC
		public void SetEnable(bool a_bEnable)
		{
			if (this.bEnable == a_bEnable)
			{
				return;
			}
			this.bEnable = a_bEnable;
			this._UpdateEnable();
		}

		// Token: 0x060092E3 RID: 37603 RVA: 0x001B48E8 File Offset: 0x001B2CE8
		protected void _UpdateEnable()
		{
			Selectable[] componentsInChildren = base.gameObject.GetComponentsInChildren<Selectable>(true);
			if (componentsInChildren != null)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].interactable = this.bEnable;
					ColorBlock colors = componentsInChildren[i].colors;
					colors.disabledColor = Color.white;
					componentsInChildren[i].colors = colors;
				}
			}
			Graphic[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Graphic>(true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				ComModifyColor comModifyColor = componentsInChildren2[j].GetComponent<ComModifyColor>();
				if (comModifyColor == null)
				{
					comModifyColor = componentsInChildren2[j].gameObject.AddComponent<ComModifyColor>();
				}
				comModifyColor.colAddColor = ((!this.bEnable) ? this.m_disableColor : Color.white);
			}
		}

		// Token: 0x040049EA RID: 18922
		private Color m_disableColor = new Color(0.6f, 0.6f, 0.6f, 1f);

		// Token: 0x040049EB RID: 18923
		public bool bEnable = true;
	}
}
