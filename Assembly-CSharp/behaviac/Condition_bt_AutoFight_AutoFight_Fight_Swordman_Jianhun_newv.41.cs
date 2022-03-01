using System;

namespace behaviac
{
	// Token: 0x020022E6 RID: 8934
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node2 : Condition
	{
		// Token: 0x06012F46 RID: 77638 RVA: 0x00599DCF File Offset: 0x005981CF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012F47 RID: 77639 RVA: 0x00599DEC File Offset: 0x005981EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C956 RID: 51542
		private BE_Target opl_p0;

		// Token: 0x0400C957 RID: 51543
		private BE_Equal opl_p1;

		// Token: 0x0400C958 RID: 51544
		private BE_State opl_p2;
	}
}
