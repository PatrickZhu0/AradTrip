using System;

namespace behaviac
{
	// Token: 0x02001E41 RID: 7745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node73 : Condition
	{
		// Token: 0x0601262F RID: 75311 RVA: 0x0055F949 File Offset: 0x0055DD49
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node73()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06012630 RID: 75312 RVA: 0x0055F95C File Offset: 0x0055DD5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C017 RID: 49175
		private float opl_p0;
	}
}
