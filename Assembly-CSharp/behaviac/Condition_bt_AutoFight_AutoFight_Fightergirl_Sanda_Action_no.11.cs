using System;

namespace behaviac
{
	// Token: 0x02001F32 RID: 7986
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node59 : Condition
	{
		// Token: 0x06012807 RID: 75783 RVA: 0x0056A543 File Offset: 0x00568943
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node59()
		{
			this.opl_p0 = 3210;
		}

		// Token: 0x06012808 RID: 75784 RVA: 0x0056A558 File Offset: 0x00568958
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1FC RID: 49660
		private int opl_p0;
	}
}
