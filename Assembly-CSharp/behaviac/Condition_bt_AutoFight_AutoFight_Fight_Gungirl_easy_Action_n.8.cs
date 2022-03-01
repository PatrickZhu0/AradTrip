using System;

namespace behaviac
{
	// Token: 0x02001F80 RID: 8064
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node13 : Condition
	{
		// Token: 0x060128A0 RID: 75936 RVA: 0x0056DD93 File Offset: 0x0056C193
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128A1 RID: 75937 RVA: 0x0056DDC8 File Offset: 0x0056C1C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C291 RID: 49809
		private int opl_p0;

		// Token: 0x0400C292 RID: 49810
		private int opl_p1;

		// Token: 0x0400C293 RID: 49811
		private int opl_p2;

		// Token: 0x0400C294 RID: 49812
		private int opl_p3;
	}
}
