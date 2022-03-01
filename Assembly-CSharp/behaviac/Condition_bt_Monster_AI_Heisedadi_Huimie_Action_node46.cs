using System;

namespace behaviac
{
	// Token: 0x0200340A RID: 13322
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node46 : Condition
	{
		// Token: 0x06015065 RID: 86117 RVA: 0x00655999 File Offset: 0x00653D99
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node46()
		{
			this.opl_p0 = 6217;
		}

		// Token: 0x06015066 RID: 86118 RVA: 0x006559AC File Offset: 0x00653DAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E940 RID: 59712
		private int opl_p0;
	}
}
