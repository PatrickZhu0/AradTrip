using System;

namespace behaviac
{
	// Token: 0x020024B7 RID: 9399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node33 : Condition
	{
		// Token: 0x060132B9 RID: 78521 RVA: 0x005B0A7D File Offset: 0x005AEE7D
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node33()
		{
			this.opl_p0 = 2507;
		}

		// Token: 0x060132BA RID: 78522 RVA: 0x005B0A90 File Offset: 0x005AEE90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCD4 RID: 52436
		private int opl_p0;
	}
}
