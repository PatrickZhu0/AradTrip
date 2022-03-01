using System;

namespace behaviac
{
	// Token: 0x02001E20 RID: 7712
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node8 : Condition
	{
		// Token: 0x060125F1 RID: 75249 RVA: 0x0055DD26 File Offset: 0x0055C126
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node8()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060125F2 RID: 75250 RVA: 0x0055DD58 File Offset: 0x0055C158
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFDA RID: 49114
		private int opl_p0;

		// Token: 0x0400BFDB RID: 49115
		private int opl_p1;

		// Token: 0x0400BFDC RID: 49116
		private int opl_p2;

		// Token: 0x0400BFDD RID: 49117
		private int opl_p3;
	}
}
