using System;

namespace behaviac
{
	// Token: 0x02003418 RID: 13336
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node14 : Condition
	{
		// Token: 0x06015081 RID: 86145 RVA: 0x00655F15 File Offset: 0x00654315
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node14()
		{
			this.opl_p0 = 6223;
		}

		// Token: 0x06015082 RID: 86146 RVA: 0x00655F28 File Offset: 0x00654328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E957 RID: 59735
		private int opl_p0;
	}
}
