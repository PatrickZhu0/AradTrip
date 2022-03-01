using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020001FD RID: 509
	public class FrameClassName : GameFrame
	{
		// Token: 0x0600103D RID: 4157 RVA: 0x00054BCC File Offset: 0x00052FCC
		public override string GetPrefabPath()
		{
			return "FramePrefabPath";
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00054BD3 File Offset: 0x00052FD3
		protected override void OnOpenFrame()
		{
			this.InitTestComUIList();
			this.UpdateTestComUIList();
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00054BE1 File Offset: 0x00052FE1
		protected override void OnCloseFrame()
		{
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00054BE4 File Offset: 0x00052FE4
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

		// Token: 0x06001041 RID: 4161 RVA: 0x00054D03 File Offset: 0x00053103
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

		// Token: 0x06001042 RID: 4162 RVA: 0x00054D36 File Offset: 0x00053136
		protected override void OnBindUIEvent()
		{
			base.BindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x00054D4F File Offset: 0x0005314F
		protected override void OnUnBindUIEvent()
		{
			base.UnBindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00054D68 File Offset: 0x00053168
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x00054D6B File Offset: 0x0005316B
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x00054D70 File Offset: 0x00053170
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

		// Token: 0x06001047 RID: 4167 RVA: 0x00054DD9 File Offset: 0x000531D9
		private void CalcTestComUIListDatas()
		{
			this.testComUIListDatas = new List<object>();
			if (this.testComUIListDatas == null)
			{
				return;
			}
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x00054DF2 File Offset: 0x000531F2
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

		// Token: 0x06001049 RID: 4169 RVA: 0x00054E2E File Offset: 0x0005322E
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x04000B19 RID: 2841
		private List<object> testComUIListDatas = new List<object>();

		// Token: 0x04000B1A RID: 2842
		private ComUIListScript testComUIList;

		// Token: 0x04000B1B RID: 2843
		private Text testTxt;

		// Token: 0x04000B1C RID: 2844
		private Button testBtn;

		// Token: 0x04000B1D RID: 2845
		private Image testImg;

		// Token: 0x04000B1E RID: 2846
		private Slider testSlider;

		// Token: 0x04000B1F RID: 2847
		private Toggle testToggle;

		// Token: 0x04000B20 RID: 2848
		private GameObject testGo;
	}
}
