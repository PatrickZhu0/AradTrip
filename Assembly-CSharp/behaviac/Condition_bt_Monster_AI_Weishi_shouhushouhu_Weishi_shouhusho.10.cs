using System;

namespace behaviac
{
	// Token: 0x02003DDE RID: 15838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node9 : Condition
	{
		// Token: 0x06016349 RID: 90953 RVA: 0x006B68F6 File Offset: 0x006B4CF6
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2501;
		}

		// Token: 0x0601634A RID: 90954 RVA: 0x006B6918 File Offset: 0x006B4D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBAE RID: 64430
		private BE_Target opl_p0;

		// Token: 0x0400FBAF RID: 64431
		private BE_Equal opl_p1;

		// Token: 0x0400FBB0 RID: 64432
		private int opl_p2;
	}
}
