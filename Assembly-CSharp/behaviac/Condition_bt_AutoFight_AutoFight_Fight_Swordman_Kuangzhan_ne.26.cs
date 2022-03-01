using System;

namespace behaviac
{
	// Token: 0x020023B4 RID: 9140
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node60 : Condition
	{
		// Token: 0x060130CE RID: 78030 RVA: 0x005A46B5 File Offset: 0x005A2AB5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node60()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060130CF RID: 78031 RVA: 0x005A46C8 File Offset: 0x005A2AC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAFC RID: 51964
		private float opl_p0;
	}
}
