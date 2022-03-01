using System;

namespace behaviac
{
	// Token: 0x02003188 RID: 12680
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node30 : Condition
	{
		// Token: 0x06014BA7 RID: 84903 RVA: 0x0063DA8B File Offset: 0x0063BE8B
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node30()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014BA8 RID: 84904 RVA: 0x0063DAC0 File Offset: 0x0063BEC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E513 RID: 58643
		private int opl_p0;

		// Token: 0x0400E514 RID: 58644
		private int opl_p1;

		// Token: 0x0400E515 RID: 58645
		private int opl_p2;

		// Token: 0x0400E516 RID: 58646
		private int opl_p3;
	}
}
