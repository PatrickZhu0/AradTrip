using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200003A RID: 58
	internal class ComIntervalGroup : Singleton<ComIntervalGroup>
	{
		// Token: 0x06000179 RID: 377 RVA: 0x0000DE0C File Offset: 0x0000C20C
		public void Register(object target, int iId, ComFunctionInterval comInterval)
		{
			if (this.m_akIntervalConfigs.Find((IntervalConfig x) => x.target == target && x.iId == iId && x.comInterval == comInterval) == null)
			{
				this.m_akIntervalConfigs.Add(new IntervalConfig
				{
					target = target,
					iId = iId,
					comInterval = comInterval
				});
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000DE88 File Offset: 0x0000C288
		public void UnRegister(object target)
		{
			this.m_akIntervalConfigs.RemoveAll((IntervalConfig x) => x.target == target);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000DEBC File Offset: 0x0000C2BC
		public void BeginInvoke(object target, int iId, float fLastTime)
		{
			this.m_akIntervalConfigs.ForEach(delegate(IntervalConfig x)
			{
				if (x.target == target && x.iId == iId && x.comInterval != null)
				{
					x.comInterval.BeginInvoke(fLastTime);
				}
			});
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000DEFC File Offset: 0x0000C2FC
		public void EnableFunction(object target, int iId)
		{
			this.m_akIntervalConfigs.ForEach(delegate(IntervalConfig x)
			{
				if (x.target == target && x.iId == iId && x.comInterval != null)
				{
					x.comInterval.EnableFunction();
				}
			});
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000DF34 File Offset: 0x0000C334
		public void DisableFunction(object target, int iId)
		{
			this.m_akIntervalConfigs.ForEach(delegate(IntervalConfig x)
			{
				if (x.target == target && x.iId == iId && x.comInterval != null)
				{
					x.comInterval.DisableFunction();
				}
			});
		}

		// Token: 0x04000159 RID: 345
		private List<IntervalConfig> m_akIntervalConfigs = new List<IntervalConfig>();
	}
}
