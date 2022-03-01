using System;

namespace behaviac
{
	// Token: 0x02001E4F RID: 7759
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node16 : Condition
	{
		// Token: 0x0601264B RID: 75339 RVA: 0x0055FF07 File Offset: 0x0055E307
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node16()
		{
			this.opl_p0 = 9732;
		}

		// Token: 0x0601264C RID: 75340 RVA: 0x0055FF1C File Offset: 0x0055E31C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C033 RID: 49203
		private int opl_p0;
	}
}
