using System;

namespace behaviac
{
	// Token: 0x02001F29 RID: 7977
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node18 : Condition
	{
		// Token: 0x060127F5 RID: 75765 RVA: 0x0056A1C2 File Offset: 0x005685C2
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node18()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060127F6 RID: 75766 RVA: 0x0056A1D8 File Offset: 0x005685D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1ED RID: 49645
		private float opl_p0;
	}
}
