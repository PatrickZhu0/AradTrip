using System;

namespace behaviac
{
	// Token: 0x02003621 RID: 13857
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node3 : Condition
	{
		// Token: 0x06015466 RID: 87142 RVA: 0x0066A0C1 File Offset: 0x006684C1
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015467 RID: 87143 RVA: 0x0066A0D4 File Offset: 0x006684D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE21 RID: 60961
		private float opl_p0;
	}
}
