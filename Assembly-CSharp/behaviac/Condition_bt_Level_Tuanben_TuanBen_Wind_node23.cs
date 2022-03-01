using System;

namespace behaviac
{
	// Token: 0x02002AFF RID: 11007
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node23 : Condition
	{
		// Token: 0x06013F12 RID: 81682 RVA: 0x005FC470 File Offset: 0x005FA870
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node23()
		{
			this.opl_p0 = 85020021;
		}

		// Token: 0x06013F13 RID: 81683 RVA: 0x005FC484 File Offset: 0x005FA884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_HaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D95F RID: 55647
		private int opl_p0;
	}
}
