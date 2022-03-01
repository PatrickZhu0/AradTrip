using System;

namespace behaviac
{
	// Token: 0x02002242 RID: 8770
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6 : Condition
	{
		// Token: 0x06012E0C RID: 77324 RVA: 0x00590819 File Offset: 0x0058EC19
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012E0D RID: 77325 RVA: 0x0059083C File Offset: 0x0058EC3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C805 RID: 51205
		private BE_Target opl_p0;

		// Token: 0x0400C806 RID: 51206
		private BE_Equal opl_p1;

		// Token: 0x0400C807 RID: 51207
		private int opl_p2;
	}
}
