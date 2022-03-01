using System;

namespace behaviac
{
	// Token: 0x02001FE3 RID: 8163
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node47 : Condition
	{
		// Token: 0x06012963 RID: 76131 RVA: 0x005722D2 File Offset: 0x005706D2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node47()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012964 RID: 76132 RVA: 0x005722E8 File Offset: 0x005706E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C355 RID: 50005
		private float opl_p0;
	}
}
