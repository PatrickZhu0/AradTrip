using System;

namespace behaviac
{
	// Token: 0x02003A46 RID: 14918
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node72 : Condition
	{
		// Token: 0x06015C55 RID: 89173 RVA: 0x00693723 File Offset: 0x00691B23
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node72()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570033;
		}

		// Token: 0x06015C56 RID: 89174 RVA: 0x00693744 File Offset: 0x00691B44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F576 RID: 62838
		private BE_Target opl_p0;

		// Token: 0x0400F577 RID: 62839
		private BE_Equal opl_p1;

		// Token: 0x0400F578 RID: 62840
		private int opl_p2;
	}
}
