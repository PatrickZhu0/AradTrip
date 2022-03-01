using System;

namespace behaviac
{
	// Token: 0x02002210 RID: 8720
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node32 : Condition
	{
		// Token: 0x06012DAA RID: 77226 RVA: 0x0058D05B File Offset: 0x0058B45B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node32()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012DAB RID: 77227 RVA: 0x0058D070 File Offset: 0x0058B470
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7A0 RID: 51104
		private float opl_p0;
	}
}
