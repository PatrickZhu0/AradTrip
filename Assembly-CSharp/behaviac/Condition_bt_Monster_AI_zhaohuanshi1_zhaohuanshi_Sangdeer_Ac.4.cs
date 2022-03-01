using System;

namespace behaviac
{
	// Token: 0x02004097 RID: 16535
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node9 : Condition
	{
		// Token: 0x06016889 RID: 92297 RVA: 0x006D2A16 File Offset: 0x006D0E16
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node9()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601688A RID: 92298 RVA: 0x006D2A2C File Offset: 0x006D0E2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100D2 RID: 65746
		private float opl_p0;
	}
}
