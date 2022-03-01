using System;

namespace behaviac
{
	// Token: 0x020039B7 RID: 14775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node20 : Condition
	{
		// Token: 0x06015B41 RID: 88897 RVA: 0x0068E149 File Offset: 0x0068C549
		public Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node20()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06015B42 RID: 88898 RVA: 0x0068E15C File Offset: 0x0068C55C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B1 RID: 62641
		private float opl_p0;
	}
}
