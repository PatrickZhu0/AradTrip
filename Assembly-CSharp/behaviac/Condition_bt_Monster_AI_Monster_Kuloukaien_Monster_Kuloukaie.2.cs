using System;

namespace behaviac
{
	// Token: 0x020036AC RID: 13996
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node8 : Condition
	{
		// Token: 0x06015572 RID: 87410 RVA: 0x00670021 File Offset: 0x0066E421
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015573 RID: 87411 RVA: 0x00670034 File Offset: 0x0066E434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF48 RID: 61256
		private float opl_p0;
	}
}
