using System;

namespace behaviac
{
	// Token: 0x02001F3B RID: 7995
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node88 : Condition
	{
		// Token: 0x06012819 RID: 75801 RVA: 0x0056A923 File Offset: 0x00568D23
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node88()
		{
			this.opl_p0 = 3211;
		}

		// Token: 0x0601281A RID: 75802 RVA: 0x0056A938 File Offset: 0x00568D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C210 RID: 49680
		private int opl_p0;
	}
}
