using System;

namespace behaviac
{
	// Token: 0x0200238A RID: 9098
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node54 : Condition
	{
		// Token: 0x0601307B RID: 77947 RVA: 0x005A1226 File Offset: 0x0059F626
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node54()
		{
			this.opl_p0 = 0.69f;
		}

		// Token: 0x0601307C RID: 77948 RVA: 0x005A123C File Offset: 0x0059F63C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA91 RID: 51857
		private float opl_p0;
	}
}
