using System;

namespace behaviac
{
	// Token: 0x02001FB3 RID: 8115
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node17 : Condition
	{
		// Token: 0x06012904 RID: 76036 RVA: 0x0057055E File Offset: 0x0056E95E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node17()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012905 RID: 76037 RVA: 0x00570574 File Offset: 0x0056E974
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2F6 RID: 49910
		private float opl_p0;
	}
}
