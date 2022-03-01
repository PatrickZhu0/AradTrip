using System;

namespace behaviac
{
	// Token: 0x02002267 RID: 8807
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node9 : Condition
	{
		// Token: 0x06012E54 RID: 77396 RVA: 0x0059292F File Offset: 0x00590D2F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012E55 RID: 77397 RVA: 0x0059294C File Offset: 0x00590D4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C861 RID: 51297
		private BE_Target opl_p0;

		// Token: 0x0400C862 RID: 51298
		private BE_Equal opl_p1;

		// Token: 0x0400C863 RID: 51299
		private BE_State opl_p2;
	}
}
