using System;

namespace behaviac
{
	// Token: 0x020039B9 RID: 14777
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node25 : Condition
	{
		// Token: 0x06015B45 RID: 88901 RVA: 0x0068E1B9 File Offset: 0x0068C5B9
		public Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node25()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06015B46 RID: 88902 RVA: 0x0068E1CC File Offset: 0x0068C5CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B3 RID: 62643
		private float opl_p0;
	}
}
