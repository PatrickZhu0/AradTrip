using System;

namespace behaviac
{
	// Token: 0x02001D24 RID: 7460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node54 : Condition
	{
		// Token: 0x0601240B RID: 74763 RVA: 0x00552246 File Offset: 0x00550646
		public Condition_bt_APC_APC_Guiqi2_Action_node54()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601240C RID: 74764 RVA: 0x0055225C File Offset: 0x0055065C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDFA RID: 48634
		private float opl_p0;
	}
}
