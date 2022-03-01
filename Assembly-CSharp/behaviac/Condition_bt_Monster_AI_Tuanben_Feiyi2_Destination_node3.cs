using System;

namespace behaviac
{
	// Token: 0x020039A7 RID: 14759
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node3 : Condition
	{
		// Token: 0x06015B22 RID: 88866 RVA: 0x0068D9CE File Offset: 0x0068BDCE
		public Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node3()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06015B23 RID: 88867 RVA: 0x0068D9E4 File Offset: 0x0068BDE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A8 RID: 62632
		private float opl_p0;
	}
}
