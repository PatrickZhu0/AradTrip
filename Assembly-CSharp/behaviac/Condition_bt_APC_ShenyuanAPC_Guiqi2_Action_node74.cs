using System;

namespace behaviac
{
	// Token: 0x02001E42 RID: 7746
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node74 : Condition
	{
		// Token: 0x06012631 RID: 75313 RVA: 0x0055F98F File Offset: 0x0055DD8F
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node74()
		{
			this.opl_p0 = 9725;
		}

		// Token: 0x06012632 RID: 75314 RVA: 0x0055F9A4 File Offset: 0x0055DDA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C018 RID: 49176
		private int opl_p0;
	}
}
