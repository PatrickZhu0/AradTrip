using System;

namespace behaviac
{
	// Token: 0x02002D75 RID: 11637
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node37 : Condition
	{
		// Token: 0x060143CC RID: 82892 RVA: 0x006143FB File Offset: 0x006127FB
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570280;
		}

		// Token: 0x060143CD RID: 82893 RVA: 0x0061441C File Offset: 0x0061281C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD98 RID: 56728
		private BE_Target opl_p0;

		// Token: 0x0400DD99 RID: 56729
		private BE_Equal opl_p1;

		// Token: 0x0400DD9A RID: 56730
		private int opl_p2;
	}
}
