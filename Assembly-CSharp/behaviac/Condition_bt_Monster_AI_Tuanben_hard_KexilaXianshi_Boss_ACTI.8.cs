using System;

namespace behaviac
{
	// Token: 0x02003C72 RID: 15474
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node77 : Condition
	{
		// Token: 0x0601608B RID: 90251 RVA: 0x006A8C95 File Offset: 0x006A7095
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node77()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x0601608C RID: 90252 RVA: 0x006A8CB8 File Offset: 0x006A70B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F915 RID: 63765
		private BE_Target opl_p0;

		// Token: 0x0400F916 RID: 63766
		private BE_Equal opl_p1;

		// Token: 0x0400F917 RID: 63767
		private int opl_p2;
	}
}
