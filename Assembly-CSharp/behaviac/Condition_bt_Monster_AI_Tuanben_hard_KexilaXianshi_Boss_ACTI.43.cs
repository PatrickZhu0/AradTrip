using System;

namespace behaviac
{
	// Token: 0x02003CA1 RID: 15521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node87 : Condition
	{
		// Token: 0x060160E9 RID: 90345 RVA: 0x006AA0C3 File Offset: 0x006A84C3
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node87()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570034;
		}

		// Token: 0x060160EA RID: 90346 RVA: 0x006AA0E4 File Offset: 0x006A84E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F98A RID: 63882
		private BE_Target opl_p0;

		// Token: 0x0400F98B RID: 63883
		private BE_Equal opl_p1;

		// Token: 0x0400F98C RID: 63884
		private int opl_p2;
	}
}
