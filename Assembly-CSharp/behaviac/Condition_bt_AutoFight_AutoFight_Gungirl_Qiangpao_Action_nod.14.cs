using System;

namespace behaviac
{
	// Token: 0x02002525 RID: 9509
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node56 : Condition
	{
		// Token: 0x06013393 RID: 78739 RVA: 0x005B62F5 File Offset: 0x005B46F5
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node56()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013394 RID: 78740 RVA: 0x005B6308 File Offset: 0x005B4708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDB7 RID: 52663
		private float opl_p0;
	}
}
