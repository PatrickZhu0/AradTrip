using System;

namespace behaviac
{
	// Token: 0x02003A47 RID: 14919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node90 : Condition
	{
		// Token: 0x06015C57 RID: 89175 RVA: 0x00693783 File Offset: 0x00691B83
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node90()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570034;
		}

		// Token: 0x06015C58 RID: 89176 RVA: 0x006937A4 File Offset: 0x00691BA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F579 RID: 62841
		private BE_Target opl_p0;

		// Token: 0x0400F57A RID: 62842
		private BE_Equal opl_p1;

		// Token: 0x0400F57B RID: 62843
		private int opl_p2;
	}
}
