using System;

namespace behaviac
{
	// Token: 0x0200368E RID: 13966
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node8 : Condition
	{
		// Token: 0x0601553A RID: 87354 RVA: 0x0066EC6D File Offset: 0x0066D06D
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601553B RID: 87355 RVA: 0x0066EC80 File Offset: 0x0066D080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEFE RID: 61182
		private float opl_p0;
	}
}
