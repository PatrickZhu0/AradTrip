using System;

namespace behaviac
{
	// Token: 0x02001ED1 RID: 7889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node5 : Condition
	{
		// Token: 0x06012747 RID: 75591 RVA: 0x0056616B File Offset: 0x0056456B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node5()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012748 RID: 75592 RVA: 0x00566188 File Offset: 0x00564588
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C138 RID: 49464
		private BE_Target opl_p0;

		// Token: 0x0400C139 RID: 49465
		private BE_Equal opl_p1;

		// Token: 0x0400C13A RID: 49466
		private BE_State opl_p2;
	}
}
