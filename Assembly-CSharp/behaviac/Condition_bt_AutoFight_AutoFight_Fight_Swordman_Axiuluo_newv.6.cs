using System;

namespace behaviac
{
	// Token: 0x0200220A RID: 8714
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node15 : Condition
	{
		// Token: 0x06012D9E RID: 77214 RVA: 0x0058CD7B File Offset: 0x0058B17B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node15()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012D9F RID: 77215 RVA: 0x0058CD90 File Offset: 0x0058B190
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C78D RID: 51085
		private float opl_p0;
	}
}
