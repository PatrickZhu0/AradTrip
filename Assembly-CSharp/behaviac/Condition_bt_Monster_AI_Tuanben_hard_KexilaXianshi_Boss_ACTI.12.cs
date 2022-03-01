using System;

namespace behaviac
{
	// Token: 0x02003C77 RID: 15479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node76 : Condition
	{
		// Token: 0x06016095 RID: 90261 RVA: 0x006A8EAB File Offset: 0x006A72AB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node76()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x06016096 RID: 90262 RVA: 0x006A8ECC File Offset: 0x006A72CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F921 RID: 63777
		private BE_Target opl_p0;

		// Token: 0x0400F922 RID: 63778
		private BE_Equal opl_p1;

		// Token: 0x0400F923 RID: 63779
		private int opl_p2;
	}
}
