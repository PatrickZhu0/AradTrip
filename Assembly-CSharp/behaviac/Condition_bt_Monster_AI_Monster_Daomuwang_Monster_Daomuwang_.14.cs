using System;

namespace behaviac
{
	// Token: 0x0200362D RID: 13869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node18 : Condition
	{
		// Token: 0x0601547E RID: 87166 RVA: 0x0066A5DD File Offset: 0x006689DD
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node18()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601547F RID: 87167 RVA: 0x0066A5F0 File Offset: 0x006689F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE39 RID: 60985
		private float opl_p0;
	}
}
