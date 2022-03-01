using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001631 RID: 5681
	public class GuildManorOwnerAttrAddUpShowFrame : GameFrame
	{
		// Token: 0x0600DF20 RID: 57120 RVA: 0x0038EFCE File Offset: 0x0038D3CE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildManorOwnerAttrAddUpShow";
		}

		// Token: 0x0600DF21 RID: 57121 RVA: 0x0038EFD5 File Offset: 0x0038D3D5
		protected override void OnOpenFrame()
		{
			this.InitTestComUIList();
			this.UpdateTestComUIList();
		}

		// Token: 0x0600DF22 RID: 57122 RVA: 0x0038EFE3 File Offset: 0x0038D3E3
		protected override void OnCloseFrame()
		{
		}

		// Token: 0x0600DF23 RID: 57123 RVA: 0x0038EFE8 File Offset: 0x0038D3E8
		protected override void _bindExUI()
		{
			this.testComUIList = this.mBind.GetCom<ComUIListScript>("testComUIList");
			this.testTxt = this.mBind.GetCom<Text>("testTxt");
			this.testBtn = this.mBind.GetCom<Button>("testBtn");
			this.testBtn.SafeSetOnClickListener(delegate
			{
			});
			this.testImg = this.mBind.GetCom<Image>("testImg");
			this.testSlider = this.mBind.GetCom<Slider>("testSlider");
			this.testSlider.SafeSetValueChangeListener(delegate(float value)
			{
			});
			this.testToggle = this.mBind.GetCom<Toggle>("testToggle");
			this.testToggle.SafeSetOnValueChangedListener(delegate(bool value)
			{
			});
			this.testGo = this.mBind.GetGameObject("testGo");
		}

		// Token: 0x0600DF24 RID: 57124 RVA: 0x0038F107 File Offset: 0x0038D507
		protected override void _unbindExUI()
		{
			this.testComUIList = null;
			this.testTxt = null;
			this.testBtn = null;
			this.testImg = null;
			this.testSlider = null;
			this.testToggle = null;
			this.testGo = null;
		}

		// Token: 0x0600DF25 RID: 57125 RVA: 0x0038F13A File Offset: 0x0038D53A
		protected override void OnBindUIEvent()
		{
			base.BindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600DF26 RID: 57126 RVA: 0x0038F153 File Offset: 0x0038D553
		protected override void OnUnBindUIEvent()
		{
			base.UnBindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600DF27 RID: 57127 RVA: 0x0038F16C File Offset: 0x0038D56C
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600DF28 RID: 57128 RVA: 0x0038F16F File Offset: 0x0038D56F
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600DF29 RID: 57129 RVA: 0x0038F174 File Offset: 0x0038D574
		private void InitTestComUIList()
		{
			if (this.testComUIList == null)
			{
				return;
			}
			this.testComUIList.Initialize();
			this.testComUIList.onBindItem = ((GameObject go) => go);
			this.testComUIList.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				if (this.testComUIListDatas == null)
				{
					return;
				}
				ComUIListTemplateItem component = go.GetComponent<ComUIListTemplateItem>();
				if (component == null)
				{
					return;
				}
				if (go.m_index >= 0 && go.m_index < this.testComUIListDatas.Count)
				{
					component.SetUp(this.testComUIListDatas[go.m_index]);
				}
			};
		}

		// Token: 0x0600DF2A RID: 57130 RVA: 0x0038F1DD File Offset: 0x0038D5DD
		private void CalcTestComUIListDatas()
		{
			this.testComUIListDatas = new List<object>();
			if (this.testComUIListDatas == null)
			{
				return;
			}
		}

		// Token: 0x0600DF2B RID: 57131 RVA: 0x0038F1F6 File Offset: 0x0038D5F6
		private void UpdateTestComUIList()
		{
			if (this.testComUIList == null)
			{
				return;
			}
			this.CalcTestComUIListDatas();
			if (this.testComUIListDatas == null)
			{
				return;
			}
			this.testComUIList.SetElementAmount(this.testComUIListDatas.Count);
		}

		// Token: 0x0600DF2C RID: 57132 RVA: 0x0038F232 File Offset: 0x0038D632
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x04008478 RID: 33912
		private List<object> testComUIListDatas = new List<object>();

		// Token: 0x04008479 RID: 33913
		private ComUIListScript testComUIList;

		// Token: 0x0400847A RID: 33914
		private Text testTxt;

		// Token: 0x0400847B RID: 33915
		private Button testBtn;

		// Token: 0x0400847C RID: 33916
		private Image testImg;

		// Token: 0x0400847D RID: 33917
		private Slider testSlider;

		// Token: 0x0400847E RID: 33918
		private Toggle testToggle;

		// Token: 0x0400847F RID: 33919
		private GameObject testGo;
	}
}
