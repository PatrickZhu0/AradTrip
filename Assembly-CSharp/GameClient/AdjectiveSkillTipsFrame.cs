using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A9E RID: 6814
	public class AdjectiveSkillTipsFrame : ClientFrame
	{
		// Token: 0x06010BA0 RID: 68512 RVA: 0x004BE4F4 File Offset: 0x004BC8F4
		protected override void _bindExUI()
		{
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mDes = this.mBind.GetCom<Text>("Des");
			this.mFrameRectTransform = this.mBind.GetCom<RectTransform>("FrameRectTransform");
			this.mCloseBtn = this.mBind.GetCom<Button>("CloseBtn");
			if (null != this.mCloseBtn)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this._onCloseBtnButtonClick));
			}
		}

		// Token: 0x06010BA1 RID: 68513 RVA: 0x004BE588 File Offset: 0x004BC988
		protected override void _unbindExUI()
		{
			this.mName = null;
			this.mDes = null;
			this.mFrameRectTransform = null;
			if (null != this.mCloseBtn)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this._onCloseBtnButtonClick));
			}
			this.mCloseBtn = null;
		}

		// Token: 0x06010BA2 RID: 68514 RVA: 0x004BE5DE File Offset: 0x004BC9DE
		private void _onCloseBtnButtonClick()
		{
			this.frameMgr.CloseFrame<AdjectiveSkillTipsFrame>(this, false);
		}

		// Token: 0x06010BA3 RID: 68515 RVA: 0x004BE5ED File Offset: 0x004BC9ED
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/AdjectiveSkillTipsFrame";
		}

		// Token: 0x06010BA4 RID: 68516 RVA: 0x004BE5F4 File Offset: 0x004BC9F4
		protected override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			if (this.userData != null)
			{
				this.adjectiveSkillTipsData = (AdjectiveSkillTipsData)this.userData;
			}
			this.InitUI();
		}

		// Token: 0x06010BA5 RID: 68517 RVA: 0x004BE61E File Offset: 0x004BCA1E
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
		}

		// Token: 0x06010BA6 RID: 68518 RVA: 0x004BE628 File Offset: 0x004BCA28
		private void InitUI()
		{
			this.mName.text = this.adjectiveSkillTipsData.Name;
			this.mDes.text = this.adjectiveSkillTipsData.Des;
			this._SetupFramePosition(this.adjectiveSkillTipsData.vec);
			this.mFrameRectTransform.gameObject.CustomActive(true);
		}

		// Token: 0x06010BA7 RID: 68519 RVA: 0x004BE684 File Offset: 0x004BCA84
		private void _SetupFramePosition2(Vector2 pos)
		{
			float num = Input.mousePosition.x - (float)Screen.width / 2f;
			float num2 = Input.mousePosition.y - (float)Screen.height / 2f;
			Logger.LogErrorFormat("x：{0} y：{1} x:{2} y:{3}", new object[]
			{
				Input.mousePosition.x,
				Input.mousePosition.y,
				num,
				num2
			});
			Vector2 vector;
			vector..ctor(num, num2);
			this.mFrameRectTransform.localPosition = vector;
		}

		// Token: 0x06010BA8 RID: 68520 RVA: 0x004BE730 File Offset: 0x004BCB30
		private void _SetupFramePosition(Vector2 pos)
		{
			RectTransform rectTransform = this.mFrameRectTransform;
			RectTransform rectTransform2 = rectTransform.transform.parent as RectTransform;
			Vector2 anchoredPosition;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform2, pos, Singleton<ClientSystemManager>.GetInstance().UICamera, ref anchoredPosition))
			{
				return;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			Vector2 vector;
			vector..ctor(10f, 10f);
			float x = vector.x;
			float num = rectTransform2.rect.size.x - vector.x - rectTransform.rect.size.x;
			float y = vector.y;
			float num2 = -(rectTransform2.rect.size.y - vector.y - rectTransform.rect.size.y);
			anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, x, num);
			anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, num2, y);
			rectTransform.anchoredPosition = anchoredPosition;
		}

		// Token: 0x06010BA9 RID: 68521 RVA: 0x004BE845 File Offset: 0x004BCC45
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x06010BAA RID: 68522 RVA: 0x004BE847 File Offset: 0x004BCC47
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0400AB09 RID: 43785
		private Text mName;

		// Token: 0x0400AB0A RID: 43786
		private Text mDes;

		// Token: 0x0400AB0B RID: 43787
		private RectTransform mFrameRectTransform;

		// Token: 0x0400AB0C RID: 43788
		private Button mCloseBtn;

		// Token: 0x0400AB0D RID: 43789
		private AdjectiveSkillTipsData adjectiveSkillTipsData = new AdjectiveSkillTipsData();
	}
}
