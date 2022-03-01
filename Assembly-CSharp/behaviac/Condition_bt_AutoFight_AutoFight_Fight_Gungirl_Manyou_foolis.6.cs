using System;

namespace behaviac
{
	// Token: 0x02001FEF RID: 8175
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node8 : Condition
	{
		// Token: 0x0601297A RID: 76154 RVA: 0x005733AF File Offset: 0x005717AF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601297B RID: 76155 RVA: 0x005733E4 File Offset: 0x005717E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C36C RID: 50028
		private int opl_p0;

		// Token: 0x0400C36D RID: 50029
		private int opl_p1;

		// Token: 0x0400C36E RID: 50030
		private int opl_p2;

		// Token: 0x0400C36F RID: 50031
		private int opl_p3;
	}
}
