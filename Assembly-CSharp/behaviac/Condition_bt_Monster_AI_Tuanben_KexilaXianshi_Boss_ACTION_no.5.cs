using System;

namespace behaviac
{
	// Token: 0x02003A3B RID: 14907
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node99 : Condition
	{
		// Token: 0x06015C3F RID: 89151 RVA: 0x00693293 File Offset: 0x00691693
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node99()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570036;
		}

		// Token: 0x06015C40 RID: 89152 RVA: 0x006932B4 File Offset: 0x006916B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F559 RID: 62809
		private BE_Target opl_p0;

		// Token: 0x0400F55A RID: 62810
		private BE_Equal opl_p1;

		// Token: 0x0400F55B RID: 62811
		private int opl_p2;
	}
}
