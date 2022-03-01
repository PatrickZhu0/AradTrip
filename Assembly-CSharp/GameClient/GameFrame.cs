using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020001F8 RID: 504
	public class GameFrame : ClientFrame
	{
		// Token: 0x0600101B RID: 4123 RVA: 0x000546E7 File Offset: 0x00052AE7
		protected sealed override void _OnOpenFrame()
		{
			this.delayCallObjs = new List<object>();
			this.intervalCallObjs = new List<object>();
			this.eventBindInfos = new List<GameFrame.UIEventBindInfo>();
			this.OnBindUIEvent();
			this.OnOpenFrame();
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x00054716 File Offset: 0x00052B16
		protected sealed override void _OnCloseFrame()
		{
			this.ClearAllDelayCall();
			this.ClearAllIntervalCall();
			this.delayCallObjs = null;
			this.intervalCallObjs = null;
			this.OnUnBindUIEvent();
			this.UnBindAllUIEvent();
			this.eventBindInfos = null;
			this.OnCloseFrame();
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0005474B File Offset: 0x00052B4B
		protected virtual void OnOpenFrame()
		{
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0005474D File Offset: 0x00052B4D
		protected virtual void OnCloseFrame()
		{
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0005474F File Offset: 0x00052B4F
		protected virtual void OnBindUIEvent()
		{
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x00054751 File Offset: 0x00052B51
		protected virtual void OnUnBindUIEvent()
		{
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x00054754 File Offset: 0x00052B54
		protected object AddDelayCall(float delay, UnityAction action)
		{
			if (action == null)
			{
				return null;
			}
			if (this.delayCallObjs == null)
			{
				return null;
			}
			object obj = new object();
			if (obj == null)
			{
				return null;
			}
			this.delayCallObjs.Add(obj);
			Singleton<InvokeMethod.TaskManager>.GetInstance().InvokeCall(obj, Time.time, delay, action);
			return obj;
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x000547A3 File Offset: 0x00052BA3
		protected void DelDelayCall(object obj)
		{
			if (obj == null)
			{
				return;
			}
			if (this.delayCallObjs == null)
			{
				return;
			}
			Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeCall(obj);
			this.delayCallObjs.Remove(obj);
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x000547D0 File Offset: 0x00052BD0
		protected void DelDelayCall(UnityAction action)
		{
			Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeCall(action);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x000547E0 File Offset: 0x00052BE0
		protected object AddIntervalCall(UnityAction action, float interval, float duration = 3.4028235E+38f, float delay = 0f)
		{
			if (action == null)
			{
				return null;
			}
			if (this.intervalCallObjs == null)
			{
				return null;
			}
			object obj = new object();
			if (obj == null)
			{
				return null;
			}
			this.intervalCallObjs.Add(obj);
			Singleton<InvokeMethod.TaskManager>.GetInstance().InvokeIntervalCall(obj, Time.time, delay, interval, duration, null, action, null);
			return obj;
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x00054835 File Offset: 0x00052C35
		protected void DelIntervalCall(object obj)
		{
			if (obj == null)
			{
				return;
			}
			if (this.intervalCallObjs == null)
			{
				return;
			}
			Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(obj);
			this.intervalCallObjs.Remove(obj);
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x00054862 File Offset: 0x00052C62
		protected void DelIntervalCall(UnityAction action)
		{
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x00054864 File Offset: 0x00052C64
		private void ClearAllDelayCall()
		{
			if (this.delayCallObjs == null)
			{
				return;
			}
			for (int i = 0; i < this.delayCallObjs.Count; i++)
			{
				Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeCall(this.delayCallObjs[i]);
			}
			this.delayCallObjs.Clear();
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x000548BC File Offset: 0x00052CBC
		private void ClearAllIntervalCall()
		{
			if (this.intervalCallObjs == null)
			{
				return;
			}
			for (int i = 0; i < this.intervalCallObjs.Count; i++)
			{
				Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(this.intervalCallObjs[i]);
			}
			this.intervalCallObjs.Clear();
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x00054914 File Offset: 0x00052D14
		protected void BindUIEvent(EUIEventID id, ClientEventSystem.UIEventHandler handler)
		{
			if (this.eventBindInfos == null)
			{
				return;
			}
			if (handler == null)
			{
				return;
			}
			this.eventBindInfos.Add(new GameFrame.UIEventBindInfo
			{
				eventID = id,
				eventHandler = handler
			});
			UIEventSystem.GetInstance().RegisterEventHandler(id, handler);
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00054960 File Offset: 0x00052D60
		protected void UnBindUIEvent(EUIEventID id, ClientEventSystem.UIEventHandler handler)
		{
			if (this.eventBindInfos == null)
			{
				return;
			}
			if (handler == null)
			{
				return;
			}
			this.eventBindInfos.RemoveAll((GameFrame.UIEventBindInfo info) => info != null && info.eventID == id && info.eventHandler == handler);
			UIEventSystem.GetInstance().UnRegisterEventHandler(id, handler);
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x000549C8 File Offset: 0x00052DC8
		private void UnBindAllUIEvent()
		{
			if (this.eventBindInfos == null)
			{
				return;
			}
			for (int i = 0; i < this.eventBindInfos.Count; i++)
			{
				GameFrame.UIEventBindInfo uieventBindInfo = this.eventBindInfos[i];
				if (uieventBindInfo != null)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(uieventBindInfo.eventID, uieventBindInfo.eventHandler);
				}
			}
			this.eventBindInfos.Clear();
		}

		// Token: 0x04000B11 RID: 2833
		private List<object> delayCallObjs = new List<object>();

		// Token: 0x04000B12 RID: 2834
		private List<object> intervalCallObjs = new List<object>();

		// Token: 0x04000B13 RID: 2835
		private List<GameFrame.UIEventBindInfo> eventBindInfos = new List<GameFrame.UIEventBindInfo>();

		// Token: 0x020001F9 RID: 505
		private class UIEventBindInfo
		{
			// Token: 0x04000B14 RID: 2836
			public EUIEventID eventID = EUIEventID.Invalid;

			// Token: 0x04000B15 RID: 2837
			public ClientEventSystem.UIEventHandler eventHandler;
		}
	}
}
