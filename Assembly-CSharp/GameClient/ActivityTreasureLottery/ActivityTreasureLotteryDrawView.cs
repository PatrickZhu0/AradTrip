using System;
using DataModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E0 RID: 5088
	public class ActivityTreasureLotteryDrawView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600C547 RID: 50503 RVA: 0x002F8500 File Offset: 0x002F6900
		public void Init(IActivityTreasureLotteryDrawModel model, bool isRandomName = true)
		{
			this.mDelta = 0f;
			this.mShowId = 0;
			this.mModel = model;
			this.InitEffects();
			if (isRandomName)
			{
				this.SetName(0);
				base.InvokeRepeating("UpdateName", this.mAnimtaionRate, this.mAnimtaionRate);
			}
			else
			{
				this.ShowResult();
			}
			if (this.mModel == null)
			{
				Logger.LogError("model is null!");
				return;
			}
			int num = Mathf.Min(this.mShowPlayerRateCount, this.mModel.TopFiveInvestPlayers.Length);
			string format = TR.Value("activity_treasure_lottery_draw_winner_info").Replace("\\n", "\n");
			string text = string.Empty;
			for (int i = 0; i < num; i++)
			{
				text += string.Format(format, new object[]
				{
					i + 1,
					this.mModel.TopFiveInvestPlayers[i].Name,
					this.mModel.TopFiveInvestPlayers[i].Rate,
					this.mModel.TopFiveInvestPlayers[i].PlatformName,
					this.mModel.TopFiveInvestPlayers[i].ServerName
				});
			}
			this.mTextRates.SafeSetText(text);
			if (this.mComItem == null && this.mComItemRoot != null)
			{
				this.mComItem = ComItemManager.Create(this.mComItemRoot.gameObject);
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mModel.ItemId);
			this.mComItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.ShowItemTip));
		}

		// Token: 0x0600C548 RID: 50504 RVA: 0x002F86B4 File Offset: 0x002F6AB4
		public void Dispose()
		{
			base.CancelInvoke();
			this.mTextResult.gameObject.CustomActive(false);
			if (this.mEffectWeiZhongJiang != null)
			{
				this.mEffectWeiZhongJiang.CustomActive(false);
			}
			if (this.mEffectZhongJiang != null)
			{
				this.mEffectZhongJiang.CustomActive(false);
			}
			ComItemManager.Destroy(this.mComItem);
			this.mComItem = null;
		}

		// Token: 0x0600C549 RID: 50505 RVA: 0x002F8724 File Offset: 0x002F6B24
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C54A RID: 50506 RVA: 0x002F873C File Offset: 0x002F6B3C
		private void InitEffects()
		{
			if (this.mEffectChiXu == null)
			{
				this.mEffectChiXu = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mEffectChiXuPrefabPath, true, 0U);
				if (this.mEffectChiXu != null)
				{
					Utility.AttachTo(this.mEffectChiXu, base.gameObject, false);
				}
			}
		}

		// Token: 0x0600C54B RID: 50507 RVA: 0x002F8798 File Offset: 0x002F6B98
		private void UpdateName()
		{
			this.mDelta += this.mAnimtaionRate;
			if (this.mDelta >= this.mAnimationTime)
			{
				base.CancelInvoke("UpdateName");
				this.ShowResult();
			}
			else
			{
				if (this.mModel != null && this.mModel.TopFiveInvestPlayers != null)
				{
					this.mShowId = ((this.mShowId + 1 < this.mModel.TopFiveInvestPlayers.Length) ? (this.mShowId + 1) : 0);
				}
				this.SetName(this.mShowId);
			}
		}

		// Token: 0x0600C54C RID: 50508 RVA: 0x002F8834 File Offset: 0x002F6C34
		private void ShowResult()
		{
			if (this.mModel != null)
			{
				string format = TR.Value("activity_treasure_lottery_draw_rand_text").Replace("\\n", "\n");
				this.mTextName.SafeSetText(string.Format(format, new object[]
				{
					this.mModel.WinnerName,
					this.mModel.WinnerRate,
					this.mModel.PlatformName,
					this.mModel.ServerName
				}));
				if (this.mModel.IsPlayerWin)
				{
					if (this.mEffectZhongJiang == null)
					{
						this.mEffectZhongJiang = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mEffectZhongJiangPrefabPath, true, 0U);
						if (this.mEffectZhongJiang != null)
						{
							Utility.AttachTo(this.mEffectZhongJiang, base.gameObject, false);
						}
					}
					this.mEffectZhongJiang.CustomActive(false);
				}
				else
				{
					if (this.mEffectWeiZhongJiang == null)
					{
						this.mEffectWeiZhongJiang = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.mEffectWeiZhongJiangPrefabPath, true, 0U);
						if (this.mEffectWeiZhongJiang != null)
						{
							Utility.AttachTo(this.mEffectWeiZhongJiang, base.gameObject, false);
						}
					}
					this.mEffectWeiZhongJiang.CustomActive(false);
				}
			}
			InvokeMethod.Invoke(this.mEffectDelay, new UnityAction(this.ShowResultEffect));
		}

		// Token: 0x0600C54D RID: 50509 RVA: 0x002F8994 File Offset: 0x002F6D94
		private void ShowResultEffect()
		{
			if (this.mEffectZhongJiang != null && this.mModel != null)
			{
				if (this.mModel.IsPlayerWin)
				{
					this.mEffectZhongJiang.CustomActive(true);
				}
			}
			else if (this.mEffectWeiZhongJiang != null && this.mModel != null && !this.mModel.IsPlayerWin)
			{
				this.mEffectWeiZhongJiang.CustomActive(true);
			}
		}

		// Token: 0x0600C54E RID: 50510 RVA: 0x002F8A16 File Offset: 0x002F6E16
		private void OnDestroy()
		{
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.ShowResultEffect));
		}

		// Token: 0x0600C54F RID: 50511 RVA: 0x002F8A2C File Offset: 0x002F6E2C
		private void SetName(int id)
		{
			if (this.mModel != null && this.mModel.TopFiveInvestPlayers != null && id >= 0 && id < this.mModel.TopFiveInvestPlayers.Length)
			{
				string format = TR.Value("activity_treasure_lottery_draw_rand_text").Replace("\\n", "\n");
				this.mTextName.SafeSetText(string.Format(format, new object[]
				{
					this.mModel.TopFiveInvestPlayers[id].Name,
					this.mModel.TopFiveInvestPlayers[id].Rate,
					this.mModel.TopFiveInvestPlayers[id].PlatformName,
					this.mModel.TopFiveInvestPlayers[id].ServerName
				}));
			}
		}

		// Token: 0x0400709D RID: 28829
		private GameObject mEffectChiXu;

		// Token: 0x0400709E RID: 28830
		private GameObject mEffectZhongJiang;

		// Token: 0x0400709F RID: 28831
		private GameObject mEffectWeiZhongJiang;

		// Token: 0x040070A0 RID: 28832
		private ComItem mComItem;

		// Token: 0x040070A1 RID: 28833
		[SerializeField]
		private Text mTextName;

		// Token: 0x040070A2 RID: 28834
		[SerializeField]
		private Text mTextResult;

		// Token: 0x040070A3 RID: 28835
		[SerializeField]
		private Text mTextWinner;

		// Token: 0x040070A4 RID: 28836
		[SerializeField]
		private Text mTextRates;

		// Token: 0x040070A5 RID: 28837
		[SerializeField]
		private Transform mComItemRoot;

		// Token: 0x040070A6 RID: 28838
		[SerializeField]
		[Header("控制显示前几名的玩家数据,默认前5")]
		private int mShowPlayerRateCount = 5;

		// Token: 0x040070A7 RID: 28839
		[SerializeField]
		[Header("前几名中奖玩家名字和中奖概率间的总字符数")]
		private int mShowPlayerRateSpacesCount = 14;

		// Token: 0x040070A8 RID: 28840
		[Header("名字随机的变量")]
		[SerializeField]
		[Tooltip("名字随机的时间")]
		private float mAnimationTime = 3f;

		// Token: 0x040070A9 RID: 28841
		[SerializeField]
		[Tooltip("名字随机的频率")]
		private float mAnimtaionRate = 0.02f;

		// Token: 0x040070AA RID: 28842
		[SerializeField]
		[Tooltip("特效播放延迟的时间")]
		private float mEffectDelay = 0.1f;

		// Token: 0x040070AB RID: 28843
		[SerializeField]
		private string mEffectChiXuPrefabPath;

		// Token: 0x040070AC RID: 28844
		[SerializeField]
		private string mEffectZhongJiangPrefabPath;

		// Token: 0x040070AD RID: 28845
		[SerializeField]
		private string mEffectWeiZhongJiangPrefabPath;

		// Token: 0x040070AE RID: 28846
		private IActivityTreasureLotteryDrawModel mModel;

		// Token: 0x040070AF RID: 28847
		private float mDelta;

		// Token: 0x040070B0 RID: 28848
		private int mShowId;
	}
}
