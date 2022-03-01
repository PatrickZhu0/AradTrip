using System;

namespace behaviac
{
	// Token: 0x020026D8 RID: 9944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node96 : Condition
	{
		// Token: 0x060136F3 RID: 79603 RVA: 0x005C9705 File Offset: 0x005C7B05
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node96()
		{
			this.opl_p0 = 2211;
		}

		// Token: 0x060136F4 RID: 79604 RVA: 0x005C9718 File Offset: 0x005C7B18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D14A RID: 53578
		private int opl_p0;
	}
}
