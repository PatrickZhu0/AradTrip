using System;

namespace behaviac
{
	// Token: 0x02002429 RID: 9257
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node37 : Condition
	{
		// Token: 0x060131AA RID: 78250 RVA: 0x005AA3CA File Offset: 0x005A87CA
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node37()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060131AB RID: 78251 RVA: 0x005AA3E0 File Offset: 0x005A87E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBD1 RID: 52177
		private float opl_p0;
	}
}
