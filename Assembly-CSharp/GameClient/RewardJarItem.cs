using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015D4 RID: 5588
	internal class RewardJarItem
	{
		// Token: 0x0600DB04 RID: 56068 RVA: 0x00372C94 File Offset: 0x00371094
		public void CreateGo(GameObject parent, EquipRecoveryRewardTable tableData)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/EquipRecovery/EquipRecoveryJar", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, parent, false);
			this.mJarRect = component.GetCom<RectTransform>("JarRect");
			this.mLabel = component.GetCom<Text>("Label");
			this.mCheck = component.GetGameObject("Check");
			this.mEffect = component.GetGameObject("Effect");
			this.mGetReward = component.GetCom<Button>("GetReward");
			this.mBox = component.GetCom<Image>("Box");
			this.mBlue = component.GetGameObject("blue");
			this.mYellow = component.GetGameObject("yellow");
			this.mOpenEffect = component.GetGameObject("OpenEffect");
			this.mRewardIcon = component.GetCom<Image>("RewardIcon");
			int value = this.jarPointNumData.Value;
			this.needScore = tableData.Integral;
			this.jarTableID = tableData.JarID;
			this.mLabel.text = tableData.Integral.ToString();
			this.mGetReward.onClick.RemoveAllListeners();
			this.mGetReward.onClick.AddListener(delegate()
			{
				if (!this.canOpen)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<RewardShow>(FrameLayer.Middle, tableData.ShowID, string.Empty);
				}
				else
				{
					DataManager<EquipRecoveryDataManager>.GetInstance()._OpenRewardJar(tableData.JarID, 1);
				}
			});
			ETCImageLoader.LoadSprite(ref this.mBox, tableData.IconPath, true);
			if (tableData.IconPath2 == "-")
			{
				this.mRewardIcon.CustomActive(false);
			}
			else
			{
				this.mRewardIcon.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.mRewardIcon, tableData.IconPath2, true);
			}
			this.curStatic = DataManager<EquipRecoveryDataManager>.GetInstance()._GetJarState(tableData.ID);
		}

		// Token: 0x0600DB05 RID: 56069 RVA: 0x00372E9C File Offset: 0x0037129C
		public void UpdateRewardJar(int index)
		{
			RewardJarStatic rewardJarStatic = DataManager<EquipRecoveryDataManager>.GetInstance()._GetJarState(index);
			this.mCheck.CustomActive(false);
			this.mYellow.CustomActive(false);
			this.mBlue.CustomActive(false);
			this.canOpen = false;
			if (rewardJarStatic != RewardJarStatic.UnOpen)
			{
				if (rewardJarStatic != RewardJarStatic.CanOpen)
				{
					if (rewardJarStatic == RewardJarStatic.HaveOpen)
					{
						this.mYellow.CustomActive(true);
						this.mCheck.CustomActive(true);
						this.mEffect.CustomActive(false);
					}
				}
				else
				{
					if (this.curStatic != RewardJarStatic.CanOpen)
					{
						this._TryPlayEffect();
					}
					this.mYellow.CustomActive(true);
					this.canOpen = true;
					this.mEffect.CustomActive(true);
				}
			}
			else
			{
				this.mBlue.CustomActive(true);
				this.mEffect.CustomActive(false);
			}
			this.curStatic = rewardJarStatic;
		}

		// Token: 0x0600DB06 RID: 56070 RVA: 0x00372F7D File Offset: 0x0037137D
		private void _TryPlayEffect()
		{
			if (this.mOpenEffect.activeSelf)
			{
				this.mOpenEffect.CustomActive(false);
			}
			this.mOpenEffect.CustomActive(true);
		}

		// Token: 0x0600DB07 RID: 56071 RVA: 0x00372FA7 File Offset: 0x003713A7
		public int GetNeedScore()
		{
			return this.needScore;
		}

		// Token: 0x0600DB08 RID: 56072 RVA: 0x00372FAF File Offset: 0x003713AF
		public int GetJarID()
		{
			return this.jarTableID;
		}

		// Token: 0x040080E6 RID: 32998
		private const string equipRecoverJarPath = "UIFlatten/Prefabs/EquipRecovery/EquipRecoveryJar";

		// Token: 0x040080E7 RID: 32999
		private RectTransform mJarRect;

		// Token: 0x040080E8 RID: 33000
		private Text mLabel;

		// Token: 0x040080E9 RID: 33001
		private GameObject mCheck;

		// Token: 0x040080EA RID: 33002
		private GameObject mEffect;

		// Token: 0x040080EB RID: 33003
		private Button mGetReward;

		// Token: 0x040080EC RID: 33004
		private Image mBox;

		// Token: 0x040080ED RID: 33005
		private int needScore;

		// Token: 0x040080EE RID: 33006
		private int jarTableID;

		// Token: 0x040080EF RID: 33007
		private GameObject mBlue;

		// Token: 0x040080F0 RID: 33008
		private GameObject mYellow;

		// Token: 0x040080F1 RID: 33009
		private GameObject mOpenEffect;

		// Token: 0x040080F2 RID: 33010
		private Image mRewardIcon;

		// Token: 0x040080F3 RID: 33011
		private bool canOpen;

		// Token: 0x040080F4 RID: 33012
		private RewardJarStatic curStatic = RewardJarStatic.UnOpen;

		// Token: 0x040080F5 RID: 33013
		private SystemValueTable jarPointNumData = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(372, string.Empty, string.Empty);
	}
}
