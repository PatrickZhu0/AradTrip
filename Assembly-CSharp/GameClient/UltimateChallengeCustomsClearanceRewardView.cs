using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013B5 RID: 5045
	public class UltimateChallengeCustomsClearanceRewardView : MonoBehaviour
	{
		// Token: 0x0600C3C4 RID: 50116 RVA: 0x002EE8C4 File Offset: 0x002ECCC4
		public void InitView()
		{
			this.itemPrefab.CustomActive(false);
			if (ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas != null)
			{
				for (int i = 0; i < ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas.Count; i++)
				{
					UltimateChallengeCustomsClearanceRewardItemData ultimateChallengeCustomsClearanceRewardItemData = ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas[i];
					if (ultimateChallengeCustomsClearanceRewardItemData != null)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.itemPrefab);
						Utility.AttachTo(gameObject, this.itemParent, false);
						if (gameObject != null)
						{
							gameObject.CustomActive(true);
							UltimateChallengeCustomsClearanceRewardItem component = gameObject.GetComponent<UltimateChallengeCustomsClearanceRewardItem>();
							if (component != null)
							{
								component.OnItemVisiable(ultimateChallengeCustomsClearanceRewardItemData);
							}
						}
					}
				}
			}
		}

		// Token: 0x04006F4A RID: 28490
		[SerializeField]
		private GameObject itemParent;

		// Token: 0x04006F4B RID: 28491
		[SerializeField]
		private GameObject itemPrefab;
	}
}
