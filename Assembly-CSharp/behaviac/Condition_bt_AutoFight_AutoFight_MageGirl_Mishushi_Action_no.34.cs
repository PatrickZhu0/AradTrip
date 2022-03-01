using System;

namespace behaviac
{
	// Token: 0x020026DC RID: 9948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node51 : Condition
	{
		// Token: 0x060136FB RID: 79611 RVA: 0x005C98B7 File Offset: 0x005C7CB7
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node51()
		{
			this.opl_p0 = 2202;
		}

		// Token: 0x060136FC RID: 79612 RVA: 0x005C98CC File Offset: 0x005C7CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D152 RID: 53586
		private int opl_p0;
	}
}
