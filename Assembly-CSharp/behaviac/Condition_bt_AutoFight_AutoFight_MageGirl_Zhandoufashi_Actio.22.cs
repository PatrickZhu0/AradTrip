using System;

namespace behaviac
{
	// Token: 0x0200271D RID: 10013
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node44 : Condition
	{
		// Token: 0x0601377C RID: 79740 RVA: 0x005CCBCD File Offset: 0x005CAFCD
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node44()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601377D RID: 79741 RVA: 0x005CCBE0 File Offset: 0x005CAFE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1D7 RID: 53719
		private float opl_p0;
	}
}
