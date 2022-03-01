using System;

namespace behaviac
{
	// Token: 0x02002435 RID: 9269
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node56 : Condition
	{
		// Token: 0x060131C2 RID: 78274 RVA: 0x005AA8B5 File Offset: 0x005A8CB5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node56()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060131C3 RID: 78275 RVA: 0x005AA8D4 File Offset: 0x005A8CD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBEC RID: 52204
		private BE_Target opl_p0;

		// Token: 0x0400CBED RID: 52205
		private BE_Equal opl_p1;

		// Token: 0x0400CBEE RID: 52206
		private BE_State opl_p2;
	}
}
