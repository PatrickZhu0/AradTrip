using System;

namespace behaviac
{
	// Token: 0x02002430 RID: 9264
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node66 : Condition
	{
		// Token: 0x060131B8 RID: 78264 RVA: 0x005AA6A1 File Offset: 0x005A8AA1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node66()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060131B9 RID: 78265 RVA: 0x005AA6C0 File Offset: 0x005A8AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBE1 RID: 52193
		private BE_Target opl_p0;

		// Token: 0x0400CBE2 RID: 52194
		private BE_Equal opl_p1;

		// Token: 0x0400CBE3 RID: 52195
		private BE_State opl_p2;
	}
}
