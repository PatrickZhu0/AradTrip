using System;

namespace behaviac
{
	// Token: 0x02003414 RID: 13332
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node4 : Condition
	{
		// Token: 0x06015079 RID: 86137 RVA: 0x00655D6F File Offset: 0x0065416F
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node4()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601507A RID: 86138 RVA: 0x00655D84 File Offset: 0x00654184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E950 RID: 59728
		private float opl_p0;
	}
}
