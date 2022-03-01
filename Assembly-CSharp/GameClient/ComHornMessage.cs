using System;
using System.Collections.Generic;
using System.Text;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000038 RID: 56
	internal class ComHornMessage : MonoBehaviour
	{
		// Token: 0x06000170 RID: 368 RVA: 0x0000D8E5 File Offset: 0x0000BCE5
		public void LinkToHornFrame()
		{
			HornFrame.Open();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000D8EC File Offset: 0x0000BCEC
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WordChatHorn, new ClientEventSystem.UIEventHandler(this.OnHornInfo));
			this.start = 0f;
			this.end = 0f;
			this.current = null;
			ScalerJump scalerJump = this.comJump;
			scalerJump.onJumpEnd = (ScalerJump.OnJumpEnd)Delegate.Combine(scalerJump.onJumpEnd, new ScalerJump.OnJumpEnd(this._OnJumpEnd));
			this.stateController.Key = "Off";
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000D968 File Offset: 0x0000BD68
		private void _OnJumpEnd(int iIndex)
		{
			this.combo.Value = iIndex;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000D978 File Offset: 0x0000BD78
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WordChatHorn, new ClientEventSystem.UIEventHandler(this.OnHornInfo));
			this.current = null;
			this.horns.Clear();
			ScalerJump scalerJump = this.comJump;
			scalerJump.onJumpEnd = (ScalerJump.OnJumpEnd)Delegate.Remove(scalerJump.onJumpEnd, new ScalerJump.OnJumpEnd(this._OnJumpEnd));
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000D9DC File Offset: 0x0000BDDC
		private void OnHornInfo(UIEvent uiEvent)
		{
			HornInfo hornInfo = uiEvent.Param1 as HornInfo;
			if (hornInfo == null)
			{
				Logger.LogErrorFormat("horn convered failed !!!", new object[0]);
				return;
			}
			this.horns.Add(hornInfo);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000DA18 File Offset: 0x0000BE18
		private void _OnHornInfoChanged(HornInfo hornInfo)
		{
			if (null != this.linkParse && hornInfo != null)
			{
				bool flag = hornInfo.num > 1 || hornInfo.combo - (ushort)hornInfo.num > 0;
				StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
				stringBuilder.AppendFormat("{{P {0} {1} {2} {3}}}:{4}", new object[]
				{
					hornInfo.roldId,
					hornInfo.name,
					hornInfo.occu,
					hornInfo.level,
					hornInfo.content
				});
				this.linkParse.SetText(stringBuilder.ToString(), true);
				StringBuilderCache.Release(stringBuilder);
				if (null != this.combo)
				{
					this.stateController.Key = "On";
					if (!flag)
					{
						this.combo.Value = (int)hornInfo.combo;
					}
					else if (hornInfo.num == 1)
					{
						this.combo.Value = (int)(hornInfo.combo - (ushort)hornInfo.num);
						this.comJumpX.StartJumpNormal(0);
						this.comJump.StartJumpNormal((int)hornInfo.combo);
					}
					else
					{
						this.combo.Value = (int)(hornInfo.combo - (ushort)hornInfo.num);
						this.comJumpX.StartJumpNormal(0);
						this.comJump.StartJumpContinue((int)(hornInfo.combo - (ushort)hornInfo.num + 1), (int)(hornInfo.num - 1));
					}
				}
			}
			else if (null == this.linkParse)
			{
				Logger.LogErrorFormat("missing script LinkParse !!", new object[0]);
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000DBBC File Offset: 0x0000BFBC
		private void Update()
		{
			if (this.horns.Count > 0)
			{
				if (this.current == null)
				{
					this.current = this.horns[0];
					this.start = Time.time;
					this.end = Time.time + (float)this.current.maxTime;
					this.endprotected = Time.time + (float)this.current.minTime;
					this._OnHornInfoChanged(this.current);
					return;
				}
				bool flag = false;
				if (this.horns.Count > 1)
				{
					flag = true;
				}
				float num = (!flag) ? this.end : this.endprotected;
				if (Time.time > num)
				{
					this.horns.Remove(this.current);
					this.current = null;
					if (this.horns.Count > 0)
					{
						this.current = this.horns[0];
						this.start = Time.time;
						this.end = Time.time + (float)this.current.maxTime;
						this.endprotected = Time.time + (float)this.current.minTime;
						this._OnHornInfoChanged(this.current);
					}
				}
			}
			this.stateController.Key = ((this.current == null) ? "Off" : "On");
		}

		// Token: 0x0400014C RID: 332
		private List<HornInfo> horns = new List<HornInfo>();

		// Token: 0x0400014D RID: 333
		private float start;

		// Token: 0x0400014E RID: 334
		private float end;

		// Token: 0x0400014F RID: 335
		private float endprotected;

		// Token: 0x04000150 RID: 336
		private HornInfo current;

		// Token: 0x04000151 RID: 337
		public LinkParse linkParse;

		// Token: 0x04000152 RID: 338
		public UINumber combo;

		// Token: 0x04000153 RID: 339
		public ScalerJump comJump;

		// Token: 0x04000154 RID: 340
		public ScalerJump comJumpX;

		// Token: 0x04000155 RID: 341
		public StateController stateController;
	}
}
