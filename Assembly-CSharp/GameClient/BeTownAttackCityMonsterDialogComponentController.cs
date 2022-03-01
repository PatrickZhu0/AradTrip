using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001189 RID: 4489
	public class BeTownAttackCityMonsterDialogComponentController : MonoBehaviour
	{
		// Token: 0x0600ABE2 RID: 44002 RVA: 0x0024EE94 File Offset: 0x0024D294
		public void InitController(int npcId)
		{
			this._npcId = npcId;
			this._npcItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this._npcId, string.Empty, string.Empty);
			if (this._npcItem != null)
			{
				this._appearInterval = (float)this._npcItem.Interval * 1f / 1000f;
				this._disappearInterval = 25f + Random.Range(0f, 10f) - 5f;
			}
			this._lastInterval = 0f;
			this._periodTime = this._appearInterval + this._disappearInterval;
		}

		// Token: 0x0600ABE3 RID: 44003 RVA: 0x0024EF30 File Offset: 0x0024D330
		public void OnUpdate(float timeElapsed)
		{
			if (this._appearInterval <= 0f)
			{
				return;
			}
			this._lastInterval += timeElapsed;
			if (this._lastInterval >= 0f && this._lastInterval <= this._appearInterval)
			{
				base.transform.gameObject.CustomActive(true);
			}
			else if (this._lastInterval > this._appearInterval && this._lastInterval <= this._periodTime)
			{
				base.transform.gameObject.CustomActive(false);
			}
			else
			{
				this._lastInterval = 0f;
				this._disappearInterval = 25f + Random.Range(0f, 10f) - 5f;
				this._periodTime = this._appearInterval + this._disappearInterval;
			}
		}

		// Token: 0x0600ABE4 RID: 44004 RVA: 0x0024F00A File Offset: 0x0024D40A
		private void OnDestroy()
		{
			this._npcId = -1;
			this._npcItem = null;
			this._appearInterval = -1f;
		}

		// Token: 0x04006060 RID: 24672
		private int _npcId = -1;

		// Token: 0x04006061 RID: 24673
		private NpcTable _npcItem;

		// Token: 0x04006062 RID: 24674
		private const float DisappearInterval = 25f;

		// Token: 0x04006063 RID: 24675
		private float _disappearInterval;

		// Token: 0x04006064 RID: 24676
		private float _appearInterval = -1f;

		// Token: 0x04006065 RID: 24677
		private float _lastInterval;

		// Token: 0x04006066 RID: 24678
		private float _periodTime;
	}
}
