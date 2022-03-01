using System;

namespace behaviac
{
	// Token: 0x0200369F RID: 13983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node12 : Condition
	{
		// Token: 0x0601555A RID: 87386 RVA: 0x0066F7A3 File Offset: 0x0066DBA3
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node12()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601555B RID: 87387 RVA: 0x0066F7D8 File Offset: 0x0066DBD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF27 RID: 61223
		private int opl_p0;

		// Token: 0x0400EF28 RID: 61224
		private int opl_p1;

		// Token: 0x0400EF29 RID: 61225
		private int opl_p2;

		// Token: 0x0400EF2A RID: 61226
		private int opl_p3;
	}
}
