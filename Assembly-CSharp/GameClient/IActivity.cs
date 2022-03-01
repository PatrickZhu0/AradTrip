using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020011BD RID: 4541
	public interface IActivity : IDisposable
	{
		// Token: 0x0600AE76 RID: 44662
		void Init(uint activityId);

		// Token: 0x0600AE77 RID: 44663
		void Show(Transform root);

		// Token: 0x0600AE78 RID: 44664
		void Hide();

		// Token: 0x0600AE79 RID: 44665
		void Close();

		// Token: 0x0600AE7A RID: 44666
		void UpdateData();

		// Token: 0x0600AE7B RID: 44667
		void UpdateTask(int taskId);

		// Token: 0x0600AE7C RID: 44668
		bool IsHaveRedPoint();

		// Token: 0x0600AE7D RID: 44669
		uint GetId();

		// Token: 0x0600AE7E RID: 44670
		string GetName();

		// Token: 0x0600AE7F RID: 44671
		OpActivityState GetState();
	}
}
