using System;

namespace behaviac
{
	// Token: 0x0200223E RID: 8766
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node2 : Condition
	{
		// Token: 0x06012E05 RID: 77317 RVA: 0x0059037B File Offset: 0x0058E77B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012E06 RID: 77318 RVA: 0x00590398 File Offset: 0x0058E798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7FF RID: 51199
		private BE_Target opl_p0;

		// Token: 0x0400C800 RID: 51200
		private BE_Equal opl_p1;

		// Token: 0x0400C801 RID: 51201
		private BE_State opl_p2;
	}
}
