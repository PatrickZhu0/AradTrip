using System;

namespace behaviac
{
	// Token: 0x02003630 RID: 13872
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node22 : Condition
	{
		// Token: 0x06015484 RID: 87172 RVA: 0x0066A716 File Offset: 0x00668B16
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node22()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015485 RID: 87173 RVA: 0x0066A74C File Offset: 0x00668B4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE3D RID: 60989
		private int opl_p0;

		// Token: 0x0400EE3E RID: 60990
		private int opl_p1;

		// Token: 0x0400EE3F RID: 60991
		private int opl_p2;

		// Token: 0x0400EE40 RID: 60992
		private int opl_p3;
	}
}
