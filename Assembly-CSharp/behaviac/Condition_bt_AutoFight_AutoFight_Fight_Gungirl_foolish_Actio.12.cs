using System;

namespace behaviac
{
	// Token: 0x02001FA4 RID: 8100
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node28 : Condition
	{
		// Token: 0x060128E7 RID: 76007 RVA: 0x0056F6CF File Offset: 0x0056DACF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128E8 RID: 76008 RVA: 0x0056F704 File Offset: 0x0056DB04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2D8 RID: 49880
		private int opl_p0;

		// Token: 0x0400C2D9 RID: 49881
		private int opl_p1;

		// Token: 0x0400C2DA RID: 49882
		private int opl_p2;

		// Token: 0x0400C2DB RID: 49883
		private int opl_p3;
	}
}
