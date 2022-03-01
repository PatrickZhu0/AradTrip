using System;

namespace behaviac
{
	// Token: 0x0200259C RID: 9628
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node96 : Condition
	{
		// Token: 0x0601347F RID: 78975 RVA: 0x005BBF37 File Offset: 0x005BA337
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node96()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130304;
		}

		// Token: 0x06013480 RID: 78976 RVA: 0x005BBF58 File Offset: 0x005BA358
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEB2 RID: 52914
		private BE_Target opl_p0;

		// Token: 0x0400CEB3 RID: 52915
		private BE_Equal opl_p1;

		// Token: 0x0400CEB4 RID: 52916
		private int opl_p2;
	}
}
