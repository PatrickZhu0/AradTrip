using System;

namespace behaviac
{
	// Token: 0x020036B4 RID: 14004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node18 : Condition
	{
		// Token: 0x06015582 RID: 87426 RVA: 0x00670389 File Offset: 0x0066E789
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node18()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015583 RID: 87427 RVA: 0x0067039C File Offset: 0x0066E79C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF58 RID: 61272
		private float opl_p0;
	}
}
