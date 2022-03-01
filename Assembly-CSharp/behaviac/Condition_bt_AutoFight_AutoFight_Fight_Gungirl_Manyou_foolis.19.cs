using System;

namespace behaviac
{
	// Token: 0x0200200A RID: 8202
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node42 : Condition
	{
		// Token: 0x060129B0 RID: 76208 RVA: 0x00574116 File Offset: 0x00572516
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node42()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060129B1 RID: 76209 RVA: 0x0057412C File Offset: 0x0057252C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3A3 RID: 50083
		private float opl_p0;
	}
}
