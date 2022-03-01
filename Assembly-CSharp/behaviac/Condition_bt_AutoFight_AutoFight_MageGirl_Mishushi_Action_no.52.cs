using System;

namespace behaviac
{
	// Token: 0x020026F4 RID: 9972
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node71 : Condition
	{
		// Token: 0x0601372B RID: 79659 RVA: 0x005CA2EF File Offset: 0x005C86EF
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node71()
		{
			this.opl_p0 = 2008;
		}

		// Token: 0x0601372C RID: 79660 RVA: 0x005CA304 File Offset: 0x005C8704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D182 RID: 53634
		private int opl_p0;
	}
}
