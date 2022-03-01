using System;

namespace behaviac
{
	// Token: 0x020023D7 RID: 9175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2 : Condition
	{
		// Token: 0x06013113 RID: 78099 RVA: 0x005A700B File Offset: 0x005A540B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013114 RID: 78100 RVA: 0x005A7028 File Offset: 0x005A5428
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB41 RID: 52033
		private BE_Target opl_p0;

		// Token: 0x0400CB42 RID: 52034
		private BE_Equal opl_p1;

		// Token: 0x0400CB43 RID: 52035
		private BE_State opl_p2;
	}
}
