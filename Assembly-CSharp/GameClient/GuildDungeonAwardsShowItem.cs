using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001610 RID: 5648
	public class GuildDungeonAwardsShowItem : MonoBehaviour
	{
		// Token: 0x0600DD68 RID: 56680 RVA: 0x00381E94 File Offset: 0x00380294
		private void Start()
		{
		}

		// Token: 0x0600DD69 RID: 56681 RVA: 0x00381E96 File Offset: 0x00380296
		private void OnDestroy()
		{
		}

		// Token: 0x0600DD6A RID: 56682 RVA: 0x00381E98 File Offset: 0x00380298
		private void Update()
		{
		}

		// Token: 0x0600DD6B RID: 56683 RVA: 0x00381E9C File Offset: 0x0038029C
		public Vector2 GetContentSize(List<AwardItemData> items)
		{
			Vector2 result = default(Vector2);
			if (items == null)
			{
				return result;
			}
			if (this.awardDesc != null)
			{
				result.y += this.awardDesc.gameObject.GetComponent<RectTransform>().rect.height;
			}
			if (this.itemsParent != null)
			{
				GridLayoutGroup component = this.itemsParent.GetComponent<GridLayoutGroup>();
				if (component != null)
				{
					int num;
					if (items.Count % component.constraintCount == 0)
					{
						num = items.Count / component.constraintCount;
					}
					else
					{
						num = items.Count / component.constraintCount + 1;
					}
					result.y += component.cellSize.y * (float)num + ((num <= 0) ? 0f : (component.spacing.y * (float)(num - 1)));
				}
			}
			result.x = base.gameObject.GetComponent<RectTransform>().rect.width;
			Rect rect = base.gameObject.GetComponent<RectTransform>().rect;
			Vector2 sizeDelta = base.gameObject.GetComponent<RectTransform>().sizeDelta;
			return result;
		}

		// Token: 0x0600DD6C RID: 56684 RVA: 0x00381FE0 File Offset: 0x003803E0
		public void SetUp(ClientFrame frame, GuildDungeonAwardsShowItem.AwardType awardType, List<AwardItemData> items)
		{
			if (awardType >= GuildDungeonAwardsShowItem.AwardType.TypeMax || items == null)
			{
				return;
			}
			if (this.txtDescs == null)
			{
				return;
			}
			if (awardType < (GuildDungeonAwardsShowItem.AwardType)this.txtDescs.Length && awardType >= GuildDungeonAwardsShowItem.AwardType.Kill3ShiTu)
			{
				if (this.awardDesc != null)
				{
					this.awardDesc.text = this.txtDescs[(int)awardType];
				}
				if (this.itemsParent != null && this.payAwardItem != null)
				{
					for (int i = 0; i < this.itemsParent.transform.childCount; i++)
					{
						GameObject gameObject = this.itemsParent.transform.GetChild(i).gameObject;
						Object.Destroy(gameObject);
					}
					for (int j = 0; j < items.Count; j++)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(items[j].ID, 100, 0);
						if (itemData != null)
						{
							itemData.Count = items[j].Num;
							GameObject gameObject2 = Object.Instantiate<GameObject>(this.payAwardItem.gameObject);
							Utility.AttachTo(gameObject2, this.itemsParent, false);
							gameObject2.CustomActive(true);
							PayRewardItem component = gameObject2.GetComponent<PayRewardItem>();
							if (component != null)
							{
								component.Initialize(frame, itemData, true, false);
								component.RefreshView(true, true);
							}
						}
					}
				}
			}
		}

		// Token: 0x040082FD RID: 33533
		[SerializeField]
		private GameObject payAwardItem;

		// Token: 0x040082FE RID: 33534
		[SerializeField]
		private GameObject itemsParent;

		// Token: 0x040082FF RID: 33535
		[SerializeField]
		private Text awardDesc;

		// Token: 0x04008300 RID: 33536
		private string[] txtDescs = new string[]
		{
			TR.Value("kill3ShiTu"),
			TR.Value("notKillBoss")
		};

		// Token: 0x02001611 RID: 5649
		public enum AwardType
		{
			// Token: 0x04008302 RID: 33538
			Kill3ShiTu,
			// Token: 0x04008303 RID: 33539
			NotKillBigBoss,
			// Token: 0x04008304 RID: 33540
			TypeMax
		}
	}
}
