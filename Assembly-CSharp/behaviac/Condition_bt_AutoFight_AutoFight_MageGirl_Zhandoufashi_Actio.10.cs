using System;

namespace behaviac
{
	// Token: 0x0200270D RID: 9997
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node97 : Condition
	{
		// Token: 0x0601375C RID: 79708 RVA: 0x005CC4E2 File Offset: 0x005CA8E2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node97()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x0601375D RID: 79709 RVA: 0x005CC4F8 File Offset: 0x005CA8F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1B5 RID: 53685
		private float opl_p0;
	}
}
