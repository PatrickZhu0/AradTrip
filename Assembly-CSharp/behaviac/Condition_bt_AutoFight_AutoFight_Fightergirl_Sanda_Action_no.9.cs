using System;

namespace behaviac
{
	// Token: 0x02001F2F RID: 7983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node12 : Condition
	{
		// Token: 0x06012801 RID: 75777 RVA: 0x0056A407 File Offset: 0x00568807
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node12()
		{
			this.opl_p0 = 3205;
		}

		// Token: 0x06012802 RID: 75778 RVA: 0x0056A41C File Offset: 0x0056881C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1F8 RID: 49656
		private int opl_p0;
	}
}
