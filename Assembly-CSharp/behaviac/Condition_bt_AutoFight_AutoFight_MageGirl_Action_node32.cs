using System;

namespace behaviac
{
	// Token: 0x020026A5 RID: 9893
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node32 : Condition
	{
		// Token: 0x0601368E RID: 79502 RVA: 0x005C7411 File Offset: 0x005C5811
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node32()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601368F RID: 79503 RVA: 0x005C7424 File Offset: 0x005C5824
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0E3 RID: 53475
		private float opl_p0;
	}
}
