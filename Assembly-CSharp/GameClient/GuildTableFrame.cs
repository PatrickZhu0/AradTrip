using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001663 RID: 5731
	internal class GuildTableFrame : ClientFrame
	{
		// Token: 0x0600E159 RID: 57689 RVA: 0x0039C5AC File Offset: 0x0039A9AC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildTable";
		}

		// Token: 0x0600E15A RID: 57690 RVA: 0x0039C5B4 File Offset: 0x0039A9B4
		protected override void _OnOpenFrame()
		{
			this.m_objGetTemplate.SetActive(false);
			this.m_parCompleteEffect1.StopEmit();
			this.m_parCompleteEffect2.StopEmit();
			for (int i = 0; i < 7; i++)
			{
				GameObject gameObject = Utility.FindGameObject(string.Format("Table/Pos{0}", i), true);
				if (gameObject != null)
				{
					GuildTableFrame.PosInfo posInfo = new GuildTableFrame.PosInfo();
					posInfo.btnJoin = Utility.GetComponetInChild<Button>(gameObject, "Join");
					posInfo.comJoinEnable = Utility.GetComponetInChild<ComButtonEnbale>(gameObject, "Join");
					posInfo.labJoin = Utility.GetComponetInChild<Text>(gameObject, "Join/Text");
					posInfo.imgIcon = Utility.GetComponetInChild<Image>(gameObject, "Icon");
					posInfo.vecIconPos = posInfo.imgIcon.transform.localPosition;
					posInfo.colIconColor = posInfo.imgIcon.color;
					posInfo.dotweens = posInfo.imgIcon.GetComponents<DOTweenAnimation>();
					posInfo.labName = Utility.GetComponetInChild<Text>(gameObject, "Name");
					posInfo.labLevel = Utility.GetComponetInChild<Text>(gameObject, "Level");
					posInfo.objHelp = Utility.FindGameObject(gameObject, "HelpMark", true);
					this.m_arrPosInfos.Add(posInfo);
				}
				else
				{
					this.m_arrPosInfos.Add(null);
				}
			}
			for (int j = 0; j < DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers.Length; j++)
			{
				GuildTableMember a_data = DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers[j];
				this._UpdatePos(j, a_data);
			}
			this._UpdateRemainTimes();
			this._UpdateFirstGetItems();
			this._UpdateHelpGetItems();
			this._UpdateDesc();
			this._RegisterUIEvent();
		}

		// Token: 0x0600E15B RID: 57691 RVA: 0x0039C747 File Offset: 0x0039AB47
		protected override void _OnCloseFrame()
		{
			this.m_arrPosInfos.Clear();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E15C RID: 57692 RVA: 0x0039C75C File Offset: 0x0039AB5C
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildJoinTableSuccess, new ClientEventSystem.UIEventHandler(this._OnGuildJoinTableSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildAddTableMember, new ClientEventSystem.UIEventHandler(this._OnGuildAddTableMember));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRemoveTableMember, new ClientEventSystem.UIEventHandler(this._OnGuildRemoveTableMember));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildTableFinished, new ClientEventSystem.UIEventHandler(this._OnTableFinished));
		}

		// Token: 0x0600E15D RID: 57693 RVA: 0x0039C7F0 File Offset: 0x0039ABF0
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildJoinTableSuccess, new ClientEventSystem.UIEventHandler(this._OnGuildJoinTableSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildAddTableMember, new ClientEventSystem.UIEventHandler(this._OnGuildAddTableMember));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRemoveTableMember, new ClientEventSystem.UIEventHandler(this._OnGuildRemoveTableMember));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildTableFinished, new ClientEventSystem.UIEventHandler(this._OnTableFinished));
		}

		// Token: 0x0600E15E RID: 57694 RVA: 0x0039C884 File Offset: 0x0039AC84
		private void _UpdatePos(int a_nPos, GuildTableMember a_data)
		{
			if (a_nPos >= 0 && a_nPos < this.m_arrPosInfos.Count)
			{
				GuildTableFrame.PosInfo posInfo = this.m_arrPosInfos[a_nPos];
				posInfo.data = a_data;
				posInfo.comJoinEnable.SetEnable(true);
				if (a_data != null)
				{
					posInfo.btnJoin.onClick.RemoveAllListeners();
					posInfo.labJoin.gameObject.SetActive(false);
					string path = string.Empty;
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)a_data.occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							path = tableItem2.IconPath;
						}
					}
					posInfo.imgIcon.gameObject.SetActive(true);
					posInfo.labLevel.gameObject.SetActive(true);
					posInfo.labName.gameObject.SetActive(true);
					ETCImageLoader.LoadSprite(ref posInfo.imgIcon, path, true);
					posInfo.labName.text = a_data.name;
					posInfo.labLevel.text = TR.Value("guild_table_level", a_data.level);
					posInfo.objHelp.SetActive(a_data.type != 0);
				}
				else
				{
					posInfo.btnJoin.onClick.RemoveAllListeners();
					posInfo.btnJoin.onClick.AddListener(delegate()
					{
						DataManager<GuildDataManager>.GetInstance().JoinTable(a_nPos);
					});
					posInfo.labJoin.gameObject.SetActive(true);
					posInfo.imgIcon.gameObject.SetActive(false);
					posInfo.labLevel.gameObject.SetActive(false);
					posInfo.labName.gameObject.SetActive(false);
					posInfo.objHelp.SetActive(false);
				}
			}
		}

		// Token: 0x0600E15F RID: 57695 RVA: 0x0039CA68 File Offset: 0x0039AE68
		private void _UpdateFirstGetItems()
		{
			GuildRoundtableTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildRoundtableTable>(0, string.Empty, string.Empty);
			for (int i = 0; i < tableItem.GetItems.Count; i++)
			{
				string[] array = tableItem.GetItems[i].Split(new char[]
				{
					','
				});
				int a_nID = int.Parse(array[0]);
				int a_nCount = int.Parse(array[1]);
				this._SetupItemUI(a_nID, a_nCount, this.m_objFirstGetItemRoot);
			}
		}

		// Token: 0x0600E160 RID: 57696 RVA: 0x0039CAE8 File Offset: 0x0039AEE8
		private void _UpdateHelpGetItems()
		{
			GuildRoundtableTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildRoundtableTable>(1, string.Empty, string.Empty);
			for (int i = 0; i < tableItem.GetItems.Count; i++)
			{
				string[] array = tableItem.GetItems[i].Split(new char[]
				{
					','
				});
				int a_nID = int.Parse(array[0]);
				int a_nCount = int.Parse(array[1]);
				this._SetupItemUI(a_nID, a_nCount, this.m_objHelpGetItemRoot);
			}
		}

		// Token: 0x0600E161 RID: 57697 RVA: 0x0039CB68 File Offset: 0x0039AF68
		private void _SetupItemUI(int a_nID, int a_nCount, GameObject a_objRoot)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.m_objGetTemplate);
			gameObject.transform.SetParent(a_objRoot.transform, false);
			gameObject.SetActive(true);
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_nID);
			Image componetInChild = Utility.GetComponetInChild<Image>(gameObject, "Icon");
			ETCImageLoader.LoadSprite(ref componetInChild, commonItemTableDataByID.Icon, true);
			Utility.GetComponetInChild<Text>(gameObject, "Count").text = a_nCount.ToString();
		}

		// Token: 0x0600E162 RID: 57698 RVA: 0x0039CBDE File Offset: 0x0039AFDE
		private void _UpdateDesc()
		{
			this.m_labDecs.text = TR.Value("guild_table_desc");
		}

		// Token: 0x0600E163 RID: 57699 RVA: 0x0039CBF8 File Offset: 0x0039AFF8
		private void _UpdateRemainTimes()
		{
			this.m_labFirstRemainTimes.text = TR.Value("guild_table_remain_times", this._GetFirstRemainTimes());
			this.m_labHelpRemainTimes.text = TR.Value("guild_table_remain_times", this._GetHelpRemainTimes());
		}

		// Token: 0x0600E164 RID: 57700 RVA: 0x0039CC48 File Offset: 0x0039B048
		private int _GetFirstRemainTimes()
		{
			int timesLimit = Singleton<TableManager>.GetInstance().GetTableItem<GuildRoundtableTable>(0, string.Empty, string.Empty).TimesLimit;
			int num = timesLimit - DataManager<CountDataManager>.GetInstance().GetCount("guild_table");
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E165 RID: 57701 RVA: 0x0039CC8C File Offset: 0x0039B08C
		private int _GetHelpRemainTimes()
		{
			int timesLimit = Singleton<TableManager>.GetInstance().GetTableItem<GuildRoundtableTable>(1, string.Empty, string.Empty).TimesLimit;
			int num = timesLimit - DataManager<CountDataManager>.GetInstance().GetCount("guild_table_help");
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600E166 RID: 57702 RVA: 0x0039CCD0 File Offset: 0x0039B0D0
		private IEnumerator _ShowTableFinished()
		{
			float startTime = Time.time;
			float elapsed = 0f;
			while (elapsed < 0.5f)
			{
				elapsed = Time.time - startTime;
				yield return Yielders.EndOfFrame;
			}
			for (int i = 0; i < this.m_arrPosInfos.Count; i++)
			{
				GuildTableFrame.PosInfo posInfo = this.m_arrPosInfos[i];
				DOTweenAnimation[] dotweens = posInfo.dotweens;
				for (int j = 0; j < dotweens.Length; j++)
				{
					dotweens[j].DORestart(false);
				}
				posInfo.comJoinEnable.SetEnable(false);
				posInfo.labLevel.gameObject.SetActive(false);
				posInfo.labName.gameObject.SetActive(false);
				posInfo.objHelp.SetActive(false);
			}
			this.m_parCompleteEffect1.StartEmit();
			this.m_parCompleteEffect2.StartEmit();
			float startTime2 = Time.time;
			float elapsed2 = 0f;
			while (elapsed2 < 2f)
			{
				elapsed2 = Time.time - startTime2;
				yield return Yielders.EndOfFrame;
			}
			this.m_parCompleteEffect1.StopEmit();
			this.m_parCompleteEffect2.StopEmit();
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_table_finished"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			float startTime3 = Time.time;
			float elapsed3 = 0f;
			while (elapsed3 < 2f)
			{
				elapsed3 = Time.time - startTime3;
				yield return Yielders.EndOfFrame;
			}
			for (int k = 0; k < this.m_arrPosInfos.Count; k++)
			{
				GuildTableFrame.PosInfo posInfo2 = this.m_arrPosInfos[k];
				posInfo2.comJoinEnable.SetEnable(true);
				posInfo2.imgIcon.transform.localPosition = posInfo2.vecIconPos;
				posInfo2.imgIcon.color = posInfo2.colIconColor;
			}
			for (int l = 0; l < DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers.Length; l++)
			{
				GuildTableMember a_data = DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers[l];
				this._UpdatePos(l, a_data);
			}
			yield break;
		}

		// Token: 0x0600E167 RID: 57703 RVA: 0x0039CCEB File Offset: 0x0039B0EB
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildTableFrame>(this, false);
		}

		// Token: 0x0600E168 RID: 57704 RVA: 0x0039CCFA File Offset: 0x0039B0FA
		private void _OnGuildJoinTableSuccess(UIEvent a_event)
		{
			this._UpdateRemainTimes();
		}

		// Token: 0x0600E169 RID: 57705 RVA: 0x0039CD04 File Offset: 0x0039B104
		private void _OnGuildAddTableMember(UIEvent a_event)
		{
			int num = (int)a_event.Param1;
			if (num >= 0 && num < DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers.Length)
			{
				this._UpdatePos(num, DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers[num]);
			}
		}

		// Token: 0x0600E16A RID: 57706 RVA: 0x0039CD54 File Offset: 0x0039B154
		private void _OnGuildRemoveTableMember(UIEvent a_event)
		{
			int num = (int)a_event.Param1;
			if (num >= 0 && num < DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers.Length)
			{
				this._UpdatePos(num, DataManager<GuildDataManager>.GetInstance().myGuild.arrTableMembers[num]);
			}
		}

		// Token: 0x0600E16B RID: 57707 RVA: 0x0039CDA3 File Offset: 0x0039B1A3
		private void _OnTableFinished(UIEvent a_event)
		{
			base.StartCoroutine(this._ShowTableFinished());
		}

		// Token: 0x0600E16C RID: 57708 RVA: 0x0039CDB2 File Offset: 0x0039B1B2
		[UIEventHandle("SendMessage")]
		private void _OnSendMessageClicked()
		{
			DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_GUILD, TR.Value("guild_table_send_chat"), 0UL, 0);
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_table_send_chat_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x0400861C RID: 34332
		[UIObject("First/Get")]
		private GameObject m_objFirstGetItemRoot;

		// Token: 0x0400861D RID: 34333
		[UIObject("Help/Get")]
		private GameObject m_objHelpGetItemRoot;

		// Token: 0x0400861E RID: 34334
		[UIControl("First/RemainTimes", null, 0)]
		private Text m_labFirstRemainTimes;

		// Token: 0x0400861F RID: 34335
		[UIControl("Help/RemainTimes", null, 0)]
		private Text m_labHelpRemainTimes;

		// Token: 0x04008620 RID: 34336
		[UIControl("Desc/Content", null, 0)]
		private Text m_labDecs;

		// Token: 0x04008621 RID: 34337
		[UIControl("Table/BG/UIEffectParticle", null, 0)]
		private GeUIEffectParticle m_parCompleteEffect1;

		// Token: 0x04008622 RID: 34338
		[UIControl("Table/BG/UIEffectParticle (1)", null, 0)]
		private GeUIEffectParticle m_parCompleteEffect2;

		// Token: 0x04008623 RID: 34339
		[UIObject("ItemTemplate")]
		private GameObject m_objGetTemplate;

		// Token: 0x04008624 RID: 34340
		private List<GuildTableFrame.PosInfo> m_arrPosInfos = new List<GuildTableFrame.PosInfo>();

		// Token: 0x02001664 RID: 5732
		private class PosInfo
		{
			// Token: 0x04008625 RID: 34341
			public GuildTableMember data;

			// Token: 0x04008626 RID: 34342
			public Button btnJoin;

			// Token: 0x04008627 RID: 34343
			public ComButtonEnbale comJoinEnable;

			// Token: 0x04008628 RID: 34344
			public Text labJoin;

			// Token: 0x04008629 RID: 34345
			public Image imgIcon;

			// Token: 0x0400862A RID: 34346
			public Text labName;

			// Token: 0x0400862B RID: 34347
			public Text labLevel;

			// Token: 0x0400862C RID: 34348
			public GameObject objHelp;

			// Token: 0x0400862D RID: 34349
			public Vector3 vecIconPos;

			// Token: 0x0400862E RID: 34350
			public Color colIconColor;

			// Token: 0x0400862F RID: 34351
			public DOTweenAnimation[] dotweens;
		}
	}
}
