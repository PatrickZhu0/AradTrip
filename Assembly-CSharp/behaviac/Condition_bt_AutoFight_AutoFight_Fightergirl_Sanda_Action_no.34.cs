using System;

namespace behaviac
{
	// Token: 0x02001F50 RID: 8016
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node27 : Condition
	{
		// Token: 0x06012843 RID: 75843 RVA: 0x0056B287 File Offset: 0x00569687
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node27()
		{
			this.opl_p0 = 3113;
		}

		// Token: 0x06012844 RID: 75844 RVA: 0x0056B29C File Offset: 0x0056969C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C23C RID: 49724
		private int opl_p0;
	}
}
