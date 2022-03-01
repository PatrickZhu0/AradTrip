using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F4 RID: 5620
	internal class GuildBattleRecordFrame : ClientFrame
	{
		// Token: 0x0600DC3D RID: 56381 RVA: 0x00379F50 File Offset: 0x00378350
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBattleRecord";
		}

		// Token: 0x0600DC3E RID: 56382 RVA: 0x00379F57 File Offset: 0x00378357
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
			this._InitRecords(this.m_togOnlySelf.isOn);
		}

		// Token: 0x0600DC3F RID: 56383 RVA: 0x00379F76 File Offset: 0x00378376
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DC40 RID: 56384 RVA: 0x00379F84 File Offset: 0x00378384
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleRecordSync, new ClientEventSystem.UIEventHandler(this._OnRecordSync));
		}

		// Token: 0x0600DC41 RID: 56385 RVA: 0x00379FA1 File Offset: 0x003783A1
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleRecordSync, new ClientEventSystem.UIEventHandler(this._OnRecordSync));
		}

		// Token: 0x0600DC42 RID: 56386 RVA: 0x00379FC0 File Offset: 0x003783C0
		private void _InitUI()
		{
			this.m_objRecordTemplate.SetActive(false);
			this.m_comSclRecords.startFouce = ComScrollList.EStartFouce.Bottom;
			this.m_comSclRecords.subScrollItemCount = 1;
			this.m_comSclRecords.mainScrollItemCount = 30;
			this.m_comSclRecords.dynamicMainScrollItemCount = 10;
			this.m_comSclRecords.SetTemplate(new GuildBattleRecordFrame.GuildRecordScrollItem(this));
		}

		// Token: 0x0600DC43 RID: 56387 RVA: 0x0037A01C File Offset: 0x0037841C
		private void _ClearUI()
		{
			this.m_comSclRecords.Clear();
		}

		// Token: 0x0600DC44 RID: 56388 RVA: 0x0037A02C File Offset: 0x0037842C
		private void _InitRecords(bool a_bOnlySelf)
		{
			if (a_bOnlySelf)
			{
				this.m_comSclRecords.SetDataRange(0, DataManager<GuildDataManager>.GetInstance().GetSelfBattleRecords().Count - 1);
			}
			else
			{
				this.m_comSclRecords.SetDataRange(0, DataManager<GuildDataManager>.GetInstance().GetBattleRecords().Count - 1);
			}
			this.m_comSclRecords.InitScrollItems();
		}

		// Token: 0x0600DC45 RID: 56389 RVA: 0x0037A089 File Offset: 0x00378489
		private void _ClearRecords()
		{
			this.m_comSclRecords.ClearScrollItems(false);
		}

		// Token: 0x0600DC46 RID: 56390 RVA: 0x0037A098 File Offset: 0x00378498
		private void _UpdateRecords(bool a_bOnlySelf)
		{
			if (a_bOnlySelf)
			{
				this.m_comSclRecords.SetDataRange(0, DataManager<GuildDataManager>.GetInstance().GetSelfBattleRecords().Count - 1);
			}
			else
			{
				this.m_comSclRecords.SetDataRange(0, DataManager<GuildDataManager>.GetInstance().GetBattleRecords().Count - 1);
			}
		}

		// Token: 0x0600DC47 RID: 56391 RVA: 0x0037A0EA File Offset: 0x003784EA
		private void _OnRecordSync(UIEvent a_event)
		{
			this._UpdateRecords(this.m_togOnlySelf.isOn);
		}

		// Token: 0x0600DC48 RID: 56392 RVA: 0x0037A0FD File Offset: 0x003784FD
		[UIEventHandle("Content/OnlySelf", typeof(Toggle), typeof(UnityAction<bool>), 0, 0)]
		private void _OnOnlySelfClicked(bool a_bChecked)
		{
			this._ClearRecords();
			this._InitRecords(a_bChecked);
		}

		// Token: 0x0600DC49 RID: 56393 RVA: 0x0037A10C File Offset: 0x0037850C
		[UIEventHandle("Content/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildBattleRecordFrame>(this, false);
		}

		// Token: 0x040081FC RID: 33276
		[UIObject("Content/Scroll/Viewport/Content")]
		private GameObject m_objRecordRoot;

		// Token: 0x040081FD RID: 33277
		[UIObject("Content/Scroll/Viewport/Text")]
		private GameObject m_objRecordTemplate;

		// Token: 0x040081FE RID: 33278
		[UIControl("Content/OnlySelf", null, 0)]
		private Toggle m_togOnlySelf;

		// Token: 0x040081FF RID: 33279
		[UIControl("Content/Scroll", null, 0)]
		private ComScrollList m_comSclRecords;

		// Token: 0x020015F5 RID: 5621
		private class GuildRecordScrollItem : ScrollItem
		{
			// Token: 0x0600DC4A RID: 56394 RVA: 0x0037A11C File Offset: 0x0037851C
			public GuildRecordScrollItem(GuildBattleRecordFrame a_frame)
			{
				this.m_frame = a_frame;
				this.m_itemTrans = Object.Instantiate<GameObject>(this.m_frame.m_objRecordTemplate).transform;
				this.m_itemTrans.SetParent(this.m_frame.m_objRecordRoot.transform, false);
				this.m_labRecord = this.m_itemTrans.GetComponent<Text>();
			}

			// Token: 0x0600DC4B RID: 56395 RVA: 0x0037A17E File Offset: 0x0037857E
			public override Vector3 GetPosInContent()
			{
				return this.m_itemTrans.GetComponent<RectTransform>().localPosition;
			}

			// Token: 0x0600DC4C RID: 56396 RVA: 0x0037A190 File Offset: 0x00378590
			public override ScrollItem Clone()
			{
				return new GuildBattleRecordFrame.GuildRecordScrollItem(this.m_frame);
			}

			// Token: 0x0600DC4D RID: 56397 RVA: 0x0037A19D File Offset: 0x0037859D
			public override void Destroy()
			{
				Object.Destroy(this.m_itemTrans.gameObject);
				this.m_itemTrans = null;
				this.m_frame = null;
				this.m_labRecord = null;
			}

			// Token: 0x0600DC4E RID: 56398 RVA: 0x0037A1C4 File Offset: 0x003785C4
			public override void SetAsFirstSibling()
			{
				this.m_itemTrans.SetAsFirstSibling();
			}

			// Token: 0x0600DC4F RID: 56399 RVA: 0x0037A1D1 File Offset: 0x003785D1
			public override void SetAsLastSibling()
			{
				this.m_itemTrans.SetAsLastSibling();
			}

			// Token: 0x0600DC50 RID: 56400 RVA: 0x0037A1DE File Offset: 0x003785DE
			public override void SetActive(bool a_bActive)
			{
				if (this.m_itemTrans.gameObject.activeSelf != a_bActive)
				{
					this.m_itemTrans.gameObject.SetActive(a_bActive);
				}
			}

			// Token: 0x0600DC51 RID: 56401 RVA: 0x0037A207 File Offset: 0x00378607
			public override bool IsActive()
			{
				return this.m_itemTrans.gameObject.activeSelf;
			}

			// Token: 0x0600DC52 RID: 56402 RVA: 0x0037A21C File Offset: 0x0037861C
			protected override void _Refresh(int a_nDataID)
			{
				List<GuildBattleRecord> list;
				if (this.m_frame.m_togOnlySelf.isOn)
				{
					list = DataManager<GuildDataManager>.GetInstance().GetSelfBattleRecords();
				}
				else
				{
					list = DataManager<GuildDataManager>.GetInstance().GetBattleRecords();
				}
				if (a_nDataID >= 0 && a_nDataID < list.Count)
				{
					this.m_labRecord.text = this._ParseRecord(list[a_nDataID]);
				}
				else
				{
					this.m_labRecord.text = string.Empty;
				}
				this.m_itemTrans.gameObject.name = a_nDataID.ToString();
			}

			// Token: 0x0600DC53 RID: 56403 RVA: 0x0037A2B8 File Offset: 0x003786B8
			private string GetPlayerNamePrefix(GuildBattleMember member)
			{
				if (member == null)
				{
					return string.Empty;
				}
				if (string.IsNullOrEmpty(member.serverName) && string.IsNullOrEmpty(member.guildName))
				{
					return string.Empty;
				}
				return TR.Value("guild_battle_record_player_name_prefix", TR.Value("color_yellow", member.serverName), TR.Value("color_yellow", member.guildName));
			}

			// Token: 0x0600DC54 RID: 56404 RVA: 0x0037A324 File Offset: 0x00378724
			private string _ParseRecord(GuildBattleRecord a_record)
			{
				string text = string.Empty;
				ulong roleID = DataManager<PlayerBaseData>.GetInstance().RoleID;
				int num = 0;
				string text2;
				if (a_record.winner.id == roleID)
				{
					text2 = TR.Value("color_green", TR.Value("guild_battle_me"));
					num = (int)a_record.winner.gotScore;
				}
				else
				{
					text2 = TR.Value("color_yellow", a_record.winner.name);
					text2 = this.GetPlayerNamePrefix(a_record.winner) + text2;
				}
				string text3;
				if (a_record.loser.id == roleID)
				{
					text3 = TR.Value("color_green", TR.Value("guild_battle_me"));
					num = (int)a_record.loser.gotScore;
				}
				else
				{
					text3 = TR.Value("color_yellow", a_record.loser.name);
					text3 = this.GetPlayerNamePrefix(a_record.loser) + text3;
				}
				if (a_record.winner.winStreak > 1)
				{
					if (a_record.loser.winStreak > 1)
					{
						text = TR.Value("guild_battle_record_format1", text2, text3, a_record.winner.winStreak, a_record.loser.winStreak);
					}
					else
					{
						text = TR.Value("guild_battle_record_format2", text2, text3, a_record.winner.winStreak);
					}
				}
				else if (a_record.loser.winStreak > 1)
				{
					text = TR.Value("guild_battle_record_format3", text2, text3, a_record.loser.winStreak);
				}
				else
				{
					text = TR.Value("guild_battle_record_format4", text2, text3);
				}
				if (num > 0)
				{
					text += TR.Value("guild_battle_record_store", num);
				}
				return text;
			}

			// Token: 0x04008200 RID: 33280
			private GuildBattleRecordFrame m_frame;

			// Token: 0x04008201 RID: 33281
			private Text m_labRecord;

			// Token: 0x04008202 RID: 33282
			private Transform m_itemTrans;
		}
	}
}
