using System;

namespace behaviac
{
	// Token: 0x02002393 RID: 9107
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node6 : Condition
	{
		// Token: 0x0601308C RID: 77964 RVA: 0x005A2485 File Offset: 0x005A0885
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 160900;
		}

		// Token: 0x0601308D RID: 77965 RVA: 0x005A24A8 File Offset: 0x005A08A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAA3 RID: 51875
		private BE_Target opl_p0;

		// Token: 0x0400CAA4 RID: 51876
		private BE_Equal opl_p1;

		// Token: 0x0400CAA5 RID: 51877
		private int opl_p2;
	}
}
