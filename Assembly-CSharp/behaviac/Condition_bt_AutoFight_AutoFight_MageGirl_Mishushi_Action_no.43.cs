using System;

namespace behaviac
{
	// Token: 0x020026E8 RID: 9960
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node46 : Condition
	{
		// Token: 0x06013713 RID: 79635 RVA: 0x005C9DD3 File Offset: 0x005C81D3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node46()
		{
			this.opl_p0 = 2003;
		}

		// Token: 0x06013714 RID: 79636 RVA: 0x005C9DE8 File Offset: 0x005C81E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D16A RID: 53610
		private int opl_p0;
	}
}
