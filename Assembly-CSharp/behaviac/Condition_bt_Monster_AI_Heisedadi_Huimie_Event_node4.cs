using System;

namespace behaviac
{
	// Token: 0x02003421 RID: 13345
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node4 : Condition
	{
		// Token: 0x06015091 RID: 86161 RVA: 0x006567EE File Offset: 0x00654BEE
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node4()
		{
			this.opl_p0 = 6219;
		}

		// Token: 0x06015092 RID: 86162 RVA: 0x00656804 File Offset: 0x00654C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E962 RID: 59746
		private int opl_p0;
	}
}
