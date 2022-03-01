using System;

namespace behaviac
{
	// Token: 0x020026F8 RID: 9976
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node23 : Condition
	{
		// Token: 0x06013733 RID: 79667 RVA: 0x005CA4A3 File Offset: 0x005C88A3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node23()
		{
			this.opl_p0 = 2011;
		}

		// Token: 0x06013734 RID: 79668 RVA: 0x005CA4B8 File Offset: 0x005C88B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D18A RID: 53642
		private int opl_p0;
	}
}
