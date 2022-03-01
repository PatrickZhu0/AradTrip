using System;

namespace behaviac
{
	// Token: 0x020024B3 RID: 9395
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node28 : Condition
	{
		// Token: 0x060132B1 RID: 78513 RVA: 0x005B0819 File Offset: 0x005AEC19
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node28()
		{
			this.opl_p0 = 2509;
		}

		// Token: 0x060132B2 RID: 78514 RVA: 0x005B082C File Offset: 0x005AEC2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCCC RID: 52428
		private int opl_p0;
	}
}
