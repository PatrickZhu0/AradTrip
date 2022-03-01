using System;

namespace behaviac
{
	// Token: 0x020024BB RID: 9403
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node38 : Condition
	{
		// Token: 0x060132C1 RID: 78529 RVA: 0x005B0C31 File Offset: 0x005AF031
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node38()
		{
			this.opl_p0 = 2522;
		}

		// Token: 0x060132C2 RID: 78530 RVA: 0x005B0C44 File Offset: 0x005AF044
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCDC RID: 52444
		private int opl_p0;
	}
}
