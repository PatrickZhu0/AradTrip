using System;

namespace behaviac
{
	// Token: 0x02001E56 RID: 7766
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node54 : Condition
	{
		// Token: 0x06012659 RID: 75353 RVA: 0x0056050D File Offset: 0x0055E90D
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node54()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601265A RID: 75354 RVA: 0x00560520 File Offset: 0x0055E920
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C042 RID: 49218
		private float opl_p0;
	}
}
