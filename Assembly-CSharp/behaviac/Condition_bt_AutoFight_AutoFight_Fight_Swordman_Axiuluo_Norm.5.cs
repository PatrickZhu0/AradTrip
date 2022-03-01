using System;

namespace behaviac
{
	// Token: 0x02002247 RID: 8775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11 : Condition
	{
		// Token: 0x06012E16 RID: 77334 RVA: 0x00590A7E File Offset: 0x0058EE7E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node11()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171901;
		}

		// Token: 0x06012E17 RID: 77335 RVA: 0x00590AA0 File Offset: 0x0058EEA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C814 RID: 51220
		private BE_Target opl_p0;

		// Token: 0x0400C815 RID: 51221
		private BE_Equal opl_p1;

		// Token: 0x0400C816 RID: 51222
		private int opl_p2;
	}
}
