using System;

namespace behaviac
{
	// Token: 0x02001EE3 RID: 7907
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node15 : Condition
	{
		// Token: 0x0601276B RID: 75627 RVA: 0x005668FF File Offset: 0x00564CFF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node15()
		{
			this.opl_p0 = 3006;
		}

		// Token: 0x0601276C RID: 75628 RVA: 0x00566914 File Offset: 0x00564D14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C15F RID: 49503
		private int opl_p0;
	}
}
