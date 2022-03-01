using System;

namespace behaviac
{
	// Token: 0x02003472 RID: 13426
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4 : Condition
	{
		// Token: 0x0601512F RID: 86319 RVA: 0x0065994A File Offset: 0x00657D4A
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06015130 RID: 86320 RVA: 0x00659960 File Offset: 0x00657D60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA33 RID: 59955
		private float opl_p0;
	}
}
