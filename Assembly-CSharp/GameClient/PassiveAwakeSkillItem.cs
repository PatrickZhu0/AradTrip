using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AA7 RID: 6823
	public class PassiveAwakeSkillItem : MonoBehaviour
	{
		// Token: 0x06010BCF RID: 68559 RVA: 0x004BF314 File Offset: 0x004BD714
		private void Start()
		{
			this.UpdateGray();
			Drag_Me drag_Me = this.mDragMe;
			drag_Me.ResponseDrag = (Drag_Me.OnResDrag)Delegate.Combine(drag_Me.ResponseDrag, new Drag_Me.OnResDrag(this.DealDrag));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdatePassiveSkillGray, new ClientEventSystem.UIEventHandler(this.UpdateGray));
		}

		// Token: 0x06010BD0 RID: 68560 RVA: 0x004BF369 File Offset: 0x004BD769
		private void UpdateGray(UIEvent uiEvent)
		{
			this.UpdateGray();
		}

		// Token: 0x06010BD1 RID: 68561 RVA: 0x004BF374 File Offset: 0x004BD774
		private void UpdateGray()
		{
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					this.gray.enabled = DataManager<SkillDataManager>.GetInstance().ActiveAwakeSkillIsGray;
				}
				else if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page2)
				{
					this.gray.enabled = DataManager<SkillDataManager>.GetInstance().ActiveAwakeSkillIsGray2;
				}
			}
		}

		// Token: 0x06010BD2 RID: 68562 RVA: 0x004BF3E0 File Offset: 0x004BD7E0
		private void OnDestroy()
		{
			Drag_Me drag_Me = this.mDragMe;
			drag_Me.ResponseDrag = (Drag_Me.OnResDrag)Delegate.Remove(drag_Me.ResponseDrag, new Drag_Me.OnResDrag(this.DealDrag));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdatePassiveSkillGray, new ClientEventSystem.UIEventHandler(this.UpdateGray));
		}

		// Token: 0x06010BD3 RID: 68563 RVA: 0x004BF430 File Offset: 0x004BD830
		public void Show()
		{
			if (!DataManager<SkillDataManager>.GetInstance().isPve())
			{
				base.gameObject.CustomActive(false);
				return;
			}
			SkillTable passiveAwakeSkillData = DataManager<SkillDataManager>.GetInstance().GetPassiveAwakeSkillData();
			if (passiveAwakeSkillData != null)
			{
				base.gameObject.CustomActive(true);
				if (DataManager<PlayerBaseData>.GetInstance().AwakeState <= 0)
				{
					this.mLockImg.CustomActive(true);
					this.mLockTxt.CustomActive(true);
					this.mIconImg.CustomActive(false);
					this.mLockTxt.SafeSetText(TR.Value("skill_passiveAwake_skill_des"));
				}
				else
				{
					this.mLockImg.CustomActive(false);
					this.mLockTxt.CustomActive(false);
					this.mIconImg.CustomActive(true);
					if (this.mIconImg != null)
					{
						ETCImageLoader.LoadSprite(ref this.mIconImg, passiveAwakeSkillData.Icon, true);
					}
				}
			}
			else
			{
				base.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06010BD4 RID: 68564 RVA: 0x004BF51D File Offset: 0x004BD91D
		private bool DealDrag(PointerEventData eventData, bool bIsDrag)
		{
			if (bIsDrag)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("skill_drag_passiveAwake_skill_tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			return false;
		}

		// Token: 0x0400AB3C RID: 43836
		[SerializeField]
		private Image mLockImg;

		// Token: 0x0400AB3D RID: 43837
		[SerializeField]
		private Image mIconImg;

		// Token: 0x0400AB3E RID: 43838
		[SerializeField]
		private Text mLockTxt;

		// Token: 0x0400AB3F RID: 43839
		[SerializeField]
		private Drag_Me mDragMe;

		// Token: 0x0400AB40 RID: 43840
		[SerializeField]
		private UIGray gray;
	}
}
