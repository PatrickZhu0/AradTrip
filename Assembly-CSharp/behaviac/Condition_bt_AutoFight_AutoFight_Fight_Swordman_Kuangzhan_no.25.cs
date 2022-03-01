using System;

namespace behaviac
{
	// Token: 0x020023FF RID: 9215
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node52 : Condition
	{
		// Token: 0x0601315D RID: 78173 RVA: 0x005A83C5 File Offset: 0x005A67C5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601315E RID: 78174 RVA: 0x005A83E4 File Offset: 0x005A67E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB88 RID: 52104
		private BE_Target opl_p0;

		// Token: 0x0400CB89 RID: 52105
		private BE_Equal opl_p1;

		// Token: 0x0400CB8A RID: 52106
		private BE_State opl_p2;
	}
}
