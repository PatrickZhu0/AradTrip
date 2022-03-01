using System;

namespace behaviac
{
	// Token: 0x02002715 RID: 10005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node4 : Condition
	{
		// Token: 0x0601376C RID: 79724 RVA: 0x005CC865 File Offset: 0x005CAC65
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node4()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601376D RID: 79725 RVA: 0x005CC878 File Offset: 0x005CAC78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1C7 RID: 53703
		private float opl_p0;
	}
}
