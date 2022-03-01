using System;

namespace behaviac
{
	// Token: 0x0200318B RID: 12683
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node12 : Condition
	{
		// Token: 0x06014BAD RID: 84909 RVA: 0x0063DBF6 File Offset: 0x0063BFF6
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node12()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570253;
		}

		// Token: 0x06014BAE RID: 84910 RVA: 0x0063DC18 File Offset: 0x0063C018
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E51A RID: 58650
		private BE_Target opl_p0;

		// Token: 0x0400E51B RID: 58651
		private BE_Equal opl_p1;

		// Token: 0x0400E51C RID: 58652
		private int opl_p2;
	}
}
