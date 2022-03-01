using System;

namespace behaviac
{
	// Token: 0x0200346F RID: 13423
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5 : Condition
	{
		// Token: 0x06015129 RID: 86313 RVA: 0x00659826 File Offset: 0x00657C26
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5()
		{
			this.opl_p0 = 900000;
			this.opl_p1 = 900000;
			this.opl_p2 = 900000;
			this.opl_p3 = 900000;
		}

		// Token: 0x0601512A RID: 86314 RVA: 0x0065985C File Offset: 0x00657C5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA2B RID: 59947
		private int opl_p0;

		// Token: 0x0400EA2C RID: 59948
		private int opl_p1;

		// Token: 0x0400EA2D RID: 59949
		private int opl_p2;

		// Token: 0x0400EA2E RID: 59950
		private int opl_p3;
	}
}
