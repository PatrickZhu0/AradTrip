using System;

namespace behaviac
{
	// Token: 0x02003945 RID: 14661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node96 : Condition
	{
		// Token: 0x06015A65 RID: 88677 RVA: 0x00688DF0 File Offset: 0x006871F0
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node96()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
			this.opl_p4 = 20000;
			this.opl_p5 = 20000;
			this.opl_p6 = 15000;
			this.opl_p7 = 15000;
		}

		// Token: 0x06015A66 RID: 88678 RVA: 0x00688E5C File Offset: 0x0068725C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3EE RID: 62446
		private int opl_p0;

		// Token: 0x0400F3EF RID: 62447
		private int opl_p1;

		// Token: 0x0400F3F0 RID: 62448
		private int opl_p2;

		// Token: 0x0400F3F1 RID: 62449
		private int opl_p3;

		// Token: 0x0400F3F2 RID: 62450
		private int opl_p4;

		// Token: 0x0400F3F3 RID: 62451
		private int opl_p5;

		// Token: 0x0400F3F4 RID: 62452
		private int opl_p6;

		// Token: 0x0400F3F5 RID: 62453
		private int opl_p7;
	}
}
