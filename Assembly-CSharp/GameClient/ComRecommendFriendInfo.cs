using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F7 RID: 6647
	internal class ComRecommendFriendInfo : MonoBehaviour
	{
		// Token: 0x060104E1 RID: 66785 RVA: 0x00492024 File Offset: 0x00490424
		public void OnAddRecommendFriend()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.value != null && this.btnAdd.enabled)
			{
				this.grayAdd.enabled = true;
				this.btnAdd.enabled = false;
				SceneRequest sceneRequest = new SceneRequest();
				sceneRequest.type = 29;
				sceneRequest.targetName = this.value.name;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
				DataManager<RelationDataManager>.GetInstance().AddQueryInfo(this.value.uid);
			}
		}

		// Token: 0x060104E2 RID: 66786 RVA: 0x004920F8 File Offset: 0x004904F8
		public void OnItemVisible(RelationData friendInfo)
		{
			this.value = null;
			this.value = friendInfo;
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)friendInfo.occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			if (this.jobIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.jobIcon, path, true);
			}
			if (this.roleName != null)
			{
				this.roleName.text = friendInfo.name;
			}
			if (this.roleLv != null)
			{
				this.roleLv.text = friendInfo.level.ToString();
			}
			if ((DataManager<PlayerBaseData>.GetInstance().Level - friendInfo.level >= 0 && DataManager<PlayerBaseData>.GetInstance().Level - friendInfo.level <= 10) || (friendInfo.level - DataManager<PlayerBaseData>.GetInstance().Level >= 0 && friendInfo.level - DataManager<PlayerBaseData>.GetInstance().Level <= 10))
			{
				this.similarLevelText.text = TR.Value("relation_recommend_similarlevel");
				this.similarLevelGo.CustomActive(true);
			}
			else if (friendInfo.level - DataManager<PlayerBaseData>.GetInstance().Level > 10 && friendInfo.level - DataManager<PlayerBaseData>.GetInstance().Level < 30)
			{
				this.similarLevelText.text = TR.Value("relation_recommend_gamerookie");
				this.similarLevelGo.CustomActive(true);
			}
			else if (friendInfo.level - DataManager<PlayerBaseData>.GetInstance().Level >= 30)
			{
				this.similarLevelText.text = TR.Value("relation_recommend_amazingpeople");
				this.similarLevelGo.CustomActive(true);
			}
			else
			{
				this.similarLevelText.text = TR.Value("relation_recommend_noviceplayer");
				this.similarLevelGo.CustomActive(true);
			}
			if (this.replaceHeadPortraitFrame != null)
			{
				if (friendInfo.playerLabelInfo.headFrame != 0U)
				{
					this.replaceHeadPortraitFrame.ReplacePhotoFrame((int)friendInfo.playerLabelInfo.headFrame);
				}
				else
				{
					this.replaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
			this.vipLv.Value = (int)friendInfo.vipLv;
			ETCImageLoader.LoadSprite(ref this.imgFightIcon, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon((int)friendInfo.seasonLv), true);
			ETCImageLoader.LoadSprite(ref this.imgFightLv, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon((int)friendInfo.seasonLv), true);
			this.imgFightLv.SetNativeSize();
			this.fightLv.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)friendInfo.seasonLv, true);
			bool flag = DataManager<RelationDataManager>.GetInstance().CanQuery(friendInfo.uid);
			this.grayAdd.enabled = !flag;
			this.btnAdd.enabled = flag;
		}

		// Token: 0x060104E3 RID: 66787 RVA: 0x004923F4 File Offset: 0x004907F4
		private void Awake()
		{
			if (this.iconBtn != null)
			{
				this.iconBtn.onClick.RemoveAllListeners();
				this.iconBtn.onClick.AddListener(new UnityAction(this.OnIconBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RelationAddRecommendFriendMsgSended, new ClientEventSystem.UIEventHandler(this._OnAddRecommendFriendMsgSended));
		}

		// Token: 0x060104E4 RID: 66788 RVA: 0x00492459 File Offset: 0x00490859
		private void OnIconBtnClick()
		{
			if (this.value != null)
			{
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.value.uid, 0U, 0U);
			}
		}

		// Token: 0x060104E5 RID: 66789 RVA: 0x00492480 File Offset: 0x00490880
		private void _OnAddRecommendFriendMsgSended(UIEvent uiEvent)
		{
			if (this.value != null && (ulong)uiEvent.Param1 == this.value.uid)
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
				if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (this.value != null && this.btnAdd.enabled)
				{
					this.grayAdd.enabled = true;
					this.btnAdd.enabled = false;
				}
			}
		}

		// Token: 0x060104E6 RID: 66790 RVA: 0x00492534 File Offset: 0x00490934
		private void OnDestroy()
		{
			this.value = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RelationAddRecommendFriendMsgSended, new ClientEventSystem.UIEventHandler(this._OnAddRecommendFriendMsgSended));
		}

		// Token: 0x0400A512 RID: 42258
		public Image jobIcon;

		// Token: 0x0400A513 RID: 42259
		public Text roleName;

		// Token: 0x0400A514 RID: 42260
		public Text roleLv;

		// Token: 0x0400A515 RID: 42261
		public UINumber vipLv;

		// Token: 0x0400A516 RID: 42262
		public Image imgFightIcon;

		// Token: 0x0400A517 RID: 42263
		public Image imgFightLv;

		// Token: 0x0400A518 RID: 42264
		public Text fightLv;

		// Token: 0x0400A519 RID: 42265
		public UIGray grayAdd;

		// Token: 0x0400A51A RID: 42266
		public Button btnAdd;

		// Token: 0x0400A51B RID: 42267
		public GameObject similarLevelGo;

		// Token: 0x0400A51C RID: 42268
		public Text similarLevelText;

		// Token: 0x0400A51D RID: 42269
		public ReplaceHeadPortraitFrame replaceHeadPortraitFrame;

		// Token: 0x0400A51E RID: 42270
		public Button iconBtn;

		// Token: 0x0400A51F RID: 42271
		private RelationData value;
	}
}
