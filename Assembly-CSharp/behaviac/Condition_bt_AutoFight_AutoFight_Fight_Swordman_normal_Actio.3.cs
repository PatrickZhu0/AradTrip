using System;

namespace behaviac
{
	// Token: 0x0200243C RID: 9276
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node12 : Condition
	{
		// Token: 0x060131CE RID: 78286 RVA: 0x005AB8E7 File Offset: 0x005A9CE7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060131CF RID: 78287 RVA: 0x005AB904 File Offset: 0x005A9D04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBF7 RID: 52215
		private BE_Target opl_p0;

		// Token: 0x0400CBF8 RID: 52216
		private BE_Equal opl_p1;

		// Token: 0x0400CBF9 RID: 52217
		private BE_State opl_p2;
	}
}
