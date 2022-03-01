using System;

namespace behaviac
{
	// Token: 0x02001F25 RID: 7973
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node1 : Condition
	{
		// Token: 0x060127ED RID: 75757 RVA: 0x0056A027 File Offset: 0x00568427
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node1()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060127EE RID: 75758 RVA: 0x0056A03C File Offset: 0x0056843C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1E6 RID: 49638
		private float opl_p0;
	}
}
