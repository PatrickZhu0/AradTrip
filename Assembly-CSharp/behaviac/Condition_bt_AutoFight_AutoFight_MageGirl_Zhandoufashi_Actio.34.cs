using System;

namespace behaviac
{
	// Token: 0x0200272D RID: 10029
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node64 : Condition
	{
		// Token: 0x0601379C RID: 79772 RVA: 0x005CD29D File Offset: 0x005CB69D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node64()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601379D RID: 79773 RVA: 0x005CD2B0 File Offset: 0x005CB6B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1F7 RID: 53751
		private float opl_p0;
	}
}
