using System;

namespace behaviac
{
	// Token: 0x02003629 RID: 13865
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node8 : Condition
	{
		// Token: 0x06015476 RID: 87158 RVA: 0x0066A429 File Offset: 0x00668829
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015477 RID: 87159 RVA: 0x0066A43C File Offset: 0x0066883C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE31 RID: 60977
		private float opl_p0;
	}
}
