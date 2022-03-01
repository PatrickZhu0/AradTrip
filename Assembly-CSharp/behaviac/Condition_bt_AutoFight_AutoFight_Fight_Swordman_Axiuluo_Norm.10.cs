using System;

namespace behaviac
{
	// Token: 0x0200224D RID: 8781
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node31 : Condition
	{
		// Token: 0x06012E22 RID: 77346 RVA: 0x00590D5D File Offset: 0x0058F15D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node31()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012E23 RID: 77347 RVA: 0x00590D80 File Offset: 0x0058F180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C827 RID: 51239
		private BE_Target opl_p0;

		// Token: 0x0400C828 RID: 51240
		private BE_Equal opl_p1;

		// Token: 0x0400C829 RID: 51241
		private int opl_p2;
	}
}
