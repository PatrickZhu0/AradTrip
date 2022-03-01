using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B17 RID: 6935
	internal class FashionMergeResultFrame : ClientFrame
	{
		// Token: 0x06011071 RID: 69745 RVA: 0x004DFDA2 File Offset: 0x004DE1A2
		public static void Open(FashionResultData data)
		{
			if (data != null)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeResultFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionMergeResultFrame>(FrameLayer.Middle, data, string.Empty);
			}
		}

		// Token: 0x06011072 RID: 69746 RVA: 0x004DFDC8 File Offset: 0x004DE1C8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionResultFrame";
		}

		// Token: 0x06011073 RID: 69747 RVA: 0x004DFDD0 File Offset: 0x004DE1D0
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as FashionResultData);
			this.m_bLock = true;
			float fDelyTime = (!(null == this.comDataBinder)) ? this.comDataBinder.lockTime : 1f;
			InvokeMethod.Invoke(this, fDelyTime, delegate()
			{
				this.m_bLock = false;
			});
			base._AddButton("OK", delegate
			{
				if (this.m_bLock)
				{
					return;
				}
				this.frameMgr.CloseFrame<FashionMergeResultFrame>(this, false);
			});
			if (null != this.comEffectLoader)
			{
				this.comEffectLoader.LoadEffect(0);
				this.comEffectLoader.ActiveEffect(0);
				this.comEffectLoader.LoadEffect(2);
				this.comEffectLoader.ActiveEffect(2);
				if (this.m_kData != null && this.m_kData.eFashionMergeResultType == FashionMergeResultType.FMRT_SPECIAL)
				{
					if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
					{
						this.comEffectLoader.LoadEffect(1);
						this.comEffectLoader.ActiveEffect(1);
						this.comEffectLoader.LoadEffect(3);
						this.comEffectLoader.ActiveEffect(3);
					}
					else
					{
						this.comEffectLoader.LoadEffect(1);
						this.comEffectLoader.ActiveEffect(1);
						this.comEffectLoader.LoadEffect(2);
						this.comEffectLoader.ActiveEffect(2);
					}
				}
			}
			this._SetData();
		}

		// Token: 0x06011074 RID: 69748 RVA: 0x004DFF30 File Offset: 0x004DE330
		protected override void _OnCloseFrame()
		{
			if (this.m_kData != null && this.m_kData.eFashionMergeResultType == FashionMergeResultType.FMRT_SPECIAL && this.m_kData.datas != null && this.m_kData.datas.Count > 1)
			{
				ItemData itemData = this.m_kData.datas[1];
				if (itemData != null)
				{
					Vector3 skyWorldPosition = this.comDataBinder.GetSkyWorldPosition();
					ItemData param = (this.m_kData.datas.Count > 2) ? this.m_kData.datas[2] : null;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionSpecialFly, skyWorldPosition.x, skyWorldPosition.y, itemData, param);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionAutoEquip, null, null, null, null);
			this.m_kData = null;
			this.m_bLock = false;
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x06011075 RID: 69749 RVA: 0x004E0021 File Offset: 0x004DE421
		private void _SetData()
		{
			if (null != this.comDataBinder)
			{
				this.comDataBinder.SetValue(this.m_kData);
			}
		}

		// Token: 0x0400AF49 RID: 44873
		[UIControl("", typeof(ComFashionMergeResultDataBinder), 0)]
		private ComFashionMergeResultDataBinder comDataBinder;

		// Token: 0x0400AF4A RID: 44874
		[UIControl("", typeof(ComEffectLoader), 0)]
		private ComEffectLoader comEffectLoader;

		// Token: 0x0400AF4B RID: 44875
		private FashionResultData m_kData;

		// Token: 0x0400AF4C RID: 44876
		private bool m_bLock;
	}
}
