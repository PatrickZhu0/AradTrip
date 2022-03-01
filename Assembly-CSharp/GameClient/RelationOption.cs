using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A0A RID: 6666
	internal class RelationOption : CachedSelectedObject<RelationOptionData, RelationOption>
	{
		// Token: 0x060105CD RID: 67021 RVA: 0x00498840 File Offset: 0x00496C40
		public sealed override void Initialize()
		{
			this.label = Utility.FindComponent<Text>(this.goLocal, "Text", true);
			this.checkLabel = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
			this.image = Utility.FindComponent<Image>(this.goLocal, "Image", true);
			this.checkImage = Utility.FindComponent<Image>(this.goLocal, "CheckMark/Image", true);
			this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
			this.goRedPoint = Utility.FindChild(this.goLocal, "RedPoint");
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPrivateChat, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPOpenSearchFrame, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FriendComMenuRemoveList, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
		}

		// Token: 0x060105CE RID: 67022 RVA: 0x004989C8 File Offset: 0x00496DC8
		public sealed override void UnInitialize()
		{
			this.label = null;
			this.checkLabel = null;
			this.image = null;
			this.checkImage = null;
			this.goCheckMark = null;
			this.goRedPoint = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPrivateChat, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPOpenSearchFrame, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FriendComMenuRemoveList, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
		}

		// Token: 0x060105CF RID: 67023 RVA: 0x00498AF4 File Offset: 0x00496EF4
		public sealed override void OnUpdate()
		{
			this.label.text = TR.Value(Utility.GetEnumDescription<RelationOptionType>(base.Value.eRelationOptionType));
			this.checkLabel.text = this.label.text;
			if (base.Value.eRelationOptionType == RelationOptionType.ROT_MY_FRIEND)
			{
				ETCImageLoader.LoadSprite(ref this.image, this.friendImagePath, true);
				ETCImageLoader.LoadSprite(ref this.checkImage, this.friendImagePath, true);
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.image, this.teacherPupilPath, true);
				ETCImageLoader.LoadSprite(ref this.checkImage, this.teacherPupilPath, true);
			}
			this.image.SetNativeSize();
			this.checkImage.SetNativeSize();
			this.CheckRedPoint();
		}

		// Token: 0x060105D0 RID: 67024 RVA: 0x00498BB4 File Offset: 0x00496FB4
		public sealed override void OnDisplayChanged(bool bShow)
		{
			this.goCheckMark.CustomActive(bShow);
		}

		// Token: 0x060105D1 RID: 67025 RVA: 0x00498BC4 File Offset: 0x00496FC4
		public void CheckRedPoint()
		{
			if (base.Value.eRelationOptionType == RelationOptionType.ROT_MY_FRIEND)
			{
				this.goRedPoint.CustomActive(DataManager<RelationDataManager>.GetInstance().GetPriDirty());
			}
			else if (base.Value.eRelationOptionType == RelationOptionType.ROT_TEACHERANDPUPIL)
			{
				bool flag = false;
				bool flag2 = DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint();
				bool flag3 = DataManager<TAPNewDataManager>.GetInstance().HaveTAPDailyRedPoint();
				if (DataManager<TAPDataManager>.GetInstance().CheckTapRedPointIsShow())
				{
					flag = DataManager<TAPNewDataManager>.GetInstance().HaveSearchRedPoint();
				}
				this.goRedPoint.CustomActive(flag2 || flag3 || flag);
			}
			else
			{
				this.goRedPoint.CustomActive(false);
			}
		}

		// Token: 0x060105D2 RID: 67026 RVA: 0x00498C6E File Offset: 0x0049706E
		private void _OnRefreshInviteList(UIEvent uiEvent)
		{
			this.CheckRedPoint();
		}

		// Token: 0x0400A5CE RID: 42446
		private string friendImagePath = "UI/Image/Packed/p_UI_Social.png:UI_Social_Tubiao_Haoyou";

		// Token: 0x0400A5CF RID: 42447
		private string teacherPupilPath = "UI/Image/Packed/p_UI_Social.png:UI_Social_Tubiao_Shitu";

		// Token: 0x0400A5D0 RID: 42448
		public Text label;

		// Token: 0x0400A5D1 RID: 42449
		public Text checkLabel;

		// Token: 0x0400A5D2 RID: 42450
		public Image image;

		// Token: 0x0400A5D3 RID: 42451
		public Image checkImage;

		// Token: 0x0400A5D4 RID: 42452
		public GameObject goCheckMark;

		// Token: 0x0400A5D5 RID: 42453
		public GameObject goRedPoint;
	}
}
