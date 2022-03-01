using System;

namespace behaviac
{
	// Token: 0x020023B8 RID: 9144
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node45 : Condition
	{
		// Token: 0x060130D6 RID: 78038 RVA: 0x005A4C0F File Offset: 0x005A300F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node45()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130D7 RID: 78039 RVA: 0x005A4C24 File Offset: 0x005A3024
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB06 RID: 51974
		private float opl_p0;
	}
}
