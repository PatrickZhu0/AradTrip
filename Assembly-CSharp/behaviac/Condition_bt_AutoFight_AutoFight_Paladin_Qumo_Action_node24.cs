using System;

namespace behaviac
{
	// Token: 0x020027C9 RID: 10185
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node24 : Condition
	{
		// Token: 0x060138D1 RID: 80081 RVA: 0x005D498B File Offset: 0x005D2D8B
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node24()
		{
			this.opl_p0 = 3601;
		}

		// Token: 0x060138D2 RID: 80082 RVA: 0x005D49A0 File Offset: 0x005D2DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D330 RID: 54064
		private int opl_p0;
	}
}
