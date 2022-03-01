using System;

namespace behaviac
{
	// Token: 0x02003A53 RID: 14931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node39 : Condition
	{
		// Token: 0x06015C6F RID: 89199 RVA: 0x00693BFB File Offset: 0x00691FFB
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node39()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 6000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06015C70 RID: 89200 RVA: 0x00693C30 File Offset: 0x00692030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F598 RID: 62872
		private int opl_p0;

		// Token: 0x0400F599 RID: 62873
		private int opl_p1;

		// Token: 0x0400F59A RID: 62874
		private int opl_p2;

		// Token: 0x0400F59B RID: 62875
		private int opl_p3;
	}
}
