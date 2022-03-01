using System;

namespace behaviac
{
	// Token: 0x02003176 RID: 12662
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node26 : Condition
	{
		// Token: 0x06014B83 RID: 84867 RVA: 0x0063D3D5 File Offset: 0x0063B7D5
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014B84 RID: 84868 RVA: 0x0063D40C File Offset: 0x0063B80C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4EF RID: 58607
		private int opl_p0;

		// Token: 0x0400E4F0 RID: 58608
		private int opl_p1;

		// Token: 0x0400E4F1 RID: 58609
		private int opl_p2;

		// Token: 0x0400E4F2 RID: 58610
		private int opl_p3;
	}
}
