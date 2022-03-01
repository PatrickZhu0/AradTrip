using System;

namespace behaviac
{
	// Token: 0x02001F4F RID: 8015
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node26 : Condition
	{
		// Token: 0x06012841 RID: 75841 RVA: 0x0056B23E File Offset: 0x0056963E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node26()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06012842 RID: 75842 RVA: 0x0056B254 File Offset: 0x00569654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C23B RID: 49723
		private float opl_p0;
	}
}
