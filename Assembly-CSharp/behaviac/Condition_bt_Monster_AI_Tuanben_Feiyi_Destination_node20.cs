using System;

namespace behaviac
{
	// Token: 0x020039C7 RID: 14791
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node20 : Condition
	{
		// Token: 0x06015B60 RID: 88928 RVA: 0x0068E96D File Offset: 0x0068CD6D
		public Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node20()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015B61 RID: 88929 RVA: 0x0068E980 File Offset: 0x0068CD80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4BA RID: 62650
		private float opl_p0;
	}
}
