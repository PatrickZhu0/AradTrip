using System;

namespace behaviac
{
	// Token: 0x02002205 RID: 8709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node5 : Condition
	{
		// Token: 0x06012D94 RID: 77204 RVA: 0x0058CB17 File Offset: 0x0058AF17
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012D95 RID: 77205 RVA: 0x0058CB2C File Offset: 0x0058AF2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C77E RID: 51070
		private float opl_p0;
	}
}
