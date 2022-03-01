using System;

namespace behaviac
{
	// Token: 0x02001F01 RID: 7937
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node13 : Condition
	{
		// Token: 0x060127A6 RID: 75686 RVA: 0x0056805B File Offset: 0x0056645B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node13()
		{
			this.opl_p0 = 3117;
		}

		// Token: 0x060127A7 RID: 75687 RVA: 0x00568070 File Offset: 0x00566470
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C19C RID: 49564
		private int opl_p0;
	}
}
