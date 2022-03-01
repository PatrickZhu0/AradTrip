using System;

namespace behaviac
{
	// Token: 0x0200368A RID: 13962
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3 : Condition
	{
		// Token: 0x06015532 RID: 87346 RVA: 0x0066EAB9 File Offset: 0x0066CEB9
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015533 RID: 87347 RVA: 0x0066EACC File Offset: 0x0066CECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEF6 RID: 61174
		private float opl_p0;
	}
}
