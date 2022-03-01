using System;

namespace behaviac
{
	// Token: 0x02001FF3 RID: 8179
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node13 : Condition
	{
		// Token: 0x06012982 RID: 76162 RVA: 0x0057354B File Offset: 0x0057194B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012983 RID: 76163 RVA: 0x00573580 File Offset: 0x00571980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C374 RID: 50036
		private int opl_p0;

		// Token: 0x0400C375 RID: 50037
		private int opl_p1;

		// Token: 0x0400C376 RID: 50038
		private int opl_p2;

		// Token: 0x0400C377 RID: 50039
		private int opl_p3;
	}
}
