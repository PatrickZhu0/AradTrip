using System;

namespace behaviac
{
	// Token: 0x02002778 RID: 10104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node22 : Condition
	{
		// Token: 0x06013831 RID: 79921 RVA: 0x005D07B1 File Offset: 0x005CEBB1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013832 RID: 79922 RVA: 0x005D07C4 File Offset: 0x005CEBC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D293 RID: 53907
		private float opl_p0;
	}
}
