using System;

namespace behaviac
{
	// Token: 0x02002F56 RID: 12118
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node9 : Condition
	{
		// Token: 0x0601477B RID: 83835 RVA: 0x00628ACE File Offset: 0x00626ECE
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node9()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601477C RID: 83836 RVA: 0x00628B04 File Offset: 0x00626F04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0E9 RID: 57577
		private int opl_p0;

		// Token: 0x0400E0EA RID: 57578
		private int opl_p1;

		// Token: 0x0400E0EB RID: 57579
		private int opl_p2;

		// Token: 0x0400E0EC RID: 57580
		private int opl_p3;
	}
}
