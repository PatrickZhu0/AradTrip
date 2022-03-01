using System;

namespace behaviac
{
	// Token: 0x02003916 RID: 14614
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node98 : Condition
	{
		// Token: 0x06015A07 RID: 88583 RVA: 0x006879D8 File Offset: 0x00685DD8
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node98()
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

		// Token: 0x06015A08 RID: 88584 RVA: 0x00687A44 File Offset: 0x00685E44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_isTargetIsCircleArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3, this.opl_p4, this.opl_p5, this.opl_p6, this.opl_p7);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F399 RID: 62361
		private int opl_p0;

		// Token: 0x0400F39A RID: 62362
		private int opl_p1;

		// Token: 0x0400F39B RID: 62363
		private int opl_p2;

		// Token: 0x0400F39C RID: 62364
		private int opl_p3;

		// Token: 0x0400F39D RID: 62365
		private int opl_p4;

		// Token: 0x0400F39E RID: 62366
		private int opl_p5;

		// Token: 0x0400F39F RID: 62367
		private int opl_p6;

		// Token: 0x0400F3A0 RID: 62368
		private int opl_p7;
	}
}
