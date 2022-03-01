using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200167D RID: 5757
	internal class HornFrame : ClientFrame
	{
		// Token: 0x0600E257 RID: 57943 RVA: 0x003A2419 File Offset: 0x003A0819
		public static void Open()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
			{
				return;
			}
			if (Pk3v3DataManager.HasInPk3v3Room())
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HornFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600E258 RID: 57944 RVA: 0x003A2448 File Offset: 0x003A0848
		public static void OpenLinkFrame(string strParam)
		{
			HornFrame.Open();
		}

		// Token: 0x0600E259 RID: 57945 RVA: 0x003A244F File Offset: 0x003A084F
		private void AddChatText(string content)
		{
			if (!string.IsNullOrEmpty(content))
			{
				InputField inputField = this.inputField;
				inputField.text += content;
			}
		}

		// Token: 0x0600E25A RID: 57946 RVA: 0x003A2474 File Offset: 0x003A0874
		private void _InitEmotionBag()
		{
			this.m_goEmotionTab = Utility.FindChild(this.frame, "EmotionTab");
			this.m_goEmotionTab.CustomActive(false);
			this.m_goEmotionPrefab = Utility.FindChild(this.m_goEmotionTab, "Emotion");
			this.m_goEmotionPrefab.CustomActive(false);
			this.m_spriteAsset = (Singleton<AssetLoader>.instance.LoadRes("UI/Image/Emotion/emotion.asset", typeof(SpriteAsset), true, 0U).obj as SpriteAsset);
			if (this.m_spriteAsset != null && this.m_spriteAsset.listSpriteAssetInfor != null)
			{
				for (int i = 0; i < this.m_spriteAsset.listSpriteAssetInfor.Count; i++)
				{
					SpriteAssetInfor spriteAssetInfor = this.m_spriteAsset.listSpriteAssetInfor[i];
					if (spriteAssetInfor != null)
					{
						this.m_akEmotionObjects.Create(i, new object[]
						{
							this.m_goEmotionTab,
							this.m_goEmotionPrefab,
							spriteAssetInfor,
							this
						});
					}
				}
			}
		}

		// Token: 0x0600E25B RID: 57947 RVA: 0x003A2577 File Offset: 0x003A0977
		private void _UnInitEmotionBag()
		{
			this.m_akEmotionObjects.DestroyAllObjects();
			this.m_spriteAsset = null;
			this.m_goEmotionPrefab = null;
			this.m_goEmotionTab = null;
		}

		// Token: 0x0600E25C RID: 57948 RVA: 0x003A259C File Offset: 0x003A099C
		protected override void _OnOpenFrame()
		{
			this._InitEmotionBag();
			this.inputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleChanged));
			this.OnValueChanged(HornFrame.ms_lastContent);
			this.inputField.text = HornFrame.ms_lastContent;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(211, string.Empty, string.Empty);
			this.hornCombHint.text = TR.Value("horn_comb_time", tableItem.Value);
			this._UpdateUIData();
		}

		// Token: 0x0600E25D RID: 57949 RVA: 0x003A2644 File Offset: 0x003A0A44
		protected override void _OnCloseFrame()
		{
			this.inputField.onValueChanged.RemoveListener(new UnityAction<string>(this.OnValueChanged));
			this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleChanged));
			this._UnInitEmotionBag();
			this.OnCloseWaitData();
		}

		// Token: 0x0600E25E RID: 57950 RVA: 0x003A2695 File Offset: 0x003A0A95
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/HornFrame/HornFrame";
		}

		// Token: 0x0600E25F RID: 57951 RVA: 0x003A269C File Offset: 0x003A0A9C
		private void _UpdateUIData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(209, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int value = tableItem.Value;
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(value, true);
				int num = (!this.toggle.isOn) ? 1 : 10;
				this.hornCount.text = ((ownedItemCount < num) ? string.Format("<color=#ff0000>{0}/{1}</color>", ownedItemCount, num) : string.Format("<color=#ffffff>{0}/{1}</color>", ownedItemCount, num));
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(value, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ETCImageLoader.LoadSprite(ref this.hornIcon, tableItem2.Icon, true);
				}
			}
		}

		// Token: 0x0600E260 RID: 57952 RVA: 0x003A276C File Offset: 0x003A0B6C
		public void OnValueChanged(string content)
		{
			int num = this._GetMaxContentLength();
			content = content.Replace("\r\n", string.Empty);
			if (num < content.Length)
			{
				content = content.Substring(0, num);
			}
			if (!string.Equals(content, this.inputField.text))
			{
				this.inputField.text = content;
				return;
			}
			int length = content.Length;
			this.conentCount.text = ((length > num) ? string.Format("<color=#ff0000>{0}/{1}</color>", length, num) : string.Format("<color=#ffffff>{0}/{1}</color>", length, num));
			if (HornFrame.ms_lastContent != content)
			{
				HornFrame.ms_lastContent = content;
			}
		}

		// Token: 0x0600E261 RID: 57953 RVA: 0x003A282B File Offset: 0x003A0C2B
		public void OnToggleChanged(bool bValue)
		{
			this._UpdateUIData();
		}

		// Token: 0x0600E262 RID: 57954 RVA: 0x003A2834 File Offset: 0x003A0C34
		private int _GetMaxContentLength()
		{
			int num = 60;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(208, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			return num / 2;
		}

		// Token: 0x0600E263 RID: 57955 RVA: 0x003A286E File Offset: 0x003A0C6E
		[UIEventHandle("Shopbg/tittlebg1/close")]
		private void _OnClickClose()
		{
			base.Close(false);
		}

		// Token: 0x0600E264 RID: 57956 RVA: 0x003A2878 File Offset: 0x003A0C78
		[UIEventHandle("Send")]
		private void _OnClickSendMsg()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
			{
				return;
			}
			if (Pk3v3DataManager.HasInPk3v3Room())
			{
				return;
			}
			if (string.IsNullOrEmpty(this.inputField.text))
			{
				SystemNotifyManager.SystemNotify(7015, string.Empty);
				return;
			}
			string sendContent = this.inputField.text;
			int num = this._GetMaxContentLength();
			if (num < sendContent.Length)
			{
				SystemNotifyManager.SystemNotify(7017, string.Empty);
				return;
			}
			sendContent = ChatFrame.GetFliterSizeString(sendContent);
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(209, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find horn id from systemValue table!", new object[0]);
				return;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem.Value, true);
			int num2 = (!this.toggle.isOn) ? 1 : 10;
			if (ownedItemCount >= num2)
			{
				this._OnSend(sendContent);
				return;
			}
			ItemComeLink.OnLink(tableItem.Value, num2 - ownedItemCount, true, delegate
			{
				this._OnSend(sendContent);
			}, false, false, false, null, string.Empty);
		}

		// Token: 0x0600E265 RID: 57957 RVA: 0x003A29B4 File Offset: 0x003A0DB4
		private void _OnSend(string content)
		{
			if (content == null)
			{
				return;
			}
			if (this._mCurWaitData != null)
			{
				Logger.LogErrorFormat("IWaitData is not null!!!", new object[0]);
				return;
			}
			SceneChatHornReq sceneChatHornReq = new SceneChatHornReq();
			if (sceneChatHornReq == null)
			{
				return;
			}
			sceneChatHornReq.content = content;
			if (this.toggle != null)
			{
				sceneChatHornReq.num = ((!this.toggle.isOn) ? 1 : 10);
			}
			NetManager.Instance().SendCommand<SceneChatHornReq>(ServerType.GATE_SERVER, sceneChatHornReq);
			this._mCurWaitData = DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneChatHornRes>(delegate(SceneChatHornRes msgRet)
			{
				this._mCurWaitData = null;
				if (msgRet.result != 0U)
				{
					if (msgRet.result != 2800004U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
				}
				else
				{
					SystemNotifyManager.SystemNotify(7016, string.Empty);
				}
				this._UpdateUIData();
				base.Close(false);
			}, true, 15f, new Action(this.OnCloseWaitData));
		}

		// Token: 0x0600E266 RID: 57958 RVA: 0x003A2A62 File Offset: 0x003A0E62
		private void OnCloseWaitData()
		{
			if (this._mCurWaitData != null)
			{
				DataManager<WaitNetMessageManager>.GetInstance().CancelWait(this._mCurWaitData);
				this._mCurWaitData = null;
			}
		}

		// Token: 0x0600E267 RID: 57959 RVA: 0x003A2A86 File Offset: 0x003A0E86
		[UIEventHandle("Emotion")]
		private void OnClickEmotionBag()
		{
			this.m_goEmotionTab.SetActive(!this.m_goEmotionTab.activeSelf);
		}

		// Token: 0x0400876D RID: 34669
		public static string ms_lastContent = string.Empty;

		// Token: 0x0400876E RID: 34670
		private GameObject m_goEmotionTab;

		// Token: 0x0400876F RID: 34671
		private GameObject m_goEmotionPrefab;

		// Token: 0x04008770 RID: 34672
		private SpriteAsset m_spriteAsset;

		// Token: 0x04008771 RID: 34673
		private CachedObjectDicManager<int, HornFrame.EmotionObject> m_akEmotionObjects = new CachedObjectDicManager<int, HornFrame.EmotionObject>();

		// Token: 0x04008772 RID: 34674
		private WaitNetMessageManager.IWaitData _mCurWaitData;

		// Token: 0x04008773 RID: 34675
		[UIControl("Toggle", typeof(Toggle), 0)]
		private Toggle toggle;

		// Token: 0x04008774 RID: 34676
		[UIControl("Icon/HorCount", typeof(Text), 0)]
		private Text hornCount;

		// Token: 0x04008775 RID: 34677
		[UIControl("Icon", typeof(Image), 0)]
		private Image hornIcon;

		// Token: 0x04008776 RID: 34678
		[UIControl("Emotion/Process", typeof(Text), 0)]
		private Text conentCount;

		// Token: 0x04008777 RID: 34679
		[UIControl("InputField", typeof(InputField), 0)]
		private InputField inputField;

		// Token: 0x04008778 RID: 34680
		[UIControl("Toggle/Hint", typeof(Text), 0)]
		private Text hornCombHint;

		// Token: 0x0200167E RID: 5758
		public class EmotionObject : CachedObject
		{
			// Token: 0x0600E26B RID: 57963 RVA: 0x003A2B18 File Offset: 0x003A0F18
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.spriteAssetInfo = (param[2] as SpriteAssetInfor);
				this.THIS = (param[3] as HornFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.emotion = this.goLocal.GetComponent<Image>();
					this.button = this.goLocal.GetComponent<Button>();
					this.button.onClick.RemoveAllListeners();
					this.button.onClick.AddListener(new UnityAction(this.OnClickEmotion));
				}
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600E26C RID: 57964 RVA: 0x003A2BEB File Offset: 0x003A0FEB
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600E26D RID: 57965 RVA: 0x003A2BF3 File Offset: 0x003A0FF3
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600E26E RID: 57966 RVA: 0x003A2C12 File Offset: 0x003A1012
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600E26F RID: 57967 RVA: 0x003A2C31 File Offset: 0x003A1031
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600E270 RID: 57968 RVA: 0x003A2C3A File Offset: 0x003A103A
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600E271 RID: 57969 RVA: 0x003A2C43 File Offset: 0x003A1043
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600E272 RID: 57970 RVA: 0x003A2C46 File Offset: 0x003A1046
			private void _UpdateItem()
			{
				this.emotion.sprite = this.spriteAssetInfo.sprite;
			}

			// Token: 0x0600E273 RID: 57971 RVA: 0x003A2C5E File Offset: 0x003A105E
			private void OnClickEmotion()
			{
				this.THIS.AddChatText("{F " + string.Format("{0}", this.spriteAssetInfo.ID) + "}");
			}

			// Token: 0x04008779 RID: 34681
			protected GameObject goLocal;

			// Token: 0x0400877A RID: 34682
			protected GameObject goParent;

			// Token: 0x0400877B RID: 34683
			protected GameObject goPrefab;

			// Token: 0x0400877C RID: 34684
			protected SpriteAssetInfor spriteAssetInfo;

			// Token: 0x0400877D RID: 34685
			protected HornFrame THIS;

			// Token: 0x0400877E RID: 34686
			private Image emotion;

			// Token: 0x0400877F RID: 34687
			private Button button;
		}
	}
}
