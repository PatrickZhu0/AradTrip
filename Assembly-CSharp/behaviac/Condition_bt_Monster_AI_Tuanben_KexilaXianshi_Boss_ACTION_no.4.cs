using System;

namespace behaviac
{
	// Token: 0x02003A3A RID: 14906
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node98 : Condition
	{
		// Token: 0x06015C3D RID: 89149 RVA: 0x00693233 File Offset: 0x00691633
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node98()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570035;
		}

		// Token: 0x06015C3E RID: 89150 RVA: 0x00693254 File Offset: 0x00691654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F556 RID: 62806
		private BE_Target opl_p0;

		// Token: 0x0400F557 RID: 62807
		private BE_Equal opl_p1;

		// Token: 0x0400F558 RID: 62808
		private int opl_p2;
	}
}
