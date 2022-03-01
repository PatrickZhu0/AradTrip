using System;

namespace behaviac
{
	// Token: 0x02001D88 RID: 7560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node40 : Condition
	{
		// Token: 0x060124CB RID: 74955 RVA: 0x0055723F File Offset: 0x0055563F
		public Condition_bt_APC_APC_Kuangzhan2_Action_node40()
		{
			this.opl_p0 = 9716;
		}

		// Token: 0x060124CC RID: 74956 RVA: 0x00557254 File Offset: 0x00555654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEB7 RID: 48823
		private int opl_p0;
	}
}
