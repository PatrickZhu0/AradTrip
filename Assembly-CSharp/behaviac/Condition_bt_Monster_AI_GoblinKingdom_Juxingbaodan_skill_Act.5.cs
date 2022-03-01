using System;

namespace behaviac
{
	// Token: 0x0200339C RID: 13212
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node2 : Condition
	{
		// Token: 0x06014F93 RID: 85907 RVA: 0x00651AB2 File Offset: 0x0064FEB2
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node2()
		{
			this.opl_p0 = 40000;
			this.opl_p1 = 40000;
			this.opl_p2 = 40000;
			this.opl_p3 = 40000;
		}

		// Token: 0x06014F94 RID: 85908 RVA: 0x00651AE8 File Offset: 0x0064FEE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E86E RID: 59502
		private int opl_p0;

		// Token: 0x0400E86F RID: 59503
		private int opl_p1;

		// Token: 0x0400E870 RID: 59504
		private int opl_p2;

		// Token: 0x0400E871 RID: 59505
		private int opl_p3;
	}
}
