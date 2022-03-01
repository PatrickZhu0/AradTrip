using System;

namespace behaviac
{
	// Token: 0x0200340B RID: 13323
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node3 : Condition
	{
		// Token: 0x06015067 RID: 86119 RVA: 0x006559DF File Offset: 0x00653DDF
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015068 RID: 86120 RVA: 0x006559F4 File Offset: 0x00653DF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E941 RID: 59713
		private float opl_p0;
	}
}
