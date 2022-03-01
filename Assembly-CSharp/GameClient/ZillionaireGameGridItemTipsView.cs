using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001938 RID: 6456
	public class ZillionaireGameGridItemTipsView : MonoBehaviour
	{
		// Token: 0x0600FB03 RID: 64259 RVA: 0x0044C388 File Offset: 0x0044A788
		public void InitView(MapGridItemData mapGridItemData)
		{
			this.mapGridItemData = mapGridItemData;
			if (this.mapGridItemData == null)
			{
				return;
			}
			if (this.mapGridItemData.gridType == 4 || this.mapGridItemData.gridType == 10 || this.mapGridItemData.gridType == 11 || this.mapGridItemData.gridType == 3 || this.mapGridItemData.gridType == 5 || this.mapGridItemData.gridType == 2)
			{
				this.rectTransformBg.offsetMin = new Vector2(this.rectTransformBg.offsetMin.x, -20f);
			}
			this.stopFrameCoroutine();
			this.coroutine = base.StartCoroutine(this.StartFrameCoroutine());
		}

		// Token: 0x0600FB04 RID: 64260 RVA: 0x0044C450 File Offset: 0x0044A850
		private void stopFrameCoroutine()
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
				this.coroutine = null;
			}
		}

		// Token: 0x0600FB05 RID: 64261 RVA: 0x0044C470 File Offset: 0x0044A870
		private IEnumerator StartFrameCoroutine()
		{
			this.OnSetCanvasGroupAlpha(0);
			this.InitInfo();
			this.InitReward();
			this.InitDungeonReward();
			yield return Yielders.GetWaitForSeconds(this.time);
			this.SetPosition();
			this.OnSetCanvasGroupAlpha(1);
			yield break;
		}

		// Token: 0x0600FB06 RID: 64262 RVA: 0x0044C48C File Offset: 0x0044A88C
		private void InitInfo()
		{
			if (this.itemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemIcon, this.mapGridItemData.gridIconPath, true);
			}
			if (this.name != null)
			{
				this.name.text = this.mapGridItemData.gridName;
			}
			if (this.desc != null)
			{
				this.desc.text = this.mapGridItemData.gridDesc;
			}
			if (this.itemCount != null)
			{
				if (this.mapGridItemData.gridType == 6 || this.mapGridItemData.gridType == 7 || this.mapGridItemData.gridType == 8 || this.mapGridItemData.gridType == 9)
				{
					this.itemCount.text = string.Format("x{0}", this.mapGridItemData.itemCount);
				}
				else
				{
					this.itemCount.text = string.Empty;
				}
			}
		}

		// Token: 0x0600FB07 RID: 64263 RVA: 0x0044C5A0 File Offset: 0x0044A9A0
		private void InitReward()
		{
			if (this.mapGridItemData.gridType == 4 || this.mapGridItemData.gridType == 10 || this.mapGridItemData.gridType == 11 || this.mapGridItemData.gridType == 3 || this.mapGridItemData.gridType == 2)
			{
				for (int i = 0; i < this.mapGridItemData.rewardList.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.mapGridItemData.rewardList[i];
					if (itemSimpleData != null)
					{
						CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.rewardContent);
						if (commonNewItem != null)
						{
							commonNewItem.InitItem(itemSimpleData.ItemID, itemSimpleData.Count);
							commonNewItem.SetItemCountFontSize(28);
						}
					}
				}
			}
		}

		// Token: 0x0600FB08 RID: 64264 RVA: 0x0044C674 File Offset: 0x0044AA74
		private void InitDungeonReward()
		{
			if (this.mapGridItemData.gridType == 5)
			{
				this.dungeonDescRoot.CustomActive(true);
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/ZillionaireGame/DungeonRewardItem", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				if (gameObject.GetComponent<ZillionaireGameDungeonRewardItem>() == null)
				{
					Object.Destroy(gameObject);
					return;
				}
				for (int i = 0; i < this.mapGridItemData.rewardList.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.mapGridItemData.rewardList[i];
					this.AddZillionaireGameDungeonRewardItem(gameObject, itemSimpleData);
				}
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600FB09 RID: 64265 RVA: 0x0044C718 File Offset: 0x0044AB18
		private void AddZillionaireGameDungeonRewardItem(GameObject gameObject, ItemSimpleData itemSimpleData)
		{
			GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
			Utility.AttachTo(gameObject2, this.dungeonRewardContent, false);
			ZillionaireGameDungeonRewardItem component = gameObject2.GetComponent<ZillionaireGameDungeonRewardItem>();
			if (component != null)
			{
				component.OnItemVisiable(itemSimpleData);
			}
		}

		// Token: 0x0600FB0A RID: 64266 RVA: 0x0044C754 File Offset: 0x0044AB54
		private void SetPosition()
		{
			if (this.contentRectTransform != null)
			{
				Utility.SetPopMenuPosition(this.contentRectTransform.gameObject, new Vector2(10f, 50f), default(Vector2));
			}
		}

		// Token: 0x0600FB0B RID: 64267 RVA: 0x0044C79A File Offset: 0x0044AB9A
		private void OnSetCanvasGroupAlpha(int alpha)
		{
			if (this.canvasGroup != null)
			{
				this.canvasGroup.alpha = (float)alpha;
			}
		}

		// Token: 0x0600FB0C RID: 64268 RVA: 0x0044C7BA File Offset: 0x0044ABBA
		private void OnDestroy()
		{
			this.stopFrameCoroutine();
			this.mapGridItemData = null;
		}

		// Token: 0x04009CD5 RID: 40149
		[SerializeField]
		private RectTransform rectTransformBg;

		// Token: 0x04009CD6 RID: 40150
		[SerializeField]
		private RectTransform contentRectTransform;

		// Token: 0x04009CD7 RID: 40151
		[SerializeField]
		private Image itemIcon;

		// Token: 0x04009CD8 RID: 40152
		[SerializeField]
		private Text name;

		// Token: 0x04009CD9 RID: 40153
		[SerializeField]
		private Text desc;

		// Token: 0x04009CDA RID: 40154
		[SerializeField]
		private Text itemCount;

		// Token: 0x04009CDB RID: 40155
		[SerializeField]
		private GameObject rewardContent;

		// Token: 0x04009CDC RID: 40156
		[SerializeField]
		private GameObject dungeonRewardContent;

		// Token: 0x04009CDD RID: 40157
		[SerializeField]
		private GameObject dungeonDescRoot;

		// Token: 0x04009CDE RID: 40158
		[SerializeField]
		private CanvasGroup canvasGroup;

		// Token: 0x04009CDF RID: 40159
		[Header("延迟显示界面时间")]
		[SerializeField]
		private float time = 0.4f;

		// Token: 0x04009CE0 RID: 40160
		private MapGridItemData mapGridItemData;

		// Token: 0x04009CE1 RID: 40161
		private Coroutine coroutine;
	}
}
