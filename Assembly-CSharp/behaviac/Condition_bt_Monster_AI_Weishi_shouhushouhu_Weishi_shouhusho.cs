using System;

namespace behaviac
{
	// Token: 0x02003DCE RID: 15822
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node3 : Condition
	{
		// Token: 0x0601632A RID: 90922 RVA: 0x006B616A File Offset: 0x006B456A
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2402;
		}

		// Token: 0x0601632B RID: 90923 RVA: 0x006B618C File Offset: 0x006B458C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB8D RID: 64397
		private BE_Target opl_p0;

		// Token: 0x0400FB8E RID: 64398
		private BE_Equal opl_p1;

		// Token: 0x0400FB8F RID: 64399
		private int opl_p2;
	}
}
