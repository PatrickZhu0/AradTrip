using System;

namespace behaviac
{
	// Token: 0x02002BA8 RID: 11176
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node1 : Condition
	{
		// Token: 0x06014058 RID: 82008 RVA: 0x00603647 File Offset: 0x00601A47
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node1()
		{
			this.opl_p0 = 16000;
			this.opl_p1 = 12000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x06014059 RID: 82009 RVA: 0x0060367C File Offset: 0x00601A7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA51 RID: 55889
		private int opl_p0;

		// Token: 0x0400DA52 RID: 55890
		private int opl_p1;

		// Token: 0x0400DA53 RID: 55891
		private int opl_p2;

		// Token: 0x0400DA54 RID: 55892
		private int opl_p3;
	}
}
