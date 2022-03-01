using System;

namespace behaviac
{
	// Token: 0x02001EEB RID: 7915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node24 : Condition
	{
		// Token: 0x0601277B RID: 75643 RVA: 0x00566C79 File Offset: 0x00565079
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node24()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601277C RID: 75644 RVA: 0x00566C8C File Offset: 0x0056508C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C171 RID: 49521
		private float opl_p0;
	}
}
