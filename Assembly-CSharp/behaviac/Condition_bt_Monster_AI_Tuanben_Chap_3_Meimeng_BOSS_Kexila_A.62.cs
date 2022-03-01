using System;

namespace behaviac
{
	// Token: 0x0200392D RID: 14637
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node97 : Condition
	{
		// Token: 0x06015A35 RID: 88629 RVA: 0x006883C0 File Offset: 0x006867C0
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node97()
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

		// Token: 0x06015A36 RID: 88630 RVA: 0x0068842C File Offset: 0x0068682C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3C2 RID: 62402
		private int opl_p0;

		// Token: 0x0400F3C3 RID: 62403
		private int opl_p1;

		// Token: 0x0400F3C4 RID: 62404
		private int opl_p2;

		// Token: 0x0400F3C5 RID: 62405
		private int opl_p3;

		// Token: 0x0400F3C6 RID: 62406
		private int opl_p4;

		// Token: 0x0400F3C7 RID: 62407
		private int opl_p5;

		// Token: 0x0400F3C8 RID: 62408
		private int opl_p6;

		// Token: 0x0400F3C9 RID: 62409
		private int opl_p7;
	}
}
