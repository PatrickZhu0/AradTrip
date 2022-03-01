using System;

namespace behaviac
{
	// Token: 0x02002B09 RID: 11017
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node31 : Condition
	{
		// Token: 0x06013F26 RID: 81702 RVA: 0x005FC84A File Offset: 0x005FAC4A
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node31()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 1;
		}

		// Token: 0x06013F27 RID: 81703 RVA: 0x005FC860 File Offset: 0x005FAC60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D972 RID: 55666
		private LevelCounterType opl_p0;

		// Token: 0x0400D973 RID: 55667
		private int opl_p1;
	}
}
