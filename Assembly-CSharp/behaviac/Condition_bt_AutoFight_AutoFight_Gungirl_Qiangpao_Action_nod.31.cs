using System;

namespace behaviac
{
	// Token: 0x0200253C RID: 9532
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node38 : Condition
	{
		// Token: 0x060133C1 RID: 78785 RVA: 0x005B6D0E File Offset: 0x005B510E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060133C2 RID: 78786 RVA: 0x005B6D44 File Offset: 0x005B5144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDE7 RID: 52711
		private int opl_p0;

		// Token: 0x0400CDE8 RID: 52712
		private int opl_p1;

		// Token: 0x0400CDE9 RID: 52713
		private int opl_p2;

		// Token: 0x0400CDEA RID: 52714
		private int opl_p3;
	}
}
