using System;

namespace behaviac
{
	// Token: 0x02002535 RID: 9525
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node60 : Condition
	{
		// Token: 0x060133B3 RID: 78771 RVA: 0x005B6A19 File Offset: 0x005B4E19
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node60()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060133B4 RID: 78772 RVA: 0x005B6A2C File Offset: 0x005B4E2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDDB RID: 52699
		private float opl_p0;
	}
}
