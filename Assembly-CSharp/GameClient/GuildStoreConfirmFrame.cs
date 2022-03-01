using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001657 RID: 5719
	internal class GuildStoreConfirmFrame : ClientFrame
	{
		// Token: 0x0600E0E8 RID: 57576 RVA: 0x00398E95 File Offset: 0x00397295
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildStoreConfirmFrame";
		}

		// Token: 0x0600E0E9 RID: 57577 RVA: 0x00398E9C File Offset: 0x0039729C
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as GuildStoreConfirmFrameData);
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<GuildStoreConfirmFrame>(this, false);
			});
			base._AddButton("minus", delegate
			{
				this.data.iCurCount--;
				this._Refresh();
			});
			base._AddButton("min", delegate
			{
				this.data.iCurCount = 1;
				this._Refresh();
			});
			base._AddButton("add", delegate
			{
				this.data.iCurCount++;
				this._Refresh();
			});
			base._AddButton("max", delegate
			{
				this.data.iCurCount = this.data.iMax;
				this._Refresh();
			});
			base._AddButton("ok", delegate
			{
				if (this.data.onOk != null)
				{
					this.data.onOk.Invoke(this.data.iCurCount);
					this.data.onOk = null;
					this.frameMgr.CloseFrame<GuildStoreConfirmFrame>(this, false);
				}
			});
			if (null != this.inputField)
			{
				this.inputField.onValueChanged.AddListener(new UnityAction<string>(this._OnValueChanged));
			}
			if (null != this.title)
			{
				this.title.text = this.data.title;
			}
			this._Refresh();
		}

		// Token: 0x0600E0EA RID: 57578 RVA: 0x00398F9E File Offset: 0x0039739E
		protected override void _OnCloseFrame()
		{
			if (null != this.inputField)
			{
				this.inputField.onValueChanged.RemoveListener(new UnityAction<string>(this._OnValueChanged));
				this.inputField = null;
			}
			this.data = null;
		}

		// Token: 0x0600E0EB RID: 57579 RVA: 0x00398FDC File Offset: 0x003973DC
		private void _OnValueChanged(string value)
		{
			int iCurCount = 0;
			if (int.TryParse(value, out iCurCount))
			{
				this.data.iCurCount = iCurCount;
			}
			this._Refresh();
		}

		// Token: 0x0600E0EC RID: 57580 RVA: 0x0039900C File Offset: 0x0039740C
		private void _Refresh()
		{
			this.data.iCurCount = (int)IntMath.Clamp((long)this.data.iCurCount, 1L, (long)this.data.iMax);
			if (this.data.iCurCount == this.data.iMax && this.data.iCurCount == 1)
			{
				this.comState.Key = "balance";
			}
			else if (this.data.iCurCount == 1)
			{
				this.comState.Key = "min";
			}
			else if (this.data.iCurCount == this.data.iMax)
			{
				this.comState.Key = "max";
			}
			else
			{
				this.comState.Key = "normal";
			}
			if (null != this.inputField)
			{
				this.inputField.onValueChanged.RemoveListener(new UnityAction<string>(this._OnValueChanged));
				this.inputField.text = this.data.iCurCount.ToString();
				this.inputField.onValueChanged.AddListener(new UnityAction<string>(this._OnValueChanged));
			}
		}

		// Token: 0x040085D1 RID: 34257
		private GuildStoreConfirmFrameData data = new GuildStoreConfirmFrameData();

		// Token: 0x040085D2 RID: 34258
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x040085D3 RID: 34259
		[UIControl("count", typeof(InputField), 0)]
		private InputField inputField;

		// Token: 0x040085D4 RID: 34260
		[UIControl("Name", typeof(Text), 0)]
		private Text title;
	}
}
