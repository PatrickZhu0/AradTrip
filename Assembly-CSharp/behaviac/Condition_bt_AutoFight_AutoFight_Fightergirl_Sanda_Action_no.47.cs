using System;

namespace behaviac
{
	// Token: 0x02001F61 RID: 8033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node77 : Condition
	{
		// Token: 0x06012865 RID: 75877 RVA: 0x0056B9D6 File Offset: 0x00569DD6
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node77()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06012866 RID: 75878 RVA: 0x0056B9EC File Offset: 0x00569DEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C261 RID: 49761
		private float opl_p0;
	}
}
