using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001BE5 RID: 7141
	internal class ComTAPRedControl : MonoBehaviour
	{
		// Token: 0x06011814 RID: 71700 RVA: 0x00517950 File Offset: 0x00515D50
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNewPupilApplyRecieved, new ClientEventSystem.UIEventHandler(this._OnNewPupilApplyRecieved));
			this._Update();
		}

		// Token: 0x06011815 RID: 71701 RVA: 0x00517973 File Offset: 0x00515D73
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNewPupilApplyRecieved, new ClientEventSystem.UIEventHandler(this._OnNewPupilApplyRecieved));
		}

		// Token: 0x06011816 RID: 71702 RVA: 0x00517990 File Offset: 0x00515D90
		private void _OnNewPupilApplyRecieved(UIEvent uiEvent)
		{
			this._Update();
		}

		// Token: 0x06011817 RID: 71703 RVA: 0x00517998 File Offset: 0x00515D98
		private void _Update()
		{
			UnityEvent unityEvent = (!DataManager<RelationDataManager>.GetInstance().HasNewApply) ? this.onFailed : this.onSucceed;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x06011818 RID: 71704 RVA: 0x005179D2 File Offset: 0x00515DD2
		public void OpenTAPSearchFrame()
		{
			TAPSystemMainFrame.OpenLinkFrame(string.Format("{0}", 0));
			DataManager<TAPDataManager>.GetInstance().OpenApplyPupilFrame();
		}

		// Token: 0x0400B615 RID: 46613
		public UnityEvent onSucceed;

		// Token: 0x0400B616 RID: 46614
		public UnityEvent onFailed;
	}
}
