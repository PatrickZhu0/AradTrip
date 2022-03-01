using System;

namespace behaviac
{
	// Token: 0x0200224E RID: 8782
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node32 : Condition
	{
		// Token: 0x06012E24 RID: 77348 RVA: 0x00590DBF File Offset: 0x0058F1BF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node32()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012E25 RID: 77349 RVA: 0x00590DD4 File Offset: 0x0058F1D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C82A RID: 51242
		private float opl_p0;
	}
}
