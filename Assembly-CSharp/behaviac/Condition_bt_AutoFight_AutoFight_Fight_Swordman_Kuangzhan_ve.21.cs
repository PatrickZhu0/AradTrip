using System;

namespace behaviac
{
	// Token: 0x0200242B RID: 9259
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node39 : Condition
	{
		// Token: 0x060131AE RID: 78254 RVA: 0x005AA48D File Offset: 0x005A888D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060131AF RID: 78255 RVA: 0x005AA4AC File Offset: 0x005A88AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBD6 RID: 52182
		private BE_Target opl_p0;

		// Token: 0x0400CBD7 RID: 52183
		private BE_Equal opl_p1;

		// Token: 0x0400CBD8 RID: 52184
		private BE_State opl_p2;
	}
}
