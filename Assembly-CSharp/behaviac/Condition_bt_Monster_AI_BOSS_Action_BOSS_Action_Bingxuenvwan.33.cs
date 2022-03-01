using System;

namespace behaviac
{
	// Token: 0x02002F97 RID: 12183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node44 : Condition
	{
		// Token: 0x060147FC RID: 83964 RVA: 0x0062AD6E File Offset: 0x0062916E
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node44()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060147FD RID: 83965 RVA: 0x0062ADA4 File Offset: 0x006291A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E15F RID: 57695
		private int opl_p0;

		// Token: 0x0400E160 RID: 57696
		private int opl_p1;

		// Token: 0x0400E161 RID: 57697
		private int opl_p2;

		// Token: 0x0400E162 RID: 57698
		private int opl_p3;
	}
}
