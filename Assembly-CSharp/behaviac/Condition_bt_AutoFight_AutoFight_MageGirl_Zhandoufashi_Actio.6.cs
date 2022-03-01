using System;

namespace behaviac
{
	// Token: 0x02002708 RID: 9992
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node78 : Condition
	{
		// Token: 0x06013752 RID: 79698 RVA: 0x005CC2E9 File Offset: 0x005CA6E9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node78()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013753 RID: 79699 RVA: 0x005CC2FC File Offset: 0x005CA6FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1AB RID: 53675
		private float opl_p0;
	}
}
