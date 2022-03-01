using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001AD7 RID: 6871
	public class ComEffectLoader : MonoBehaviour
	{
		// Token: 0x06010DDE RID: 69086 RVA: 0x004D01B0 File Offset: 0x004CE5B0
		public GameObject LoadEffect(int iIndex)
		{
			if (this.mPoolsObject == null)
			{
				this.mPoolsObject = new GameObject[this.mEffectPools.Length];
			}
			if (iIndex >= 0 && iIndex < this.mPoolsObject.Length)
			{
				if (null == this.mPoolsObject[iIndex])
				{
					this.mPoolsObject[iIndex] = (Singleton<AssetLoader>.instance.LoadRes(this.mEffectPools[iIndex], typeof(GameObject), true, 0U).obj as GameObject);
					if (iIndex >= 0 && iIndex < this.mParents.Length)
					{
						Utility.AttachTo(this.mPoolsObject[iIndex], this.mParents[iIndex], false);
					}
				}
				return this.mPoolsObject[iIndex];
			}
			return null;
		}

		// Token: 0x06010DDF RID: 69087 RVA: 0x004D0268 File Offset: 0x004CE668
		public void ActiveEffect(int iIndex)
		{
			if (this.mPoolsObject != null && iIndex >= 0 && iIndex < this.mPoolsObject.Length)
			{
				this.mPoolsObject[iIndex].CustomActive(true);
			}
		}

		// Token: 0x06010DE0 RID: 69088 RVA: 0x004D0298 File Offset: 0x004CE698
		public void DeActiveEffect(int iIndex)
		{
			if (this.mPoolsObject != null && iIndex >= 0 && iIndex < this.mPoolsObject.Length)
			{
				this.mPoolsObject[iIndex].CustomActive(false);
			}
		}

		// Token: 0x06010DE1 RID: 69089 RVA: 0x004D02C8 File Offset: 0x004CE6C8
		public void SetEffectPosition(int iIndex, Vector3 worldPos)
		{
			if (this.mPoolsObject != null && iIndex >= 0 && iIndex < this.mPoolsObject.Length && null != this.mPoolsObject[iIndex])
			{
				this.mPoolsObject[iIndex].transform.position = worldPos;
			}
		}

		// Token: 0x06010DE2 RID: 69090 RVA: 0x004D031C File Offset: 0x004CE71C
		private void OnDestroy()
		{
			if (this.mPoolsObject != null)
			{
				for (int i = 0; i < this.mPoolsObject.Length; i++)
				{
					if (null != this.mPoolsObject[i])
					{
						Object.Destroy(this.mPoolsObject[i]);
						this.mPoolsObject[i] = null;
					}
				}
			}
		}

		// Token: 0x0400AD32 RID: 44338
		public string[] mEffectPools = new string[0];

		// Token: 0x0400AD33 RID: 44339
		public GameObject[] mParents = new GameObject[0];

		// Token: 0x0400AD34 RID: 44340
		private GameObject[] mPoolsObject;
	}
}
