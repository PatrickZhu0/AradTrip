using System;

namespace behaviac
{
	// Token: 0x02002EDB RID: 11995
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node71 : Condition
	{
		// Token: 0x06014690 RID: 83600 RVA: 0x00622DBF File Offset: 0x006211BF
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node71()
		{
			this.opl_p0 = 13000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014691 RID: 83601 RVA: 0x00622DF4 File Offset: 0x006211F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E003 RID: 57347
		private int opl_p0;

		// Token: 0x0400E004 RID: 57348
		private int opl_p1;

		// Token: 0x0400E005 RID: 57349
		private int opl_p2;

		// Token: 0x0400E006 RID: 57350
		private int opl_p3;
	}
}
