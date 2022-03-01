using System;

namespace behaviac
{
	// Token: 0x02003C6E RID: 15470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node84 : Condition
	{
		// Token: 0x06016083 RID: 90243 RVA: 0x006A8ADB File Offset: 0x006A6EDB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node84()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x06016084 RID: 90244 RVA: 0x006A8AFC File Offset: 0x006A6EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F90A RID: 63754
		private BE_Target opl_p0;

		// Token: 0x0400F90B RID: 63755
		private BE_Equal opl_p1;

		// Token: 0x0400F90C RID: 63756
		private int opl_p2;
	}
}
