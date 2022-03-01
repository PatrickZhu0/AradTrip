using System;

namespace behaviac
{
	// Token: 0x02001F31 RID: 7985
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node58 : Condition
	{
		// Token: 0x06012805 RID: 75781 RVA: 0x0056A4FA File Offset: 0x005688FA
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node58()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012806 RID: 75782 RVA: 0x0056A510 File Offset: 0x00568910
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1FB RID: 49659
		private float opl_p0;
	}
}
