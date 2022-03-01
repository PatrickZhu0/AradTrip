using System;

namespace behaviac
{
	// Token: 0x02002BA2 RID: 11170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node5 : Condition
	{
		// Token: 0x0601404D RID: 81997 RVA: 0x0060321E File Offset: 0x0060161E
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node5()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601404E RID: 81998 RVA: 0x00603254 File Offset: 0x00601654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA45 RID: 55877
		private int opl_p0;

		// Token: 0x0400DA46 RID: 55878
		private int opl_p1;

		// Token: 0x0400DA47 RID: 55879
		private int opl_p2;

		// Token: 0x0400DA48 RID: 55880
		private int opl_p3;
	}
}
