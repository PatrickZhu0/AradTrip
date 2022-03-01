using System;

namespace behaviac
{
	// Token: 0x02003A45 RID: 14917
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node76 : Condition
	{
		// Token: 0x06015C53 RID: 89171 RVA: 0x006936C3 File Offset: 0x00691AC3
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node76()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x06015C54 RID: 89172 RVA: 0x006936E4 File Offset: 0x00691AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F573 RID: 62835
		private BE_Target opl_p0;

		// Token: 0x0400F574 RID: 62836
		private BE_Equal opl_p1;

		// Token: 0x0400F575 RID: 62837
		private int opl_p2;
	}
}
