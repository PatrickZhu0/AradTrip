using System;

namespace behaviac
{
	// Token: 0x020030FD RID: 12541
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node1 : Condition
	{
		// Token: 0x06014AA7 RID: 84647 RVA: 0x006392AC File Offset: 0x006376AC
		public Condition_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522065;
		}

		// Token: 0x06014AA8 RID: 84648 RVA: 0x006392D0 File Offset: 0x006376D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E41C RID: 58396
		private BE_Target opl_p0;

		// Token: 0x0400E41D RID: 58397
		private BE_Equal opl_p1;

		// Token: 0x0400E41E RID: 58398
		private int opl_p2;
	}
}
