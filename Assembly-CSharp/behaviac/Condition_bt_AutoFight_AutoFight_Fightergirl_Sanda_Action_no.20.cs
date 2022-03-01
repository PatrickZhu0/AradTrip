using System;

namespace behaviac
{
	// Token: 0x02001F3E RID: 7998
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node30 : Condition
	{
		// Token: 0x0601281F RID: 75807 RVA: 0x0056AA92 File Offset: 0x00568E92
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node30()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012820 RID: 75808 RVA: 0x0056AAA8 File Offset: 0x00568EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C217 RID: 49687
		private float opl_p0;
	}
}
