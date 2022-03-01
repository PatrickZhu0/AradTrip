using System;

namespace behaviac
{
	// Token: 0x02002B27 RID: 11047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node31 : Condition
	{
		// Token: 0x06013F60 RID: 81760 RVA: 0x005FDAF2 File Offset: 0x005FBEF2
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node31()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 1;
		}

		// Token: 0x06013F61 RID: 81761 RVA: 0x005FDB08 File Offset: 0x005FBF08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D99C RID: 55708
		private LevelCounterType opl_p0;

		// Token: 0x0400D99D RID: 55709
		private int opl_p1;
	}
}
