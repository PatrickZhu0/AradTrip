using System;

namespace behaviac
{
	// Token: 0x02002596 RID: 9622
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node90 : Condition
	{
		// Token: 0x06013473 RID: 78963 RVA: 0x005BBCF7 File Offset: 0x005BA0F7
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node90()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130202;
		}

		// Token: 0x06013474 RID: 78964 RVA: 0x005BBD18 File Offset: 0x005BA118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEA0 RID: 52896
		private BE_Target opl_p0;

		// Token: 0x0400CEA1 RID: 52897
		private BE_Equal opl_p1;

		// Token: 0x0400CEA2 RID: 52898
		private int opl_p2;
	}
}
