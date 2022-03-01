using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001BE3 RID: 7139
	internal class ComTAPOpenControl : MonoBehaviour
	{
		// Token: 0x06011805 RID: 71685 RVA: 0x00517539 File Offset: 0x00515939
		private void Awake()
		{
			this._RegisterEvent();
			this._Check();
		}

		// Token: 0x06011806 RID: 71686 RVA: 0x00517547 File Offset: 0x00515947
		private void _RegisterEvent()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x06011807 RID: 71687 RVA: 0x0051756F File Offset: 0x0051596F
		private void _OnLevelChanged(int iPre, int iCur)
		{
			this._Check();
		}

		// Token: 0x06011808 RID: 71688 RVA: 0x00517577 File Offset: 0x00515977
		private void _UnRegisterEvent()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x06011809 RID: 71689 RVA: 0x005175A0 File Offset: 0x005159A0
		private void _Check()
		{
			bool flag = ComTAPOpenControl.IsOpen();
			UnityEvent unityEvent = (!flag) ? this.onFailed : this.onOk;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x0601180A RID: 71690 RVA: 0x005175D8 File Offset: 0x005159D8
		public static bool IsOpen()
		{
			int num = 99;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(276, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			return num <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x0601180B RID: 71691 RVA: 0x00517620 File Offset: 0x00515A20
		public static ClientFrame _OpenTAPSystem(TAPSystemTabType eTAPSystemTabType, object data)
		{
			TAPTabData taptabData = data as TAPTabData;
			if (taptabData != null)
			{
				if (eTAPSystemTabType == TAPSystemTabType.TSTT_RELATION_INFO)
				{
					return Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPFrame>(taptabData.root, taptabData, string.Empty) as ClientFrame;
				}
			}
			return null;
		}

		// Token: 0x0601180C RID: 71692 RVA: 0x00517664 File Offset: 0x00515A64
		public void OnClickToOpenTAPSystemFrame()
		{
			if (!ComTAPOpenControl.IsOpen())
			{
				return;
			}
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPSystemMainFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSystemMainFrame>(FrameLayer.Middle, new TAPSystemMainFrameData
				{
					eTAPSystemTabType = TAPSystemTabType.TSTT_RELATION_INFO
				}, string.Empty);
			}
		}

		// Token: 0x0601180D RID: 71693 RVA: 0x005176AB File Offset: 0x00515AAB
		private void OnDestroy()
		{
			this._UnRegisterEvent();
		}

		// Token: 0x0400B608 RID: 46600
		public UnityEvent onOk;

		// Token: 0x0400B609 RID: 46601
		public UnityEvent onFailed;
	}
}
