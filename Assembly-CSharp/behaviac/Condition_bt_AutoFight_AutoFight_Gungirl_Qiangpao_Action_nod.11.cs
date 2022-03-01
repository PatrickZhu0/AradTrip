using System;

namespace behaviac
{
	// Token: 0x02002521 RID: 9505
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node43 : Condition
	{
		// Token: 0x0601338B RID: 78731 RVA: 0x005B6141 File Offset: 0x005B4541
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node43()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601338C RID: 78732 RVA: 0x005B6154 File Offset: 0x005B4554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDAF RID: 52655
		private float opl_p0;
	}
}
