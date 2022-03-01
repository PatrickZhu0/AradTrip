using System;

namespace behaviac
{
	// Token: 0x02001F66 RID: 8038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node83 : Condition
	{
		// Token: 0x0601286F RID: 75887 RVA: 0x0056BBD7 File Offset: 0x00569FD7
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node83()
		{
			this.opl_p0 = 3007;
		}

		// Token: 0x06012870 RID: 75888 RVA: 0x0056BBEC File Offset: 0x00569FEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C26A RID: 49770
		private int opl_p0;
	}
}
