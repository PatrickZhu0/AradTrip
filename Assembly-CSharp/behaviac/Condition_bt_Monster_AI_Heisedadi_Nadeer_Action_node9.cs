using System;

namespace behaviac
{
	// Token: 0x020034D7 RID: 13527
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node9 : Condition
	{
		// Token: 0x060151F3 RID: 86515 RVA: 0x0065D776 File Offset: 0x0065BB76
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060151F4 RID: 86516 RVA: 0x0065D7AC File Offset: 0x0065BBAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB06 RID: 60166
		private int opl_p0;

		// Token: 0x0400EB07 RID: 60167
		private int opl_p1;

		// Token: 0x0400EB08 RID: 60168
		private int opl_p2;

		// Token: 0x0400EB09 RID: 60169
		private int opl_p3;
	}
}
