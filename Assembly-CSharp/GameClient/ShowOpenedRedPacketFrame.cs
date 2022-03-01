using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019E0 RID: 6624
	internal class ShowOpenedRedPacketFrame : ClientFrame
	{
		// Token: 0x060103C6 RID: 66502 RVA: 0x0048AF08 File Offset: 0x00489308
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RedPack/ShowOpenedRedPack";
		}

		// Token: 0x060103C7 RID: 66503 RVA: 0x0048AF10 File Offset: 0x00489310
		protected override void _OnOpenFrame()
		{
			RedPacketDetail redPacketDetail = this.userData as RedPacketDetail;
			if (redPacketDetail == null)
			{
				Logger.LogErrorFormat("open ShowOpenedRedPacketFrame, userdata is invalid!", new object[0]);
				return;
			}
			this.m_objReceiverTemplate.SetActive(false);
			string getMoneyIcon = DataManager<RedPackDataManager>.GetInstance().GetGetMoneyIcon((int)redPacketDetail.baseEntry.reason);
			string costMoneyIcon = DataManager<RedPackDataManager>.GetInstance().GetCostMoneyIcon((int)redPacketDetail.baseEntry.reason);
			ETCImageLoader.LoadSprite(ref this.m_imgOwnerHead, this._GetHeadByJobID((int)redPacketDetail.ownerIcon.occu), true);
			this.m_labOwnerLevel.text = redPacketDetail.ownerIcon.level.ToString();
			this.m_labOwnerName.text = TR.Value("WhoistheRedPack", redPacketDetail.ownerIcon.name);
			this.m_labRedPacketName.text = redPacketDetail.baseEntry.name;
			this.m_labTotalDesc1.text = TR.Value("guild_redpacket_total_desc1", redPacketDetail.baseEntry.totalNum, redPacketDetail.baseEntry.totalMoney);
			ETCImageLoader.LoadSprite(ref this.m_imgTotalIcon, costMoneyIcon, true);
			int num = (int)redPacketDetail.baseEntry.totalNum - redPacketDetail.receivers.Length;
			if (num > 0)
			{
				this.m_labTotalDesc2.text = TR.Value("guild_redpacket_total_desc2_remain", num);
			}
			else
			{
				this.m_labTotalDesc2.text = TR.Value("guild_redpacket_total_desc2_finish");
			}
			uint num2 = 0U;
			GameObject gameObject = null;
			RedPacketReceiverEntry redPacketReceiverEntry = null;
			for (int i = 0; i < redPacketDetail.receivers.Length; i++)
			{
				RedPacketReceiverEntry redPacketReceiverEntry2 = redPacketDetail.receivers[i];
				if (redPacketReceiverEntry2.icon.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					redPacketReceiverEntry = redPacketReceiverEntry2;
				}
				GameObject gameObject2 = Object.Instantiate<GameObject>(this.m_objReceiverTemplate);
				gameObject2.transform.SetParent(this.m_objReceiverRoot.transform, false);
				gameObject2.SetActive(true);
				Image componetInChild = Utility.GetComponetInChild<Image>(gameObject2, "Head/Viewport/Image");
				ETCImageLoader.LoadSprite(ref componetInChild, this._GetHeadByJobID((int)redPacketReceiverEntry2.icon.occu), true);
				Utility.GetComponetInChild<Text>(gameObject2, "Name").text = redPacketReceiverEntry2.icon.name;
				Utility.GetComponetInChild<Text>(gameObject2, "Count/Text").text = redPacketReceiverEntry2.money.ToString();
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject2, "Count/Icon");
				ETCImageLoader.LoadSprite(ref componetInChild2, getMoneyIcon, true);
				if (redPacketDetail.receivers.Length >= (int)redPacketDetail.baseEntry.totalNum && num2 < redPacketReceiverEntry2.money)
				{
					num2 = redPacketReceiverEntry2.money;
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
					gameObject = Utility.FindGameObject(gameObject2, "Best", true);
					gameObject.SetActive(true);
				}
				else
				{
					Utility.FindGameObject(gameObject2, "Best", true).SetActive(false);
				}
			}
			if (redPacketReceiverEntry != null)
			{
				this.m_labMyGetDesc.text = redPacketReceiverEntry.money.ToString();
				this.m_labAkeyppdDes.text = TR.Value("guild_redpacket_my_get_des", redPacketDetail.ownerIcon.name);
				this.m_imgMyGetIcon.gameObject.SetActive(true);
				this.m_labMyGetDes.gameObject.SetActive(true);
				ETCImageLoader.LoadSprite(ref this.m_imgMyGetIcon, getMoneyIcon, true);
			}
			else
			{
				this.m_labMyGetDesc.text = TR.Value("guild_redpacket_my_get_none");
				this.m_labAkeyppdDes.text = TR.Value("guild_redpacket_my_get_no", redPacketDetail.ownerIcon.name);
				this.m_imgMyGetIcon.gameObject.SetActive(false);
				this.m_labMyGetDes.gameObject.SetActive(false);
			}
			if (redPacketDetail.baseEntry.type == 1)
			{
				base._AddButton("Akeypropaganda/AKeyBtn", new UnityAction(this.AKeyGuildPropaganda));
			}
			else if (redPacketDetail.baseEntry.type == 2)
			{
				base._AddButton("Akeypropaganda/AKeyBtn", new UnityAction(this.AKeyPropaganda));
			}
			if (ShowOpenedRedPacketFrame.showRedPacketMode == ShowRedPacketMode.Show)
			{
				this.Akeypropaganda.CustomActive(false);
				this.Owned.CustomActive(false);
				this.MoveOffset(ref this.Desc, 0, 80);
				GameObject gameObject3 = this.ScrollView.gameObject;
				this.MoveOffset(ref gameObject3, 0, 80);
				this.ScrollView.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(this.ScrollView.gameObject.GetComponent<RectTransform>().sizeDelta.x, 360f);
			}
		}

		// Token: 0x060103C8 RID: 66504 RVA: 0x0048B3A0 File Offset: 0x004897A0
		private void MoveOffset(ref GameObject obj, int ix, int iy)
		{
			if (obj == null)
			{
				return;
			}
			RectTransform component = obj.GetComponent<RectTransform>();
			Vector3 localPosition = default(Vector3);
			localPosition = component.localPosition;
			localPosition.x += (float)ix;
			localPosition.y += (float)iy;
			obj.transform.localPosition = localPosition;
		}

		// Token: 0x060103C9 RID: 66505 RVA: 0x0048B3FF File Offset: 0x004897FF
		protected override void _OnCloseFrame()
		{
			ShowOpenedRedPacketFrame.showRedPacketMode = ShowRedPacketMode.Open;
			this.m_grayAKeyBtn.enabled = false;
			this.isClick = false;
		}

		// Token: 0x060103CA RID: 66506 RVA: 0x0048B41C File Offset: 0x0048981C
		protected override void _bindExUI()
		{
			this.Akeypropaganda = this.mBind.GetGameObject("Akeypropaganda");
			this.Owned = this.mBind.GetGameObject("Owned");
			this.ScrollView = this.mBind.GetCom<ScrollRect>("ScrollView");
			this.Desc = this.mBind.GetGameObject("Desc");
		}

		// Token: 0x060103CB RID: 66507 RVA: 0x0048B481 File Offset: 0x00489881
		protected override void _unbindExUI()
		{
			this.Akeypropaganda = null;
			this.Owned = null;
			this.ScrollView = null;
			this.Desc = null;
		}

		// Token: 0x060103CC RID: 66508 RVA: 0x0048B4A0 File Offset: 0x004898A0
		private string _GetHeadByJobID(int a_nJobID)
		{
			string result = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(a_nJobID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					result = tableItem2.IconPath;
				}
			}
			return result;
		}

		// Token: 0x060103CD RID: 66509 RVA: 0x0048B4F8 File Offset: 0x004898F8
		private void AKeyPropaganda()
		{
			if (this.isClick)
			{
				return;
			}
			string text = this.m_labAkeyppdDes.text;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(172, string.Empty, string.Empty);
			if (tableItem != null && tableItem.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_level"), tableItem.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				return;
			}
			int freeWorldChatLeftTimes = DataManager<ChatManager>.GetInstance().FreeWorldChatLeftTimes;
			if (freeWorldChatLeftTimes <= 0 && !DataManager<ChatManager>.GetInstance().CheckWorldActivityValueEnough())
			{
				SystemNotifyManager.SystemNotify(7006, delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.VIP, string.Empty);
				});
				return;
			}
			if (!ChatManager.world_chat_try_enter_cool_down())
			{
				SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_interval"), ChatManager.world_cool_time), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				return;
			}
			SystemNotifyManager.SysNotifyTextAnimation("发送喊话成功!", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
			DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_WORLD, text, 0UL, 0);
			this.m_grayAKeyBtn.enabled = true;
			this.isClick = true;
		}

		// Token: 0x060103CE RID: 66510 RVA: 0x0048B614 File Offset: 0x00489A14
		private void AKeyGuildPropaganda()
		{
			if (this.isClick)
			{
				return;
			}
			string text = this.m_labAkeyppdDes.text;
			SystemNotifyManager.SysNotifyTextAnimation("发送喊话成功!", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
			DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_GUILD, text, 0UL, 0);
			this.m_grayAKeyBtn.enabled = true;
			this.isClick = true;
		}

		// Token: 0x0400A44A RID: 42058
		[UIControl("Head/Viewport/Image", null, 0)]
		private Image m_imgOwnerHead;

		// Token: 0x0400A44B RID: 42059
		[UIControl("Head/Level", null, 0)]
		private Text m_labOwnerLevel;

		// Token: 0x0400A44C RID: 42060
		[UIControl("Head/Name", null, 0)]
		private Text m_labOwnerName;

		// Token: 0x0400A44D RID: 42061
		[UIControl("RedPackName", null, 0)]
		private Text m_labRedPacketName;

		// Token: 0x0400A44E RID: 42062
		[UIControl("Owned/Group/Text", null, 0)]
		private Text m_labMyGetDesc;

		// Token: 0x0400A44F RID: 42063
		[UIControl("Owned/Group/Des", null, 0)]
		private Text m_labMyGetDes;

		// Token: 0x0400A450 RID: 42064
		[UIControl("Owned/Group/Icon", null, 0)]
		private Image m_imgMyGetIcon;

		// Token: 0x0400A451 RID: 42065
		[UIControl("Desc/Text", null, 0)]
		private Text m_labTotalDesc1;

		// Token: 0x0400A452 RID: 42066
		[UIControl("Desc/Icon", null, 0)]
		private Image m_imgTotalIcon;

		// Token: 0x0400A453 RID: 42067
		[UIControl("Desc/Text2", null, 0)]
		private Text m_labTotalDesc2;

		// Token: 0x0400A454 RID: 42068
		[UIObject("ScrollView/Viewport/Content")]
		private GameObject m_objReceiverRoot;

		// Token: 0x0400A455 RID: 42069
		[UIObject("ScrollView/Viewport/Content/Template")]
		private GameObject m_objReceiverTemplate;

		// Token: 0x0400A456 RID: 42070
		[UIControl("Akeypropaganda/Des", null, 0)]
		private Text m_labAkeyppdDes;

		// Token: 0x0400A457 RID: 42071
		[UIControl("Akeypropaganda/AKeyBtn", null, 0)]
		private UIGray m_grayAKeyBtn;

		// Token: 0x0400A458 RID: 42072
		private bool isClick;

		// Token: 0x0400A459 RID: 42073
		public static ShowRedPacketMode showRedPacketMode;

		// Token: 0x0400A45A RID: 42074
		private GameObject Akeypropaganda;

		// Token: 0x0400A45B RID: 42075
		private GameObject Owned;

		// Token: 0x0400A45C RID: 42076
		private ScrollRect ScrollView;

		// Token: 0x0400A45D RID: 42077
		private GameObject Desc;
	}
}
