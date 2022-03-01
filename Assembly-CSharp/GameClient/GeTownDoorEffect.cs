using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200119C RID: 4508
	public class GeTownDoorEffect : MonoBehaviour
	{
		// Token: 0x0600AC9B RID: 44187 RVA: 0x0025319D File Offset: 0x0025159D
		public void SetDoorOpen(bool a_bOpend)
		{
			if (this.opendEffect != null)
			{
				this.opendEffect.SetActive(a_bOpend);
			}
			if (this.closedEffect != null)
			{
				this.closedEffect.SetActive(!a_bOpend);
			}
		}

		// Token: 0x0600AC9C RID: 44188 RVA: 0x002531DC File Offset: 0x002515DC
		public void Update()
		{
			this.m_fTime -= Time.deltaTime;
			if (this.m_fTime <= 0f)
			{
				this.m_fTime = this.m_fMaxUpdateTime;
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= this.levelLimit)
				{
					if (this.unLockFunctionID == -1)
					{
						this.SetDoorOpen(true);
					}
					else
					{
						FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(this.unLockFunctionID, string.Empty, string.Empty);
						if (tableItem == null)
						{
							this.SetDoorOpen(false);
						}
						if (Utility.IsUnLockArea(tableItem.AreaID))
						{
							this.SetDoorOpen(true);
						}
						else
						{
							this.SetDoorOpen(false);
						}
					}
				}
				else
				{
					this.SetDoorOpen(false);
				}
			}
		}

		// Token: 0x040060C0 RID: 24768
		public GameObject opendEffect;

		// Token: 0x040060C1 RID: 24769
		public GameObject closedEffect;

		// Token: 0x040060C2 RID: 24770
		public int levelLimit = 1;

		// Token: 0x040060C3 RID: 24771
		public int unLockFunctionID = -1;

		// Token: 0x040060C4 RID: 24772
		private float m_fMaxUpdateTime = 0.5f;

		// Token: 0x040060C5 RID: 24773
		private float m_fTime;
	}
}
