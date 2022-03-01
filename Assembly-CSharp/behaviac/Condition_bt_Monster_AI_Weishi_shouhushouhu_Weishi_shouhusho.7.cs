using System;

namespace behaviac
{
	// Token: 0x02003DD9 RID: 15833
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node3 : Condition
	{
		// Token: 0x0601633F RID: 90943 RVA: 0x006B6770 File Offset: 0x006B4B70
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2401;
		}

		// Token: 0x06016340 RID: 90944 RVA: 0x006B6794 File Offset: 0x006B4B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBA3 RID: 64419
		private BE_Target opl_p0;

		// Token: 0x0400FBA4 RID: 64420
		private BE_Equal opl_p1;

		// Token: 0x0400FBA5 RID: 64421
		private int opl_p2;
	}
}
