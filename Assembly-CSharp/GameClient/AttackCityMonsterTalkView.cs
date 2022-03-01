using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001446 RID: 5190
	public class AttackCityMonsterTalkView : MonoBehaviour
	{
		// Token: 0x0600C94C RID: 51532 RVA: 0x0030F130 File Offset: 0x0030D530
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600C94D RID: 51533 RVA: 0x0030F138 File Offset: 0x0030D538
		private void BindUiEventSystem()
		{
			if (this.monsterBeatButton != null)
			{
				this.monsterBeatButton.onClick.AddListener(new UnityAction(this.OnMonsterBeatClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.rewardItemList != null)
			{
				ComUIListScript comUIListScript = this.rewardItemList;
				comUIListScript.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnRewardItemSelected));
				ComUIListScript comUIListScript2 = this.rewardItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SyncAttackCityMonsterUpdate, new ClientEventSystem.UIEventHandler(this.OnSyncSceneNpcUpdate));
		}

		// Token: 0x0600C94E RID: 51534 RVA: 0x0030F21C File Offset: 0x0030D61C
		public void InitData(ulong npcGuid)
		{
			AttackCityMonsterTalkView.StopBeatAttackCityMonster();
			this._monsterGuid = npcGuid;
			this._monsterInfo = DataManager<AttackCityMonsterDataManager>.GetInstance().GetSceneNpcByNpcGuid(this._monsterGuid);
			if (this._monsterInfo == null)
			{
				return;
			}
			this._monsterId = (int)this._monsterInfo.id;
			this._npcItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this._monsterId, string.Empty, string.Empty);
			this.InitTalkViewInfo();
			this.InitHardLevelInfo();
			this.InitRewardItemList();
		}

		// Token: 0x0600C94F RID: 51535 RVA: 0x0030F29C File Offset: 0x0030D69C
		private void InitTalkViewInfo()
		{
			if (this._npcItem == null)
			{
				return;
			}
			if (this.monsterImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.monsterImage, this._npcItem.NpcBody, true);
				this.monsterImage.SetNativeSize();
			}
			if (this.monsterName != null)
			{
				this.monsterName.text = this._npcItem.NpcName.Replace("[UserName]", DataManager<PlayerBaseData>.GetInstance().Name);
			}
			this._talkTable = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(this._npcItem.FunctionIntParam2, string.Empty, string.Empty);
			this.UpdateMonsterTalkContent();
			this.beatLimitLabel.text = TR.Value("monster_attack_beat_limit_label");
			this.monsterLimit.text = string.Format(TR.Value("monster_attack_city_limit"), DataManager<AttackCityMonsterDataManager>.GetInstance().GetLeftBeatTimes(), DataManager<AttackCityMonsterDataManager>.GetInstance()._attackCityMonsterTotalTimes);
			this.closeButtonText.text = TR.Value("monster_attack_city_not_beat");
			this.monsterBeatText.text = TR.Value("monster_attack_city_beat");
			if (this._monsterInfo.funcType == 2)
			{
				this.monsterLimit.gameObject.CustomActive(false);
				this.beatLimitLabel.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600C950 RID: 51536 RVA: 0x0030F3FC File Offset: 0x0030D7FC
		private void InitHardLevelInfo()
		{
			if (this.hardLevelText != null)
			{
				this.hardLevelText.text = TR.Value("monster_attack_city_hard_level");
			}
			if (this.starList == null || this.starList.Count <= 0)
			{
				return;
			}
			if (this._npcItem == null)
			{
				return;
			}
			int hard = this._npcItem.Hard;
			if (hard <= 0)
			{
				return;
			}
			for (int i = 0; i < this.starList.Count; i++)
			{
				if (i < hard)
				{
					this.starList[i].transform.gameObject.CustomActive(true);
				}
				else
				{
					this.starList[i].transform.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600C951 RID: 51537 RVA: 0x0030F4CC File Offset: 0x0030D8CC
		private void InitRewardItemList()
		{
			if (this.dropItemsText != null)
			{
				this.dropItemsText.text = TR.Value("monster_attack_city_drop_items");
			}
			if (this.rewardItemList == null)
			{
				return;
			}
			int dungeonId = (int)this._monsterInfo.dungeonId;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null || tableItem.DropItems.Count <= 0)
			{
				return;
			}
			if (this._rewardDataModelList == null)
			{
				this._rewardDataModelList = new List<RewardItemDataModel>();
			}
			this._rewardDataModelList.Clear();
			for (int i = 0; i < tableItem.DropItems.Count; i++)
			{
				int id = tableItem.DropItems[i];
				RewardItemDataModel item = new RewardItemDataModel
				{
					Id = id,
					Number = 1
				};
				this._rewardDataModelList.Add(item);
			}
			if (this._rewardDataModelList == null || this._rewardDataModelList.Count <= 0)
			{
				this.rewardItemList.transform.gameObject.CustomActive(false);
				return;
			}
			this.rewardItemList.transform.gameObject.CustomActive(true);
			this.rewardItemList.Initialize();
			this.rewardItemList.SetElementAmount(this._rewardDataModelList.Count);
		}

		// Token: 0x0600C952 RID: 51538 RVA: 0x0030F628 File Offset: 0x0030DA28
		private void UnBindUiEventSystem()
		{
			if (this.monsterBeatButton != null)
			{
				this.monsterBeatButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.rewardItemList != null)
			{
				ComUIListScript comUIListScript = this.rewardItemList;
				comUIListScript.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnRewardItemSelected));
				ComUIListScript comUIListScript2 = this.rewardItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SyncAttackCityMonsterUpdate, new ClientEventSystem.UIEventHandler(this.OnSyncSceneNpcUpdate));
		}

		// Token: 0x0600C953 RID: 51539 RVA: 0x0030F6F1 File Offset: 0x0030DAF1
		private void OnDestroy()
		{
			this.ClearData();
			this._monsterInfo = null;
			this._npcItem = null;
			this._talkTable = null;
			this.UnBindUiEventSystem();
			DataManager<AttackCityMonsterDataManager>.GetInstance().ResetOpenTalkFrameType();
		}

		// Token: 0x0600C954 RID: 51540 RVA: 0x0030F71E File Offset: 0x0030DB1E
		private void ClearData()
		{
			if (this._rewardDataModelList != null)
			{
				this._rewardDataModelList.Clear();
				this._rewardDataModelList = null;
			}
		}

		// Token: 0x0600C955 RID: 51541 RVA: 0x0030F73D File Offset: 0x0030DB3D
		private void OnMonsterBeatClick()
		{
			this.OnMonsterBeat();
			this.OnCloseFrame();
		}

		// Token: 0x0600C956 RID: 51542 RVA: 0x0030F74C File Offset: 0x0030DB4C
		private void OnMonsterBeat()
		{
			if (DataManager<PlayerBaseData>.GetInstance().Level < 25)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_level_not_satisfied"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._monsterInfo != null && this._monsterInfo.funcType == 1)
			{
				Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
				if (myTeam == null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_no_army"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_not_be_captain"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				for (int i = 0; i < (int)myTeam.currentMemberCount; i++)
				{
					if (i < myTeam.members.Length)
					{
						if (myTeam.members[i].avatarInfo != null && myTeam.members[i].id != 0UL && myTeam.members[i].level < 25)
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_team_member_level_not_satisfied"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
					}
				}
			}
			bool flag = DataManager<SkillDataManager>.GetInstance().IsShowSkillTreeFrameTipBySkillConfig(new Action(this.OnEnterGame));
			if (flag)
			{
				return;
			}
			AttackCityMonsterTalkView.StartBeatAttackCityMonster(this._monsterGuid);
		}

		// Token: 0x0600C957 RID: 51543 RVA: 0x0030F87B File Offset: 0x0030DC7B
		private void OnEnterGame()
		{
			AttackCityMonsterTalkView.StartBeatAttackCityMonster(this._monsterGuid);
		}

		// Token: 0x0600C958 RID: 51544 RVA: 0x0030F888 File Offset: 0x0030DC88
		private void OnRewardItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this._rewardDataModelList.Count)
			{
				return;
			}
			RewardItemDataModel rewardItemDataModel = this._rewardDataModelList[index];
			if (rewardItemDataModel == null)
			{
				return;
			}
			AttackCityMonsterRewardItem component = item.GetComponent<AttackCityMonsterRewardItem>();
			if (component == null)
			{
				return;
			}
			component.InitData(rewardItemDataModel);
		}

		// Token: 0x0600C959 RID: 51545 RVA: 0x0030F8F1 File Offset: 0x0030DCF1
		private void OnRewardItemSelected(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
		}

		// Token: 0x0600C95A RID: 51546 RVA: 0x0030F900 File Offset: 0x0030DD00
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AttackCityMonsterTalkFrame>(null, false);
		}

		// Token: 0x0600C95B RID: 51547 RVA: 0x0030F90E File Offset: 0x0030DD0E
		private void OnSyncSceneNpcUpdate(UIEvent uiEvent)
		{
			this._monsterInfo = DataManager<AttackCityMonsterDataManager>.GetInstance().GetSceneNpcByNpcGuid(this._monsterGuid);
			if (this._monsterInfo == null)
			{
				return;
			}
			this.UpdateMonsterTalkContent();
		}

		// Token: 0x0600C95C RID: 51548 RVA: 0x0030F938 File Offset: 0x0030DD38
		private void UpdateMonsterTalkContent()
		{
			if (this._talkTable == null)
			{
				return;
			}
			string format = this._talkTable.TalkText.Replace("[UserName]", DataManager<PlayerBaseData>.GetInstance().Name);
			int totalTimes = (int)this._monsterInfo.totalTimes;
			int remainTimes = (int)this._monsterInfo.remainTimes;
			this.monsterTalkContent.text = string.Format(format, remainTimes, totalTimes);
		}

		// Token: 0x0600C95D RID: 51549 RVA: 0x0030F9A6 File Offset: 0x0030DDA6
		private static void StartBeatAttackCityMonster(ulong guid)
		{
			AttackCityMonsterTalkView._beatAttackCityMonsterCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(AttackCityMonsterTalkView.StartBeatAttackCityMonsterCoroutine(guid));
		}

		// Token: 0x0600C95E RID: 51550 RVA: 0x0030F9BD File Offset: 0x0030DDBD
		private static void StopBeatAttackCityMonster()
		{
			if (AttackCityMonsterTalkView._beatAttackCityMonsterCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(AttackCityMonsterTalkView._beatAttackCityMonsterCoroutine);
				AttackCityMonsterTalkView._beatAttackCityMonsterCoroutine = null;
			}
			AttackCityMonsterTalkView._isSendMessage = false;
		}

		// Token: 0x0600C95F RID: 51551 RVA: 0x0030F9E4 File Offset: 0x0030DDE4
		private static IEnumerator StartBeatAttackCityMonsterCoroutine(ulong guid)
		{
			if (!AttackCityMonsterTalkView._isSendMessage)
			{
				SceneDungeonStartReq req = new SceneDungeonStartReq
				{
					cityMonsterId = guid
				};
				MessageEvents msg = new MessageEvents();
				SceneDungeonStartRes res = new SceneDungeonStartRes();
				AttackCityMonsterTalkView._isSendMessage = true;
				yield return MessageUtility.Wait<SceneDungeonStartReq, SceneDungeonStartRes>(ServerType.GATE_SERVER, msg, req, res, true, 10f);
				AttackCityMonsterTalkView._isSendMessage = false;
			}
			yield break;
		}

		// Token: 0x0400742A RID: 29738
		[SerializeField]
		private Text monsterName;

		// Token: 0x0400742B RID: 29739
		[SerializeField]
		private Text monsterTalkContent;

		// Token: 0x0400742C RID: 29740
		[SerializeField]
		private Text monsterLimit;

		// Token: 0x0400742D RID: 29741
		[SerializeField]
		private Text closeButtonText;

		// Token: 0x0400742E RID: 29742
		[SerializeField]
		private Text monsterBeatText;

		// Token: 0x0400742F RID: 29743
		[SerializeField]
		private Text hardLevelText;

		// Token: 0x04007430 RID: 29744
		[SerializeField]
		private Text dropItemsText;

		// Token: 0x04007431 RID: 29745
		[SerializeField]
		private Text beatLimitLabel;

		// Token: 0x04007432 RID: 29746
		[SerializeField]
		private Image monsterImage;

		// Token: 0x04007433 RID: 29747
		[SerializeField]
		private Button monsterBeatButton;

		// Token: 0x04007434 RID: 29748
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007435 RID: 29749
		[SerializeField]
		private ComUIListScript rewardItemList;

		// Token: 0x04007436 RID: 29750
		[SerializeField]
		private List<GameObject> starList;

		// Token: 0x04007437 RID: 29751
		private ulong _monsterGuid;

		// Token: 0x04007438 RID: 29752
		private int _monsterId = -1;

		// Token: 0x04007439 RID: 29753
		private SceneNpc _monsterInfo;

		// Token: 0x0400743A RID: 29754
		private NpcTable _npcItem;

		// Token: 0x0400743B RID: 29755
		private TalkTable _talkTable;

		// Token: 0x0400743C RID: 29756
		private const string UserNameStr = "[UserName]";

		// Token: 0x0400743D RID: 29757
		private static Coroutine _beatAttackCityMonsterCoroutine;

		// Token: 0x0400743E RID: 29758
		private static bool _isSendMessage;

		// Token: 0x0400743F RID: 29759
		private List<RewardItemDataModel> _rewardDataModelList;
	}
}
