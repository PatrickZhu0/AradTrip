using System;

namespace behaviac
{
	// Token: 0x02003C7A RID: 15482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node91 : Condition
	{
		// Token: 0x0601609B RID: 90267 RVA: 0x006A8FCB File Offset: 0x006A73CB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node91()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570035;
		}

		// Token: 0x0601609C RID: 90268 RVA: 0x006A8FEC File Offset: 0x006A73EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F92A RID: 63786
		private BE_Target opl_p0;

		// Token: 0x0400F92B RID: 63787
		private BE_Equal opl_p1;

		// Token: 0x0400F92C RID: 63788
		private int opl_p2;
	}
}
