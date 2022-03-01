using System;

namespace behaviac
{
	// Token: 0x02002545 RID: 9541
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node77 : Condition
	{
		// Token: 0x060133D3 RID: 78803 RVA: 0x005B70F5 File Offset: 0x005B54F5
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node77()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133D4 RID: 78804 RVA: 0x005B7108 File Offset: 0x005B5508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDFB RID: 52731
		private float opl_p0;
	}
}
