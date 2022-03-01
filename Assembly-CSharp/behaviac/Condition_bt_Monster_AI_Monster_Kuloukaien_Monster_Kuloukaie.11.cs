using System;

namespace behaviac
{
	// Token: 0x020036B8 RID: 14008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node3 : Condition
	{
		// Token: 0x0601558A RID: 87434 RVA: 0x0067053D File Offset: 0x0066E93D
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node3()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601558B RID: 87435 RVA: 0x00670550 File Offset: 0x0066E950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF60 RID: 61280
		private float opl_p0;
	}
}
