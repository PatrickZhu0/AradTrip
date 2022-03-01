using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018D7 RID: 6359
	public class BossKillItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F848 RID: 63560 RVA: 0x00436C9C File Offset: 0x0043509C
		public void Init(int id, BossKillMonsterModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mId = id;
			this.UpdateData(data);
			this._InitDropItems();
			this.mOnItemClick = onItemClick;
			this.mButtonGoChallenge.SafeAddOnClickListener(new UnityAction(this._OnButtonGoChallengeClick));
		}

		// Token: 0x0600F849 RID: 63561 RVA: 0x00436CD0 File Offset: 0x004350D0
		public void UpdateData(BossKillMonsterModel data)
		{
			this.mData = data;
			this.mTextTitle.SafeSetText(string.Format(TR.Value("activity_boss_kill_item_title"), data.Name));
			this.mTextTimeZone.CustomActive(true);
			if (data.MonsterType == MonsterType.Boss_Pos && data.IsActive)
			{
				this.mTextTimeZone.SafeSetText(Function.GetTime((int)data.StartTime, (int)data.EndTime));
			}
			else if (data.MonsterType == MonsterType.Elite_Pos || data.MonsterType == MonsterType.Monster_Pos)
			{
				this.mTextTimeZone.SafeSetText(TR.Value("activity_boss_kill_item_can_challenge_all_day"));
			}
			else
			{
				this.mTextTimeZone.CustomActive(false);
			}
			if (data.RemainNum == 4294967295U || (data.MonsterType == MonsterType.Boss_Pos && !data.IsActive))
			{
				this.mTextRemainCout.CustomActive(false);
			}
			else
			{
				this.mTextRemainCout.CustomActive(true);
				this.mTextRemainCout.SafeSetText(string.Format(TR.Value("activity_boss_kill_item_remain_count"), data.RemainNum));
			}
			if (data.MonsterType == MonsterType.Boss_Pos)
			{
				if (!data.IsActive)
				{
					this.mRefreshTime.CustomActive(true);
					this.mButtonGoChallenge.CustomActive(false);
				}
				else if (data.RemainNum == 0U)
				{
					this.mRefreshTime.CustomActive(true);
					this.mButtonGoChallenge.CustomActive(false);
				}
				else
				{
					this.mRefreshTime.CustomActive(false);
					this.mButtonGoChallenge.CustomActive(true);
				}
			}
			else if (data.MonsterType == MonsterType.Elite_Pos || data.MonsterType == MonsterType.Monster_Pos)
			{
				this.mRefreshTime.CustomActive(false);
				this.mButtonGoChallenge.CustomActive(true);
			}
		}

		// Token: 0x0600F84A RID: 63562 RVA: 0x00436EA4 File Offset: 0x004352A4
		public void Destroy()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F84B RID: 63563 RVA: 0x00436EB8 File Offset: 0x004352B8
		public void Dispose()
		{
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
			this.mOnItemClick = null;
			this.mButtonGoChallenge.SafeRemoveOnClickListener(new UnityAction(this._OnButtonGoChallengeClick));
		}

		// Token: 0x0600F84C RID: 63564 RVA: 0x00436F28 File Offset: 0x00435328
		private void Update()
		{
			if (this.mData.NextRollStartTime > 0U)
			{
				this.mTextRefreshTime.SafeSetText(string.Format(TR.Value("activity_boss_kill_item_refresh_time"), Function.SetShowTime((int)this.mData.NextRollStartTime)));
			}
			else
			{
				this.mTextRefreshTime.SafeSetText(TR.Value("activity_boss_kill_item_activity_end"));
			}
		}

		// Token: 0x0600F84D RID: 63565 RVA: 0x00436F8C File Offset: 0x0043538C
		private void _InitDropItems()
		{
			if (this.mData.DropList == null)
			{
				return;
			}
			for (int i = 0; i < this.mData.DropList.Length; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mDropItemRoot.gameObject);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.mData.DropList[i].itemId, 100, 0);
					if (itemData != null)
					{
						itemData.Count = (int)this.mData.DropList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (BossKillItem.<>f__mg$cache0 == null)
						{
							BossKillItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, BossKillItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
			}
		}

		// Token: 0x0600F84E RID: 63566 RVA: 0x00437069 File Offset: 0x00435469
		private void _OnButtonGoChallengeClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mId, 0, 0UL);
			}
		}

		// Token: 0x04009964 RID: 39268
		[SerializeField]
		private Text mTextTitle;

		// Token: 0x04009965 RID: 39269
		[SerializeField]
		private Text mTextRemainCout;

		// Token: 0x04009966 RID: 39270
		[SerializeField]
		private Text mTextTimeZone;

		// Token: 0x04009967 RID: 39271
		[SerializeField]
		private RectTransform mDropItemRoot;

		// Token: 0x04009968 RID: 39272
		[SerializeField]
		private Button mButtonGoChallenge;

		// Token: 0x04009969 RID: 39273
		[SerializeField]
		private GameObject mRefreshTime;

		// Token: 0x0400996A RID: 39274
		[SerializeField]
		private Text mTextRefreshTime;

		// Token: 0x0400996B RID: 39275
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x0400996C RID: 39276
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x0400996D RID: 39277
		private BossKillMonsterModel mData;

		// Token: 0x0400996E RID: 39278
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400996F RID: 39279
		private int mId;

		// Token: 0x04009970 RID: 39280
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
