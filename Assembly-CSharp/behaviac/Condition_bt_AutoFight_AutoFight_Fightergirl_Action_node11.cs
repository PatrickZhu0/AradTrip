using System;

namespace behaviac
{
	// Token: 0x02001EDF RID: 7903
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node11 : Condition
	{
		// Token: 0x06012763 RID: 75619 RVA: 0x0056674B File Offset: 0x00564B4B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node11()
		{
			this.opl_p0 = 3007;
		}

		// Token: 0x06012764 RID: 75620 RVA: 0x00566760 File Offset: 0x00564B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C157 RID: 49495
		private int opl_p0;
	}
}
