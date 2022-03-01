using System;

namespace behaviac
{
	// Token: 0x020024A8 RID: 9384
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node15 : Condition
	{
		// Token: 0x0601329B RID: 78491 RVA: 0x005B01E1 File Offset: 0x005AE5E1
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node15()
		{
			this.opl_p0 = 2508;
		}

		// Token: 0x0601329C RID: 78492 RVA: 0x005B01F4 File Offset: 0x005AE5F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCB5 RID: 52405
		private int opl_p0;
	}
}
