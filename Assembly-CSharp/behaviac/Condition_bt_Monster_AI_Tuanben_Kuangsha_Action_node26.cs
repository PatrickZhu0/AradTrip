using System;

namespace behaviac
{
	// Token: 0x02003AC7 RID: 15047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node26 : Condition
	{
		// Token: 0x06015D4D RID: 89421 RVA: 0x006987A1 File Offset: 0x00696BA1
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node26()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015D4E RID: 89422 RVA: 0x006987D8 File Offset: 0x00696BD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F65B RID: 63067
		private int opl_p0;

		// Token: 0x0400F65C RID: 63068
		private int opl_p1;

		// Token: 0x0400F65D RID: 63069
		private int opl_p2;

		// Token: 0x0400F65E RID: 63070
		private int opl_p3;
	}
}
