using System;

namespace behaviac
{
	// Token: 0x02003DCF RID: 15823
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node4 : Condition
	{
		// Token: 0x0601632C RID: 90924 RVA: 0x006B61CB File Offset: 0x006B45CB
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2502;
		}

		// Token: 0x0601632D RID: 90925 RVA: 0x006B61EC File Offset: 0x006B45EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB90 RID: 64400
		private BE_Target opl_p0;

		// Token: 0x0400FB91 RID: 64401
		private BE_Equal opl_p1;

		// Token: 0x0400FB92 RID: 64402
		private int opl_p2;
	}
}
