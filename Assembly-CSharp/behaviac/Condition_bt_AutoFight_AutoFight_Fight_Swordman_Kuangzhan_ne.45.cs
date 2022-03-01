using System;

namespace behaviac
{
	// Token: 0x020023CD RID: 9165
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node0 : Condition
	{
		// Token: 0x06013100 RID: 78080 RVA: 0x005A5883 File Offset: 0x005A3C83
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 160900;
		}

		// Token: 0x06013101 RID: 78081 RVA: 0x005A58A4 File Offset: 0x005A3CA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB31 RID: 52017
		private BE_Target opl_p0;

		// Token: 0x0400CB32 RID: 52018
		private BE_Equal opl_p1;

		// Token: 0x0400CB33 RID: 52019
		private int opl_p2;
	}
}
