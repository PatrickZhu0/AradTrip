using System;

namespace behaviac
{
	// Token: 0x02001E5A RID: 7770
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node14 : Condition
	{
		// Token: 0x06012661 RID: 75361 RVA: 0x005606C1 File Offset: 0x0055EAC1
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012662 RID: 75362 RVA: 0x005606D4 File Offset: 0x0055EAD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C04A RID: 49226
		private float opl_p0;
	}
}
