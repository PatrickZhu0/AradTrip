using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200004F RID: 79
	internal class ComPetTipsUnit : MonoBehaviour
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x00010008 File Offset: 0x0000E408
		private void _OnCreate(ComPetTipsUnitData data, GameObject goLocal)
		{
			if (null != goLocal)
			{
				ComPetTipsUnitType eComPetTipsUnitType = data.eComPetTipsUnitType;
				if (eComPetTipsUnitType == ComPetTipsUnitType.CPTUT_TITLE || eComPetTipsUnitType == ComPetTipsUnitType.CPTUT_CONTENT)
				{
					Text[] componentsInChildren = goLocal.GetComponentsInChildren<Text>();
					if (componentsInChildren != null && componentsInChildren.Length > 0)
					{
						componentsInChildren[0].text = data.content;
					}
				}
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00010064 File Offset: 0x0000E464
		private GameObject _allocateFromPoos(ComPetTipsUnitType eComPetTipsUnitType)
		{
			if (eComPetTipsUnitType >= ComPetTipsUnitType.CPTUT_SPERATE_LINE && eComPetTipsUnitType < (ComPetTipsUnitType)this.pools.Length && this.pools[(int)eComPetTipsUnitType].Count > 0)
			{
				GameObject gameObject = this.pools[(int)eComPetTipsUnitType][0];
				this.pools[(int)eComPetTipsUnitType].RemoveAt(0);
				this.actives[(int)eComPetTipsUnitType].Add(gameObject);
				return gameObject;
			}
			return null;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000100CC File Offset: 0x0000E4CC
		public void setTips(List<ComPetTipsUnitData> datas)
		{
			this._recycleTips();
			this.goSperateLine.CustomActive(false);
			this.goContent.CustomActive(false);
			this.goTitle.CustomActive(false);
			for (int i = 0; i < datas.Count; i++)
			{
				if (datas[i] != null && datas[i].eComPetTipsUnitType != ComPetTipsUnitType.CPTUT_COUNT)
				{
					GameObject gameObject = this._allocateFromPoos(datas[i].eComPetTipsUnitType);
					if (null == gameObject)
					{
						GameObject gameObject2 = null;
						ComPetTipsUnitType eComPetTipsUnitType = datas[i].eComPetTipsUnitType;
						if (eComPetTipsUnitType != ComPetTipsUnitType.CPTUT_CONTENT)
						{
							if (eComPetTipsUnitType != ComPetTipsUnitType.CPTUT_SPERATE_LINE)
							{
								if (eComPetTipsUnitType == ComPetTipsUnitType.CPTUT_TITLE)
								{
									gameObject2 = this.goTitle;
								}
							}
							else
							{
								gameObject2 = this.goSperateLine;
							}
						}
						else
						{
							gameObject2 = this.goContent;
						}
						if (null == gameObject2)
						{
							goto IL_138;
						}
						gameObject = Object.Instantiate<GameObject>(gameObject2);
						if (null != gameObject)
						{
							this.actives[(int)datas[i].eComPetTipsUnitType].Add(gameObject);
						}
					}
					if (null != gameObject)
					{
						Utility.AttachTo(gameObject, this.goParent, false);
						this._OnCreate(datas[i], gameObject);
						gameObject.CustomActive(true);
						gameObject.transform.SetSiblingIndex(i + 3);
					}
				}
				IL_138:;
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00010224 File Offset: 0x0000E624
		private void _recycleTips()
		{
			for (int i = 0; i < this.actives.Length; i++)
			{
				for (int j = 0; j < this.actives[i].Count; j++)
				{
					this.actives[i][j].CustomActive(false);
					this.pools[i].Add(this.actives[i][j]);
				}
				this.actives[i].Clear();
			}
		}

		// Token: 0x040001CB RID: 459
		public GameObject goSperateLine;

		// Token: 0x040001CC RID: 460
		public GameObject goTitle;

		// Token: 0x040001CD RID: 461
		public GameObject goContent;

		// Token: 0x040001CE RID: 462
		public GameObject goParent;

		// Token: 0x040001CF RID: 463
		private List<GameObject>[] pools = new List<GameObject>[]
		{
			new List<GameObject>(),
			new List<GameObject>(),
			new List<GameObject>()
		};

		// Token: 0x040001D0 RID: 464
		private List<GameObject>[] actives = new List<GameObject>[]
		{
			new List<GameObject>(),
			new List<GameObject>(),
			new List<GameObject>()
		};
	}
}
