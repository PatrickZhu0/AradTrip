using System;

namespace behaviac
{
	// Token: 0x02001F62 RID: 8034
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node79 : Condition
	{
		// Token: 0x06012867 RID: 75879 RVA: 0x0056BA1F File Offset: 0x00569E1F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node79()
		{
			this.opl_p0 = 3006;
		}

		// Token: 0x06012868 RID: 75880 RVA: 0x0056BA34 File Offset: 0x00569E34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C262 RID: 49762
		private int opl_p0;
	}
}
