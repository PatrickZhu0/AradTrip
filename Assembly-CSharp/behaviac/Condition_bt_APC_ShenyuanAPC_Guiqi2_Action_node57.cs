using System;

namespace behaviac
{
	// Token: 0x02001E57 RID: 7767
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node57 : Condition
	{
		// Token: 0x0601265B RID: 75355 RVA: 0x00560553 File Offset: 0x0055E953
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node57()
		{
			this.opl_p0 = 9733;
		}

		// Token: 0x0601265C RID: 75356 RVA: 0x00560568 File Offset: 0x0055E968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C043 RID: 49219
		private int opl_p0;
	}
}
