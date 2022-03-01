using System;

namespace behaviac
{
	// Token: 0x0200317C RID: 12668
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node13 : Condition
	{
		// Token: 0x06014B8F RID: 84879 RVA: 0x0063D5BA File Offset: 0x0063B9BA
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570253;
		}

		// Token: 0x06014B90 RID: 84880 RVA: 0x0063D5DC File Offset: 0x0063B9DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4F9 RID: 58617
		private BE_Target opl_p0;

		// Token: 0x0400E4FA RID: 58618
		private BE_Equal opl_p1;

		// Token: 0x0400E4FB RID: 58619
		private int opl_p2;
	}
}
