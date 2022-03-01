using System;

namespace behaviac
{
	// Token: 0x0200361D RID: 13853
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node28 : Condition
	{
		// Token: 0x0601545E RID: 87134 RVA: 0x00669F0D File Offset: 0x0066830D
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601545F RID: 87135 RVA: 0x00669F20 File Offset: 0x00668320
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE19 RID: 60953
		private float opl_p0;
	}
}
