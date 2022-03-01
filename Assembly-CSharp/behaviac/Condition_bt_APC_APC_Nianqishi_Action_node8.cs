using System;

namespace behaviac
{
	// Token: 0x02001DE8 RID: 7656
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node8 : Condition
	{
		// Token: 0x06012586 RID: 75142 RVA: 0x0055B598 File Offset: 0x00559998
		public Condition_bt_APC_APC_Nianqishi_Action_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180000;
		}

		// Token: 0x06012587 RID: 75143 RVA: 0x0055B5BC File Offset: 0x005599BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF78 RID: 49016
		private BE_Target opl_p0;

		// Token: 0x0400BF79 RID: 49017
		private BE_Equal opl_p1;

		// Token: 0x0400BF7A RID: 49018
		private int opl_p2;
	}
}
