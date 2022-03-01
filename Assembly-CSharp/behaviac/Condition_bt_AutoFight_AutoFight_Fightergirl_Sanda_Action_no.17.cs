using System;

namespace behaviac
{
	// Token: 0x02001F3A RID: 7994
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node87 : Condition
	{
		// Token: 0x06012817 RID: 75799 RVA: 0x0056A8DA File Offset: 0x00568CDA
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node87()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012818 RID: 75800 RVA: 0x0056A8F0 File Offset: 0x00568CF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C20F RID: 49679
		private float opl_p0;
	}
}
