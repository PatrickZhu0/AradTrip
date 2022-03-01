using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A02 RID: 6658
	internal class RelationFrameNew : ClientFrame
	{
		// Token: 0x0601056C RID: 66924 RVA: 0x00495BED File Offset: 0x00493FED
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as RelationFrameData);
			if (this.data == null)
			{
				this.data = new RelationFrameData();
			}
			this._InitFilters();
			this._RegisterUIEvent();
		}

		// Token: 0x0601056D RID: 66925 RVA: 0x00495C22 File Offset: 0x00494022
		protected override void _OnCloseFrame()
		{
			this._CloseChildrenFrames();
			this._UnInitFilters();
			this._UnRegisterUIEvent();
			this.data = null;
		}

		// Token: 0x0601056E RID: 66926 RVA: 0x00495C3D File Offset: 0x0049403D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/RelationFrame";
		}

		// Token: 0x0601056F RID: 66927 RVA: 0x00495C44 File Offset: 0x00494044
		public static void CommandOpen(RelationFrameData data = null)
		{
			if (data == null)
			{
				data = new RelationFrameData();
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RelationFrameNew>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x06010570 RID: 66928 RVA: 0x00495C68 File Offset: 0x00494068
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				RelationFrameNew.CommandOpen(new RelationFrameData
				{
					eRelationOptionType = (RelationOptionType)int.Parse(strParam)
				});
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat(ex.ToString(), new object[0]);
			}
		}

		// Token: 0x06010571 RID: 66929 RVA: 0x00495CBC File Offset: 0x004940BC
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPStartTalk, new ClientEventSystem.UIEventHandler(this._OnTAPStartTalk));
		}

		// Token: 0x06010572 RID: 66930 RVA: 0x00495CD9 File Offset: 0x004940D9
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPStartTalk, new ClientEventSystem.UIEventHandler(this._OnTAPStartTalk));
		}

		// Token: 0x06010573 RID: 66931 RVA: 0x00495CF8 File Offset: 0x004940F8
		private void _OnTAPStartTalk(UIEvent iEvent)
		{
			string mTalk = string.Empty;
			this.data = (iEvent.Param1 as RelationFrameData);
			if (iEvent.Param2 != null)
			{
				mTalk = (iEvent.Param2 as string);
			}
			RelationOptionData optionData = new RelationOptionData();
			optionData.eRelationOptionType = this.data.eRelationOptionType;
			optionData.eRelationTabType = this.data.eRelationTabType;
			optionData.eCurrentRelationData = this.data.eCurrentRelationData;
			optionData.mTalk = mTalk;
			RelationOption relationOption = this.m_akFilters.ActiveObjects.Find((RelationOption x) => x.Value.eRelationOptionType == optionData.eRelationOptionType);
			if (relationOption != null)
			{
				relationOption.OnRefresh(new object[]
				{
					optionData
				});
				relationOption.OnSelected();
			}
			optionData.eCurrentRelationData = null;
			optionData.mTalk = string.Empty;
		}

		// Token: 0x06010574 RID: 66932 RVA: 0x00495DEC File Offset: 0x004941EC
		private void _InitFilters()
		{
			this.goFilter.CustomActive(false);
			for (int i = 0; i < 2; i++)
			{
				this.m_akFilters.Create(new object[]
				{
					this.goFilterParent,
					this.goFilter,
					new RelationOptionData
					{
						eRelationOptionType = (RelationOptionType)i,
						eRelationTabType = this.data.eRelationTabType,
						eCurrentRelationData = this.data.eCurrentRelationData
					},
					Delegate.CreateDelegate(typeof(CachedSelectedObject<RelationOptionData, RelationOption>.OnSelectedDelegate), this, "OnSelectedDelegate"),
					false
				});
			}
			RelationOption relationOption = this.m_akFilters.ActiveObjects.Find((RelationOption x) => x.Value.eRelationOptionType == this.data.eRelationOptionType);
			if (relationOption != null)
			{
				relationOption.OnSelected();
			}
		}

		// Token: 0x06010575 RID: 66933 RVA: 0x00495EB8 File Offset: 0x004942B8
		private void OnSelectedDelegate(RelationOptionData data)
		{
			if (data.eRelationOptionType < RelationOptionType.ROT_MY_FRIEND || data.eRelationOptionType >= RelationOptionType.ROT_COUNT)
			{
				Logger.LogErrorFormat("enum value is out of range ,value = {0}", new object[]
				{
					data.eRelationOptionType
				});
				return;
			}
			if (data.eRelationOptionType == RelationOptionType.ROT_MY_FRIEND)
			{
				if (this.friendFrame == null)
				{
					this.friendFrame = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<RelationFriendFrame>(this.childrenRoot, new RelationFriendFrameData
					{
						eRelationTabType = data.eRelationTabType,
						eCurrentRelationData = data.eCurrentRelationData,
						mTalk = data.mTalk
					}, string.Empty) as RelationFriendFrame);
				}
				if (this.TapFrame != null)
				{
					this.TapFrame.Close(true);
					this.TapFrame = null;
				}
				this.friendHelpGo.CustomActive(true);
				this.tapHelpGo.CustomActive(false);
			}
			else if (data.eRelationOptionType == RelationOptionType.ROT_TEACHERANDPUPIL)
			{
				if (this.TapFrame == null)
				{
					this.TapFrame = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPFrame>(this.childrenRoot, null, string.Empty) as TAPFrame);
				}
				if (this.friendFrame != null)
				{
					this.friendFrame.Close(true);
					this.friendFrame = null;
				}
				this.friendHelpGo.CustomActive(false);
				this.tapHelpGo.CustomActive(true);
			}
			DataManager<RelationDataManager>.GetInstance().SetRecentlyHaveRead();
		}

		// Token: 0x06010576 RID: 66934 RVA: 0x00496010 File Offset: 0x00494410
		private void _MainRelationTabChanged(UIEvent uiEvent)
		{
			RelationOptionType eRelationOptionType = (RelationOptionType)uiEvent.Param1;
			RelationOption relationOption = this.m_akFilters.Find((RelationOption x) => x.Value.eRelationOptionType == eRelationOptionType);
			if (relationOption != null)
			{
				relationOption.OnSelected();
			}
		}

		// Token: 0x06010577 RID: 66935 RVA: 0x00496058 File Offset: 0x00494458
		private void _UnInitFilters()
		{
			this.m_akFilters.DestroyAllObjects();
		}

		// Token: 0x06010578 RID: 66936 RVA: 0x00496065 File Offset: 0x00494465
		[UIEventHandle("Close")]
		private void _OnClickClose()
		{
			DataManager<RelationDataManager>.GetInstance().SetRecentlyHaveRead();
			base.Close(false);
		}

		// Token: 0x06010579 RID: 66937 RVA: 0x00496078 File Offset: 0x00494478
		private void _CloseChildrenFrames()
		{
			if (this.friendFrame != null)
			{
				this.friendFrame.Close(true);
				this.friendFrame = null;
			}
			if (this.TapFrame != null)
			{
				this.TapFrame.Close(true);
				this.TapFrame = null;
			}
		}

		// Token: 0x0400A56E RID: 42350
		private RelationFrameData data;

		// Token: 0x0400A56F RID: 42351
		[UIObject("VerticalFilter")]
		private GameObject goFilterParent;

		// Token: 0x0400A570 RID: 42352
		[UIObject("VerticalFilter/Filter")]
		private GameObject goFilter;

		// Token: 0x0400A571 RID: 42353
		private CachedObjectListManager<RelationOption> m_akFilters = new CachedObjectListManager<RelationOption>();

		// Token: 0x0400A572 RID: 42354
		[UIObject("ComWnd/Title/Help")]
		private GameObject friendHelpGo;

		// Token: 0x0400A573 RID: 42355
		[UIObject("ComWnd/Title/TapHelp")]
		private GameObject tapHelpGo;

		// Token: 0x0400A574 RID: 42356
		[UIObject("Root")]
		private GameObject childrenRoot;

		// Token: 0x0400A575 RID: 42357
		private RelationFriendFrame friendFrame;

		// Token: 0x0400A576 RID: 42358
		private TAPRelationInfoFrame TapRelationInfoFrame;

		// Token: 0x0400A577 RID: 42359
		private TAPFrame TapFrame;
	}
}
