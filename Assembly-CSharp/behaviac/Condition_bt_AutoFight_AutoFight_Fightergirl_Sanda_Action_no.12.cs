using System;

namespace behaviac
{
	// Token: 0x02001F33 RID: 7987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node57 : Condition
	{
		// Token: 0x06012809 RID: 75785 RVA: 0x0056A58B File Offset: 0x0056898B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node57()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601280A RID: 75786 RVA: 0x0056A5C0 File Offset: 0x005689C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1FD RID: 49661
		private int opl_p0;

		// Token: 0x0400C1FE RID: 49662
		private int opl_p1;

		// Token: 0x0400C1FF RID: 49663
		private int opl_p2;

		// Token: 0x0400C200 RID: 49664
		private int opl_p3;
	}
}
